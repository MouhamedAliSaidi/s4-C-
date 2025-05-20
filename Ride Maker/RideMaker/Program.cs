// Create at least 4 different vehicles using any of the constructors (use each constructor at least once)

Vehicle car = new Vehicle("Honda", "Blue");
Vehicle bike = new Vehicle("Bike", 1, "Red", false);
Vehicle skateboard = new Vehicle("Skateboard", 1, "Green", false);
Vehicle airplane = new Vehicle("Plane", 500, "White", true);

// Put all the vehicles you created into a List
Vehicle[] vehicles = { car, bike, skateboard, airplane };

//Loop through the List and have each vehicle run its ShowInfo() method
foreach (var v in vehicles)
{
    v.ShowInfo();
    Console.WriteLine();
}

// Make one of the vehicles Travel 100 miles
car.Travel(100);
// Print the information of the vehicle to verify the distance traveled went up
car.ShowInfo(); 



//test