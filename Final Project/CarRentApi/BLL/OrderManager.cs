using BOL;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    static public class OrderManager
    {
        /// <summary>
        /// SelectAllOrders reads all Orders from the DB by the EF ref
        /// and maps the DAL objects to BOL objects
        /// </summary>
        #region   static public OrderModel[] SelectAllOrders()

        static public OrderModel[] SelectAllOrders()
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    return ef.Orders.Select(dbOrder => new OrderModel
                    {
                        StartDate = dbOrder.StartDate,
                        ReturnDate = dbOrder.ReturnDate,
                        ActualReturnDate = dbOrder.ActualReturnDate,

                        User = new UserModel
                        {
                            FullName = dbOrder.User.FullName,
                            IdCard = dbOrder.User.IdCard,
                            UserName = dbOrder.User.UserName,
                            DoB = dbOrder.User.DoB,
                            IsMale = dbOrder.User.IsMale,
                            EmailAddress = dbOrder.User.EmailAddress,
                            Passwd = dbOrder.User.Passwd,
                            Img = dbOrder.User.Img,

                            Role = new UserRoleModel
                            {
                                RoleID = dbOrder.User.UserRole.RoleID,
                                RoleName = dbOrder.User.UserRole.RoleName
                            }
                        },
                        Car = new CarModel
                        {
                            CarType = new CarTypeModel
                            {
                                ManufactrName = dbOrder.Car.CarType.ManufactrName,
                                Model = dbOrder.Car.CarType.Model,
                                DailyCost = dbOrder.Car.CarType.DailyCost,
                                OverdueCostDay = dbOrder.Car.CarType.OverdueCostDay,
                                ManufactYear = dbOrder.Car.CarType.ManufactYear,
                                IsManual = dbOrder.Car.CarType.IsManual
                            },
                            CurrentMileage = dbOrder.Car.CurrentMileage,
                            Img = dbOrder.Car.Img,
                            IsProperForRent = dbOrder.Car.IsProperForRent,
                            CarNumber = dbOrder.Car.CarNumber,

                            Branch = new BranchModel
                            {
                                FullAddress = dbOrder.Car.Branch.FullAddress,
                                Latitude = dbOrder.Car.Branch.Latitude,
                                Longitude = dbOrder.Car.Branch.Longitude,
                                BranchName = dbOrder.Car.Branch.BranchName
                            }
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
        /// SelectOrderByCarNumber selects a specific Order from the DB by the EF ref
        /// by the `carNumber` parameter
        /// </summary>
        /// <param name="carNumber"></param>
        /// <returns>returns a specific Order Model</returns>
        #region static public OrderModel SelectOrderByCarNumber(string carNumber)

        static public OrderModel SelectOrderByCarNumber(string carNumber)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    Order selectedOrder = ef.Orders.FirstOrDefault(dbOrder => dbOrder.Car.CarNumber == carNumber);
                    if (selectedOrder == null)
                        return null;

                    
                    return new OrderModel
                    {

                        StartDate = selectedOrder.StartDate,
                        ReturnDate = selectedOrder.ReturnDate,
                        ActualReturnDate = selectedOrder.ActualReturnDate,
                        User = new UserModel
                        {
                            FullName = selectedOrder.User.FullName,
                            IdCard = selectedOrder.User.IdCard,
                            UserName = selectedOrder.User.UserName,
                            DoB = selectedOrder.User.DoB,
                            IsMale = selectedOrder.User.IsMale,
                            EmailAddress = selectedOrder.User.EmailAddress,
                            Passwd = selectedOrder.User.Passwd,
                            Img = selectedOrder.User.Img,

                            Role = new UserRoleModel
                            {
                                RoleID = selectedOrder.User.UserRole.RoleID,
                                RoleName = selectedOrder.User.UserRole.RoleName
                            }
                        },

                        Car = new CarModel
                        {
                            CarType = new CarTypeModel
                            {
                                ManufactrName = selectedOrder.Car.CarType.ManufactrName,
                                Model = selectedOrder.Car.CarType.Model,
                                DailyCost = selectedOrder.Car.CarType.DailyCost,
                                OverdueCostDay = selectedOrder.Car.CarType.OverdueCostDay,
                                ManufactYear = selectedOrder.Car.CarType.ManufactYear,
                                IsManual = selectedOrder.Car.CarType.IsManual
                            },
                            CurrentMileage = selectedOrder.Car.CurrentMileage,
                            Img = selectedOrder.Car.Img,
                            IsProperForRent = selectedOrder.Car.IsProperForRent,
                            CarNumber = selectedOrder.Car.CarNumber,

                            Branch = new BranchModel
                            {
                                FullAddress = selectedOrder.Car.Branch.FullAddress,
                                Latitude = selectedOrder.Car.Branch.Latitude,
                                Longitude = selectedOrder.Car.Branch.Longitude,
                                BranchName = selectedOrder.Car.Branch.BranchName
                            }
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
        /// InsertOrder inserts a new Order to the DB by the EF ref
        ///  maps the `newOrder` parameter (BOL object) to a `Order` (DAL object)
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region  static public bool InsertOrder(OrderModel newOrder)
            
        static public bool InsertOrder(OrderModel newOrder)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    User selectedUser = ef.Users.FirstOrDefault(dbUser => dbUser.FullName == newOrder.User.FullName);
                    if (selectedUser == null)
                        return false;

                    Car selectedCar = ef.Cars.FirstOrDefault(dbCar => dbCar.CarNumber == newOrder.Car.CarNumber);
                    if (selectedUser == null)
                        return false;

                    Order newDbOrder = new Order
                    {
                        StartDate = newOrder.StartDate,
                        ReturnDate = newOrder.ReturnDate,
                        ActualReturnDate = newOrder.ActualReturnDate,
                        UserID = selectedUser.UserID,
                        CarID = selectedCar.CarID
                    };

                    ef.Orders.Add(newDbOrder);
                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        #endregion


        /// <summary>
        /// UpdateOrderByCarNumber updates a specific Order from the DB by the EF ref
        /// by the `carNumber` parameter
        /// </summary>
        /// <param name="carNumber"></param>
        /// <param name="newOrder"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region  static public bool UpdateOrderByCarNumber(string carNumber, OrderModel newOrder)

        static public bool UpdateOrderByCarNumber(string carNumber, OrderModel newOrder)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    Order selectedOrder = ef.Orders.FirstOrDefault(dbOrder => dbOrder.Car.CarNumber == carNumber);
                    if (selectedOrder == null)
                        return false;

                    selectedOrder.StartDate = newOrder.StartDate;
                    selectedOrder.ReturnDate = newOrder.ReturnDate;
                    selectedOrder.ActualReturnDate = newOrder.ActualReturnDate;

                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        #endregion


        /// <summary>
        /// DeleteOrderByDate delete a specific Order from the DB by the EF ref
        /// by the `carNumber` parameter
        /// </summary>
        /// <param name="carNumber"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool DeleteOrderByDate(string carNumber)

        static public bool DeleteOrderByDate(string carNumber)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    Order selectedOrder = ef.Orders.FirstOrDefault(dbOrder => dbOrder.Car.CarNumber == carNumber);
                    if (selectedOrder == null)
                        return false;

                    ef.Orders.Remove(selectedOrder);
                    ef.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        #endregion

    }
}
