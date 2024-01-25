using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class GradeTypeModel
    {
        public int Id { get; set; }
        public string GradeTypeName { get; set; }
        public int DisplaySeq { get; set; }
        public byte UserFlag { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
