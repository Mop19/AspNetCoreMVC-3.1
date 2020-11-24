﻿using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public interface ICompteRepository
    {
        Task<IdentityResult> CreationUserAsync(DeconnecterUserModel logingUser);
        Task<SignInResult> PasswordSignInAsync(SeConnecterUserModel connecterUserModel);
        Task SignOutAsync();
    }
}