using System;

namespace MobileDevices
{
    // Смартфон. IComparable - сравнение по цене,
    // ICloneable - создание независимой копии
    public class Smartphone : MobileDevice,
        IComparable<Smartphone>, ICloneable
    {
        private int _ram;
        private string _osVersion;

        public int Ram
        {
            get { return _ram; }
            set { _ram = value > 0 ? value : 0; }
        }

        public string OsVersion
        {
            get { return _osVersion; }
            set
            {
                _osVersion = string.IsNullOrWhiteSpace(value)
                    ? "Unknown" : value;
            }
        }

        public Smartphone()
            : this("Unknown", 0.0, 0, "Unknown")
        {
        }

        public Smartphone(string brand, double price,
            int ram, string osVersion) : base(brand, price)
        {
            Ram = ram;
            OsVersion = osVersion;
        }

        public int CompareTo(Smartphone other)
        {
            if (other == null)
            {
                return 1;
            }
            return Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            // Поля - числа и строки, поэтому достаточно
            // создать новый объект с теми же значениями
            return new Smartphone(
                Brand, Price, Ram, OsVersion);
        }

        public override string ToString()
        {
            return base.ToString() + ", RAM: " + Ram
                + "GB, OS: " + OsVersion;
        }
    }
}
