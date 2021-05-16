using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBInventoryItem
    {
        [BsonElement("Quantity")] public int Quantity { get; set; }
        [BsonElement("Item")] public MDBItem MdbItem { get; set; }

    }
}
