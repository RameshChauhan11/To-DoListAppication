using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using To_DoListAppication.Models;
using To_DoListAppication.Repository;

namespace To_DoListAppication.Controllers;

public class AdminController : Controller
{
    private ISinInService sinInService;
    private IWorkRecordSevice workRecordSevice;

    public AdminController(ISinInService _sinInService,IWorkRecordSevice _workRecordSevice)
    {
        //  _logger = logger;
        sinInService = _sinInService;
        workRecordSevice = _workRecordSevice;

    }

    public IActionResult Index()
    {

        return View();
    }
    
    public IActionResult UserSignInDetails()
    {
        if(sinInService == null)
        {
            return null;
        }
       List<SignInModel> sm= (List<SignInModel>)  sinInService.AllSignIn();
        return View(sm);
    }
    public IActionResult DeleteSignRecord(int Id)
    {
        if(Id!=null)
        {
           
               int res= sinInService.DeleteAnySignIn(Id);
                if (res > 0)
                {
                    return Content("<script>alert('Record deleted Successfully...');location.href='/Admin/UserSignInDetails'</script>", "text/html");
                }
            
        }
        return NotFound();
    }
    public IActionResult AllWorkRecords()
    {
        List<WorkRecordModel> sm = (List<WorkRecordModel>)workRecordSevice.AllWorkRecord();
        if (sinInService == null)
            return null;
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
                    return Content("<script>alert('Record deleted Successfully...');location.href='/Admin/AllWorkRecords'</script>", "text/html");
                }
            }

        }
        return View();
    }
    public IActionResult AdminLogout()
    {
        Response.Cookies.Delete("user");
        return RedirectToAction("login", "login");
    }
}
