using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewForms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Controller
{
    public class ViewModelManager
    {
        public event Action<ViewModel> VMReadyEvent;
        public event Action RequestCloseAllWindows;

        private Dictionary<int, SharedAnimeChan> sharedChans = new Dictionary<int, SharedAnimeChan>();

        MainFormVM mainVM;

        public ViewModelManager()
        {
        }
        public void Start()
        {
            RegistrationVM registrationMV = new RegistrationVM();
            registrationMV.RegistrationMVReadyEvent += MVReady;
            registrationMV.OpenErrorEvent += OpenError;
            registrationMV.OpenMainFormEvent += openMainForm;
            registrationMV.Start();
        }

        private void OpenError(string error)
        {
            ErrorVM errorVM = new ErrorVM(error);
            errorVM.errorMVReadyEvent += MVReady;
            errorVM.Start();
        }

        private void openMainForm()
        {
            mainVM = new MainFormVM();
            mainVM.MainformMVReadyEvent += MVReady;
            mainVM.OpenAnimeChanCardEvent += OpenAnimeChanCard;
            mainVM.OpenAnimeChanCardShowEvent += OpenAnimeChanCardShow;
            mainVM.OpenAnimeChanCardCreateEvent += OpenAnimeChanCardCreate;
            mainVM.OpenFilterChanEvent += OpenFilterChan;
            mainVM.OpenErrorEvent += OpenError;
            mainVM.Start();
        }

        private void OpenAnimeChanCard(AnimeChanDTO animeChanDTO)
        {
            if (!sharedChans.TryGetValue(animeChanDTO.Id, out var shared))
            {
                shared = new SharedAnimeChan(animeChanDTO);
                sharedChans[animeChanDTO.Id] = shared;
            }

            AnimeChanCardVM animeChanCardVM = new AnimeChanCardVM(shared, true);
            animeChanCardVM.AnimeChanCardMVReadyEvent += MVReady;
            animeChanCardVM.OpenSkillsSettingsEvent += OpenSkillsSettings;
            animeChanCardVM.Start();

            animeChanCardVM.OpenErrorEvent += OpenError;
            animeChanCardVM.RequestSave += () =>
            {
                var index = mainVM.Chans.ToList().FindIndex(c => c.Id == shared.DTO.Id);
                if(index != null && index >=0 && index < mainVM.Chans.Count)
                {
                    mainVM.Chans[index] = shared.DTO;
                }
            };
        }
        private void OpenAnimeChanCardShow(AnimeChanDTO animeChanDTO)
        {
            if (!sharedChans.TryGetValue(animeChanDTO.Id, out var shared))
            {
                shared = new SharedAnimeChan(animeChanDTO);
                sharedChans[animeChanDTO.Id] = shared;
            }
            AnimeChanCardVM animeChanCardVM = new AnimeChanCardVM(shared, false);
            animeChanCardVM.AnimeChanCardMVReadyEvent += MVReady;
            animeChanCardVM.OpenConclutionEvent += OpenConclution;
            animeChanCardVM.Start();
        }
        private void OpenConclution(AnimeChanDTO animeChanDTO)
        {
            ConclutionVM conclutionVM = new ConclutionVM(animeChanDTO);
            conclutionVM.conclutionMVReadyEvent += MVReady;
            conclutionVM.Start();

            RequestCloseAllWindows?.Invoke();
        }

        private void OpenAnimeChanCardCreate()
        {
            AnimeChanCardVM animeChanCardVM = new AnimeChanCardVM();
            animeChanCardVM.AnimeChanCardMVReadyEvent += MVReady;
            animeChanCardVM.OpenErrorEvent += OpenError;
            animeChanCardVM.OpenSkillsSettingsEvent += OpenSkillsSettings;
            animeChanCardVM.Start();
            animeChanCardVM.RequestCreate += (AnimeChanDTO chan) => mainVM.Chans.Add(chan);
        }
        private void OpenSkillsSettings(SharedAnimeChan chan)
        {
            SkillSettingsVM skillsSettingsVM = new SkillSettingsVM(chan);
            skillsSettingsVM.SkillsSettingsMVReadyEvent += MVReady;
            skillsSettingsVM.Start();
        }

        private void OpenFilterChan()
        {
            FilterChanVM filterChanVM = new FilterChanVM();
            filterChanVM.filterChanMVReadyEvent += MVReady;
            filterChanVM.LoadFilterListEvent += () => mainVM.LoadFilterList();
            filterChanVM.Start();
        }
        private void MVReady(ViewModel viewModel)
        {
            VMReadyEvent.Invoke(viewModel);
        }


    }
}
