using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.Oduncler.Commands.TeslimEt;

public class TeslimEtOduncCommand : IRequest<TeslimEdildiOduncResponse>
{
    public Guid OduncId { get; set; }
    
    public class TeslimEtOduncCommandHandler 
        : IRequestHandler<TeslimEtOduncCommand, TeslimEdildiOduncResponse>
    {
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _businessRules;
        private readonly IMapper _mapper;

        public TeslimEtOduncCommandHandler(
            IOduncRepository oduncRepository,
            OduncBusinessRules businessRules,
            IMapper mapper)
        {
            _oduncRepository = oduncRepository;
            _businessRules = businessRules;
            _mapper = mapper;
        }

        public async Task<TeslimEdildiOduncResponse> Handle(TeslimEtOduncCommand request, CancellationToken ct)
        {
            // Kayıt var mı?
            var odunc = await _oduncRepository.GetAsync(
                o => o.Id == request.OduncId,
                cancellationToken: ct
            );
            await _businessRules.OduncShouldExistWhenSelected(odunc);

            // Sadece "OduncVerildi" olan iade edilebilir
            if (odunc!.Durum != OduncDurum.OduncVerildi)
                throw new BusinessException("Bu kayıt iade edilemez. (Durum OduncVerildi olmalı)");

            odunc.Durum = OduncDurum.TeslimAlindi;
            odunc.GercekTeslimTarihi = DateTime.Now;

            await _oduncRepository.UpdateAsync(odunc);

            return _mapper.Map<TeslimEdildiOduncResponse>(odunc);
        }
    }

}


