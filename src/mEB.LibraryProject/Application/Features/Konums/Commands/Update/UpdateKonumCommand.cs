using Application.Features.Konums.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Konums.Commands.Update;

public class UpdateKonumCommand : IRequest<UpdatedKonumResponse>
{
    public Guid Id { get; set; }
    public required Guid KutuphaneId { get; set; }
    public Guid? UstKonumId { get; set; }
    public required KonumTip KonumTip { get; set; }
    public required string Ad { get; set; }

    public class UpdateKonumCommandHandler : IRequestHandler<UpdateKonumCommand, UpdatedKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKonumRepository _konumRepository;
        private readonly KonumBusinessRules _konumBusinessRules;

        public UpdateKonumCommandHandler(IMapper mapper, IKonumRepository konumRepository,
                                         KonumBusinessRules konumBusinessRules)
        {
            _mapper = mapper;
            _konumRepository = konumRepository;
            _konumBusinessRules = konumBusinessRules;
        }

        public async Task<UpdatedKonumResponse> Handle(UpdateKonumCommand request, CancellationToken cancellationToken)
        {
            Konum? konum = await _konumRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _konumBusinessRules.KonumShouldExistWhenSelected(konum);
            konum = _mapper.Map(request, konum);

            await _konumRepository.UpdateAsync(konum!);

            UpdatedKonumResponse response = _mapper.Map<UpdatedKonumResponse>(konum);
            return response;
        }
    }
}