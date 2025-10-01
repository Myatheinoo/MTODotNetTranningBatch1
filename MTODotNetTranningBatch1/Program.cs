using System;
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // Variables and Data Type
        // 1. Numeric Type
        int age = 12;
        float pi = 3.14f;
        decimal salary = 550000.55m;
        Console.WriteLine($"Age : {age}, Pi : {pi}, Salary : {salary}");

        // 2. Boolean and Char
        bool isCompleted = true;
        char initial = 'A';
        Console.WriteLine($"Complete : {isCompleted}, Initial : {initial}");

        // 3. Strin and Object 
        string name = "Aye Aye";
        object anyValue = 123;
        Console.WriteLine($"Name : {name}, Object : {anyValue}");

        // Types of Operators
        // 1. Numeric Operator => +,-,*,/,%
        int a = 10;
        int b = 3;
        Console.WriteLine(a + b); // output : 13
        Console.WriteLine(a % b); // output : 1

        // 2. Relational(Comparison) Operator => >,<,>=,<=,==,!=
        Console.WriteLine(a > b); // output : true
        Console.WriteLine(a <= b); // output : false

        // 3. Logical Operator => &&,||,!
        bool isSunny = true; bool isWarm = false;
        Console.WriteLine(isSunny && isWarm); // output : false
        Console.WriteLine(isSunny || isWarm); // output : true

        // 4. Assignment Operators => =,+=,-=,*=,/=,%=
        int x = 10;
        x += 5; // output : 15
        x *= 2; // output : 30
        Console.WriteLine(x);

        // 5. Unary Operators => ++,--, !
        int y = 5;
        Console.WriteLine(++y); // output : 6 (Pre-increment)
        Console.WriteLine(y--); // output : 6 (post-decrement)

        // 6.Bitwise Operators => &,|,^,~,<<,>>
        int num1 = 5; // Binary: 0101
        int num2 = 3; // Binary: 0011
        Console.WriteLine(num1 & num2); // output: 1 (Bitwise AND)
        Console.WriteLine(num1 | num2); // output: 7 (Bitwise OR)

        //Types of Control Statements
        //1. Conditional Statements
        int z = 10;
        if (z > 15)
        {
            Console.WriteLine("Greater than 15");
        }
        else if (z == 10)
        {
            Console.WriteLine("Equal to 10"); // Output: Equal to 10
        }
        else
        {
            Console.WriteLine("Less than 10");
        }

        // 2. Looping Statements
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Count : {i}");
        }

        // 3. Jump Statements
        for (int i = 0; i < 10; i++)
        {
            if (i == 5) break;      // exit loop when i is 5
            Console.WriteLine(i); // output : 1 to 4
        }

        // 4. Exception Handling Statements
        int result = 1;
        try
        {
            if (result == 1)
            {
                throw new Exception("result cannot be null");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            Console.WriteLine("Execution completed.");
        }

        // 5. Selection Statements
        int day = 3;
        switch (day)
        {
            case 1: Console.WriteLine("Today is monday"); break;
            case 2: Console.WriteLine("Today is Tuesday"); break;
            default: Console.WriteLine("Other day"); break; // output : other day
        }

        // Object creation
        Dog myDog = new("Golden Retriever");
        myDog.Bark(); // Output: Golden Retriever is barking.

        Cat cat = new Cat();
        cat.Meow(); // output : The cat meow
        cat.Eat();  // output : this animal eat food
        cat.Sound(); // output : the cat cannot bark

        Human human = new Human();
        human.Eat(); // outupt : human eat food
        human.Walk(); // output : human walk upright

        // Usage
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(5, 3));       // Output: 8
        Console.WriteLine(calc.Add(5.5, 3.3));   // Output: 8.8
        Console.WriteLine(calc.Add(1, 2, 3));    // Output: 6

        // Usage
        Person person = new Person();
        person.Name = "John Doe";  // Using the property
        person.DisplayInfo();      // Output: Name: John Doe

        // Usage
        BankAccount account = new BankAccount();
        account.Deposit = 500;  // Adding money to the account
        Console.WriteLine(account.Balance);  // Output: 500

        // LINQ Basics
        // 1. Query Syntax
        int[] numbers = { 1, 2, 3, 4, 5 };
        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num); // Output: 2, 4
        }

        // 2.Method Syntax
        var oddNumbers = numbers.Where(x => x % 2 != 0);
        foreach (var num in oddNumbers)
        {
            Console.WriteLine(num); // outptu : 1, 3, 5
        }

        var filterNumber = numbers.Where(x => x > 2).OrderByDescending(x => x).Select(x => x * 2);
        foreach (var num in filterNumber)
        {
            Console.WriteLine(num); // output : 10, 8, 6
        }

        List<Student> students = new List<Student>();
        students.AddRange(new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "John Doe",
                FatherName = "Robert Doe",
                Age = 20,
                Address = "123 Elm Street, Springfield",
                DateOfBirth = new DateTime(2003, 5, 15),
                MobileNo = "123-456-7890",
                Gender = "Male"
            },
            new Student
            {
                Id = 2,
                Name = "Jane Smith",
                FatherName = "Michael Smith",
                Age = 22,
                Address = "456 Oak Avenue, Metropolis",
                DateOfBirth = new DateTime(2001, 3, 10),
                MobileNo = "987-654-3210",
                Gender = "Female"
            },
            new Student
            {
                Id = 3,
                Name = "Alice Johnson",
                FatherName = "William Johnson",
                Age = 19,
                Address = "789 Pine Road, Gotham",
                DateOfBirth = new DateTime(2004, 8, 20),
                MobileNo = "555-666-7777",
                Gender = "Female"
            },
            new Student
            {
                Id = 4,
                Name = "Mark Lee",
                FatherName = "Thomas Lee",
                Age = 21,
                Address = "101 Maple Drive, Star City",
                DateOfBirth = new DateTime(2002, 12, 5),
                MobileNo = "222-333-4444",
                Gender = "Male"
            }
        });

        var lst = students.Where(x => x.Age > 20).ToList();
        var lstFemale = students.Where(x => x.Gender == "Female").ToList();
        var lstMale = students.Where(x => x.Gender == "Male").ToList();
        var lstOrder = students.OrderBy(x => x.Name).ToList();
        var maxAge = students.Max(x => x.Age);
        var dob = students.Where(x => x.DateOfBirth.Year <= 2003).ToList();

        // File Handling
        string path = "example.txt";
        using (StreamWriter sw = new StreamWriter(path))
        {
            Console.WriteLine("Hello , World");

        }

        using (StreamReader sr = new StreamReader(path))
        {
            string context = sr.ReadToEnd();
            Console.WriteLine(context);
        }
        string sourcePath = "example.txt";
        string destinationPath = "destination.txt";

        // Copy file
        File.Copy(sourcePath, destinationPath, true);

        // Check if file exists
        if (File.Exists(destinationPath))
        {
            Console.WriteLine("File copied successfully.");
        }

        // Delete file
        File.Delete(destinationPath);

        double value = 1234.5678;

        Console.WriteLine(value.ToString("C"));  // Currency
        //Console.WriteLine(value.ToString("D"));  // Decimal
        Console.WriteLine(value.ToString("E"));  // Exponential
        Console.WriteLine(value.ToString("F"));  // Fixed-point
        Console.WriteLine(value.ToString("N"));  // Number
        Console.WriteLine(value.ToString("P"));  // Percent

        // Date time format
        DateTime now = DateTime.Now;
        Console.WriteLine(now.ToString("yyyy-MM-dd")); // Standard format
        Console.WriteLine(now.ToString("dddd, dd MMMM yyyy")); // Custom format

    }
}

