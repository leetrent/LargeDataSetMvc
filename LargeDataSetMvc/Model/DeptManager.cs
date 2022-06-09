using System;
using System.Collections.Generic;

namespace LargeDataSetMvc.Model
{
    public partial class DeptManager
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; } = null!;
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }

        public virtual Department DeptNoNavigation { get; set; } = null!;
        public virtual Employee EmpNoNavigation { get; set; } = null!;
    }
}
