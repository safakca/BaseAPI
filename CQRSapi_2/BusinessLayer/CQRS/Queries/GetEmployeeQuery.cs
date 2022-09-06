using AutoMapper;
using CQRSapi_2.BusinessLayer.Dtos;
using CQRSapi_2.BusinessLayer.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSapi_2.BusinessLayer.CQRS.Queries
{
    public partial class GetEmployeeQuery : IRequest<IEnumerable<EmployeeDto>>
    {

        public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDto>>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public GetEmployeeQueryHandler(IMapper mapper)
            {
                _mapper = mapper;
            } 

            async Task<IEnumerable<EmployeeDto>> IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDto>>.Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                var employeest=await _employeeRepository.GetAllAsync();
                var employeesMapped= _mapper.Map<IEnumerable<EmployeeDto>>(employeest);
                return employeesMapped;
            }
        }
    }
}
