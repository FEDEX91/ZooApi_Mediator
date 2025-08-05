using MediatR;
using ZooApi_Mediator.Interfaces;

namespace ZooApi_Mediator.Features.Bird.Queries
{
    public class GetBirdHandler : IRequestHandler<GetBirdQuery, IEnumerable<Entities.Bird>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBirdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Entities.Bird>> Handle(GetBirdQuery request, CancellationToken cancellationToken)
        {
            var birds = await _unitOfWork.Birds.GetAllAsync();

            return birds;
        }
    }
}
