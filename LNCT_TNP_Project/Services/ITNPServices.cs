using LNCT_TNP_Project.DTO;
using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNCT_TNP_Project.Services
{
    public interface ITNPServices
    {
        void NewPost(NewPostDTO model);
        List<AskQueryDTO> ViewQuery();
        void ChangePassword(TNPMemberRegisterDTO tnpModel);
        TNPMemberRegisterDTO GetTNP(string email);
        bool LoginTnp(TNPMemberRegisterDTO model);
        List<StudentProfileDTO> GetAllStudent();
        void LogoutTnp();
    }
}
