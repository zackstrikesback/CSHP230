using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface ICourseRepository
    {
        CourseModel[] GetAll();
    }

    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CourseRepository : ICourseRepository
    {
        public CourseModel[] GetAll()
        {
            return DatabaseAccessor.Instance.Classes.Select(t =>
                                        new CourseModel
                                        {
                                            Id = t.ClassId,
                                            Name = t.ClassName,
                                            Description = t.ClassDescription,
                                            Price = t.ClassPrice
                                        })
            .ToArray();
        }
    }

}
