using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;

namespace Raizen.SICCadastro.Rebate.DAL
{
    public partial interface ICalculoRebateProporcionalSicDAO
    {
        void IncluirComTransacao(CalculoRebateProporcionalSic calculoRebateFaixaSic, DatabaseManager databaseManager);
    }
}