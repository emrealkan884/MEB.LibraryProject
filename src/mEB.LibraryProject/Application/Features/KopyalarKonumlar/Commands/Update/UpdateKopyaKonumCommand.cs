using Application.Features.KopyalarKonumlar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.KopyalarKonumlar.Commands.Update;

public class UpdateKopyaKonumCommand : IRequest<UpdatedKopyaKonumResponse>
{
    public Guid Id { get; set; }
    public required Guid KopyaId { get; set; }
    public required Guid KonumId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required int Adet { get; set; }

    public class UpdateKopyaKonumCommandHandler : IRequestHandler<UpdateKopyaKonumCommand, UpdatedKopyaKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaKonumRepository _kopyaKonumRepository;
        private readonly KopyaKonumBusinessRules _kopyaKonumBusinessRules;

        public UpdateKopyaKonumCommandHandler(IMapper mapper, IKopyaKonumRepository kopyaKonumRepository,
                                         KopyaKonumBusinessRules kopyaKonumBusinessRules)
        {
            _mapper = mapper;
            _kopyaKonumRepository = kopyaKonumRepository;
            _kopyaKonumBusinessRules = kopyaKonumBusinessRules;
        }

        public async Task<UpdatedKopyaKonumResponse> Handle(UpdateKopyaKonumCommand request, CancellationToken cancellationToken)
        {
            KopyaKonum? kopyaKonum = await _kopyaKonumRepository.GetAsync(predicate: kk => kk.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaKonumBusinessRules.KopyaKonumShouldExistWhenSelected(kopyaKonum);
            kopyaKonum = _mapper.Map(request, kopyaKonum);

            await _kopyaKonumRepository.UpdateAsync(kopyaKonum!);

            UpdatedKopyaKonumResponse response = _mapper.Map<UpdatedKopyaKonumResponse>(kopyaKonum);
            return response;
        }
    }
}