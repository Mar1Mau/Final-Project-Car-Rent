using BOL;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    static public class CarManager
    {

        /// <summary>
        /// SelectAllCars reads all the Cars from the DB by the EF ref
        /// and maps the DAL objects to BOL objects
        /// </summary>
         #region static public CarModel[] SelectAllCars()

        static public CarModel[] SelectAllCars()
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    return ef.Cars.Select(dbCar => new CarModel
                    {
                        CarType = new CarTypeModel
                        {
                            ManufactrName = dbCar.CarType.ManufactrName,
                            Model = dbCar.CarType.Model,
                            DailyCost = dbCar.CarType.DailyCost,
                            OverdueCostDay = dbCar.CarType.OverdueCostDay,
                            ManufactYear = dbCar.CarType.ManufactYear,
                            IsManual = dbCar.CarType.IsManual
                        },

                        CurrentMileage = dbCar.CurrentMileage,
                        Img = dbCar.Img,
                        IsProperForRent = dbCar.IsProperForRent,
                        CarNumber = dbCar.CarNumber,

                        Branch = new BranchModel
                        {
                            FullAddress = dbCar.Branch.FullAddress,
                            Latitude = dbCar.Branch.Latitude,
                            Longitude = dbCar.Branch.Longitude,
                            BranchName = dbCar.Branch.BranchName
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
        /// SelectCarByCarNumber selects a specific Car from the DB by the EF ref
        /// by the `carNumber` parameter
        /// </summary>
        /// <param name="carNumber">gets the number of Car</param>
        /// <returns>returns a specific Car Model</returns>
        #region static public CarModel SelectCarByCarNumber(string carNumber)

        static public CarModel SelectCarByCarNumber(string carNumber)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    Car selectedCar = ef.Cars.FirstOrDefault(dbCar => dbCar.CarNumber == carNumber);
                    if (selectedCar == null)
                        return null;

                    return new CarModel
                    {
                        CarType = new CarTypeModel
                        {
                            ManufactrName = selectedCar.CarType.ManufactrName,
                            Model = selectedCar.CarType.Model,
                            DailyCost = selectedCar.CarType.DailyCost,
                            OverdueCostDay = selectedCar.CarType.OverdueCostDay,
                            ManufactYear = selectedCar.CarType.ManufactYear,
                            IsManual = selectedCar.CarType.IsManual
                        },

                        CurrentMileage = selectedCar.CurrentMileage,
                        Img = selectedCar.Img,
                        IsProperForRent = selectedCar.IsProperForRent,
                        CarNumber = selectedCar.CarNumber,

                        Branch = new BranchModel
                        {
                            FullAddress = selectedCar.Branch.FullAddress,
                            Latitude = selectedCar.Branch.Latitude,
                            Longitude = selectedCar.Branch.Longitude,
                            BranchName = selectedCar.Branch.BranchName
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
        /// InsertCar inserts a new Car to the DB by the EF ref
        /// maps the `newCar` parameter (BOL object) to a `Car` (DAL object)
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool InsertCar(CarModel newCar)


        static public bool InsertCar(CarModel newCar)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    CarType selectedCarType = ef.CarTypes.FirstOrDefault(dbCarType => dbCarType.Model == newCar.CarType.Model);
                    if (selectedCarType == null)
                        return false;

                    Branch selectedBranch = ef.Branches.FirstOrDefault(dbBranch => dbBranch.BranchName == newCar.Branch.BranchName);
                    if (selectedBranch == null)
                        return false;

                    Car newDbCar = new Car
                    {
                        CarTypeID = selectedCarType.CarTypeID,
                        CurrentMileage = newCar.CurrentMileage,
                        Img = newCar.Img,
                        IsProperForRent = newCar.IsProperForRent,
                        CarNumber = newCar.CarNumber,
                        BranchID = selectedBranch.BranchID
                    };

                    ef.Cars.Add(newDbCar);
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
        /// UpdateCarByCarNumber updates a specific Car from the DB by the EF ref
        /// by the `authorName` parameter
        /// </summary>
        /// <param name="carNumber"></param>
        /// <param name="newCar"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool UpdateCarByCarNumber(string carNumber, CarModel newCar)


        static public bool UpdateCarByCarNumber(string carNumber, CarModel newCar)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    Car selectedCar = ef.Cars.FirstOrDefault(dbCar => dbCar.CarNumber == carNumber);
                    if (selectedCar == null)
                        return false;


                    selectedCar.CurrentMileage = newCar.CurrentMileage;
                    selectedCar.Img = newCar.Img;
                    selectedCar.IsProperForRent = newCar.IsProperForRent;
                    selectedCar.CarNumber = newCar.CarNumber;
                    
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
        /// DeleteCarByCarNumber delete a specific Car from the DB by the EF ref
        /// by the `carNumber` parameter
        /// </summary>
        /// <param name="carNumber"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region  static public bool DeleteCarByCarNumber(string carNumber)


        static public bool DeleteCarByCarNumber(string carNumber)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    Car selectedCar = ef.Cars.FirstOrDefault(dbCar => dbCar.CarNumber == carNumber);
                    if (selectedCar == null)
                        return false;

                    ef.Cars.Remove(selectedCar);
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
