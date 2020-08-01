using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Demo
    {
        public string Test01()
        {
            Thread.Sleep(2000);
            return "AAA";
        }

        public async Task<string> Test01Async()
        {
            await Task.Delay(2000);
            return "AAA";
        }

        public int Test02()
        {
            Thread.Sleep(3000);
            return new Random().Next();
        }
        public async Task02<string> Test02Async()
        {
            await Task.Delay(3000);
            return new Random().Next();
        }

        public string Test03()
        {
            Thread.Sleep(5000);
            return new Random().Next();
        }
    }
}
