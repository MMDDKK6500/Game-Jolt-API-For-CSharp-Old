using System;
using gamejoltapi;

namespace apitest
{
    class Program
    {
        static void Main(string[] args)
        {
            string game_id = "499308";
            string private_key = "my_private_key";
            string username = "MMDDKK";
            string token = "don't share your token pls";
            //Use this project to test the lib
            //https://gamejolt.com/game-api/doc here you can get every command(Each category is a class)
            Console.WriteLine(User.authUser(game_id, private_key, username, token));
            Console.ReadKey();
        }
    }
}
