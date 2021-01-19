using System;
using GameJoltAPI;

namespace apitest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Time.getTime("499308", "4adc3e1c1df4fe3581cbe114b58633fe"));
            Console.WriteLine(User.fetchUser("499308", "4adc3e1c1df4fe3581cbe114b58633fe", "MMDDKK"));
            Console.ReadKey();
        }
    }
}
