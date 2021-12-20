using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LNCT_TNP_Project.Models;

namespace LNCT_TNP_Project.Repository.Implementation
{
    public class TNPRepository : ITNPRepository
    {
        private LNCT_TNP_DBEntities context;

        public TNPRepository()
        {
            context = new LNCT_TNP_DBEntities();
        }

        public List<TblStudentProfile> GetAllStudent()
        {
            return context.TblStudentProfiles.ToList();
        }

        public void ChangePasswordTnp(TblTNPMemberRegister model)
        {
            var chanpass = context.TblTNPMemberRegisters.FirstOrDefault(x => x.TNPID == model.TNPID);
            if (chanpass != null)
            {
                //chanpass.TNPID = model.TNPID;
                chanpass.Password = model.Password;
                context.Entry(chanpass).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TblTNPMemberRegister GetTNP(string email)
        {
            var tnp = context.TblTNPMemberRegisters.FirstOrDefault(x => x.EmailID == email);
            if (tnp != null)
            {
                return tnp;
            }
            return tnp;
        }

        public bool LoginTnp(TblTNPMemberRegister model)
        {
            bool isValid = context.TblTNPMemberRegisters.Any(x => x.EmailID == model.EmailID && x.Password ==model.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(model.EmailID, false);
                return isValid;
            }
            return isValid;
        }

        public void LogoutTnp()
        {
            FormsAuthentication.SignOut();
        }

        public void NewPost(TblNewPost model)
        {
            if (model != null)
            {
                context.TblNewPosts.Add(model);
                context.SaveChanges();
            }
           
        }

        public List<AskQuery> ViewQuery()
        {
            return context.AskQueries.OrderByDescending(ord => ord.CreatedOn).ToList();
            
        }
    }
}