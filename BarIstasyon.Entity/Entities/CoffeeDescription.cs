using System;
namespace BarIstasyon.Entity.Entities
{
	public class CoffeeDescription
	{
        public int CoffeeDescriptionID { get; set; }

        public int CoffeeID { get; set; }

        public Coffee Coffee { get; set; }

        public int Details { get; set; }
    }
}

