using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using To_DoListAppication.Models;
using To_DoListAppication.ToDoDBContext;


namespace To_DoListAppication.Repository
{
    public class SinInService : ISinInService
    {
        private TODoDBContext db {  get; set; }
        public SinInService (TODoDBContext dBContext)
        {
            db= dBContext;
        }

        public List<SignInModel> AllSignIn()
        {
            List<SignInModel> sm =  db.signInModels.ToList();
            if (sm == null)
            {
                return null;
            }
            return sm;
        }
        
        public object SignInById(string email)
        {
            var obj = db.signInModels.Where(e=>e.email==email).FirstOrDefault();
            return obj;
        }
       
        //public int DeleteSignIn(int Id,string email)
        //{
        //    if (Id != 0)
        //    {
        //       var obj= db.signInModels.Where(e=>e.Id==Id&&e.email==email).FirstOrDefault()  ;
        //        if(obj != null)
        //        {
        //            db.signInModels.Remove(obj);
        //           int res= db.SaveChanges();
        //            return res;
        //        }
        //    }
        //    return 0;
        //}

        public void UpadteSignIn(SignInModel Data)
        {
            if (Data.Id != 0)
            {
                var dataFromDB = db.signInModels.FirstOrDefault(x => x.Id == Data.Id);
                if (dataFromDB != null)
                {
                    dataFromDB.name = Data.name;
                    
                    dataFromDB.mobile = Data.mobile;
                }
            }
        }

        public int InsertSignIn(SignInModel Data)
        {

            if (Data != null)
            {
                db.signInModels.Add(Data);
                int res = db.SaveChanges();
                return res;
            }
            return 0;
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }

        public int DeleteAnySignIn(int Id)
        {
          var user= db.signInModels.Find(Id) ;
            if (user!=null)
            {
                db.signInModels.Remove(user);
                int res= db.SaveChanges();
                return res;
            }
            return 0;
        }
    }
}
