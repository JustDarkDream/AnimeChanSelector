namespace Model
{
    internal static class Saves
    {
        static internal List<Skill> skills = new List<Skill>();
        static internal int temporaryID = 0; //Айди, с помощью которого вычисляется нужная тянка
        static internal FilterStats filterStats = new FilterStats(); //Сохраняет все введенные данные для фильтрации
        static internal List<AnimeChan> filterAnimeChanList = new List<AnimeChan>() { };
        static internal MainPerson mainPerson;
    }
}