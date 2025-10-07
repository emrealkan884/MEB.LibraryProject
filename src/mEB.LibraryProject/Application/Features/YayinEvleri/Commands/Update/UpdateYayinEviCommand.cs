using Application.Features.YayinEvleri.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.YayinEvleri.Commands.Update;

public class UpdateYayinEviCommand : IRequest<UpdatedYayinEviResponse>
{
    public Guid Id { get; set; }
    public required string Adi { get; set; }

    public class UpdateYayinEviCommandHandler : IRequestHandler<UpdateYayinEviCommand, UpdatedYayinEviResponse>
    {
        private readonly IMapper _mapper;
        private readonly IYayinEviRepository _yayinEviRepository;
        private readonly YayinEviBusinessRules _yayinEviBusinessRules;

        public UpdateYayinEviCommandHandler(IMapper mapper, IYayinEviRepository yayinEviRepository,
                                         YayinEviBusinessRules yayinEviBusinessRules)
        {
            _mapper = mapper;
            _yayinEviRepository = yayinEviRepository;
            _yayinEviBusinessRules = yayinEviBusinessRules;
        }

        public async Task<UpdatedYayinEviResponse> Handle(UpdateYayinEviCommand request, CancellationToken cancellationToken)
        {
            YayinEvi? yayinEvi = await _yayinEviRepository.GetAsync(predicate: ye => ye.Id == request.Id, cancellationToken: cancellationToken);
            await _yayinEviBusinessRules.YayinEviShouldExistWhenSelected(yayinEvi);
            yayinEvi = _mapper.Map(request, yayinEvi);

            await _yayinEviRepository.UpdateAsync(yayinEvi!);

            UpdatedYayinEviResponse response = _mapper.Map<UpdatedYayinEviResponse>(yayinEvi);
            return response;
        }
    }
}