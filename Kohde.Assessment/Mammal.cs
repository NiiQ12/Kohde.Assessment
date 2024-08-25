namespace Kohde.Assessment {
    public abstract class Mammal : IDetails {
        public string Name { get; set; }
        public int Age { get; set; }

        public Mammal() { }

        public Mammal(string name, int age) {
            Name = name;
            Age = age;
        }

        public string GetDetails() {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
