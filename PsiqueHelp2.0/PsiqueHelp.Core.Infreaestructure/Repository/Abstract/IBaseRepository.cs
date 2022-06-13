using System;
using System.Collections.Generic;
using System.Text;

using PsiqueHelp.Core.Domain.Interfaces;

namespace PsiqueHelp.Core.Infreastructure.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId> : ICreate<Entity>, IRead<Entity, EntityId>,
       IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {

    }
}
