using VehicleHierarchy.Vehicles;
using VehicleHierarchy.Interfaces;

namespace VehicleHierarchy.Vehicles
{
    public class Truck : Vehicle, ICargo
    {
        public int LoadCapacity { get; set; }

        public Truck(string brand, int year, int capacity) : base(brand, year)
        {
            LoadCapacity = capacity;
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} truck engine roars to life!");
        }

        public void LoadCargo()
        {
            Console.WriteLine($"{Brand} truck is loading {LoadCapacity} tons of cargo.");
        }
    }
}
