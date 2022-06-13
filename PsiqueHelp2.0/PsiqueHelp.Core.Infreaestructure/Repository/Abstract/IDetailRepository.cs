using System;
using System.Collections.Generic;
using System.Text;

using PsiqueHelp.Core.Domain.Interfaces;
namespace PsiqueHelp.Core.Infreaestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId> : ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);
        void Cancel(Guid entityId);
    }
}
