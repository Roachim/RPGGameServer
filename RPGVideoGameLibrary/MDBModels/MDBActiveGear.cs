using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace RPGVideoGameLibrary.MDBModels
{
    public class MDBActiveGear
    {
        [BsonElement("Head")] public MDBEquipment Head { get; set; }

        [BsonElement("Chest")] public MDBEquipment Chest { get; set; }

        [BsonElement("Hands")] public MDBEquipment Hands { get; set; }

        [BsonElement("Legs")] public MDBEquipment Legs { get; set; }

        [BsonElement("Feet")] public MDBEquipment Feet { get; set; }

        [BsonElement("Left_Hand")] public MDBEquipment LeftHand { get; set; }

        [BsonElement("Right_Hand")] public MDBEquipment RightHand { get; set; }

    }
}
