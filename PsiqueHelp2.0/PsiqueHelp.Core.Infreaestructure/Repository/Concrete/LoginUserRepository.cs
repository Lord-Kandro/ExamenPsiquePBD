using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class LoginUserRepository : IBaseRepository<LoginUsers, Guid>
    {
        private PsiqueDB db;
        public LoginUserRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public LoginUsers Create(LoginUsers log)
        {
            log.Id_Login = Guid.NewGuid();//Define nuevo identificador único
            db.loginuSERS.Add(log);
            return log;
        }

        public void Delete(Guid entityId)
        {
            var selectedlog = db.loginuSERS
                .Where(lu => lu.Id_Login == entityId).FirstOrDefault();
            //selecciona el login a través del id
            if (selectedlog != null)//verificando si el login existe
                db.loginuSERS.Remove(selectedlog);
        }

        public List<LoginUsers> GetAll()
        {
            return db.loginuSERS.ToList();
        }

        public LoginUsers GetById(Guid entityId)
        {
            var selectedlog = db.loginuSERS
                 .Where(lu => lu.Id_Login == entityId).FirstOrDefault();
            return selectedlog;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public LoginUsers Update(LoginUsers log)
        {
            var selectedlog = db.loginuSERS
                .Where(lu => lu.Id_Login == log.Id_Login)
                .FirstOrDefault();
            //Selecciona el login por id desde la BD
            if (selectedlog != null)
            {
                selectedlog.email = log.email;
                selectedlog.password = log.password;
                selectedlog.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectedlog).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedlog;
        }
    }
}
