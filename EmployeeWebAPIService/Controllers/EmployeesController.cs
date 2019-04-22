using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebAPIService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<EmployeesUpdated> Get()
        {
            using (EmployeeDBEntities dbContext = new EmployeeDBEntities())
            {
                return dbContext.EmployeesUpdated.ToList();
            }
        }

        public EmployeesUpdated Get(string empCode)
        {
            using (EmployeeDBEntities dbContext = new EmployeeDBEntities())
            {
                var employee = dbContext.EmployeesUpdated.FirstOrDefault(x => x.code == empCode);
                return employee;
            }
        }

    }
}
