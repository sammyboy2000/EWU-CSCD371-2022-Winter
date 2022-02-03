using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        public string GetJoke(HttpClient httpClient)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            return httpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api")).Result;
        }
    }
}
