using AutoMapper;
using CQRSapi_2.BusinessLayer.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSapi_2.BusinessLayer.CQRS.Commands
{
    public partial class RemoveEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveEmployeeCommand(int id)
        {
            Id = id;
        }

        public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public RemoveEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
            {
                await  _employeeRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }

    }
}
