using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.CourseDB;
using System.Data;
using System.Data.Entity;

namespace LearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly CourseDbEntities entities;

        static DatabaseAccessor()
        {
            entities = new CourseDbEntities();
            entities.Database.Connection.Open();
        }

        public static CourseDbEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
