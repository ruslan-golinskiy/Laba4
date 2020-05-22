using Rus_OOP_4._3;
using System;
using System.IO;
namespace Rus_OOP_4._3
{
    public class Schedule
    {
        private int _number;
        private int _dayNumber;
        private string _day;
        private string _subject;
        private string _surename;
        private string _form;

        public int Number
        {
            get => _number;
            set => _number = value;
        }
        public int DayNumber
        {
            get => _dayNumber;
            set => _dayNumber = value;
        }
        public string Day
        {
            get => _day;
            set => _day = value;
        }
        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }
        public string Surename
        {
            get => _surename;
            set => _surename = value;
        }
        public string Form
        {
            get => _form;
            set => _form = value;
        }

        private int DayStrToInt(string str)
        {
            if (str == "Понеділок")
            {

                return 1;
            }

            if (str == "Вівторок")
            {
                return 2;
            }

            if (str == "Неділя")
            {
                return 7;
            }

            if (str == "Понедiлок")
            {
                return 1;
            }

            if (str == "Вiвторок")
            {
                return 2;
            }

            if (str == "Середа")
            {
                return 3;
            }

            if (str == "Четвер")
            {
                return 4;
            }

            if (str == "П'ятниця")
            {
                return 5;
            }

            if (str == "Субота")
            {
                return 6;
            }

            if (str == "Недiля")
            {
                return 7;
            }

            return 0;
        }

        public Schedule()
        {
            Number = 0;
            Day = "Не вказано";
            DayNumber = DayStrToInt(Day);
            Surename = "Не вказано";
            Form = "Не вказано";
        }

        public Schedule(int number)
        {
            Number = number;
            Day = "Не вказано";
            DayNumber = DayStrToInt(Day);
            Surename = "Не вказано";
            Form = "Не вказано";
        }

        public Schedule(int number, string day)
        {
            Number = number;
            Day = day;
            DayNumber = DayStrToInt(Day);
            Surename = "Не вказано";
            Form = "Не вказано";
        }

        public Schedule(int number, string day, string subject)
        {
            Number = number;
            Day = day;
            DayNumber = DayStrToInt(Day);
            Subject = subject;
            Surename = "Не вказано";
            Form = "Не вказано";
        }

        public Schedule(int number, string day, string subject, string surename)
        {
            Number = number;
            Day = day;
            DayNumber = DayStrToInt(Day);
            Subject = subject;
            Surename = surename;
            Form = "Не вказано";
        }

        public Schedule(int number, string day, string subject, string surename, string form)
        {
            Number = number;
            Day = day;
            DayNumber = DayStrToInt(Day);
            Subject = subject;
            Surename = surename;
            Form = form;
        }
    }
}
class Input
{
    public static void Key()
    {
        Work.Parse(Read(), false);

        Console.WriteLine("Додавання записiв: +");
        Console.WriteLine("Редагування записiв: E");
        Console.WriteLine("Знищення записiв: -");
        Console.WriteLine("Виведення записiв: Enter");
        Console.WriteLine("Пошук записiв: F");
        Console.WriteLine("Сортуванн записiв: S");
        Console.WriteLine("Вихiд: Esc");

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.OemPlus:
                Console.WriteLine();
                Work.Add();
                break;

            case ConsoleKey.E:
                Console.WriteLine();
                Work.Edit();
                break;

            case ConsoleKey.OemMinus:
                Console.WriteLine();
                Work.Remove();
                break;

            case ConsoleKey.Enter:
                Console.WriteLine();
                Output.Write(Program.schedule);
                Key();
                break;

            case ConsoleKey.F:
                Console.WriteLine();
                Work.Find();
                break;

            case ConsoleKey.S:
                Console.WriteLine();
                Work.Sort();
                break;

            case ConsoleKey.Escape:
                return;
        }
    }
    public static string[] Read()
    {
        StreamReader fromFile = new StreamReader("base.txt");

        return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
    }
}

class Work
{
    public static void Add()
    {
        Console.WriteLine("Введiть данi");

        string str = Console.ReadLine();

        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Parse(elements, true);

        Input.Key();
    }

