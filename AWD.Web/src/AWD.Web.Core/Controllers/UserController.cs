using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWD.Library;
using AWD.Web.Common;
using AWD.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace AWD.Web.Core.Controllers
{
    public class UserController : Controller
    {
        private IOptions<ApplicationConfiguration> _config;
        public UserController(IOptions<ApplicationConfiguration> config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //throw new Exception("hello");
            var result = CommonFuncs.Add(3, 4);
            return View(GetAll());
        }

        private IList<UserViewModel> GetAll()
        {
            // var apiClient = new ApiClient(new Uri(_config.Value.BaseURL));
            // var customers = await apiClient.Get("/api/customer");
            var users = new List<UserViewModel>();
            users.Add(new UserViewModel
            {
                Id = 1,
                Name = "test",
                Age = 2
            });
            return users;
        }
    }
}