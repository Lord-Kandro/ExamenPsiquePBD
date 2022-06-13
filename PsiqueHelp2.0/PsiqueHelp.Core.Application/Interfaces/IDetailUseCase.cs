using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Interfaces;

namespace PsiqueHelp.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}
