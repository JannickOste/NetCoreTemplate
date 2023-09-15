using Microsoft.AspNetCore.Mvc;
using App.Core.Domain.ViewModels.User;

using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.ViewModels.Default;
using App.Auth.Domain.ViewModels.User;
using App.Auth.Domain.User;
using Microsoft.AspNetCore.Authorization;
using App.Core.Domain.Controllers;

namespace App.Auth.Infrastructure.Controllers;

/**
* @author: Oste Jannick
* @description: A User endpoint controller template for CRUD user interactions with the API. 
* @Date: 2023-09-11
*/
[Route("[controller]")]
public class UserController : AEntityController<User, UserCreateViewModel, UserUpdateViewModel>
{
    public UserController(
        IDatabaseRepository<User> repository,
        IEntityRemapper<UserCreateViewModel, User> createMapper,
        IEntityRemapper<UserUpdateViewModel, User> updateMapper
    ) : base(repository, createMapper, updateMapper) {}

    [Authorize]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public override ActionResult Create([FromBody] UserCreateViewModel userCreateViewModel) => base.Create(userCreateViewModel);
    
}