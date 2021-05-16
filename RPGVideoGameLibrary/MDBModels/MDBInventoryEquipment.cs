using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBInventoryEquipment
    {
        [BsonElement("Quantity")] public int Quantity { get; set; }
        [BsonElement("EquipmentPiece")] public MDBEquipment MdbEquipment { get; set; }

    }
}
