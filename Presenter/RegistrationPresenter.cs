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
    internal class RegistrationPresenter
    {
        internal RegistrationPresenter(IViewRegistration view, ILogic logic)
        {
            view.SaveMainPersonEvent += logic.SaveMainPerson;
            view.DeleteAnimeChansEvent += logic.DeleteAnimeChans;
            view.DeleteSkillsEvent += logic.DeleteSkills;
            view.LoadAllSkillsInDBEvent += logic.LoadAllSkillsInDB;
            view.CreateAnimeChansEvent += logic.CreateAnimeChans;
            view.CreateAnimeChansInDBEvent += logic.CreateAnimeChansInDB;

        }
    }
}
