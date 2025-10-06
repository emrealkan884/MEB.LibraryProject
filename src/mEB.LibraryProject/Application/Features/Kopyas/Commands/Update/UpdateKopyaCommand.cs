using Application.Features.Kopyas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Kopyas.Commands.Update;

public class UpdateKopyaCommand : IRequest<UpdatedKopyaResponse>
{
    public Guid Id { get; set; }
    public required Guid KitapId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required string Barkod { get; set; }

    public class UpdateKopyaCommandHandler : IRequestHandler<UpdateKopyaCommand, UpdatedKopyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaRepository _kopyaRepository;
        private readonly KopyaBusinessRules _kopyaBusinessRules;

        public UpdateKopyaCommandHandler(IMapper mapper, IKopyaRepository kopyaRepository,
                                         KopyaBusinessRules kopyaBusinessRules)
        {
            _mapper = mapper;
            _kopyaRepository = kopyaRepository;
            _kopyaBusinessRules = kopyaBusinessRules;
        }

        public async Task<UpdatedKopyaResponse> Handle(UpdateKopyaCommand request, CancellationToken cancellationToken)
        {
            Kopya? kopya = await _kopyaRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaBusinessRules.KopyaShouldExistWhenSelected(kopya);
            kopya = _mapper.Map(request, kopya);

            await _kopyaRepository.UpdateAsync(kopya!);

            UpdatedKopyaResponse response = _mapper.Map<UpdatedKopyaResponse>(kopya);
            return response;
        }
    }
}