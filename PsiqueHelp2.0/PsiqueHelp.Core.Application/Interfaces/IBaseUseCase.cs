﻿using System;
using System.Collections.Generic;
using System.Text;
using PsiqueHelp.Core.Domain.Interfaces;
namespace PsiqueHelp.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
