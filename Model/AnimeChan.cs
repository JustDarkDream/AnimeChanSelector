namespace Model
{
    public class AnimeChan
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Height { get; internal set; }

        public int Weight { get; internal set; }

        public int Age {  get; internal set; }

        public int Id { get; internal set; }
        public int Size { get; internal set; }

        public List<Skills> Skills { get; internal set; } = new List<Skills>();

        public AnimeChan(string firstName, string lastName, int age, int id, int height, int weight, int size, List<Skills> skills)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id;
            Height = height;
            Weight = weight;
            Size = size;
            Skills = skills;
        }
    }
}
