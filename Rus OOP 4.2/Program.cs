using System;

namespace Rus_OOP_4._2
{
    public class University
    {


        public string LastName;
        public DateTime data;
        public string city;

        public University(string LastName, DateTime data, string city)
        {
            this.LastName = LastName;
            this.data = data;
            this.city = city;
        }

    }
    class Program
    {
        static void Swap(ref University x, ref University y)
        {
            var t = x;
            x = y;
            y = t;
        }

       
        static int Partition(University[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].data < array[maxIndex].data)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static University[] QuickSort(University[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static University[] QuickSort(University[] array)
        {
            
            return QuickSort(array, 0, array.Length - 1);
        }
        static void Main(string[] args)
        {

            Console.Write("Введіть кількість Студентів: ");
            int n = int.Parse(Console.ReadLine());
            University[] b = new University[n];
            DateTime[] d = new DateTime[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Студент №" + (i + 1));

                Console.Write("прізвище: ");
                string LastName = Console.ReadLine();
                Console.Write("дата народження: ");
                string demotime = Console.ReadLine();
                DateTime data = Convert.ToDateTime(demotime);
               
                Console.Write(" Місце народження: ");
                string city = Console.ReadLine();


                b[i] = new University(LastName, data, city);
                d[i] = b[i].data;
                
            }

           
               
            University[] b1 = new University[n];
            Console.WriteLine("Прізвище\t\tДата народження\t\tМісце народження");
            for(int i = 0; i < n; i++)
            {
                b1= QuickSort(b);
                Console.WriteLine("{0}\t\t{1}\t\t{2}", b1[i].LastName, b1[i].data.ToString("dd.MM.yyyy"), b1[i].city);
            }
             



            
        }
    }
}
