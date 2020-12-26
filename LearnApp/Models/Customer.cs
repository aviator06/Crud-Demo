using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnApp.Models
{
    public class Customer
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string CustomerId { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }
 
        public string DOB { get; set; }

            public string City { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            public Customer getValue { get; set; }
        
    }
}
