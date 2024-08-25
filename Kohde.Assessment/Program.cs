using Kohde.Assessment.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohde.Assessment {
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program {
        static void Main(string[] args) {
            #region Assessment A

            Console.WriteLine("=============== Assessment A ================");

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 

            // Added constructors
            // Added an abstract class for shared properties
            var human = new Human("John", 35, "M");
            Console.WriteLine(human);

            var dog = new Dog("Walter", 7, "Epol");
            Console.WriteLine(dog);

            var cat = new Cat("Snowball", 35, "Whiskers");
            Console.WriteLine(cat);

            #endregion

            #region Assessment B

            Console.WriteLine("\n=============== Assessment B ================");

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            Console.WriteLine("\n=============== Assessment C ================");

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };
            // the following method must return the first event number - as suggested by it's name
            var firstValue = GetFirstEvenValue(numbers);
            Console.WriteLine("First Number: " + firstValue);

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };
            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            Console.WriteLine("\n=============== Assessment D ================");

            // there are multiple corrections required!!
            // correct the following statement(s)
            try {
                Dog bulldog = null;

                // Check if the object is null and throw an ArgumentNullException if it is
                // Throw more precise error than the object reference error that would have been caught otherwise
                if (bulldog == null)
                    throw new ArgumentNullException(nameof(bulldog), "Dog object is null.");

                // Dog implements the IDisposable interface instead of casting bulldog as IDisposable
                // Call Dispose directly on the object
                bulldog.Dispose();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Assessment E

            Console.WriteLine("\n=============== Assessment E ================");

            DisposeSomeObject();

            #endregion

            #region Assessment F

            Console.WriteLine("\n=============== Assessment F ================");

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            ShowSomeMammalInformation(human);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(cat);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD
            string a = Program.GenericTester(walter => walter.GetDetails(), dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            #region Assessment G

            Console.WriteLine("\n=============== Assessment G ================");

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code
            try {
                CatchAndRethrowExplicitly();
            } catch (ArithmeticException e) {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion

            #region Assessment H

            Console.WriteLine("\n=============== Assessment H ================");

            try {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                Console.WriteLine(CallMethodWithReflection());
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region IoC / DI

            Console.WriteLine("\n================= IoC / DI ==================");

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            Console.WriteLine("\n============ Bonus XP - Dungeon =============");

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE

            const string abc = "asduqwezxc";
            foreach (var vowel in abc.SelectOnlyVowels()) {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE

            List<Dog> dogs = new List<Dog>
            {
                new Dog {Age = 8, Name = "Max"},
                new Dog {Age = 3, Name = "Rocky"},
                new Dog {Age = 9, Name = "XML"}
            };

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

            foreach (var d in foo) {
                ShowSomeMammalInformation(d);
            }

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8

            List<Cat> cats = new List<Cat>
            {
                new Cat {Age = 1, Name = "Capri"},
                new Cat {Age = 8, Name = "Cara"},
                new Cat {Age = 3, Name = "Captain Hooks"}
            };

            var bar = cats.CustomWhere(x => x.Age <= 4);

            foreach (var c in bar) {
                ShowSomeMammalInformation(c);
            }

            // < CATS REQUIRED OUTPUT =>
            //      Name: Capri Age: 1
            //      Name: Captain Hooks Age: 3

            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method

        public static void PerformanceTest() {
            // Changed to StringBuilder as concatenating strings creates a new string object in memory; which in this case happens 500000 times
            // StringBuilder appends onto the existing buffer in memory as opposed to creating new objects
            var someLongDataString = new StringBuilder();
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) {
                someLongDataString.Append(source);
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers) {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE

            // Returns 0 if no even number is found
            return numbers.FirstOrDefault(x => x % 2 == 0);
        }

        public static string GetSingleStringValue(List<string> stringList) {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT

            // Seems like it's expected to use SingleOrDefault; however, the ask is for the FIRST item to be returned and not the ONLY item
            // return stringList.SingleOrDefault(x => x.IndexOf("a") != -1);
            return stringList.FirstOrDefault(x => x.IndexOf("a") != -1);
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject() {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            // Changed try-catch to using as the Dispose method gets called when exiting a using block of a disposable object
            using (var disposableObject = new DisposableObject()) {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");

                return disposableObject;
            }
        }

        #endregion

        #region Assessment F Methods

        //public static void ShowSomeHumanInformation(Human human) {
        //    Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
        //}

        //public static void ShowSomeDogInformation(Dog dog) {
        //    Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
        //}

        //public static void ShowSomeCatInformation(Cat cat) {
        //    Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);
        //}

        public static void ShowSomeMammalInformation<T>(T mammal) where T : Mammal {
            Console.WriteLine("Name: " + mammal.Name + " Age: " + mammal.Age);
        }

        public static TRes GenericTester<T, TRes>(Func<T, TRes> func, T obj) where T : Mammal, new() {
            if (obj == null) {
                obj = new T();
            }

            return func(obj);
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly() {
            try {
                ThrowException();
            } catch (ArithmeticException) {
                throw; // Rethrow the original exception, preserving the stack trace
            }
        }

        private static void ThrowException() {
            throw new ArithmeticException("illegal expression - was this picked up??");
        }

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection() {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IS JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
            //throw new NotImplementedException(); // ATT: REMOVE THIS LINE

            var method = typeof(Program).GetMethod("DisplaySomeStuff");
            if (method == null) {
                throw new NotImplementedException();
            }

            var genericMethod = method.MakeGenericMethod(typeof(string));

            return (string)genericMethod.Invoke(typeof(Program), new object[] {
                "Displaying Some Stuff..."
            });
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class {
            return string.Format("Here it is: {0}", toDisplay);
        }

        #endregion

        #region IoC / DI

        public static void PerformIoCActions() {
            /*  A very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
             *  By making use of the classes provided, perform the following tasks:
             *  
             *  Two classes and two interfaces have been created for you, namely:
             *  
             *      - IDevice
             *      - SamsungDevice
             *      - IDeviceProcessor
             *      - DeviceProcessor
             * 
             *  The actual declarations can be view lower down in this file.
             *  
             *  The following needs to happen:
             *      
             *      1. register the interfaces with the respective classes
             *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
             *      
             *  Some of the code below has been done, but you need to fill in the blanks
             */

            // 1. register the interfaces and classes
            var container = Ioc.Container;
            container.Register<IDevice, SamsungDevice>();
            container.Register<IDeviceProcessor, DeviceProcessor>();

            // 2. resolve the IDeviceProcessor
            var deviceProcessor = container.Resolve<IDeviceProcessor>();
            // call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Bonus XP - Dungeon

        //Extension methods on IEnumerables
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> list, Func<T, bool> predicate) {
            return list.Where(predicate);
        }

        public static IEnumerable<char> SelectOnlyVowels(this IEnumerable<char> searchInput) {
            return searchInput.Where(c => "aeiou".Contains(c));
        }

        #endregion Bonus XP - Dungeon
    }

    public interface IDevice {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice {
        public string DeviceCode { get; private set; }

        public SamsungDevice() {
            this.DeviceCode = "Samsung";
        }
    }

    public interface IDeviceProcessor {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device) {
            this.Device = device;
        }

        public double GetDevicePrice() {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
