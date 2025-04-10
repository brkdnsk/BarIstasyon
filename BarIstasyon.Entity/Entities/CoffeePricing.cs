using System;
namespace BarIstasyon.Entity.Entities
{
	public class CoffeePricing
	{
        public int CoffeePricingID { get; set; }

        public int CoffeeID { get; set; }

        public Coffee Coffee { get; set; }
    }
}

