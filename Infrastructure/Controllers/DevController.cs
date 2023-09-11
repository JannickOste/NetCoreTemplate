namespace NetCore.Infrastructure.Controllers;

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Data;


// Doesnt really do much, just for development-testing purposes.
[Route("[controller]")]
public class DevController : Controller
{
    [HttpGet("[action]")]
    public ActionResult GetAllRepoModel()
    {
        return Ok(Assembly.GetExecutingAssembly()
                            .GetTypes().Where(
                                t => t.GetCustomAttribute<RepositoryTargetAttribute>() is not null
                            ).Select(i => i.FullName));
    }
}