using System;
using System.Collections.Generic;

namespace LargeDataSetMvc.Model
{
    public partial class DeptEmpLatestDate
    {
        public int EmpNo { get; set; }
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
