﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PsiqueHelp.Core.Domain.Interfaces
{
    public interface ITransaction
    {
        void saveAllChanges();
    }
}
