using Application.Features.YayinEvleri.Constants;
using Application.Features.YayinEvleri.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.YayinEvleri.Commands.Delete;

public class DeleteYayinEviCommand : IRequest<DeletedYayinEviResponse>
{
    public Guid Id { get; set; }

    public class DeleteYayinEviCommandHandler : IRequestHandler<DeleteYayinEviCommand, DeletedYayinEviResponse>
    {
        private readonly IMapper _mapper;
        private readonly IYayinEviRepository _yayinEviRepository;
        private readonly YayinEviBusinessRules _yayinEviBusinessRules;

        public DeleteYayinEviCommandHandler(IMapper mapper, IYayinEviRepository yayinEviRepository,
                                         YayinEviBusinessRules yayinEviBusinessRules)
        {
            _mapper = mapper;
            _yayinEviRepository = yayinEviRepository;
            _yayinEviBusinessRules = yayinEviBusinessRules;
        }

        public async Task<DeletedYayinEviResponse> Handle(DeleteYayinEviCommand request, CancellationToken cancellationToken)
        {
            YayinEvi? yayinEvi = await _yayinEviRepository.GetAsync(predicate: ye => ye.Id == request.Id, cancellationToken: cancellationToken);
            await _yayinEviBusinessRules.YayinEviShouldExistWhenSelected(yayinEvi);

            await _yayinEviRepository.DeleteAsync(yayinEvi!);

            DeletedYayinEviResponse response = _mapper.Map<DeletedYayinEviResponse>(yayinEvi);
            return response;
        }
    }
}