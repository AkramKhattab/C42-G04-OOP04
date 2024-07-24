using System;
using System.Collections;
using System.Collections.Generic;

namespace C42_G04_OOP04
{
    #region Project 1: 3D Point Class Implementation

    public class Point3D : IComparable<Point3D>, ICloneable
    {
        // Question 1: Define 3D Point Class and the basic Constructors (use chaining in constructors).
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() : this(0, 0, 0) { }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(int coordinate) : this(coordinate, coordinate, coordinate) { }

        // Question 2: Override the ToString Function to produce this output: Point Coordinates: (10 10 10).
        public override string ToString()
        {
            return $"Point Coordinates: ({X} {Y} {Z})";
        }

        // Question 3: Try to use == If (P1 == P2) Does it work properly?
        public static bool operator ==(Point3D p1, Point3D p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Point3D p = (Point3D)obj;
            return X == p.X && Y == p.Y && Z == p.Z;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y, Z).GetHashCode();
        }

        // Question 4: Implement ICloneable interface to be able to clone the object.
        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }

        // Question 5: Define an array of points and sort this array based on X & Y coordinates.
        public int CompareTo(Point3D other)
        {
            if (other == null)
                return 1;

            int compareX = X.CompareTo(other.X);
            if (compareX != 0)
                return compareX;

            int compareY = Y.CompareTo(other.Y);
            if (compareY != 0)
                return compareY;

            return Z.CompareTo(other.Z);
        }

        public static void Main()
        {
            Console.WriteLine("Enter coordinates for point P1:");
            int x1 = Convert.ToInt32(Console.ReadLine());
            int y1 = Convert.ToInt32(Console.ReadLine());
            int z1 = Convert.ToInt32(Console.ReadLine());
            Point3D P1 = new Point3D(x1, y1, z1);

            Console.WriteLine("Enter coordinates for point P2:");
            int x2 = Convert.ToInt32(Console.ReadLine());
            int y2 = Convert.ToInt32(Console.ReadLine());
            int z2 = Convert.ToInt32(Console.ReadLine());
            Point3D P2 = new Point3D(x2, y2, z2);

            Console.WriteLine(P1 == P2 ? "Points are equal." : "Points are not equal.");

            List<Point3D> points = new List<Point3D>
        {
            P1,
            P2,
            new Point3D(3, 2, 1),
            new Point3D(6, 5, 4),
            new Point3D(9, 8, 7)
        };

            points.Sort();

            Console.WriteLine("Sorted points:");
            foreach (var point in points)
            {
                Console.WriteLine(point);
            }
        }
    }

    #endregion


    #region Project 2: Maths Class Implementation

    public static class Maths
    {
        // Question 1: Define Class Maths that has four methods: Add Subtract Multiply and Divide each of them takes two parameters.
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return a / b;
        }

        // Question 2: Call each method in Main().
        // Question 3: Modify the program so that you do not have to create an instance of class to call the four methods.
        public static void Main()
        {
            Console.WriteLine("Addition: " + Add(5, 3));
            Console.WriteLine("Subtraction: " + Subtract(5, 3));
            Console.WriteLine("Multiplication: " + Multiply(5, 3));
            Console.WriteLine("Division: " + Divide(5, 3));
        }
    }

    #endregion


    #region Project 3: Duration Class Implementation

    public class Duration
    {
        // Question 1: Define Class Duration To include Three Attributes Hours Minutes and Seconds.
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        // Constructor to initialize with hours, minutes, and seconds (handles Number 3)
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        // Constructor to initialize with total seconds (handles Number 3)
        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }

        // Question 2: Override All System.Object Members (ToString, Equals, GetHashCode).
        public override string ToString()
        {
            return $"Hours: {Hours} Minutes: {Minutes} Seconds: {Seconds}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Duration d = (Duration)obj;
            return Hours == d.Hours && Minutes == d.Minutes && Seconds == d.Seconds;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Hours, Minutes, Seconds).GetHashCode();
        }

        // Question 4: Implement All required Operators overloading to enable this Code:
        public static Duration operator +(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.Hours + d2.Hours) * 3600 + (d1.Minutes + d2.Minutes) * 60 + d1.Seconds + d2.Seconds;
            return new Duration(totalSeconds);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.Hours * 3600 + d.Minutes * 60 + d.Seconds + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return d + seconds;
        }

        public static Duration operator ++(Duration d)
        {
            return d + 60;
        }

        public static Duration operator --(Duration d)
        {
            return d + (-60);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.Hours - d2.Hours) * 3600 + (d1.Minutes - d2.Minutes) * 60 + d1.Seconds - d2.Seconds;
            return new Duration(totalSeconds);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.Hours > d2.Hours || (d1.Hours == d2.Hours && (d1.Minutes > d2.Minutes || (d1.Minutes == d2.Minutes && d1.Seconds > d2.Seconds)));
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d2 > d1;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1 > d2 || d1 == d2;
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d2 >= d1;
        }

        public static bool operator ==(Duration d1, Duration d2)
        {
            return d1.Equals(d2);
        }

        public static bool operator !=(Duration d1, Duration d2)
        {
            return !d1.Equals(d2);
        }

        // Question 5: DateTime Obj = (DateTime) D1
        public static implicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
        }

        public static void Main()
        {
            // Testing constructors (Number 3)
            Duration D1 = new Duration(11015);
            Console.WriteLine(D1.ToString()); // Output: Hours: 3 Minutes: 3 Seconds: 35

            Duration D2 = new Duration(7800);
            Console.WriteLine(D2.ToString()); // Output: Hours: 2 Minutes: 10 Seconds: 0

            // Testing operator overloads (Number 4)
            Duration D3 = D1 + D2;
            Console.WriteLine(D3.ToString()); // Combined duration

            D3 = D1 + 7800;
            Console.WriteLine(D3.ToString()); // Add seconds to duration

            D3 = 666 + D3;
            Console.WriteLine(D3.ToString()); // Add seconds to duration

            D3 = ++D1;
            Console.WriteLine(D3.ToString()); // Increment duration by 60 seconds

            D3 = --D2;
            Console.WriteLine(D3.ToString()); // Decrement duration by 60 seconds

            D1 = D1 - D2;
            Console.WriteLine(D1.ToString()); // Subtract durations

            Console.WriteLine(D1 > D2); // Comparison
            Console.WriteLine(D1 <= D2); // Comparison

            // Implicit conversion to DateTime (Number 5)
            DateTime dt = (DateTime)D1;
            Console.WriteLine(dt.ToString("HH:mm:ss"));
        }
    }

    #endregion
}