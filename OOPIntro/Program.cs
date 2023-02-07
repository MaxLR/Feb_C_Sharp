Person laura = new Person()
{
    FirstName = "Laura",
    LastName = "Larramore"
};

Person harold = new Person("Harold", "Barleta");

Student corbin = new Student("Corbin", "Call", "C#");
Student robert = new Student("Robert", "Anderson", "C#");
Student inna = new Student("Inna", "Z", "C#");
Student caleb = new Student("Caleb", "Stewart", "C#");

List<string> maxStacks = new List<string>()
{
    "C#",
    "Python",
    "MERN"
};

Instructor max = new Instructor("Max", "Rauchman", maxStacks);

List<Student> studentList = new List<Student>()
{
    corbin,
    robert,
    inna,
    caleb,
};

// Console.WriteLine(laura.FullName());
// Console.WriteLine(harold.FullName());
// Console.WriteLine(corbin.FullName());
// Console.WriteLine(robert.CurrentStack);
// Console.WriteLine(max.FullName());
// Console.WriteLine(max.StacksTaught[1]);

Lecture oopLecture = new Lecture("OOP Lecture", max, studentList);

oopLecture.PrintAttendance();


public class Person
{
    // auto implemented properties. Fields don't use { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Parameterless constructor allows for constructing manually
    public Person() { }

    /*
    Constructors are methods that are named after the class itself.
    No return is needed b/c it's implicit that a new instance is
    being returned.

    The first constructor you add will override the default parameterless
    constructor. If you want to construct from scratch with no params, you
    need to add the empty constructor yourself (see above)

    We now have a constructor that comes in many forms: polymorphism.
    */
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }
}

public class Student : Person
{
    public string CurrentStack { get; set; }

    public Student(string firstName, string lastName, string currentStack) : base(firstName, lastName)
    {
        CurrentStack = currentStack;
    }
}

public class Instructor : Person
{
    public List<string> StacksTaught { get; set; }

    public Instructor(string firstName, string lastName, List<string> stacksTaught) : base(firstName, lastName)
    {
        StacksTaught = stacksTaught;
    }
}

public class Lecture
{
    public string Topic { get; set; }
    public Person Teacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Lecture(string topic, Person teacher, List<Student> students)
    {
        Topic = topic;
        Teacher = teacher;
        Students = students;
    }

    public void PrintAttendance()
    {
        Console.WriteLine("Topic: " + Topic);
        Console.WriteLine("Instructor Name: " + Teacher.FullName());
        foreach(Student student in Students)
        {
            Console.WriteLine("Student: " + student.FullName());
        }
    }
}