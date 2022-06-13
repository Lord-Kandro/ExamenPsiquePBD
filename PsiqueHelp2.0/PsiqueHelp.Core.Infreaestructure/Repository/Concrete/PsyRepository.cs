using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class PsyRepository : IBaseRepository<Psy_Da, Guid>
    {
        private PsiqueDB db;
        public PsyRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public Psy_Da Create(Psy_Da psy)
        {
            psy.Id_User_Psy = Guid.NewGuid();//Define nuevo identificador único
            db.psYDA.Add(psy);
            return psy;
        }

        public void Delete(Guid entityId)
        {
            var selectedpsy = db.psYDA
                .Where(pd => pd.Id_User_Psy == entityId).FirstOrDefault();
            //selecciona al psy a través del id
            if (selectedpsy != null)//verificando si el psy existe
                db.psYDA.Remove(selectedpsy);
        }

        public List<Psy_Da> GetAll()
        {
            return db.psYDA.ToList();
        }

        public Psy_Da GetById(Guid entityId)
        {
            var selectedpsy = db.psYDA
                .Where(pd => pd.Id_User_Psy == entityId).FirstOrDefault();
            return selectedpsy;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Psy_Da Update(Psy_Da psy)
        {
            var selectedpsy = db.psYDA
                .Where(pd => pd.Id_User_Psy == psy.Id_User_Psy)
                .FirstOrDefault();
            //Selecciona al usuario por id desde la BD
            if (selectedpsy != null)
            {
                selectedpsy.Name = psy.Name;
                selectedpsy.Surname = psy.Surname;
                selectedpsy.Nick = psy.Nick;
                selectedpsy.City = psy.City;
                selectedpsy.Department = psy.Department;
                selectedpsy.email = psy.email;
                selectedpsy.password = psy.password;
                selectedpsy.cell = psy.cell;
                selectedpsy.idPerson = psy.idPerson;
                selectedpsy.Register_S = psy.Register_S;
                selectedpsy.folio = psy.folio;
                selectedpsy.volume = psy.volume;
                selectedpsy.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectedpsy).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedpsy;
        }
    }
}
