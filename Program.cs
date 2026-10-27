using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MobileDevices
{
    class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PrintInts(IEnumerable<int> numbers)
        {
            foreach (int x in numbers)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        static void PrintPhones(
            IEnumerable<Smartphone> phones)
        {
            foreach (Smartphone p in phones)
            {
                Console.WriteLine("  " + p);
            }
        }

        // Задание 1: ArrayList
        static void Task1()
        {
            Console.WriteLine("=== Task 1: ArrayList ===");

            ArrayList list = new ArrayList();
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                list.Add(rnd.Next(1, 100));
            }
            list.Add("Hello");

            object removed = list[1];
            list.Remove(removed);
            Console.WriteLine("Removed: " + removed);

            Console.WriteLine("Count: " + list.Count);
            foreach (object item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int index = list.IndexOf("Hello");
            if (index >= 0)
            {
                Console.WriteLine("Hello index: " + index);
            }
            else
            {
                Console.WriteLine("Hello not found");
            }
            Console.WriteLine();
        }

        // Задание 2: Queue<int> -> List<int>
        static void Task2()
        {
            Console.WriteLine("=== Task 2: Queue<int> ===");

            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= 6; i++)
            {
                queue.Enqueue(i * 10);
            }
            Console.WriteLine("Queue:");
            PrintInts(queue);

            int n = 2;
            for (int i = 0; i < n; i++)
            {
                queue.Dequeue();
            }
            Console.WriteLine("Removed " + n + " items:");
            PrintInts(queue);

            // У очереди один способ добавления - Enqueue
            queue.Enqueue(70);
            queue.Enqueue(80);
            Console.WriteLine("After adding 70 and 80:");
            PrintInts(queue);

            List<int> list = new List<int>();
            foreach (int x in queue)
            {
                list.Add(x);
            }
            Console.WriteLine("List:");
            PrintInts(list);

            int value = 50;
            int index = list.IndexOf(value);
            if (index >= 0)
            {
                Console.WriteLine(value + " index " + index);
            }
            else
            {
                Console.WriteLine(value + " not found");
            }
            Console.WriteLine();
        }

        static Smartphone FindByBrand(List<Smartphone> phones,
            string brand)
        {
            foreach (Smartphone p in phones)
            {
                if (p.Brand == brand)
                {
                    return p;
                }
            }
            return null;
        }

        // Задание 3: Queue<Smartphone> -> List<Smartphone>
        static void Task3()
        {
            Console.WriteLine("=== Task 3: Smartphone ===");

            Queue<Smartphone> queue = new Queue<Smartphone>();
            queue.Enqueue(new Smartphone(
                "Apple", 999.99, 6, "iOS"));
            queue.Enqueue(new Smartphone(
                "Samsung", 799.99, 8, "Android"));
            queue.Enqueue(new Smartphone(
                "Xiaomi", 399.99, 12, "Android"));
            queue.Enqueue(new Smartphone(
                "Nokia", 199.99, 4, "Android"));
            queue.Enqueue(new Smartphone(
                "Google", 699.99, 8, "Android"));
            Console.WriteLine("Queue:");
            PrintPhones(queue);

            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("After removing 2 items:");
            PrintPhones(queue);

            queue.Enqueue(new Smartphone(
                "Huawei", 599.99, 8, "HarmonyOS"));
            queue.Enqueue(new Smartphone(
                "Sony", 899.99, 12, "Android"));
            Console.WriteLine("After adding 2 items:");
            PrintPhones(queue);

            List<Smartphone> list = new List<Smartphone>();
            foreach (Smartphone p in queue)
            {
                list.Add(p);
            }
            Console.WriteLine("List:");
            PrintPhones(list);

            Smartphone found = FindByBrand(list, "Sony");
            if (found != null)
            {
                Console.WriteLine("Found: " + found);
            }
            else
            {
                Console.WriteLine("Sony not found");
            }

            list.Sort();
            Console.WriteLine("By price (IComparable):");
            PrintPhones(list);

            list.Sort(new SmartphoneRamComparer());
            Console.WriteLine("By RAM (IComparer):");
            PrintPhones(list);

            Smartphone original = list[0];
            Smartphone copy = (Smartphone)original.Clone();
            copy.Brand = "Copy";
            copy.Price = 1;
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Copy:     " + copy);
            Console.WriteLine();
        }

        // Обработчик события CollectionChanged
        static void OnPhonesChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Changed: " + e.Action);
            if (e.NewItems != null)
            {
                foreach (Smartphone p in e.NewItems)
                {
                    Console.WriteLine("  added:   " + p);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Smartphone p in e.OldItems)
                {
                    Console.WriteLine("  removed: " + p);
                }
            }
        }

        // Задание 4: ObservableCollection<Smartphone>
        static void Task4()
        {
            Console.WriteLine("=== Task 4: Observable ===");

            ObservableCollection<Smartphone> phones =
                new ObservableCollection<Smartphone>();
            phones.CollectionChanged += OnPhonesChanged;

            Smartphone apple = new Smartphone(
                "Apple", 999.99, 6, "iOS");
            Smartphone samsung = new Smartphone(
                "Samsung", 799.99, 8, "Android");

            phones.Add(apple);
            phones.Add(samsung);
            phones.Remove(apple);
            phones.RemoveAt(0);

            Console.WriteLine("Final count: " + phones.Count);
            Console.WriteLine();
        }
    }
}
