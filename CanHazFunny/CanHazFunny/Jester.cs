using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    internal class Jester : IJokeService, IOutput
    {
        HttpClient IJokeService.HttpClient => throw new NotImplementedException();
    }
}
