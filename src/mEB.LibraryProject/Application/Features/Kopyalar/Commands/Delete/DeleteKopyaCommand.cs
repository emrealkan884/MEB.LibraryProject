using Application.Features.Kopyalar.Constants;
using Application.Features.Kopyalar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Kopyalar.Commands.Delete;

public class DeleteKopyaCommand : IRequest<DeletedKopyaResponse>
{
    public Guid Id { get; set; }

    public class DeleteKopyaCommandHandler : IRequestHandler<DeleteKopyaCommand, DeletedKopyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaRepository _kopyaRepository;
        private readonly KopyaBusinessRules _kopyaBusinessRules;

        public DeleteKopyaCommandHandler(IMapper mapper, IKopyaRepository kopyaRepository,
                                         KopyaBusinessRules kopyaBusinessRules)
        {
            _mapper = mapper;
            _kopyaRepository = kopyaRepository;
            _kopyaBusinessRules = kopyaBusinessRules;
        }

        public async Task<DeletedKopyaResponse> Handle(DeleteKopyaCommand request, CancellationToken cancellationToken)
        {
            Kopya? kopya = await _kopyaRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaBusinessRules.KopyaShouldExistWhenSelected(kopya);

            await _kopyaRepository.DeleteAsync(kopya!);

            DeletedKopyaResponse response = _mapper.Map<DeletedKopyaResponse>(kopya);
            return response;
        }
    }
}