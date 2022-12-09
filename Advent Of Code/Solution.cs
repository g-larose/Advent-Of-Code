using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code
{
    public class Solution
    {
        const string InputSuffix = "input";
        private static string session = GetSecretJson();
        public int Day { get; private set; }
        public int Year { get; private set; }
        public string BaseUrl { get; set; }
        public string Input { get; set; }

        public Solution(int year, int day) 
        {
            Day = day;
            Year = year;
            BaseUrl = $"https://adventofcode.com/{Year}/day";
            Input = GetInput(Day);
        }
        private static string GetSecretJson()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "secret.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<Config>(json);

            return configJson!.Secret!;
        }

        string GetInput(int day)
        {
            string cachedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Year}\\Day{day}", "input.txt");

            if (File.Exists(cachedFile)) return File.ReadAllText(cachedFile);
            else
            {
                string contents = "";
                Task.Run(async () =>
                 {
                     var wc = new HttpClient();
                     var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/{day}/{InputSuffix}");
                     wc.DefaultRequestHeaders.Add("User-Agent", Uri.EscapeDataString("https://www.github.com/g-larose"));
                     wc.DefaultRequestHeaders.Add(nameof(HttpRequestHeader.Cookie), $"session={session}");
                     var response = await wc.SendAsync(request);
                     contents = await response.Content.ReadAsStringAsync();
                     if (!File.Exists(cachedFile))
                     {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Year}\\Day{Day}"));
                        
                        File.WriteAllText(cachedFile, contents);
                     }   
                     else
                     {
                         File.WriteAllText(cachedFile, contents);
                     }  
                     
                 }).Wait();

                return contents;
            }
        }
    }
}
