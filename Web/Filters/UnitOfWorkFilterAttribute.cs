using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class UnitOfWorkFilterAttribute : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork;
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            UnitOfWork.SaveChanges();
        }
    }
}
