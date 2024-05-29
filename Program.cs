using System;
using System.Runtime.InteropServices;

namespace CombinedTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Display type information");
                Console.WriteLine("2. Convert centuries to other time units");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        DisplayTypeInfo();
                        break;
                    case "2":
                        ConvertCenturies();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayTypeInfo()
        {
            Console.Clear();
            PrintTypeInfo<sbyte>("sbyte");
            PrintTypeInfo<byte>("byte");
            PrintTypeInfo<short>("short");
            PrintTypeInfo<ushort>("ushort");
            PrintTypeInfo<int>("int");
            PrintTypeInfo<uint>("uint");
            PrintTypeInfo<long>("long");
            PrintTypeInfo<ulong>("ulong");
            PrintTypeInfo<float>("float");
            PrintTypeInfo<double>("double");
            PrintTypeInfo<decimal>("decimal");

            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

        static void PrintTypeInfo<T>(string typeName)
        {
            Console.WriteLine($"{typeName,-10} | {GetSize<T>(),-10} bytes | {GetMinValue<T>(),-30} | {GetMaxValue<T>(),-30}");
        }

        static int GetSize<T>()
        {
            return typeof(T).IsValueType ? Marshal.SizeOf<T>() : throw new InvalidOperationException("Reference types not supported");
        }

        static object GetMinValue<T>()
        {
            return typeof(T).IsValueType ? Activator.CreateInstance<T>() switch
            {
                sbyte _ => sbyte.MinValue,
                byte _ => byte.MinValue,
                short _ => short.MinValue,
                ushort _ => ushort.MinValue,
                int _ => int.MinValue,
                uint _ => uint.MinValue,
                long _ => long.MinValue,
                ulong _ => ulong.MinValue,
                float _ => float.MinValue,
                double _ => double.MinValue,
                decimal _ => decimal.MinValue,
                _ => throw new NotImplementedException()
            } : throw new InvalidOperationException("Reference types not supported");
        }

        static object GetMaxValue<T>()
        {
            return typeof(T).IsValueType ? Activator.CreateInstance<T>() switch
            {
                sbyte _ => sbyte.MaxValue,
                byte _ => byte.MaxValue,
                short _ => short.MaxValue,
                ushort _ => ushort.MaxValue,
                int _ => int.MaxValue,
                uint _ => uint.MaxValue,
                long _ => long.MaxValue,
                ulong _ => ulong.MaxValue,
                float _ => float.MaxValue,
                double _ => double.MaxValue,
                decimal _ => decimal.MaxValue,
                _ => throw new NotImplementedException()
            } : throw new InvalidOperationException("Reference types not supported");
        }

        static void ConvertCenturies()
        {
            Console.Clear();
            Console.Write("Enter number of centuries: ");
            if (int.TryParse(Console.ReadLine(), out int centuries))
            {
                int years = centuries * 100;
                long days = (long)(years * 365.2425); // Using average year length accounting for leap years
                long hours = days * 24;
                long minutes = hours * 60;
                long seconds = minutes * 60;
                long milliseconds = seconds * 1000;
                long microseconds = milliseconds * 1000;
                long nanoseconds = microseconds * 1000;

                Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }
    }
}