    public static void Remove()
    {
        Console.Write("Прiзвище викладача: ");

        string surename = Console.ReadLine();

        bool[] write = new bool[Program.schedule.Length];

        for (int i = 0; i < Program.schedule.Length; ++i)
        {
            if (Program.schedule[i] != null)
            {
                if (Program.schedule[i].Surename == surename)
                {
                    Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.schedule[i].Number, Program.schedule[i].Day, Program.schedule[i].Subject, Program.schedule[i].Surename, Program.schedule[i].Form);

                    Console.WriteLine("Видалити? (Y/N)");

                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Y)
                    {
                        Program.delete[i] = true;
                    }
                    else
                    {
                        Program.delete[i] = false;
                    }
                }
            }
        }
    }

    public static void Edit()
    {
        Console.Write("Прiзвище викладача: ");

        string surename = Console.ReadLine();

        bool[] write = new bool[Program.schedule.Length];

        for (int i = 0; i < Program.schedule.Length; ++i)
        {
            if (Program.schedule[i] != null)
            {
                if (Program.schedule[i].Surename == surename)
                {
                    Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.schedule[i].Number, Program.schedule[i].Day, Program.schedule[i].Subject, Program.schedule[i].Surename, Program.schedule[i].Form);

                    Console.WriteLine("Введiть нову iнформацiю");

                    string str = Console.ReadLine();

                    string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Program.schedule[i] = new Schedule(int.Parse(elements[0]), elements[1], elements[2], elements[3], elements[4]);
                }
            }
        }
    }

    public static void Find()
    {
        Console.Write("Прiзвище викладача: ");

        string surename = Console.ReadLine();

        bool[] write = new bool[Program.schedule.Length];

        for (int i = 0; i < Program.schedule.Length; ++i)
        {
            if (Program.schedule[i] != null)
            {
                if (Program.schedule[i].Surename == surename)
                {
                    write[i] = true;
                }
                else
                {
                    write[i] = false;
                }
            }

        }

        Output.Write(Program.schedule, write);

        Input.Key();
    }

    public static void Sort()
    {
        int index = 0;

        while (Program.schedule[index + 1] != null)
        {
            for (int i = 0; i < Program.schedule.Length - 1; ++i)
            {
                if (Program.schedule[i + 1] != null)
                {
                    if (Program.schedule[i].DayNumber > Program.schedule[i + 1].DayNumber)
                    {
                        string tempStr;
                        int tempInt;

                        tempInt = Program.schedule[i].Number;
                        Program.schedule[i].Number = Program.schedule[i + 1].Number;
                        Program.schedule[i + 1].Number = tempInt;

                        tempInt = Program.schedule[i].DayNumber;
                        Program.schedule[i].DayNumber = Program.schedule[i + 1].DayNumber;
                        Program.schedule[i + 1].DayNumber = tempInt;

                        tempStr = Program.schedule[i].Day;
                        Program.schedule[i].Day = Program.schedule[i + 1].Day;
                        Program.schedule[i + 1].Day = tempStr;

                        tempStr = Program.schedule[i].Subject;
                        Program.schedule[i].Subject = Program.schedule[i + 1].Subject;
                        Program.schedule[i + 1].Subject = tempStr;

                        tempStr = Program.schedule[i].Surename;
                        Program.schedule[i].Surename = Program.schedule[i + 1].Surename;
                        Program.schedule[i + 1].Surename = tempStr;

                        tempStr = Program.schedule[i].Form;
                        Program.schedule[i].Form = Program.schedule[i + 1].Form;
                        Program.schedule[i + 1].Form = tempStr;
                    }
                }
            }

            ++index;
        }

        Output.Write(Program.schedule);

        Input.Key();
    }

    private static void Save(Schedule s)
    {
        StreamWriter save = new StreamWriter("base.txt", true);

        save.WriteLine(s.Number);
        save.WriteLine(s.Day);
        save.WriteLine(s.Subject);
        save.WriteLine(s.Surename);
        save.WriteLine(s.Form);

        save.Close();
    }

    public static void Parse(string[] elements, bool save)
    {
        int counter = 0;

        while (Program.schedule[counter] != null)
        {
            ++counter;
        }

        for (int i = 0; i < elements.Length; i += 5)
        {
            Program.schedule[counter + i / 5] = new Schedule(int.Parse(elements[i]), elements[i + 1], elements[i + 2], elements[i + 3], elements[i + 4]);
            if (save)
            {
                Save(Program.schedule[counter + i / 5]);
            }
        }
    }
}
class Output
{
    public static void Write(Schedule[] s)
    {
        Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", "Номер пари", "День тижня", "Предмет", "Прiзвище викладача", "Форма заняття");

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] != null)
            {
                Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.schedule[i].Number, Program.schedule[i].Day, Program.schedule[i].Subject, Program.schedule[i].Surename, Program.schedule[i].Form);
            }
        }
    }

    public static void Write(Schedule[] s, bool[] write)
    {
        Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", "Номер пари", "День тижня", "Предмет", "Прiзвище викладача", "Форма заняття");

        for (int i = 0; i < s.Length; ++i)
        {
            if ((write[i]) && (!Program.delete[i]))
            {
                Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.schedule[i].Number, Program.schedule[i].Day, Program.schedule[i].Subject, Program.schedule[i].Surename, Program.schedule[i].Form);
            }
        }
    }
}



 


class Program
    {
        public static Schedule[] schedule = new Schedule[100000000];
        public static bool[] delete = new bool[100000000];

        static void Main(string[] args)
        {
            Input.Key();
        }

    }
}
