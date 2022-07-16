using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class NotesRepository : IBaseRepository<Notes, Guid>
    {
        private PsiqueDB db;
        public NotesRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public Notes Create(Notes nota)
        {
            nota.id_Note = Guid.NewGuid();//Define nuevo identificador único
            db.notES.Add(nota);
            return nota;
        }

        public void Delete(Guid entityId)
        {
            var selectednota = db.notES
                .Where(n => n.id_Note == entityId).FirstOrDefault();
            //selecciona al usuario a través del id
            if (selectednota != null)//verificando si la nota existe
                db.notES.Remove(selectednota);
        }

        public List<Notes> GetAll()
        {
            return db.notES.ToList();
        }

        public Notes GetById(Guid entityId)
        {
            var selectednota = db.notES
                .Where(n => n.id_Note == entityId).FirstOrDefault();
            return selectednota;
        }

        public void saveAllChanges()
        {

            db.SaveChanges();
        }

        public Notes Update(Notes nota)
        {
            var selectednota = db.notES
                .Where(n => n.id_Note == nota.id_Note)
                .FirstOrDefault();
            //Selecciona la nota por id desde la BD
            if (selectednota != null)
            {
                selectednota.title = nota.title;
                selectednota.description = nota.description;
                selectednota.date = nota.date;
                selectednota.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectednota).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectednota;
        }
    }
}
