using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Facadee.Facade;

public class FacadeBase : Controller
{	
	[ApiExplorerSettings(IgnoreApi = true)]
	public override void OnActionExecuting(ActionExecutingContext ctx) 
	{
		base.OnActionExecuting(ctx);
	}
	
}