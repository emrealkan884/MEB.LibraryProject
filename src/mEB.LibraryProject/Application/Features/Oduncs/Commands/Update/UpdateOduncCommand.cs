using Application.Features.Oduncs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Oduncs.Commands.Update;

public class UpdateOduncCommand : IRequest<UpdatedOduncResponse>
{
    public Guid Id { get; set; }
    public required Guid KopyaId { get; set; }
    public required Guid KullaniciId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required DateTime OduncAlmaTarihi { get; set; }
    public required DateTime SonTeslimTarihi { get; set; }
    public DateTime? GercekTeslimTarihi { get; set; }
    public required OduncDurum Durum { get; set; }

    public class UpdateOduncCommandHandler : IRequestHandler<UpdateOduncCommand, UpdatedOduncResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _oduncBusinessRules;

        public UpdateOduncCommandHandler(IMapper mapper, IOduncRepository oduncRepository,
                                         OduncBusinessRules oduncBusinessRules)
        {
            _mapper = mapper;
            _oduncRepository = oduncRepository;
            _oduncBusinessRules = oduncBusinessRules;
        }

        public async Task<UpdatedOduncResponse> Handle(UpdateOduncCommand request, CancellationToken cancellationToken)
        {
            Odunc? odunc = await _oduncRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _oduncBusinessRules.OduncShouldExistWhenSelected(odunc);
            odunc = _mapper.Map(request, odunc);

            await _oduncRepository.UpdateAsync(odunc!);

            UpdatedOduncResponse response = _mapper.Map<UpdatedOduncResponse>(odunc);
            return response;
        }
    }
}