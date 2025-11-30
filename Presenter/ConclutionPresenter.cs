using Microsoft.EntityFrameworkCore.Metadata;
using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class ConclutionPresenter
    {
        internal ConclutionPresenter(IViewConclution view, ILogic logic)
        {
            view.MakeConclutionEvent += logic.MakeConclution;

            logic.WriteConclutionEvent += view.WriteConclution;
        }
    }
}