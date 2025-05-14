using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Dto.AboutDtos
{
    

    public class ResultAboutDto
	{


            
            public string AboutID { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string imageURL { get; set; }
        



    }
}

