using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DijitalIcerikler.Commands.Create;

public class CreateDijitalIcerikCommand : IRequest<CreatedDijitalIcerikResponse>
{
    public Guid EserId { get; set; }
    public required string Tur { get; set; }
    public required string Url { get; set; }

    public class CreateDijitalIcerikCommandHandler : IRequestHandler<CreateDijitalIcerikCommand, CreatedDijitalIcerikResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDijitalIcerikRepository _dijitalIcerikRepository;
        public async Task<CreatedDijitalIcerikResponse> Handle(CreateDijitalIcerikCommand request, CancellationToken cancellationToken)
        {
            DijitalIcerik dijitalIcerik = _mapper.Map<DijitalIcerik>(request);

            await _dijitalIcerikRepository.AddAsync(dijitalIcerik);

            CreatedDijitalIcerikResponse response = _mapper.Map<CreatedDijitalIcerikResponse>(dijitalIcerik);
            return response;
        }
    }
}


