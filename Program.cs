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

        // ---------- Задание 1: ArrayList ----------
        static void Task1()
        {
            Console.WriteLine("=== Task 1: ArrayList ===");

            ArrayList list = new ArrayList();
            Random rnd = new Random();

            // a) 5 случайных целых чисел
            for (int i = 0; i < 5; i++)
            {
                list.Add(rnd.Next(1, 100));
            }

            // b) добавляем строку
            list.Add("Hello");

            // c) удаляем заданный элемент (число, которое стоит вторым)
            object toRemove = list[1];
            list.Remove(toRemove);
            Console.WriteLine("Removed element: " + toRemove);

            // d) количество элементов и сама коллекция
            Console.WriteLine("Count: " + list.Count);
            foreach (object item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // e) поиск заданного значения
            if (list.Contains("Hello"))
                Console.WriteLine("\"Hello\" found at index " + list.IndexOf("Hello"));
            else
                Console.WriteLine("\"Hello\" not found");

            Console.WriteLine();
        }

        // ---------- Задание 2: Queue<int> -> List<int> ----------
        static void Task2()
        {
            Console.WriteLine("=== Task 2: Queue<int> -> List<int> ===");

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);

            // a) вывод коллекции
            Console.WriteLine("Queue:");
            foreach (int x in queue)
                Console.Write(x + " ");
            Console.WriteLine();

            // b) удаляем n = 2 элемента
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("After removing 2 elements:");
            foreach (int x in queue)
                Console.Write(x + " ");
            Console.WriteLine();

            // c) добавляем другие элементы (у Queue один способ добавления - Enqueue)
            queue.Enqueue(70);
            queue.Enqueue(80);
            Console.WriteLine("After adding 70 and 80:");
            foreach (int x in queue)
                Console.Write(x + " ");
            Console.WriteLine();

            // d) вторая коллекция List<int>
            List<int> list = new List<int>();
            foreach (int x in queue)
                list.Add(x);

            // e) вывод второй коллекции
            Console.WriteLine("List:");
            foreach (int x in list)
                Console.Write(x + " ");
            Console.WriteLine();

            // f) поиск значения во второй коллекции
            int search = 50;
            if (list.Contains(search))
                Console.WriteLine(search + " found at index " + list.IndexOf(search));
            else
                Console.WriteLine(search + " not found");

            Console.WriteLine();
        }

        // ---------- Задание 3: Queue<Smartphone> -> List<Smartphone> ----------
        static void PrintPhones(IEnumerable<Smartphone> phones)
        {
            foreach (Smartphone p in phones)
                Console.WriteLine("  " + p);
        }

        static void Task3()
        {
            Console.WriteLine("=== Task 3: Queue<Smartphone> -> List<Smartphone> ===");

            Queue<Smartphone> queue = new Queue<Smartphone>();
            queue.Enqueue(new Smartphone("Apple", 999.99, 6, "iOS"));
            queue.Enqueue(new Smartphone("Samsung", 799.99, 8, "Android"));
            queue.Enqueue(new Smartphone("Xiaomi", 399.99, 12, "Android"));
            queue.Enqueue(new Smartphone("Nokia", 199.99, 4, "Android"));
            queue.Enqueue(new Smartphone("Google", 699.99, 8, "Android"));

            // a) вывод коллекции
            Console.WriteLine("Queue:");
            PrintPhones(queue);

            // b) удаляем 2 элемента
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("After removing 2 elements:");
            PrintPhones(queue);

            // c) добавляем другие элементы
            queue.Enqueue(new Smartphone("Huawei", 599.99, 8, "HarmonyOS"));
            queue.Enqueue(new Smartphone("Sony", 899.99, 12, "Android"));
            Console.WriteLine("After adding 2 elements:");
            PrintPhones(queue);

            // d) вторая коллекция
            List<Smartphone> list = new List<Smartphone>();
            foreach (Smartphone p in queue)
                list.Add(p);

            // e) вывод второй коллекции
            Console.WriteLine("List:");
            PrintPhones(list);

            // f) поиск значения: смартфон с брендом Sony
            Smartphone found = list.Find(p => p.Brand == "Sony");
            if (found != null)
                Console.WriteLine("Found: " + found);
            else
                Console.WriteLine("Not found");

            // IComparable: сортировка по цене
            list.Sort();
            Console.WriteLine("Sorted by price (IComparable):");
            PrintPhones(list);

            // IComparer: сортировка по ОЗУ
            list.Sort(new SmartphoneRamComparer());
            Console.WriteLine("Sorted by RAM (IComparer):");
            PrintPhones(list);

            // ICloneable: копия не зависит от оригинала
            Smartphone original = list[0];
            Smartphone copy = (Smartphone)original.Clone();
            copy.Brand = "Copy";
            copy.Price = 1;
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Copy:     " + copy);

            Console.WriteLine();
        }

        // ---------- Задание 4: ObservableCollection<Smartphone> ----------
        static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed, action: " + e.Action);

            if (e.NewItems != null)
            {
                foreach (Smartphone p in e.NewItems)
                    Console.WriteLine("  added:   " + p);
            }

            if (e.OldItems != null)
            {
                foreach (Smartphone p in e.OldItems)
                    Console.WriteLine("  removed: " + p);
            }
        }

        static void Task4()
        {
            Console.WriteLine("=== Task 4: ObservableCollection<Smartphone> ===");

            ObservableCollection<Smartphone> phones = new ObservableCollection<Smartphone>();
            phones.CollectionChanged += OnCollectionChanged;

            Smartphone apple = new Smartphone("Apple", 999.99, 6, "iOS");
            Smartphone samsung = new Smartphone("Samsung", 799.99, 8, "Android");

            phones.Add(apple);
            phones.Add(samsung);
            phones.Remove(apple);
            phones.RemoveAt(0);

            Console.WriteLine("Count at the end: " + phones.Count);
            Console.WriteLine();
        }
    }
}
