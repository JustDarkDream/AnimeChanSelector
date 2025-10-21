namespace Model
{
    internal class MainPerson
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Height { get; internal set; }

        public int Weight { get; internal set; }

        public int Age { get; internal set; }
        public int Size { get; internal set; }

        /// <summary>
        /// Конструктор экземпляра класса MainPerson.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="weight">Вес</param>
        /// <param name="size">Размер (чего??)</param>
        public MainPerson(string firstName, string lastName, int age, int height, int weight, int size)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;
            Size = size;
        }
    }
}
