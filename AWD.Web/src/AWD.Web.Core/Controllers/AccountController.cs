using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AWD.Web.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using AWD.Library;
using AWD.Web.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AWD.Web.Core.Controllers
{
    public class AccountController : Controller
    {
        private IOptions<ApplicationConfiguration> _configuration;

        public AccountController(IOptions<ApplicationConfiguration> config)
        {
            _configuration = config;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var apiClient = new ApiClient(new Uri(_configuration.Value.BaseURL));
                var result = await apiClient.Post("/api/account/token", JsonConvert.SerializeObject(new { username = model.Email, password = model.Password}));
                return View(model);
            }
            // ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
