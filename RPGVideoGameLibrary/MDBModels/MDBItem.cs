using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("Type")] public short Type { get; set; }
        [BsonElement("Description")] public string Description { get; set; }
        [BsonElement("Effect")] public string Effect { get; set; }
    }
}
