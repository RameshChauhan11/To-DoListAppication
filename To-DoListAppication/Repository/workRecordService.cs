using To_DoListAppication.Models;
using To_DoListAppication.ToDoDBContext;

namespace To_DoListAppication.Repository
{
    public class workRecordService : IWorkRecordSevice
    {

        private TODoDBContext db { get; set; }
        public workRecordService(TODoDBContext dBContext)
        {
            db = dBContext;
        }
        public List<WorkRecordModel> AllWorkRecord()
        {
            List<WorkRecordModel> wd=(List<WorkRecordModel>) db.workRecordModels.ToList();
            
                return wd;
           
        }

        public int DeleteWorkRecord(int workId)
        {
            var obj = db.workRecordModels.Find(workId);
            if(obj != null) 
            { 
                db.workRecordModels.Remove(obj);
                int res=db.SaveChanges();
                return res;
            }
            return 0;
        }

        public int InsertWorkRecord( WorkRecordModel wd)
        {
           if(wd!=null)
            {
              db.workRecordModels.Add(wd);
                
            }
           int res = db.SaveChanges();  
            return res;
        }

        public int UpdateWorkRecord( WorkRecordModel wd)
        {
            var obj = db.workRecordModels.FirstOrDefault(x => x.workId == wd.workId);
            if(obj != null)
            {
                obj.workName=wd.workName;
                obj.dateOfWork = wd.dateOfWork;
                obj.workDetails=wd.workDetails;
                obj.IsCompleted=wd.IsCompleted;
                db.workRecordModels.Update(obj);
               int res= db.SaveChanges();
                return res;
            }
            return 0;
        }

        public object WorkRecordById(int workId)
        {
            var obj=db.workRecordModels.Find(workId);
            return obj;
        }

        public List<WorkRecordModel> UserWorkRecord(string email)
        {
           List<WorkRecordModel> list= db.workRecordModels.Where(e=>e.userEmail== email).ToList();
            return list;
        }
    }
}
