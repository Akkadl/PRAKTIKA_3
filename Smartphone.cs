using System;
using System.Collections.Generic;

namespace MobileDevices
{
    // IComparable - сравнение смартфонов по цене
    // ICloneable  - глубокое копирование
    public class Smartphone : MobileDevice, IComparable<Smartphone>, ICloneable
    {
        private int _ram;
        private string _osVersion;

        public int Ram
        {
            get => _ram;
            set => _ram = value > 0 ? value : 0;
        }

        public string OsVersion
        {
            get => _osVersion;
            set => _osVersion = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public Smartphone() : this("Unknown", 0.0, 0, "Unknown") { }

        public Smartphone(string brand, double price, int ram, string osVersion)
            : base(brand, price)
        {
            Ram = ram;
            OsVersion = osVersion;
        }

        public int CompareTo(Smartphone other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            // Все поля - числа и неизменяемые строки, поэтому создаем новый объект с теми же значениями
            return new Smartphone(Brand, Price, Ram, OsVersion);
        }

        public override string ToString()
        {
            return base.ToString() + $", RAM: {Ram}GB, OS: {OsVersion}";
        }
    }

    // IComparer - сравнение смартфонов по объему ОЗУ
    public class SmartphoneRamComparer : IComparer<Smartphone>
    {
        public int Compare(Smartphone x, Smartphone y)
        {
            return x.Ram.CompareTo(y.Ram);
        }
    }
}
