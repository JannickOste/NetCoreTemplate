using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using App.Core.Infrastructure.Database;
using App.Auth.Domain.Services;
using App.Auth.Domain.Models.User;
using App.Auth.Domain.User;

namespace App.Auth.Infrastructure.Services;

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