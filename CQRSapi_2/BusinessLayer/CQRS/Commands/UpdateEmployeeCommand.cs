using AutoMapper;
using CQRSapi_2.BusinessLayer.Dtos;
using CQRSapi_2.BusinessLayer.Interfaces;
using CQRSapi_2.EntityLayer.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSapi_2.BusinessLayer.CQRS.Commands
{
    public partial class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entityMapped = _mapper.Map<Employee>(request);
                var updated = await _employeeRepository.UpdateAsync(entityMapped);
                var updatedMapped = _mapper.Map<EmployeeDto>(updated);
                return updatedMapped;
            }
        }
    }
}