// Classes and Objects
class Dog
{
    // Fields
    private string breed;

    // Property
    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    // Constructor
    public Dog(string breed)
    {
        Breed = breed;
    }

    // Method
    public void Bark()
    {
        Console.WriteLine($"{Breed} is barking.");
    }
}

// Inheritance
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("This animal make a sound");
    }
    public void Eat()
    {
        Console.WriteLine("This animal eat food");
    }
}

class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("The cat cannot bark");
    }
    public void Meow()
    {
        Console.WriteLine("The cat meow");
    }
}

// Interface
interface IAnimal
{
    void Eat();
}
interface IWalk
{
    void Walk();
}
class Human : IAnimal, IWalk
{
    public void Eat()
    {
        Console.WriteLine("Human eat food");
    }
    public void Walk()
    {
        Console.WriteLine("Human walk upright");
    }
}

//  Polymorphism
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

//Encapsulation 
class Person
{
    // Private field
    private string name;

    // Public property
    public string Name
    {
        get { return name; } // Getter
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty.");
            }
        } // Setter
    }

    // Public method
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}");
    }
}
class BankAccount
{
    private double balance;

    // Read-only property
    public double Balance
    {
        get { return balance; }
    }

    // Write-only property
    public double Deposit
    {
        set
        {
            if (value > 0)
            {
                balance += value;
            }
        }
    }
}


