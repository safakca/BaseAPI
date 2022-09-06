using AutoMapper;
using CQRSapi_2.BusinessLayer.Dtos;
using CQRSapi_2.BusinessLayer.Interfaces;
using CQRSapi_2.EntityLayer.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSapi_2.BusinessLayer.CQRS.Commands
{
    public partial class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }



        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var mappedEntity = _mapper.Map<Employee>(request);
                var created =await _employeeRepository.CreateAsync(mappedEntity);
                var createdMapped = _mapper.Map<EmployeeDto>(created);
                return createdMapped;
            }
        }

    }
}
