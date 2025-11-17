using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IConclution
    {
        ///<summary>Создаёт результат отношений с выбранной тянкой</summary>
        /// <returns>Возвращает строку с результатом отношений с выбранной тянкой</returns>
        public string MakeConclution();
    }
}
