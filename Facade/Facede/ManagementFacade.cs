using IoT.Kernel.Controller;
using IoT.Kernel.DTO.Request;
using IoT.Kernel.DTO.Response;
using IoT.Kernel.Model.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Facede;


[ApiController]    
[Route("V1/Management", Name = "Management")]	
[Produces("application/json")]
public class ManagementFacade : FacadeBase
{
    public ManagementFacade() 
	{
	}

    [HttpPost, Route("CreateUser")] 
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)] 
	public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest) 
	{ 
		try 
		{
			object ret = await new ManagementController().CreateUser(userRequest); 
			return Json(ret); 
		} 
		catch (Exception e)
		{
			throw new Exception($"Erro: {e.Message}");
		} 
	}

	[HttpPost, Route("UpdateUser")] 
	[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)] 
	public async Task<IActionResult> UpdateUser([FromBody] UserRequest user) 
	{
		try 
		{
			object ret = await new ManagementController().UpdateUser(user); 
			return Json(ret); 
		} 
		catch (Exception e) 
		{ 
			throw new Exception($"Erro: {e.Message}");
		} 
	}
	
	[HttpPost, Route("ResetPassword")] 
	[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)] 
	public async Task<IActionResult> ResetPassword([FromForm] string email) 
	{ 
		try 
		{
			object ret = await new ManagementController().ResetPassword(email); 
			return Json(ret); 
		} 
		catch (Exception e) 
		{ 
			throw new Exception($"Erro: {e.Message}");
		} 
	}
}