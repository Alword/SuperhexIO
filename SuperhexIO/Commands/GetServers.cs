using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperhexIO.Commands
{
    public class GetServers
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<string> List()
        {
            HttpResponseMessage response = await client.GetAsync("https://mm.superhex.io/serversv2");
            //HttpResponseMessage response = await client.GetAsync("https://mm.superhex.io/?zone=RU");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GetBestInZone(string zone = "RU") 
        {
            HttpResponseMessage response = await client.GetAsync($"https://mm.superhex.io/?zone={zone}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
