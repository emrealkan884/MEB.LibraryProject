using Application.Features.YayinEvleri.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.YayinEvleri.Queries.GetById;

public class GetByIdYayinEviQuery : IRequest<GetByIdYayinEviResponse>
{
    public Guid Id { get; set; }

    public class GetByIdYayinEviQueryHandler : IRequestHandler<GetByIdYayinEviQuery, GetByIdYayinEviResponse>
    {
        private readonly IMapper _mapper;
        private readonly IYayinEviRepository _yayinEviRepository;
        private readonly YayinEviBusinessRules _yayinEviBusinessRules;

        public GetByIdYayinEviQueryHandler(IMapper mapper, IYayinEviRepository yayinEviRepository, YayinEviBusinessRules yayinEviBusinessRules)
        {
            _mapper = mapper;
            _yayinEviRepository = yayinEviRepository;
            _yayinEviBusinessRules = yayinEviBusinessRules;
        }

        public async Task<GetByIdYayinEviResponse> Handle(GetByIdYayinEviQuery request, CancellationToken cancellationToken)
        {
            YayinEvi? yayinEvi = await _yayinEviRepository.GetAsync(predicate: ye => ye.Id == request.Id, cancellationToken: cancellationToken);
            await _yayinEviBusinessRules.YayinEviShouldExistWhenSelected(yayinEvi);

            GetByIdYayinEviResponse response = _mapper.Map<GetByIdYayinEviResponse>(yayinEvi);
            return response;
        }
    }
}