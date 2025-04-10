using System;
namespace BarIstasyon.Entity.Entities
{
	public class Feature
	{
        public int FeatureID { get; set; }

        public string Name { get; set; }

        public List<CoffeeFeature> CoffeeFeatures { get; set; }
    }
}

