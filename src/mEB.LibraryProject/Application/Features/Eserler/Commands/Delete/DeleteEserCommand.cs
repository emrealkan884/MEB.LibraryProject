using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Eserler.Commands.Delete;

public class DeleteEserCommand : IRequest<DeletedEserResponse>
{
    public Guid Id { get; set; }

    public class DeleteEserCommandHandler : IRequestHandler<DeleteEserCommand, DeletedEserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserRepository _eserRepository;
        private readonly EserBusinessRules _eserBusinessRules;

        public DeleteEserCommandHandler(IMapper mapper, IEserRepository eserRepository,
                                         EserBusinessRules eserBusinessRules)
        {
            _mapper = mapper;
            _eserRepository = eserRepository;
            _eserBusinessRules = eserBusinessRules;
        }

        public async Task<DeletedEserResponse> Handle(DeleteEserCommand request, CancellationToken cancellationToken)
        {
            Eser? eser = await _eserRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eserBusinessRules.EserShouldExistWhenSelected(eser);

            await _eserRepository.DeleteAsync(eser!);

            DeletedEserResponse response = _mapper.Map<DeletedEserResponse>(eser);
            return response;
        }
    }
}