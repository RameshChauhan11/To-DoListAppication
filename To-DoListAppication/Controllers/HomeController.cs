using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using To_DoListAppication.Models;
using To_DoListAppication.Repository;

namespace To_DoListAppication.Controllers
{
    public class HomeController : Controller
    {
        private ISinInService sinInService;
        private IWorkRecordSevice workRecordSevice;

        public HomeController(ISinInService _sinInService, IWorkRecordSevice _workRecordSevice)
        {
            //  _logger = logger;
            sinInService = _sinInService;
            workRecordSevice = _workRecordSevice;

        }

     
        public IActionResult AddWorkRecord()
        {
            ViewBag.email = Request.Cookies["user"];
            return View();
        }
        [HttpPost]
        public IActionResult AddWorkRecord(WorkRecordModel wd)
        {
            if(ModelState.IsValid)
            { 
                int res= workRecordSevice.InsertWorkRecord(wd);
                if (res > 0)
                {
                    return Content("<script>alert('Work Added Successfully...');location.href='/home/AddWorkRecord'</script>", "text/html");
                }
            }
            return View();
        }
        public IActionResult Profile()
        {
            string email= Request.Cookies["user"];
            var obj =sinInService.SignInById(email);
            return View(obj);
        }
        public IActionResult updateSignIn(int Id)
        {
            string email = Request.Cookies["user"];
            var obj = sinInService.SignInById(email);
            return View(obj);
        }
        [HttpPost]
        public IActionResult updateSignIn(SignInModel sm)
        {
            if(sm.Id != 0)
            {
                sinInService.UpadteSignIn(sm);
                var res = sinInService.SaveChanges();
                if(res == true)
                {
                    return Content("<script>alert('Profile Update  Successfully...');location.href='/home/Profile'</script>", "text/html");

                }
            }
            return View();
        }

        public IActionResult UserWorkRecords()
        {
            string email = Request.Cookies["user"].ToString();
            List<WorkRecordModel> sm = (List<WorkRecordModel>)workRecordSevice.UserWorkRecord(email);
            
            return View(sm);
        }
        public IActionResult workRecordDelete(int workId)
        {
            if (workId != 0)
            {
                var obj = workRecordSevice.WorkRecordById(workId);
                if (obj != null)
                {
                    int res = workRecordSevice.DeleteWorkRecord(workId);
                    if (res > 0)
                    {
                        return Content("<script>alert('Record deleted Successfully...');location.href='/home/UserWorkRecords'</script>", "text/html");
                    }
                }

            }
            return View();
        }
        public IActionResult workRecordEdit(int workId,string email)
        {
            object obj;
            if (workId != 0)
            {
                ViewBag.email=email;
                 obj = workRecordSevice.WorkRecordById(workId);
                return View(obj);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult workRecordEdit(WorkRecordModel wd)
        {
            if(ModelState.IsValid)
            {
                    int res=workRecordSevice.UpdateWorkRecord(wd);
                if (res > 0)
                {
                    return Content("<script>alert('Record Updated  Successfully...');location.href='/Home/UserWorkRecords'</script>", "text/html");

                }
            }
            return View(); 
        }
            public IActionResult userLogout()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("login", "login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
