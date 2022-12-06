using JobOffice.DataAcces.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffice.DataAcces.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly JobOfficeContext context;

        public QueryExecutor(JobOfficeContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
