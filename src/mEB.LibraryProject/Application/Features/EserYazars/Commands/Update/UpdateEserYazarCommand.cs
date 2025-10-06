using Application.Features.EserYazars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EserYazars.Commands.Update;

public class UpdateEserYazarCommand : IRequest<UpdatedEserYazarResponse>
{
    public Guid Id { get; set; }
    public required Guid EserId { get; set; }
    public required Guid YazarId { get; set; }

    public class UpdateEserYazarCommandHandler : IRequestHandler<UpdateEserYazarCommand, UpdatedEserYazarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserYazarRepository _eserYazarRepository;
        private readonly EserYazarBusinessRules _eserYazarBusinessRules;

        public UpdateEserYazarCommandHandler(IMapper mapper, IEserYazarRepository eserYazarRepository,
                                         EserYazarBusinessRules eserYazarBusinessRules)
        {
            _mapper = mapper;
            _eserYazarRepository = eserYazarRepository;
            _eserYazarBusinessRules = eserYazarBusinessRules;
        }

        public async Task<UpdatedEserYazarResponse> Handle(UpdateEserYazarCommand request, CancellationToken cancellationToken)
        {
            EserYazar? eserYazar = await _eserYazarRepository.GetAsync(predicate: ey => ey.Id == request.Id, cancellationToken: cancellationToken);
            await _eserYazarBusinessRules.EserYazarShouldExistWhenSelected(eserYazar);
            eserYazar = _mapper.Map(request, eserYazar);

            await _eserYazarRepository.UpdateAsync(eserYazar!);

            UpdatedEserYazarResponse response = _mapper.Map<UpdatedEserYazarResponse>(eserYazar);
            return response;
        }
    }
}