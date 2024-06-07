using To_DoListAppication.Models;

namespace To_DoListAppication.Repository
{
    public interface IWorkRecordSevice
    {
        public List<WorkRecordModel> AllWorkRecord();   
        public object WorkRecordById(int workID);   
        public int DeleteWorkRecord(int workID);   
        public int UpdateWorkRecord( WorkRecordModel wd);   
        public int InsertWorkRecord(WorkRecordModel wd);   
        public List<WorkRecordModel> UserWorkRecord(string email);   
    }
}
