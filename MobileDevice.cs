using System;

namespace MobileDevices
{
    public class MobileDevice
    {
        private string _brand;
        private double _price;

        public string Brand
        {
            get => _brand;
            set => _brand = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public double Price
        {
            get => _price;
            set => _price = value >= 0 ? value : 0;
        }

        public MobileDevice() : this("Unknown", 0.0) { }

        public MobileDevice(string brand, double price)
        {
            Brand = brand;
            Price = price;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}, Price: {Price}$";
        }
    }
}
