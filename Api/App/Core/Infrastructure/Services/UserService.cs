using App.Core.Domain.Entities.User;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using App.Core.Domain.Services;
using App.Core.Infrastructure.Database;

namespace App.Core.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly DatabaseRepository<UserScope> scopeRepository;

    public UserService(
        UserManager<User> userManager,
        DatabaseRepository<UserScope> scopeRepository
    ) {
        this.userManager = userManager;
        this.scopeRepository = scopeRepository;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        await Task.CompletedTask;
        // var user = await userManager.FindByIdAsync(context.Subject.GetSubjectId());
        // if (user != null)
        // {
        //     var claims = await userManager.GetClaimsAsync(user);
        //     context.IssuedClaims.AddRange(claims);
        // }
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        await Task.CompletedTask;
        // var user = await userManager.FindByIdAsync(context.Subject.GetSubjectId());
        // context.IsActive = user != null;
    }
}