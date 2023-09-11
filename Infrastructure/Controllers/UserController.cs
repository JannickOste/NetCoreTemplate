using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Data;
using NetCore.Domain.Models;
using NetCore.Domain.ViewModels;
using NetCore.Domain.ViewModels.Default;
using NetCore.Domain.ViewModels.User;
using NetCore.Infrastructure.Mapper.User;

namespace NetCore.Infrastructure.Controllers;

/**
* @author: Oste Jannick
* @description: A User endpoint controller template for CRUD user interactions with the API. 
* @Date: 2023-09-11
*/
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IDatabaseRepository<User> repository;
    public UserController(
        IDatabaseRepository<User> repository
    )
    {
        this.repository = repository;
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <response code="200">User created</response> 
    /// <response code="400">User has missing or invalid values</response> 
    /// <response code="500">Something went wrong while creating the user</response> 
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost("")]

    public ActionResult Create([FromBody] UserCreateViewModel userCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            User user = this.repository.Insert(
                UserCreateToUserMapper.Map(userCreateViewModel)
            );

            return Ok(new UserDetailViewModel()
            {
                User = user
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }

    }

    /// <summary>
    /// Read a list of all users
    /// </summary>
    /// <response code="200">List of all users.</response> 
    /// <response code="500">Something went wrong when attempting to get all users.</response> 
    [HttpGet("")]
    [ProducesResponseType(typeof(UserListViewModel), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult List()
    {
        try
        {
            return Ok(new UserListViewModel()
            {
                Users = this.repository.GetAll()
            });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    //!TODO: repo model doesnt work for this 
    /// <summary>
    /// Read a specific user.
    /// </summary>
    /// <response code="200">Fetched user.</response> 
    /// <response code="400">The user with the ID did not exist</response> 
    /// <response code="500">Something went wrong when attempting to get the user.</response> 
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Detail(int id)
    {
        try
        {
            return Ok(new UserDetailViewModel()
            {
                User = this.repository.GetById(id)
            });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Update a specific user.
    /// </summary>
    /// <response code="200">The newly updated user.</response> 
    /// <response code="400">Some required fields where missing / invalid </response> 
    /// <response code="500">An error occured when updating the user</response> 
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Update(int id)
    {
        return Ok(id);
    }

    /// <summary>
    /// Delete a specific user.
    /// </summary>
    /// <response code="204">The user has been deleted.</response> 
    /// <response code="500">An error occured when deleting the user</response> 
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Delete(int id)
    {
        try
        {
            User target = this.repository.GetById(id);
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