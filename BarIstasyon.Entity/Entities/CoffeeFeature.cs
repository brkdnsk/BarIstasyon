using System;
namespace BarIstasyon.Entity.Entities
{
	public class CoffeeFeature
	{
        public string CoffeeFeatureID { get; set; }

        public int CoffeeID { get; set; }

        public Coffee Coffee { get; set; }

        public Feature Feature { get; set; }

        public int FeatureID { get; set; }

        public bool Avaliable { get; set; }
    }
}

