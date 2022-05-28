using System.Xml.Serialization;
using LFC.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    

namespace LFC.Web.Controllers
{
    public class Teacher : User
    {
        [Authorize(Roles = "Teacher")]
        public class AdministrationController : Controller
        {
            public IActionResult Index() =>
                Content("Teacher");
            
        }
        
        
    }
}