using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Clay3.Models;
using Clay3.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Clay3.Controllers
{
    [Authorize]
    public class DoorController : Controller
    {

        private readonly IDoorItemService _doorItemService;
        private readonly UserManager<ApplicationUser> _userManager;


        public DoorController(IDoorItemService doorItemService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _doorItemService = doorItemService;
        }
        
        public async Task<ActionResult> Index()
        {            
            if(TempData["OpenDoor"] != null)
            {                
                if((int)TempData["OpenDoor"] == 0)
                {
                    ViewBag.StatusMessage = "Sorry, You are not authorized to open the door!";
                }
                else if ((int) TempData["OpenDoor"] == 1)
                {
                    ViewBag.StatusMessage = "Yes, You have opened the door";
                }
                else { }
            }


            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());


            if (user == null)
            {
                return View("Error");
            }

            var _doors = await _doorItemService.GetDoorItemsAsync();

            var model = new DoorViewModel()
            {
                doors = _doors
            };

            return View(model);
        }


        
        public async Task<ActionResult> OpenDoor (Guid door)
        {            
            var currentUser =  await _userManager.FindByIdAsync(User.Identity.GetUserId());

            var success = await _doorItemService.OpenDoorAsync(currentUser, door);         

            if(success)
            {
                TempData["OpenDoor"] = 1;
                return RedirectToAction("Index");
            }
            else
            {
                
                TempData["OpenDoor"] = 0;
                return RedirectToAction("Index");
            }       
        }

        public enum DoorMessageId
        {
            OpenDoorFail,
            OpenDoorSuccess
                 
        }


    }
}