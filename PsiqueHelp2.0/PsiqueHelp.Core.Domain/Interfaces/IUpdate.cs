using System;
using System.Collections.Generic;
using System.Text;

namespace PsiqueHelp.Core.Domain.Interfaces
{
    public interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
