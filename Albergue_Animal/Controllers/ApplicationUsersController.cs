using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albergue_Animal.Areas.Identity.Data;
using Albergue_Animal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

namespace Albergue_Animal.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationUserContext _context;
        private readonly UserManager<ApplicationUser> _userManager;



        public ApplicationUsersController(ApplicationUserContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Utilizadores.ToListAsync());
        //}

          [Authorize(Roles = "Admin" )]
        public IActionResult Index()
        {
            //  if (User.IsInRole("Admin"))
            // {
            //     return RedirectToAction("Index", "Home");
            // }
            // else
            //// {C:\Users\joaos\Desktop\I\EST\4ºAno\PV\LAB\Lab6_2\Albergue_Animal\Albergue_Animal\Areas\Identity\Pages\Account\AccessDenied.cshtml.cs
            //     return Redirect("Albergue_Animal/Areas/Identity/Pages/Account/AccessDenied");
            // }
            //if (User.IsInRole("Admin"))
            //{
               // ViewData["role"] = "Admin";
                return View(_context.Utilizadores.ToList());
            //}
            //else
            //{
                //return View(AccessDenied());
            //}
        }













        public IActionResult AccessDenied()
        {
            return View();
        }

        }
}
