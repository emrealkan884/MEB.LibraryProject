using Application.Features.KopyalarKonumlar.Constants;
using Application.Features.KopyalarKonumlar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.KopyalarKonumlar.Commands.Delete;

public class DeleteKopyaKonumCommand : IRequest<DeletedKopyaKonumResponse>
{
    public Guid Id { get; set; }

    public class DeleteKopyaKonumCommandHandler : IRequestHandler<DeleteKopyaKonumCommand, DeletedKopyaKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaKonumRepository _kopyaKonumRepository;
        private readonly KopyaKonumBusinessRules _kopyaKonumBusinessRules;

        public DeleteKopyaKonumCommandHandler(IMapper mapper, IKopyaKonumRepository kopyaKonumRepository,
                                         KopyaKonumBusinessRules kopyaKonumBusinessRules)
        {
            _mapper = mapper;
            _kopyaKonumRepository = kopyaKonumRepository;
            _kopyaKonumBusinessRules = kopyaKonumBusinessRules;
        }

        public async Task<DeletedKopyaKonumResponse> Handle(DeleteKopyaKonumCommand request, CancellationToken cancellationToken)
        {
            KopyaKonum? kopyaKonum = await _kopyaKonumRepository.GetAsync(predicate: kk => kk.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaKonumBusinessRules.KopyaKonumShouldExistWhenSelected(kopyaKonum);

            await _kopyaKonumRepository.DeleteAsync(kopyaKonum!);

            DeletedKopyaKonumResponse response = _mapper.Map<DeletedKopyaKonumResponse>(kopyaKonum);
            return response;
        }
    }
}