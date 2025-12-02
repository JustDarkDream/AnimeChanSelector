using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IViewConclution
    {
        event Action MakeConclutionEvent;
        public void WriteConclution(string str);

        bool CorrectWork();
    }
}
