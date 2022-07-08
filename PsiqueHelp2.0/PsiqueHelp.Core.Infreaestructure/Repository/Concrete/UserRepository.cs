using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreaestructure.Repository.Concrete
{
    public class UserDaRepository : IBaseRepository<UserDa, Guid>
    {
        private readonly PsiqueDB db;
        public UserDaRepository(PsiqueDB db)
        {
            this.db = db;
        }

        public UserDa Create(UserDa user)
        {
            user.Id_UserDa =Guid.NewGuid();//Define nuevo identificador único
            db.useRDA.Add(user);
            return user;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.useRDA
                .Where(ud => ud.Id_UserDa == entityId).FirstOrDefault();
            //selecciona al usuario a través del id
            if (selectedUser != null)//verificando si el usuario existe
                db.useRDA.Remove(selectedUser);
        }

        public List<UserDa> GetAll()
        {
            return db.useRDA.ToList();
        }

        public UserDa GetById(Guid entityId)
        {
            var selectedUser = db.useRDA
                .Where(ud => ud.Id_UserDa == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public UserDa Update(UserDa user)
        {
            var selectedUser = db.useRDA
                .Where(ud => ud.Id_UserDa == user.Id_UserDa)
                .FirstOrDefault();
            //Selecciona al usuario por id desde la BD
            if (selectedUser != null)
            {
                selectedUser.Name = user.Name;
                selectedUser.Surname = user.Surname;
                selectedUser.Nick = user.Nick;
                selectedUser.City = user.City;
                selectedUser.Department = user.Department;
                selectedUser.Email = user.Email;
                selectedUser.Password = user.Password;
                selectedUser.Cell = user.Cell;
                selectedUser.IdPerson = user.IdPerson;
                selectedUser.age = user.age;
                selectedUser.Updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados
                
                db.Entry(selectedUser).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedUser;
        }
    }
}
