using System;
using System.Collections.Generic;

namespace LargeDataSetMvc.Model
{
    public partial class Department
    {
        public Department()
        {
            DeptEmps = new HashSet<DeptEmp>();
            DeptManagers = new HashSet<DeptManager>();
        }

        public string DeptNo { get; set; } = null!;
        public string DeptName { get; set; } = null!;

        public virtual ICollection<DeptEmp> DeptEmps { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
    }
}
