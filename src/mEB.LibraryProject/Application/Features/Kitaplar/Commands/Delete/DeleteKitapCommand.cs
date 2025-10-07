using Application.Features.Eserler.Commands.Delete;
using Application.Features.Eserler.Rules;
using Application.Features.Kitaplar.Commands.Delete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;



public class DeleteKitapCommand : IRequest<DeletedKitapResponse>
{
    public Guid Id { get; set; }

    public class DeleteKitapCommandHandler : IRequestHandler<DeleteKitapCommand, DeletedKitapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKitapRepository _kitapRepository;
        private readonly EserBusinessRules _kitapBusinessRules;

        public DeleteKitapCommandHandler(IMapper mapper, IKitapRepository kitapRepository,
            EserBusinessRules kitapBusinessRules)
        {
            _mapper = mapper;
            _kitapRepository = kitapRepository;
            _kitapBusinessRules = kitapBusinessRules;
        }

        public async Task<DeletedKitapResponse> Handle(DeleteKitapCommand request, CancellationToken cancellationToken)
        {
            Kitap? kitap = await _kitapRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _kitapBusinessRules.EserShouldExistWhenSelected(kitap);

            await _kitapRepository.DeleteAsync(kitap!);

            DeletedKitapResponse response = _mapper.Map<DeletedKitapResponse>(kitap);
            return response;
        }
    }
   
}