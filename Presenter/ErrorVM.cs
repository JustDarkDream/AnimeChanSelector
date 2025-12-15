using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ErrorVM: ViewModel
    {
        public event Action<ViewModel> errorMVReadyEvent;
        public string Error { get; set; }

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="error">Текст ошибки</param>
        public ErrorVM(string error)
        {
            Error = error;
        }

        /// <summary>
        /// Метод, сообщающий о готовности к работе
        /// </summary>
        public void Start()
        {
            //Какую подготовку?
            errorMVReadyEvent.Invoke(this);
        }
    }
}
