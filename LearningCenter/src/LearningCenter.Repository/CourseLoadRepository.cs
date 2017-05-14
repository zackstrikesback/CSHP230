using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

//namespace LearningCenter.Repository
//{
//    public interface ICourseLoadRepository
//    {
//        CourseLoadModel Add(int userId, int classId);
//        bool Remove(int userId, int classId);
//        CourseLoadModel[] GetAll(int userId);
//    }

//    public class CourseLoadModel
//    {
//        public int UserId { get; set; }
//        public CourseModel[] Classes { get; set; }
//    }

//    public class CourseLoadRepository : ICourseLoadRepository
//    {
//        public CourseLoadModel Add(int userId, int classId)
//        {
//            var item = DatabaseAccessor.Instance.Users.Include(user.Classes).Add(
//                new LearningCenter.CourseDB.CourseLoadItem { ClassId = classId, UserId = userId });

//            DatabaseAccessor.Instance.SaveChanges();

//            return new CourseLoadModel { UserId = item.UserId, ClassId = item.ClassId };
//        }

//        public CourseLoadModel[] GetAll(int userId)
//        {
//            var items = DatabaseAccessor.Instance.Users
//                .Where(t => t.UserId == userId)
//                .Include(t=> t.Classes)
//                .Select(t => new CourseLoadModel { UserId = t.UserId, Classes = t.Classes.ToArray })
//                .ToArray();
//            return items;
//        }

//        public bool Remove(int userId, int classId)
//        {
//            var items = DatabaseAccessor.Instance.CourseLoadItems
//                                .Where(t => t.UserId == userId && t.ClassId == classId);

//            if (items.Count() == 0)
//            {
//                return false;
//            }

//            DatabaseAccessor.Instance.CourseLoadItems.Remove(items.First());

//            DatabaseAccessor.Instance.SaveChanges();

//            return true;
//        }
//    }
//}
