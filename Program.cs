using System;

namespace OOPDemo
{
    #region Abstract Class and Method
    // Abstract class cannot be instantiated and can have abstract methods that must be implemented by derived classes.
    abstract class Animal
    {
        public abstract void Speak(); // Abstract method
        public abstract string Name { get; set; } // Abstract property

        public void Sleep() // Non-abstract method
        {
            Console.WriteLine("Sleeping...");
        }
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }

        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    #endregion

    #region Abstract Class VS Interface
    // Interface cannot contain any implementation, only definitions.
    interface IFlyable
    {
        void Fly();
    }

    class Bird : Animal, IFlyable
    {
        public override void Speak()
        {
            Console.WriteLine("Tweet!");
        }

        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Fly()
        {
            Console.WriteLine("Flying...");
        }
    }
    #endregion

    #region Operator Overloading
    class Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Overloading the + operator
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        // Overloading the ++ operator
        public static Complex operator ++(Complex c)
        {
            return new Complex(c.Real + 1, c.Imaginary + 1);
        }

        // Overloading the == operator
        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Real == c2.Real && c1.Imaginary == c2.Imaginary;
        }

        // Overloading the != operator
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex c = (Complex)obj;
                return this == c;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }
    }
    #endregion

    #region User Defined Casting Operator
    class Temperature
    {
        public double Celsius { get; set; }

        public static implicit operator double(Temperature temp)
        {
            return temp.Celsius;
        }

        public static explicit operator Temperature(double d)
        {
            return new Temperature { Celsius = d };
        }
    }
    #endregion

    #region Static Class, Method, Constructor, Property, Attributes
    static class MathUtils
    {
        public static double Pi { get; } = 3.14159;

        static MathUtils() // Static constructor
        {
            Console.WriteLine("Static constructor called.");
        }

        public static double Square(double number)
        {
            return number * number;
        }
    }
    #endregion

    #region Sealed Class, Method, Property
    sealed class FinalClass
    {
        public void Display()
        {
            Console.WriteLine("This is a sealed class.");
        }
    }

    class BaseClass
    {
        public virtual void Display()
        {
            Console.WriteLine("Base class display method.");
        }
    }

    class DerivedClass : BaseClass
    {
        public sealed override void Display()
        {
            Console.WriteLine("Derived class sealed display method.");
        }
    }

    class AnotherDerivedClass : DerivedClass
    {
        // This will cause a compile error because Display is sealed in DerivedClass
        // public override void Display()
        // {
        //     Console.WriteLine("Another derived class display method.");
        // }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Testing Abstract Class and Method
            Dog dog = new Dog();
            dog.Name = "Buddy";
            Console.WriteLine($"Dog's name is {dog.Name}");
            dog.Speak();
            dog.Sleep();
            #endregion

            #region Testing Abstract Class VS Interface
            Bird bird = new Bird();
            bird.Name = "Tweety";
            Console.WriteLine($"Bird's name is {bird.Name}");
            bird.Speak();
            bird.Fly();
            #endregion

            #region Testing Operator Overloading
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(2, 2);
            Complex c3 = c1 + c2;
            Console.WriteLine($"c3: {c3.Real} + {c3.Imaginary}i");

            c1++;
            Console.WriteLine($"c1 after increment: {c1.Real} + {c1.Imaginary}i");

            bool areEqual = c1 == c2;
            Console.WriteLine($"c1 == c2: {areEqual}");
            #endregion

            #region Testing User Defined Casting Operator
            Temperature temp = new Temperature { Celsius = 37.5 };
            double tempInDouble = temp; // Implicit cast
            Console.WriteLine($"Temperature in double: {tempInDouble}");

            Temperature newTemp = (Temperature)98.6; // Explicit cast
            Console.WriteLine($"Temperature in Celsius: {newTemp.Celsius}");
            #endregion

            #region Testing Static Class, Method, Constructor, Property, Attributes
            Console.WriteLine($"Pi: {MathUtils.Pi}");
            double number = 5;
            double square = MathUtils.Square(number);
            Console.WriteLine($"Square of {number}: {square}");
            #endregion

            #region Testing Sealed Class, Method, Property
            FinalClass finalClass = new FinalClass();
            finalClass.Display();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Display();
            #endregion
        }
    }
}