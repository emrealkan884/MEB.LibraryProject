using Application.Features.EserlerYazarlar.Constants;
using Application.Features.EserlerYazarlar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EserlerYazarlar.Commands.Delete;

public class DeleteEserYazarCommand : IRequest<DeletedEserYazarResponse>
{
    public Guid Id { get; set; }

    public class DeleteEserYazarCommandHandler : IRequestHandler<DeleteEserYazarCommand, DeletedEserYazarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserYazarRepository _eserYazarRepository;
        private readonly EserYazarBusinessRules _eserYazarBusinessRules;

        public DeleteEserYazarCommandHandler(IMapper mapper, IEserYazarRepository eserYazarRepository,
                                         EserYazarBusinessRules eserYazarBusinessRules)
        {
            _mapper = mapper;
            _eserYazarRepository = eserYazarRepository;
            _eserYazarBusinessRules = eserYazarBusinessRules;
        }

        public async Task<DeletedEserYazarResponse> Handle(DeleteEserYazarCommand request, CancellationToken cancellationToken)
        {
            EserYazar? eserYazar = await _eserYazarRepository.GetAsync(predicate: ey => ey.Id == request.Id, cancellationToken: cancellationToken);
            await _eserYazarBusinessRules.EserYazarShouldExistWhenSelected(eserYazar);

            await _eserYazarRepository.DeleteAsync(eserYazar!);

            DeletedEserYazarResponse response = _mapper.Map<DeletedEserYazarResponse>(eserYazar);
            return response;
        }
    }
}