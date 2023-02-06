// See https://aka.ms/new-console-template for more information
Console.WriteLine("This is an update!");

string name = "Harold";
int someNumber = 42;
// this will error out in C#, unlike non-strongly typed languages (e.g. python, javascript)
// name = someNumber;

// Console.WriteLine(name);

// all functions need to have a "method signature" (the data type that's being returned).
// if nothing is returned, that method signature is void (instead of an int, string, object, etc.)
void PrintDivisibleNumbers(int start = 1, int end = 100)
{
    for (int i = start; i <= end; i++)
    {
        bool isDivisibleBy3 = i % 3 == 0;
        bool isDivisibleBy5 = i % 5 == 0;
        bool isDivisibleBy3And5 = isDivisibleBy3 && isDivisibleBy3;
        
        if(isDivisibleBy3And5)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (isDivisibleBy3)
        {
            Console.WriteLine("Fizz");
        }
        else if (isDivisibleBy5)
        {
            Console.WriteLine("Buzz");
        }
        else 
        {
            Console.WriteLine(i);
        }
    }
}

// PrintDivisibleNumbers(1, 20);
// PrintDivisibleNumbers();

// Create a list with the names: Laura, Caleb, Harold, Corbin, Robert, Inna
// return a list that only includes names longer than 5 characters

List<string> FilterToLongNames()
{
    List<string> names = new List<string>()
    {
        "Laura", "Caleb", "Harold", "Corbin", "Robert", "Inna"
    };

    List<string> output = new List<string>();

    foreach (string name in names)
    {
        if(name.Length > 5)
        {
            output.Add(name);
        }
    }

    return output;
}

List<string> longNames = FilterToLongNames();

foreach(string longName in longNames)
{
    Console.WriteLine(longName);
}