using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface ICourseManager
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

    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseModel[] GetAll()
        {
            return courseRepository.GetAll().Select(t =>
                            new CourseModel
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Description = t.Description,
                                Price = t.Price
                            })
                            .ToArray();
        }
        public CourseModel GetClass(int id)
        {
            var course = courseRepository.GetClass(id);
            return new CourseModel { Id = course.Id, Name = course.Name, Description = course.Description, Price = course.Price };
        }
    }
}
