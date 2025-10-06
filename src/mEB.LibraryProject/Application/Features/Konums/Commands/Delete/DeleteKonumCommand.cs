using Application.Features.Konums.Constants;
using Application.Features.Konums.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Konums.Commands.Delete;

public class DeleteKonumCommand : IRequest<DeletedKonumResponse>
{
    public Guid Id { get; set; }

    public class DeleteKonumCommandHandler : IRequestHandler<DeleteKonumCommand, DeletedKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKonumRepository _konumRepository;
        private readonly KonumBusinessRules _konumBusinessRules;

        public DeleteKonumCommandHandler(IMapper mapper, IKonumRepository konumRepository,
                                         KonumBusinessRules konumBusinessRules)
        {
            _mapper = mapper;
            _konumRepository = konumRepository;
            _konumBusinessRules = konumBusinessRules;
        }

        public async Task<DeletedKonumResponse> Handle(DeleteKonumCommand request, CancellationToken cancellationToken)
        {
            Konum? konum = await _konumRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _konumBusinessRules.KonumShouldExistWhenSelected(konum);

            await _konumRepository.DeleteAsync(konum!);

            DeletedKonumResponse response = _mapper.Map<DeletedKonumResponse>(konum);
            return response;
        }
    }
}