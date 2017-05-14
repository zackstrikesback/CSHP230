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
        CourseModel GetClass(int id);
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
        public CourseModel GetClass(int id)
        {
            var course = DatabaseAccessor.Instance.Classes
                .FirstOrDefault(t => t.ClassId == id);

            if (course == null)
            {
                return null;
            }

            return new CourseModel { Id = course.ClassId, Name = course.ClassName, Description = course.ClassDescription, Price = course.ClassPrice};
        }
    }

}
