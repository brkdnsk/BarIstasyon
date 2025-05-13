using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Dto.AboutDtos
{
	public class ResultAboutDto
	{

           
           
            public ObjectId AboutID { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string imageURL { get; set; }
        



    }
}

