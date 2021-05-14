using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RPGVideoGameLibrary.Models;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBCharacter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")] public string Name { get; set; }

        [BsonElement("Stats")] public MDBStats Stats { get; set; }
        [BsonElement("Inventory")] public MDBInventory Inventory { get; set; }
        [BsonElement("Skills")] public List<MDBSkill> Skills { get; set; }
        [BsonElement("Passives")] public List<MDBPassive> Passives { get; set; }
        [BsonElement("ActiveGear")] public MDBActiveGear ActiveGear { get; set; }
    }
}
