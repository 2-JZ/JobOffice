using JobOffice.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobOffice.DataAcces.CQRS.Queries
{
    public class GetEmployeeByUsernameQuery: QueryBase<Employee>
    {
        public string Login { get; set; }
        public override async Task<Employee> Execute(JobOfficeContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Login == this.Login);
            return employee;
        }
    }
}
