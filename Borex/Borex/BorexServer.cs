using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borex
{
    public class BorexServer
    {
        List<Rate> rates = new List<Rate>()
        {
            new Rate (Currencies.USD, 68, 2 ),
            new Rate(Currencies.EUR, 75, -3),
            new Rate(Currencies.CZK, 1.6, -0.2),
            new Rate(Currencies.PLN,11,1)
        };

        public IEnumerable<Rate> Rates
        {
            get

            {
                foreach (var rate in rates)
                    yield return rate;
            }
        }

        public void Exchange (Account account, Currencies from, Currencies to, double amount)
        {
            Console.WriteLine("{0,7:00} transferred from {1,-5} to {2,-5}", amount, from, to);
            account[from] -= amount;
            amount *= Rates.Where(z => z.Currency == from).FirstOrDefault().Cost;
            amount *= 0.95;
            amount /= Rates.Where(z => z.Currency == to).FirstOrDefault().Cost;
            account[to] += amount;
        }
    }
}
