using System;
namespace BarIstasyon.Entity.Entities
{
	public class Base
	{
        public string BaseID { get; set; }

        public string Name { get; set; }

        public List<Coffee> Coffees { get; set; }
    }
}

