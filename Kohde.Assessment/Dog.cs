using System;

namespace Kohde.Assessment {
    public class Dog : Mammal, IDisposable {
        public string Food { get; set; }

        public Dog() { }

        public Dog(string name, int age, string food) : base(name, age) {
            Food = food;
        }

        public override string ToString() {
            return $"{GetDetails()}, Food: {Food}";
        }

        public void Dispose() {
            Console.WriteLine("Disposed of dog");
        }
    }
}