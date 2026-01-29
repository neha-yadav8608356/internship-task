using VehicleHierarchy.Vehicles;

namespace VehicleHierarchy.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, int year, bool sidecar) : base(brand, year)
        {
            HasSidecar = sidecar;
        }

        public override void Start()
        {
            Console.WriteLine($"{Brand} motorcycle revs up!");
        }
    }
}
