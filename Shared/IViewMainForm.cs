using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IViewMainForm
    {
        event Action LoadAnimeChanListEvent;
        event Action<int> FindByIdEvent;
        event Action LoadIdEvent;
        event Action<int> DeleteAnimeChanEvent;
        event Action LoadFilterAnimeChanListEvent;
        event Action DestroyFilterEvent;
        event Action FindAnimeChanEvent;
        event Action GetMainPersonEvent;

        event Func<IViewAnimeChanCard> GetIViewAnimeChanCardEvent;
        event Func<IViewFilterChan> GetIViewFilterChanEvent;

        void LoadAnimeChanList(IEnumerable<AnimeChanDTO> list);
        void GetMainPerson(MainPersonDTO main);

        void FindById(AnimeChanDTO chan);
        void FilterAnimeChanList(List<AnimeChanDTO> chans);
        void LoadId(int id);
        void FindAnimeChan(AnimeChanDTO chan);
        void LoadAnimeChanList(List<AnimeChanDTO> list);

        bool CorrectWork();
    }
}
