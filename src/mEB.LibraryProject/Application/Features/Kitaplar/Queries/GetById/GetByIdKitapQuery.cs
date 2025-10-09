using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetByIdKitapQuery : IRequest<GetByIdKitapResponse>
{
    public Guid Id { get; set; }

    public class GetByIdKitapQueryHandler : IRequestHandler<GetByIdKitapQuery, GetByIdKitapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKitapRepository _kitapRepository;
        private readonly KitapBusinessRules _kitapBusinessRules;

        public GetByIdKitapQueryHandler(IMapper mapper, IKitapRepository kitapRepository,
            KitapBusinessRules kitapBusinessRules)
        {
            _mapper = mapper;
            _kitapRepository = kitapRepository;
            _kitapBusinessRules = kitapBusinessRules;
        }

        public async Task<GetByIdKitapResponse> Handle(GetByIdKitapQuery request, CancellationToken cancellationToken)
        {
            Kitap? kitap = await _kitapRepository.GetAsync(
                predicate: e => e.Id == request.Id,
                include: k => k.Include(k=>k.Baskilar).ThenInclude(b => b.YayinEvi),
                cancellationToken: cancellationToken);
            await _kitapBusinessRules.KitapShouldExistWhenSelected(kitap);

            GetByIdKitapResponse response = _mapper.Map<GetByIdKitapResponse>(kitap);
            return response;
        }
    }
}