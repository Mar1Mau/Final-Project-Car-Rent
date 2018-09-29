using BOL;
using DAL;
using System;
using System.Linq;


namespace BLL
{
    static public class UserManager
    {
        /// <summary>
        /// SelectAllUsers reads all Users from the DB by the EF ref
        /// and maps the DAL objects to BOL objects
        /// </summary>
        #region static public UserModel[] SelectAllUsers()

        static public UserModel[] SelectAllUsers()
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    return ef.Users.Select(dbUser => new UserModel
                    {
                        FullName = dbUser.FullName,
                        IdCard = dbUser.IdCard,
                        UserName = dbUser.UserName,
                        DoB = dbUser.DoB,
                        IsMale = dbUser.IsMale,
                        EmailAddress = dbUser.EmailAddress,
                        Passwd = dbUser.Passwd,
                        Img = dbUser.Img,
                        Role = new UserRoleModel
                        {
                            RoleID = dbUser.UserRole.RoleID,
                            RoleName = dbUser.UserRole.RoleName
                        }
                    }).ToArray();

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        /// <summary>
        /// SelectUserByName selects a specific User from the DB by the EF ref
        /// by the `userName` parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>returns a specific User Model</returns>
        #region   static public UserModel SelectUserByName(string userName)

        static public UserModel SelectUserByName(string userName)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    User selectedUser = ef.Users.FirstOrDefault(dbUser => dbUser.UserName == userName);
                    if (selectedUser == null)
                        return null;

                    return new UserModel
                    {
                        FullName = selectedUser.FullName,
                        IdCard = selectedUser.IdCard,
                        UserName = selectedUser.UserName,
                        DoB = selectedUser.DoB,
                        IsMale = selectedUser.IsMale,
                        EmailAddress = selectedUser.EmailAddress,
                        Passwd = selectedUser.Passwd,
                        Img = selectedUser.Img,
                        Role = new UserRoleModel
                        {
                            RoleID = selectedUser.UserRole.RoleID,
                            RoleName = selectedUser.UserRole.RoleName
                        }

                    };

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        /// <summary>
        /// GetUser selects a specific User from the DB by the EF ref
        /// by the `name` and `password`parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        #region static public UserModel GetUser(string name, string password)

        static public UserModel GetUser(string name, string password)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    User dbUser = ef.Users.FirstOrDefault(user => user.UserName == name && user.Passwd == password);
                    if (dbUser != null)
                    {
                        UserModel user = new UserModel
                        {
                            FullName = dbUser.FullName,
                            IdCard = dbUser.IdCard,
                            UserName = dbUser.UserName,
                            DoB = dbUser.DoB,
                            IsMale = dbUser.IsMale,
                            EmailAddress = dbUser.EmailAddress,
                            Passwd = dbUser.Passwd,
                            Img = dbUser.Img,
                            Role = new UserRoleModel
                            {
                                RoleID = dbUser.UserRole.RoleID,
                                RoleName = dbUser.UserRole.RoleName
                            }

                        };

                        return user;

                    }

                }
            }
            catch (Exception) { }
            return null;
            
        }
        #endregion


        /// <summary>
        /// InsertUser inserts a new User to the DB by the EF ref
        ///  maps the `newUser` parameter (BOL object) to a `User` (DAL object)
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool InsertUser (UserModel newUser)

        static public bool InsertUser (UserModel newUser)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    UserRole selectedUserRole = ef.UserRoles.FirstOrDefault(dbUserRole => dbUserRole.RoleName == newUser.Role.RoleName);
                    if (selectedUserRole == null)
                        return false;
                    
                    User newDbUser = new User
                    {
                        FullName = newUser.FullName,
                        IdCard = newUser.IdCard,
                        UserName = newUser.UserName,
                        DoB = newUser.DoB,
                        IsMale = newUser.IsMale,
                        EmailAddress = newUser.EmailAddress,
                        Passwd = newUser.Passwd,
                        RoleID = selectedUserRole.RoleID,
                        Img = newUser.Img
                        
                    };

                    ef.Users.Add(newDbUser);
                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// UpdateUserByName updates a specific User from the DB by the EF ref
        /// by the `userName` parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newUser"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool UpdateUserByName(string userName, UserModel newUser)

        static public bool UpdateUserByName(string userName, UserModel newUser)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    User selectedUser = ef.Users.FirstOrDefault(dbUser => dbUser.UserName == userName);
                    if (selectedUser == null)
                        return false;

                    selectedUser.FullName = newUser.FullName;
                    selectedUser.IdCard = newUser.IdCard;
                    selectedUser.UserName = newUser.UserName;
                    selectedUser.DoB = newUser.DoB;
                    selectedUser.IsMale = newUser.IsMale;
                    selectedUser.EmailAddress = newUser.EmailAddress;
                    selectedUser.Passwd = newUser.Passwd;
                    selectedUser.Img = newUser.Img;
                   
                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        /// <summary>
        /// DeleteUserByName delete a specific User from the DB by the EF ref
        /// by the `userName` parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool DeleteUserByName(string userName)

        static public bool DeleteUserByName(string userName)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    User selectedUser = ef.Users.FirstOrDefault(dbUser => dbUser.UserName == userName);
                    if (selectedUser == null)
                        return false;

                    ef.Users.Remove(selectedUser);
                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }

}

