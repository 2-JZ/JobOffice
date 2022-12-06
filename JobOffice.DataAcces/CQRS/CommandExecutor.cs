using JobOffice.DataAcces.CQRS;
using JobOffice.DataAcces.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly JobOfficeContext context;

        public CommandExecutor(JobOfficeContext context)
        {
            this.context = context;

        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        
        }
    }

}
