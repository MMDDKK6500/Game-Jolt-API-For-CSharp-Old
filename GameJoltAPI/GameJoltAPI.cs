using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace GameJoltAPI
{
    public class tools
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> get(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://api.gamejolt.com/api/game/v1_2/" + url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException)
            {
                return "An error has occured!";
            }
        }

        public static string MD5Hash(string input)
        {
            MD5 m = MD5.Create();
            byte[] data = m.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sbuild = new StringBuilder();

            for (int i = 0; i < data.Length; ++i)
                sbuild.Append(data[i].ToString("x2"));

            return sbuild.ToString();

        }
    }

    public class Time
    {
        public static string getTime(string game_id, string private_key)
        {
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/time/?game_id=" + game_id + private_key);
            Console.WriteLine(signature);
            string url = "time/?game_id=" + game_id + "&signature=" + signature;
            string response = tools.get(url).Result;
            return response;
        }
    }

    public class User
    {
        public static string fetchUser(string game_id, string private_key, string username)
        {
            string url = "users/?game_id=" + game_id +"&username=" + username;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }

        public static string authUser(string game_id, string private_key, string username, string token)
        {
            string url = "users/auth/?game_id=" + game_id + "&username=" + username + "&user_token=" + token;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }
    }
}