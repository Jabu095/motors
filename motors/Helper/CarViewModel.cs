using motors.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace motors.Helper
{
    public class CarViewModel
    {
        public List<Car> Cars { get; set; }

        public List<Car> BuildCars(List<Car> cars, CarSearch filter)
        {
            if (filter.Makes.Count() > 0)
            {
                var NewCars = new List<Car>();
                filter.Makes.ForEach(delegate (string name)
                {
                    var subCar = cars.Where(x => x.Make.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (subCar.Count() > 0)
                    {
                        subCar.ForEach(delegate (Car _car)
                        {
                            NewCars.Add(_car);
                        });
                    }
                });
                return NewCars;
            }
            return null;
        }

    }

    public class CarSearch
    {
        public List<string> Makes { get; set; }
        public List<string> Model { get; set; }
        public List<string> Years { get; set; }

        public Transmisson Transmission { get; set; }
        public FuelType FuelType { get; set; }
        public double PriceRange { get; set; }
    }
}