using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Core.Infreastructure.Repository.Abstract;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class mediumsRepository : IBaseRepository<mediums, Guid>
    {
        private PsiqueDB db;
        public mediumsRepository(PsiqueDB db)
        {
            this.db = db;
        }
        public mediums Create(mediums medio)
        {
            medio.Id_Medios = Guid.NewGuid();//Define nuevo identificador único
            db.mediumS.Add(medio);
            return medio;
        }

        public void Delete(Guid entityId)
        {
            var selectedmediums = db.mediumS
                .Where(m => m.Id_Medios == entityId).FirstOrDefault();
            //selecciona el medio a través del id
            if (selectedmediums != null)//verificando si el usuario existe
                db.mediumS.Remove(selectedmediums);
        }

        public List<mediums> GetAll()
        {
            return db.mediumS.ToList();
        }

        public mediums GetById(Guid entityId)
        {
            var selectedmedio = db.mediumS
                .Where(m => m.Id_Medios == entityId).FirstOrDefault();
            return selectedmedio;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public mediums Update(mediums medio)
        {
            var selectedmedio = db.mediumS
                .Where(m => m.Id_Medios == medio.Id_Medios)
                .FirstOrDefault();
            //Selecciona el medio por id desde la BD
            if (selectedmedio != null)
            {
                selectedmedio.video = medio.video;
                selectedmedio.image = medio.image;
                selectedmedio.music = medio.music;

                selectedmedio.updated_at = DateTime.Now;
                //modifica los valores con los nuevos ingresados

                db.Entry(selectedmedio).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedmedio;
        }
    }
}
