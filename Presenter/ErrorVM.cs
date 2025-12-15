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
        public ErrorVM(string error)
        {
            Error = error;
        }

        public void Start()
        {
            //Какую подготовку?
            errorMVReadyEvent.Invoke(this);
        }
    }
}
