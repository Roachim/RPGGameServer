using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")] public string Name { get; set; }

        [BsonElement("Password")] public string Password { get; set; }

        [BsonElement("Email")] public string Email { get; set; }

        [BsonElement("Characters")] public List<MDBCharacter> CharacterList { get; set; }

    }
}
