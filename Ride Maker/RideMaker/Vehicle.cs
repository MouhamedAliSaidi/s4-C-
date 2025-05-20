public class Vehicle
{
    public string Name;
    public int Passengers;
    public string Color;
    public bool HasEngine;
    private int DistanceTraveled;

    // A constructor that allows a user to fill in all fields (except distance traveled)
    public Vehicle(string name, int passengers, string color, bool hasEngine)
    {
        Name = name;
        Passengers = passengers;
        Color = color;
        HasEngine = hasEngine;
        DistanceTraveled = 0;
    }

    // A constructor that only allows a user to fill in name and color and provides default values for all other fields (you can assume it will become some sort of car)
    public Vehicle(string name, string color)
    {
        Name = name;
        Color = color;
        Passengers = 4;
        HasEngine = true;
        DistanceTraveled = 0;
    }

    // A method called ShowInfo() 
    public void ShowInfo()
    {
        System.Console.WriteLine($"Name: {Name}, Passengers: {Passengers}, Color: {Color}, Has Engine: {HasEngine}, Distance Traveled: {DistanceTraveled}");
    }

    // A method called Travel() accepts input for distance, adds that distance to the total distance traveled, and prints out a message saying how far the vehicle has gone
    public void Travel(int miles)
    {
        DistanceTraveled += miles;
        System.Console.WriteLine($"{Name} has traveled {miles} miles.");
    }
}

//test