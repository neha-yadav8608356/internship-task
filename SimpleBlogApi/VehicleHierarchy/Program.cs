using VehicleHierarchy.Vehicles;
using VehicleHierarchy.Interfaces;

class Program
{
    static void Main()
    {
        // Create vehicles
        Vehicle car = new Car("Toyota", 2022, 5);
        Vehicle truck = new Truck("Volvo", 2020, 10);
        Vehicle bike = new Motorcycle("Harley", 2021, false);

        // Polymorphism: call Start on base class reference
        Vehicle[] vehicles = { car, truck, bike };
        foreach (var v in vehicles)
        {
            v.Start();
            v.Stop();
            Console.WriteLine();
        }

        // Using interface
        ICargo cargoTruck = truck as ICargo;
        cargoTruck?.LoadCargo();
    }
}

