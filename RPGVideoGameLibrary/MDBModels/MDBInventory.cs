using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBInventory
    {
        [BsonElement("Max_Space")] public int MaxSpace { get; set; }
        [BsonElement("Occupied_Space")] public int OccupiedSpace { get; set; }
        [BsonElement("Equipment")] public List<MDBInventoryEquipment> MdbInventoryEquipments { get; set; }
        [BsonElement("Items")] public List<MDBInventoryItem> MdbInventoryItemsList { get; set; }


    }
}
