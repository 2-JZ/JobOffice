using JobOffice.DataAcces.Entities;

namespace JobOffice.DataAcces.CQRS.Commands
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(JobOfficeContext context)
        {
            await context.Employees.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        
        }
    }
}
