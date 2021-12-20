using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Repository
{
    public interface ITNPRepository
    {
        void ChangePasswordTnp(TblTNPMemberRegister model);
        List<AskQuery> ViewQuery();
        TblTNPMemberRegister GetTNP(string email);
        void NewPost(TblNewPost model);
        bool LoginTnp(TblTNPMemberRegister model);
        List<TblStudentProfile> GetAllStudent();
        void LogoutTnp();
    }
}
