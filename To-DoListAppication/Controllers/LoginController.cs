using Microsoft.AspNetCore.Mvc;
using To_DoListAppication.Models;
using To_DoListAppication.Repository;

namespace To_DoListAppication.Controllers
{
    public class LoginController : Controller
    {
        private ISinInService sinInService;

        private Icheckuser checkuser;
        public LoginController(ISinInService _sinInService, Icheckuser checkuser)
        {
            //  _logger = logger;
            sinInService = _sinInService;
            this.checkuser = checkuser; 
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(LoginModel lm)
        {
            if(ModelState.IsValid)
            {
                if (lm.email == "Admin@gmail.com" && lm.password == "111") 
                {
                    Response.Cookies.Append("admin", lm.email, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(1) // Set cookie expiration
                    });
                    return Content("<script>alert('Admin Loggin Successfully...');location.href='/Admin/UserSignInDetails'</script>", "text/html");

                }
               string user =checkuser.check(lm);
                if (user=="Valid User")
                {
                    Response.Cookies.Append("user", lm.email, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddHours(1) // Set cookie expiration
                    });
                    return Content("<script>alert('User Loggin Successfully...');location.href='/home/AddWorkRecord'</script>", "text/html");
                   
                }
            }
            return Content("<script>alert('Invalid user ? Please try again');location.href='/login/login'</script>", "text/html");

        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel sm)
        {
            if (ModelState.IsValid)
            {
                int res = sinInService.InsertSignIn(sm);
                if (res > 0)
                {
                    return Content("<script>alert('SignIn Successfully...');location.href='/login/login'</script>", "text/html");
                }
            }
            return View();
            
        }
    }
}
