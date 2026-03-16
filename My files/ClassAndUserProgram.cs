using System;
namespace NewProject
{
    public abstract class Animal
    {
        private int _number;


        public abstract string Word { get; }

        public Animal(int number)
        {
            _number = number;
        }

        public void Method1()
        {
            Console.WriteLine("Animal method 1");
        }

        public virtual void Method2()
        {
            Console.WriteLine("Animal method 2");
        }

        public abstract void Method3();
        
    }

    public class Cat : Animal
    {
        public Cat(int number) : base(number)
        {
        }

        public override string Word => "Meow";
        public new void Method1()
        {
            Console.WriteLine("Cat Method 1");
        }

        public override void Method2()
        {
            Console.WriteLine("Overrided Method 2 in Cat class");
        }


        public override void Method3()
        {
            Console.WriteLine("Overrided abstact Method 3 in Cat class");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Cat cat1 = new Cat(1);
            Animal cat2 = new Cat(2);


            cat1.Method1(); cat1.Method2(); cat1.Method3();
            Console.WriteLine();
            cat2.Method1(); cat2.Method2(); cat2.Method3();
        }
    }
}
