using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleBasketManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeBasketSync objsync = new ConsumeBasketSync();
            objsync.GetAllBaskets();
            objsync.GetCustBasket(1);
            //objsync.ClearBasketsForCust(1);

            ConsumeBasketAsync objasync = new ConsumeBasketAsync();
            //objasync.AddItemToBasket(1);

            
        }
    }
}
