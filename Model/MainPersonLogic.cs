using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MainPersonLogic: IMainPerson
    {
        private Saves saves;

        public MainPersonLogic(Saves savess, IUnitOfWork unitOfWorkk)
        {
            saves = savess;
        }

        public void SaveMainPerson(string firstName, string lastName, int age, int height, int weight, int size)
        {
            saves.MainPerson = new MainPerson(firstName, lastName, age, height, weight, size);
        }

        public MainPerson GetMainPerson()
        {
            return saves.MainPerson;
        }
    }
}
