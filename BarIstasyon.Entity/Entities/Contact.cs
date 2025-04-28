using System;
namespace BarIstasyon.Entity.Entities
{
	public class Contact
	{
        public string ContactID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime SendDate { get; set; }
    }
}

