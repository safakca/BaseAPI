using CQRSapi_2.BusinessLayer.Interfaces;
using CQRSapi_2.DataLayer.Context;
using CQRSapi_2.DataLayer.Repositories;
using CQRSapi_2.EntityLayer.Entities;

namespace CQRSapi_2.BusinessLayer.Services
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
