using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace gamejoltapi
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

    public class Sessions
    {
        public static string openSession(string game_id, string private_key, string username, string token)
        {
            string url = "sessions/open/?game_id=" + game_id + "&username=" + username + "&user_token=" + token;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }

        public static string closeSession(string game_id, string private_key, string username, string token)
        {
            string url = "sessions/close/?game_id=" + game_id + "&username=" + username + "&user_token=" + token;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }

        public static string pingSession(string game_id, string private_key, string username, string token, string status)
        {
            if (status==""||status==null)
            {
                string surl = "sessions/ping/?game_id=" + game_id + "&username=" + username + "&user_token=" + token;
                string ssignature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + surl + private_key);
                string surls = surl + "&signature=" + ssignature;
                string sresponse = tools.get(surls).Result;
                return sresponse;
            }else
            {
                string url = "sessions/ping/?game_id=" + game_id + "&username=" + username + "&user_token=" + token + "&status=" + status;
                string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
                string urls = url + "&signature=" + signature;
                string response = tools.get(urls).Result;
                return response;
            }
        }

        public static string checkSession(string game_id, string private_key, string username, string token)
        {
            string url = "sessions/check/?game_id=" + game_id + "&username=" + username + "&user_token=" + token;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }
    }

    public class Scores
    {
        public static string addScore(string game_id, string private_key, string score, int sort, int table_id, string extra_data, string guest, string username, string token)
        {
            if (username==null||username=="")
            {
                if (extra_data == null || extra_data == "")
                {
                    string urlu = "scores/add/?game_id=" + game_id + "&guest=" + guest + "&score=" + score + "&sort=" + sort + "&table_id=" + table_id;
                    string signatureu = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + urlu + private_key);
                    string urlsu = urlu + "&signature=" + signatureu;
                    string responseu = tools.get(urlsu).Result;
                    return responseu;
                }else
                {
                    string urlu = "scores/add/?game_id=" + game_id + "&guest=" + guest + "&score=" + score + "&sort=" + sort + "&table_id=" + table_id + "&extra_data=" + extra_data;
                    string signatureu = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + urlu + private_key);
                    string urlsu = urlu + "&signature=" + signatureu;
                    string responseu = tools.get(urlsu).Result;
                    return responseu;
                }
            }else
            {
                if (extra_data==null||extra_data=="")
                {
                    string eurl = "scores/add/?game_id=" + game_id + "&username=" + username + "&user_token=" + token + "&score=" + score + "&sort=" + sort + "&table_id=" + table_id;
                    string esignature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + eurl + private_key);
                    string eurls = eurl + "&signature=" + esignature;
                    string eresponse = tools.get(eurls).Result;
                    return eresponse;
                }
                else
                {
                    string url = "scores/add/?game_id=" + game_id + "&username=" + username + "&user_token=" + token + "&score=" + score + "&sort=" + sort + "&table_id=" + table_id + "&extra_data=" + extra_data;
                    string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
                    string urls = url + "&signature=" + signature;
                    string response = tools.get(urls).Result;
                    return response;
                }
            }
        }
        public static string getRank(string game_id, string private_key, int sort, int table_id)
        {
            string url = "scores/get-rank/?game_id=" + game_id + "&sort=" + sort + "&table_id=" + table_id;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }

        //public static string fetchScore(string game_id,)
        //I have a life ok? https://gamejolt.com/game-api/doc/scores/fetch
        //look at this, this is ridiculous, it would take an entire day to do that! Pls someone do it for me

        public static string getTables(string game_id, string private_key)
        {
            string url = "scores/tables/?game_id=" + game_id;
            string signature = tools.MD5Hash("http://api.gamejolt.com/api/game/v1_2/" + url + private_key);
            string urls = url + "&signature=" + signature;
            string response = tools.get(urls).Result;
            return response;
        }
    }

/*    public class Trophies
    {
        public static string fetchTrophies()
    }*/
}