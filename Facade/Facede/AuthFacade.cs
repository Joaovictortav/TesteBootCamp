using IoT.Kernel.Controller;
using IoT.Kernel.DTO.Request;
using IoT.Kernel.DTO.Response;
using IoT.Kernel.Model.Auth;
using IoT.Kernel.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Facede
{
	[ApiController]    
    [Route("V1/Auth", Name = "Auth")]	
	[Produces("application/json")]
	public class AuthFacade : FacadeBase
	{
		public AuthFacade() 
		{
		}
		
		[HttpGet, Route("VerifyToken")] 
		[ProducesResponseType(typeof(VerifyResponse), StatusCodes.Status200OK)] 
		public async Task<IActionResult> VerifyToken([FromHeader(Name = "AuthToken")] string authToken) 
		{ 
			try 
			{
				_ = Auth.SetToken(Request.Headers["AuthToken"].ToString());
				return Ok(await new AuthController().VerifyToken()); 
			} 
			catch (Exception e)
			{
				throw new Exception($"Erro: {e.Message}");
			} 
		}
		
		[HttpPost, Route("Login")] 
		[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)] 
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) 
		{
			try 
			{
				var ret = await new AuthController().Login(loginRequest); 
				return Json(ret);
			} 
			catch (Exception e) 
			{ 
				throw new Exception($"Erro: {e.Message}");
			} 
		}
		
		[HttpPost, Route("GetUser")] 
		[ProducesResponseType(typeof(User), StatusCodes.Status200OK)] 
		public async Task<IActionResult> GetUser([FromHeader(Name = "AuthToken")] string authToken, [FromForm] string? email, [FromForm] Guid? guid) 
		{
			try 
			{
				_ = Auth.SetToken(Request.Headers["AuthToken"].ToString());
				object? ret = await new AuthController().GetUser(email, guid); 
				return Json(ret);
			} 
			catch (Exception e) 
			{ 
				throw new Exception($"Erro: {e.Message}");
			} 
		}
	}
}
