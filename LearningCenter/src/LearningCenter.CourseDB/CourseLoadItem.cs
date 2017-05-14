using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.CourseDB
{
    public partial class CourseLoadItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public int ClassPrice { get; set; }

        public virtual Class Class { get; set; }
        public virtual User User { get; set; }
    }
}
