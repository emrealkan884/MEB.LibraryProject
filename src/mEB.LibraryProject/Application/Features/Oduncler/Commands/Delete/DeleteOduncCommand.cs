using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Oduncler.Commands.Delete;

public class DeleteOduncCommand : IRequest<DeletedOduncResponse>
{
    public Guid Id { get; set; }

    public class DeleteOduncCommandHandler : IRequestHandler<DeleteOduncCommand, DeletedOduncResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _oduncBusinessRules;

        public DeleteOduncCommandHandler(IMapper mapper, IOduncRepository oduncRepository,
                                         OduncBusinessRules oduncBusinessRules)
        {
            _mapper = mapper;
            _oduncRepository = oduncRepository;
            _oduncBusinessRules = oduncBusinessRules;
        }

        public async Task<DeletedOduncResponse> Handle(DeleteOduncCommand request, CancellationToken cancellationToken)
        {
            Odunc? odunc = await _oduncRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _oduncBusinessRules.OduncShouldExistWhenSelected(odunc);

            await _oduncRepository.DeleteAsync(odunc!);

            DeletedOduncResponse response = _mapper.Map<DeletedOduncResponse>(odunc);
            return response;
        }
    }
}