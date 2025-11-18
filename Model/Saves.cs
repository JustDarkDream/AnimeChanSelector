namespace Model
{
    public class Saves
    {

        internal List<Skill> Skills { get; set; } = new List<Skill>();
        internal int TemporaryID { get; set; } //Айди, с помощью которого вычисляется нужная тянка
        internal FilterStats FilterStats { get; set; } = new FilterStats(); //Сохраняет все введенные данные для фильтрации
        internal List<AnimeChan> FilterAnimeChanList { get; set; } = new List<AnimeChan>() { };
        internal List<AnimeChan> AnimeChanList { get; set; } = new List<AnimeChan>() { };
        internal MainPerson MainPerson { get; set; }

        private static Saves instance;

        private Saves() { }

        public static Saves GetInstatnce()
        {
            if (instance == null)
            {
                instance = new Saves() { TemporaryID = 0 };
            }
            return instance;
        }
    }
}