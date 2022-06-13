using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Models;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;
using PsiqueHelp.Core.Infreaestructure.Repository.Abstract;


namespace PsiqueHelp.Core.Infreastructure.Repository.Concrete
{
    public class commentsRepository : IDetailRepository<comments, Guid>
    {
        private PsiqueDB db;
        public commentsRepository(PsiqueDB db)
        {
            this.db = db;
        }

        public void Cancel(Guid transactionId)
        {
            var selectedComment = GetDetailsByTransaction(transactionId);
            if (selectedComment != null)
            {
                selectedComment.ForEach(detail =>
                {
                    db.commeNTS.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se han encontrado comentarios para eliminar");
        }

        public comments Create(comments entity)
        {
            db.commeNTS.Add(entity);
            return entity;
        }

        public List<comments> GetDetailsByTransaction(Guid transactionId)
        {
            var selectedcomm = db.commeNTS
                .Where(c => c.Id_Forum == transactionId)
                .ToList();
            return selectedcomm;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
