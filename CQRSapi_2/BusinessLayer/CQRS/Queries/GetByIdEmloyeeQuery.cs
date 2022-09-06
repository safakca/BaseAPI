using AutoMapper;
using CQRSapi_2.BusinessLayer.Dtos;
using CQRSapi_2.BusinessLayer.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSapi_2.BusinessLayer.CQRS.Queries
{
    public partial class GetByIdEmloyeeQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }

        public GetByIdEmloyeeQuery(int id)
        {
            Id = id;
        }

        public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmloyeeQuery, EmployeeDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public GetByIdEmployeeQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<EmployeeDto> Handle(GetByIdEmloyeeQuery request, CancellationToken cancellationToken)
            {
                var employeeList = await _employeeRepository.GetByIdAsync(request.Id);
                var mappedList = _mapper.Map<EmployeeDto>(employeeList);
                return mappedList;
            }
        }



    }
}
