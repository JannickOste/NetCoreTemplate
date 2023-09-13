using Microsoft.AspNetCore.Mvc;
using App.Core.Domain.ViewModels.User;

using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.ViewModels.Default;
using App.Auth.Domain.Models.User;

namespace App.Core.Infrastructure.Controllers;

/**
* @author: Oste Jannick
* @description: A User endpoint controller template for CRUD user interactions with the API. 
* @Date: 2023-09-11
*/
[Route("[controller]")]
public class UserScopeController : Controller
{
    private readonly IDatabaseRepository<UserScope> repository;

    private readonly IEntityRemapper<UserScopeCreateViewModel, UserScope> createMapper;
    private readonly IEntityRemapper<UserScopeUpdateViewModel, UserScope> updateMapper;

    public UserScopeController(
        IDatabaseRepository<UserScope> repository,
        IEntityRemapper<UserScopeCreateViewModel, UserScope>  createMapper,
        IEntityRemapper<UserScopeUpdateViewModel, UserScope>  updateMapper
    )
    {
        this.repository = repository;
        this.createMapper = createMapper;
        this.updateMapper = updateMapper;
    }

    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost("")]

    public ActionResult Create([FromBody] UserScopeCreateViewModel userCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            UserScope userScope = this.repository.Insert(
                this.createMapper.Remap(userCreateViewModel)
            );

            return Ok(new UserScopeDetailViewModel()
            {
                UserScope = userScope
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }

    }

    [HttpGet("")]
    [ProducesResponseType(typeof(UserListViewModel), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult List()
    {
        try
        {
            return Ok(new UserScopeListViewModel()
            {
                UserScopes = this.repository.GetAll()
            });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Detail(int id)
    {
        try
        {
            UserScope? target = this.repository.GetById(id);
            if (target is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = "User not found"
                });
            }

            return Ok(new UserScopeDetailViewModel()
            {
                UserScope = target
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Update(int id, [FromBody] UserScopeUpdateViewModel userUpdateViewModel)
    {
        UserScope? user = this.repository.GetById(id);
        if (user is null)
        {
            return BadRequest(new ErrorViewModel()
            {
                Error = "User not found"
            });
        }

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        UserScope updatedUser = this.updateMapper.Copy(userUpdateViewModel, user);
        this.repository.Update(updatedUser);

        return Ok(new UserScopeDetailViewModel(){
            UserScope = updatedUser
        });
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Delete(int id)
    {
        try
        {
            UserScope? target = this.repository.GetById(id);
            if (target is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = "User not found"
                });
            }

            this.repository.Delete(target);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}