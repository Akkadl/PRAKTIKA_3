using System.Collections.Generic;

namespace MobileDevices
{
    // IComparer - сравнение смартфонов по объему ОЗУ
    public class SmartphoneRamComparer : IComparer<Smartphone>
    {
        public int Compare(Smartphone x, Smartphone y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.Ram.CompareTo(y.Ram);
        }
    }
}
