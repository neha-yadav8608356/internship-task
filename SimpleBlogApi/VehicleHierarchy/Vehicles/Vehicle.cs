namespace VehicleHierarchy.Vehicles
{
    public class Vehicle
    {
        public string Brand { get; set; } = "";
        public int Year { get; set; }

        public Vehicle() { }

        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        public virtual void Start()
        {
            Console.WriteLine($"{Brand} vehicle started.");
        }

        public virtual void Stop()
        {
            Console.WriteLine($"{Brand} vehicle stopped.");
        }
    }
}
