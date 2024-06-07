using To_DoListAppication.Models;

namespace To_DoListAppication.Repository
{
    public interface ISinInService
    {
        public List<SignInModel> AllSignIn();
        public object SignInById(string email );
        //public int DeleteSignIn(int Id ,string email);
        public int DeleteAnySignIn(int Id );
        public void UpadteSignIn(SignInModel Data );
        public int InsertSignIn(SignInModel Data );
        public bool SaveChanges();
    }
}
