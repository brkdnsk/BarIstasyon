using System;
namespace BarIstasyon.Entity.Entities
{
	public class Pricing
	{
        public int PricingID { get; set; }

        public string Name { get; set; }

        public List<CoffeePricing> CoffeePricings { get; set; }
    }
}

