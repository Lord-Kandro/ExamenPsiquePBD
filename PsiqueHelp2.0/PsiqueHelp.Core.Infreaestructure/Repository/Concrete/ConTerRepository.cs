using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class ConTerRepository : IBaseRepository<ConTer, Guid>
    {
        private PsiqueDB db;
        public ConTerRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public ConTer Create(ConTer conter)
        {
            conter.ConTer_id = Guid.NewGuid();//Define nuevo identificador único
            db.conteR.Add(conter);
            return conter;
        }

        public void Delete(Guid entityId)
        {
            var selectedCont = db.conteR
                .Where(ct => ct.ConTer_id == entityId).FirstOrDefault();
            //selecciona el contenido a través del id
            if (selectedCont != null)//verificando si el Contenido existe
                db.conteR.Remove(selectedCont);
        }

        public List<ConTer> GetAll()
        {
            return db.conteR.ToList();
        }

        public ConTer GetById(Guid entityId)
        {
            var selectedCon = db.conteR
                 .Where(ct => ct.ConTer_id == entityId).FirstOrDefault();
            return selectedCon;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public ConTer Update(ConTer cont)
        {
            var selectedcont = db.conteR
                .Where(ct => ct.ConTer_id == cont.ConTer_id)
                .FirstOrDefault();
            //Selecciona el contenido por id desde la BD
            if (selectedcont != null)
            {
                selectedcont.Title = cont.Title;
                selectedcont.Description = cont.Description;
                selectedcont.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectedcont).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedcont;
        }
    }
}
