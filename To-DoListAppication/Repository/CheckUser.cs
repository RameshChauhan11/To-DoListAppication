using Microsoft.AspNetCore.Identity;
using To_DoListAppication.Models;
using To_DoListAppication.ToDoDBContext;

namespace To_DoListAppication.Repository
{
    public class CheckUser : Icheckuser
    {
        private TODoDBContext db { get; set; }
        public CheckUser(TODoDBContext dBContext)
        {
            db = dBContext;
        }
        public string check(LoginModel login)
        {
            var obj = db.signInModels.Where(e => e.email == login.email && e.password == login.password).FirstOrDefault(); ;
            if (obj !=null)
            {
                return "Valid User";
            }
            return "InValid User";
        }
    }
}
