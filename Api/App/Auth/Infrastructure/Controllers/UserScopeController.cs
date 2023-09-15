using Microsoft.AspNetCore.Mvc;
using App.Core.Domain.ViewModels.User;

using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.ViewModels.Default;
using App.Auth.Domain.Models.User;
using App.Auth.Domain.ViewModels.UserScope;
using App.Core.Domain.Controllers;

namespace App.Core.Infrastructure.Controllers;

[Route("[controller]")]
public class UserScopeController : AEntityController<UserScope, UserScopeCreateViewModel, UserScopeUpdateViewModel>
{
    public UserScopeController(
        IDatabaseRepository<UserScope> repository,
        IEntityRemapper<UserScopeCreateViewModel, UserScope>  createMapper,
        IEntityRemapper<UserScopeUpdateViewModel, UserScope>  updateMapper
    ) : base(repository, createMapper, updateMapper) {}
}