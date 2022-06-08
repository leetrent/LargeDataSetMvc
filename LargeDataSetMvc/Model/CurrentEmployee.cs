using System;
using System.Collections.Generic;

namespace LargeDataSetMvc.Model
{
    public partial class CurrentEmployee
    {
        public int EmpNo { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
