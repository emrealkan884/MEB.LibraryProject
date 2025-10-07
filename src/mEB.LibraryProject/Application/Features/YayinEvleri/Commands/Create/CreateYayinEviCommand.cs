using Application.Features.YayinEvleri.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.YayinEvleri.Commands.Create;

public class CreateYayinEviCommand : IRequest<CreatedYayinEviResponse>
{
    public required string Adi { get; set; }

    public class CreateYayinEviCommandHandler : IRequestHandler<CreateYayinEviCommand, CreatedYayinEviResponse>
    {
        private readonly IMapper _mapper;
        private readonly IYayinEviRepository _yayinEviRepository;
        private readonly YayinEviBusinessRules _yayinEviBusinessRules;

        public CreateYayinEviCommandHandler(IMapper mapper, IYayinEviRepository yayinEviRepository,
                                         YayinEviBusinessRules yayinEviBusinessRules)
        {
            _mapper = mapper;
            _yayinEviRepository = yayinEviRepository;
            _yayinEviBusinessRules = yayinEviBusinessRules;
        }

        public async Task<CreatedYayinEviResponse> Handle(CreateYayinEviCommand request, CancellationToken cancellationToken)
        {
            YayinEvi yayinEvi = _mapper.Map<YayinEvi>(request);

            await _yayinEviRepository.AddAsync(yayinEvi);

            CreatedYayinEviResponse response = _mapper.Map<CreatedYayinEviResponse>(yayinEvi);
            return response;
        }
    }
}