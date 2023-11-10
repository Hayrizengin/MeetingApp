using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace MeetingApp.Controllers
{
    
    public class MeetingController : Controller
    {
        //bunları yazsak da yazmasak da default hali zaten [HttpGet]'dir
        [HttpGet]
        public IActionResult Apply(){
            return View();
        }

        //Aşağıdaki metod sayesinde Model Binding yapıyoruz formdan gelen bilgiler direkt buraya geliyor
        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            if(ModelState.IsValid)
            {
                Repository.CreateUser(model);            // Where koşulu
                ViewBag.UserCount = Repository.Users.Where(info=>info.WillAttend == true).Count(); 
                return View("Thanks",model);
            }else{
                return View(model);
            }
            
        }

        [HttpGet]  
        public IActionResult List(){
            return View(Repository.Users);
        }

        // meeting/details/2
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }

    }
}