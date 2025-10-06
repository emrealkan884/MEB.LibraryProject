using Application.Features.EserYazars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EserYazars.Commands.Create;

public class CreateEserYazarCommand : IRequest<CreatedEserYazarResponse>
{
    public required Guid EserId { get; set; }
    public required Guid YazarId { get; set; }
    

    public class CreateEserYazarCommandHandler : IRequestHandler<CreateEserYazarCommand, CreatedEserYazarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserYazarRepository _eserYazarRepository;
        private readonly EserYazarBusinessRules _eserYazarBusinessRules;

        public CreateEserYazarCommandHandler(IMapper mapper, IEserYazarRepository eserYazarRepository,
                                         EserYazarBusinessRules eserYazarBusinessRules)
        {
            _mapper = mapper;
            _eserYazarRepository = eserYazarRepository;
            _eserYazarBusinessRules = eserYazarBusinessRules;
        }

        public async Task<CreatedEserYazarResponse> Handle(CreateEserYazarCommand request, CancellationToken cancellationToken)
        {
            EserYazar eserYazar = _mapper.Map<EserYazar>(request);

            await _eserYazarRepository.AddAsync(eserYazar);

            eserYazar = await _eserYazarRepository
                .Query()
                .Include(x => x.Eser)
                .Include(x => x.Yazar)
                .FirstAsync(x => x.Id == eserYazar.Id, cancellationToken);
            
            CreatedEserYazarResponse response = _mapper.Map<CreatedEserYazarResponse>(eserYazar);
            return response;
        }
    }
}