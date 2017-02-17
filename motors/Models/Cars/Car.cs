using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace motors.Models.Cars
{
    public enum Condition
    {
        UsedCard,NewCar
    }

    public enum CarLable
    {
        NewCar,Sold,Reduced
    }

    public enum FuelType
    {
        Petrol, Diesel
    }
    public enum Transmisson
    {
        Automatic, Manual, DSC
    }

    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public int Mileage { get; set; }
        public Nullable<DateTime> Year { get; set; }
        public Transmisson Transmisson { get; set; }
        [Required]
        public Condition Condition { get; set; }
        public double Price { get; set; }
        public FuelType FuelType { get; set; }
        public Nullable<DateTime> DateUploaded { get; set; }
        public string Location { get; set; }
        public CarLable Lable { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string CarDescription { get; set; }
        public virtual ICollection<CarPictures> Pictures { get; set; }

    }

    public class CarPictures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateUploaded { get; set; }
        public Car Car { get; set; }
    }

    public class CarApplication
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class Contactdealer
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public Car Car { get; set; }
    }
}