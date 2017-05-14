using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
        UserModel GetUser(int id);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                                      && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var check = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower());
            if (check != null)
            {
                return null;
            }

            var user = DatabaseAccessor.Instance.Users
                    .Add(new LearningCenter.CourseDB.User { UserEmail = email, UserPassword = password });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel GetUser(int id)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        //public AddClass(int UserId, int CourseId)
        //{
        //    var user = UserRepository.GetUser(UserId);

        //    // Get the Class object from the database

        //    var classToAdd = CourseRepository.GetClass(CourseId);

        //    // Use entity framework to add classes to the user

        //    user.Classes.Add(classToAdd);

        //    // Save the changes to database

        //    DatabaseAccessor.Instance.SaveChanges();
        //}
    }
}
