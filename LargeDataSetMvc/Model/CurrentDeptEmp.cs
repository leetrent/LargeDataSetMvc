using System;
using System.Collections.Generic;

namespace LargeDataSetMvc.Model
{
    public partial class CurrentDeptEmp
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; } = null!;
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
