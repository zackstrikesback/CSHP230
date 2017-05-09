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
        CourseModel[] Courses { get; }
        CourseModel Course(int courseId);
    }
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourseModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class CourseManager
    {
        private readonly ICourseRepository courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseModel[] All
        {
            get
            {
                return courseRepository.Courses.Select(t => new CourseModel(t.Id, t.Name)).ToArray();
            }
        }
        public CourseModel Course(int classId)
        {
            var courseModel = courseRepository.Course(classId);
            return new CourseModel(courseModel.Id, courseModel.Name);
        }
    }
}
