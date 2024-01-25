// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public LogoutModel(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _userManager = userManager; 
             _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //-*-UpdateLastSeen  //---c
           var user =  await  _userManager.GetUserAsync(User);
            user.Lastseen = DateTime.Now; 
            await  _userManager.UpdateAsync(user); 
            //-----------------------------------------------------------------------
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
