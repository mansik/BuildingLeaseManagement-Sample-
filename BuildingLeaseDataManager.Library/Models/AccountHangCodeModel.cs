﻿using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class AccountHangCodeModel
    {
        public int Id { get; set; }
        public int InOutgoings { get; set; }
        public string AccountHangName { get; set; }
        public int DisplaySeq { get; set; }
        // gridView에서 별도의 코딩없이 체크박스가 나타나도록 하기 위해서 bool형 사용함.
        public bool UseFlag { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
