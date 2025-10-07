using Application.Features.Kutuphaneler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Kutuphaneler.Commands.Update;

public class UpdateKutuphaneCommand : IRequest<UpdatedKutuphaneResponse>
{
    public Guid Id { get; set; }
    public required string Adi { get; set; }
    public required string Adres { get; set; }
    public required KurumTuru KurumTuru { get; set; }
    public Guid? UstKutuphaneId { get; set; }

    public class UpdateKutuphaneCommandHandler : IRequestHandler<UpdateKutuphaneCommand, UpdatedKutuphaneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKutuphaneRepository _kutuphaneRepository;
        private readonly KutuphaneBusinessRules _kutuphaneBusinessRules;

        public UpdateKutuphaneCommandHandler(IMapper mapper, IKutuphaneRepository kutuphaneRepository,
                                         KutuphaneBusinessRules kutuphaneBusinessRules)
        {
            _mapper = mapper;
            _kutuphaneRepository = kutuphaneRepository;
            _kutuphaneBusinessRules = kutuphaneBusinessRules;
        }

        public async Task<UpdatedKutuphaneResponse> Handle(UpdateKutuphaneCommand request, CancellationToken cancellationToken)
        {
            Kutuphane? kutuphane = await _kutuphaneRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kutuphaneBusinessRules.KutuphaneShouldExistWhenSelected(kutuphane);
            kutuphane = _mapper.Map(request, kutuphane);

            await _kutuphaneRepository.UpdateAsync(kutuphane!);

            UpdatedKutuphaneResponse response = _mapper.Map<UpdatedKutuphaneResponse>(kutuphane);
            return response;
        }
    }
}