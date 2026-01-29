using VehicleHierarchy.Vehicles;

namespace VehicleHierarchy.Vehicles
{
    public class Car : Vehicle
    {
        public int Seats { get; set; }

        public Car(string brand, int year, int seats) : base(brand, year)
        {
            Seats = seats;
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} car is starting smoothly.");
        }
    }
}
