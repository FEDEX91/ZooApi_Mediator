using MediatR;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public class GetBirdHandler : IRequestHandler<GetBirdQuery, IEnumerable<Domain.Entities.Bird>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBirdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Entities.Bird>> Handle(GetBirdQuery request, CancellationToken cancellationToken)
        {
            var birds = await _unitOfWork.Birds.GetAllAsync();

            return birds;
        }
    }
}
