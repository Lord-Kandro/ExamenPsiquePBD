using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class ForumRepository : IBaseRepository<Forum, Guid>
    {
        private PsiqueDB db;
        public ForumRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public Forum Create(Forum foru)
        {
            foru.Id_Forum = Guid.NewGuid();//Define nuevo identificador único
            db.forUM.Add(foru);
            return foru;
        }

        public void Delete(Guid entityId)
        {
            var selectedfor = db.forUM
                .Where(f => f.Id_Forum == entityId).FirstOrDefault();
            //selecciona el foro a través del id
            if (selectedfor != null)//verificando si el foro existe
                db.forUM.Remove(selectedfor);
        }

        public List<Forum> GetAll()
        {
            return db.forUM.ToList();
        }

        public Forum GetById(Guid entityId)
        {
            var selectedfor = db.forUM
                 .Where(f => f.Id_Forum == entityId).FirstOrDefault();
            return selectedfor;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Forum Update(Forum foru)
        {
            var selectedfor = db.forUM
                .Where(f => f.Id_Forum == foru.Id_Forum)
                .FirstOrDefault();
            //Selecciona el foro por id desde la BD
            if (selectedfor != null)
            {
                selectedfor.topic = foru.topic;
                selectedfor.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectedfor).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedfor;
        }
    }
}
