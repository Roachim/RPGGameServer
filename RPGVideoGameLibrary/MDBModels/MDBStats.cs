using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBStats
    {
        [BsonElement("Hp")] public int HP { get; set; }
        [BsonElement("Atk")] public int Atk { get; set; }
        [BsonElement("Def")] public int Def { get; set; }
    }
}
