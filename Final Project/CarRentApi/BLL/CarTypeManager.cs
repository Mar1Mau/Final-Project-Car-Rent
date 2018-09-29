using BOL;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    static public class CarTypeManager
    {

        /// <summary>
        /// SelectAllCarTypes reads all the CarTypes from the DB by the EF ref
        /// and maps the DAL objects to BOL objects
        /// </summary>
        #region static public CarTypeModel[] SelectAllCarTypes()

        static public CarTypeModel[] SelectAllCarTypes()
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    return ef.CarTypes.Select(dbCarType => new CarTypeModel
                    {
                        ManufactrName = dbCarType.ManufactrName,
                        Model = dbCarType.Model,
                        DailyCost = dbCarType.DailyCost,
                        OverdueCostDay = dbCarType.OverdueCostDay,
                        ManufactYear = dbCarType.ManufactYear,
                        IsManual = dbCarType.IsManual

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
        /// SelectCarTypeByModel selects a specific CarType from the DB by the EF ref
        /// by the `model` parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>returns a specific CarType Model</returns>
        #region static public CarTypeModel SelectCarTypeByModel(string model)

        static public CarTypeModel SelectCarTypeByModel(string model)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    CarType selectedType = ef.CarTypes.FirstOrDefault(dbType => dbType.Model == model);
                    if (selectedType == null)
                        return null;

                    return new CarTypeModel
                    {
                        ManufactrName = selectedType.ManufactrName,
                        Model = selectedType.Model,
                        DailyCost = selectedType.DailyCost,
                        OverdueCostDay = selectedType.OverdueCostDay,
                        ManufactYear = selectedType.ManufactYear,
                        IsManual = selectedType.IsManual
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
        ///  InsertCarType inserts a new CarType to the DB by the EF ref
        ///  maps the `newCarType` parameter (BOL object) to a `CarType` (DAL object)
        /// </summary>
        /// <param name="newCarType"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region  static public bool InsertCarType(CarTypeModel newCarType)

        static public bool InsertCarType(CarTypeModel newCarType)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    CarType newDbCarType = new CarType
                    {
                        ManufactrName = newCarType.ManufactrName,
                        Model = newCarType.Model,
                        DailyCost = newCarType.DailyCost,
                        OverdueCostDay = newCarType.OverdueCostDay,
                        ManufactYear = newCarType.ManufactYear,
                        IsManual = newCarType.IsManual

                    };

                    ef.CarTypes.Add(newDbCarType);
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
        /// UpdateCarTypeByModel updates a specific CarType from the DB by the EF ref
        /// by the `model` parameter
        /// </summary>
        /// <param name="model"></param>
        /// <param name="newCarType"></param>
        /// <returns>returns bool value - if the action was success</returns>
        #region static public bool UpdateCarTypeByModel(string model, CarTypeModel newCarType)

        static public bool UpdateCarTypeByModel(string model, CarTypeModel newCarType)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    CarType selectedCarType = ef.CarTypes.FirstOrDefault(dbCarType => dbCarType.Model == model);
                    if (selectedCarType == null)
                        return false;

                    selectedCarType.ManufactrName = newCarType.ManufactrName;
                    selectedCarType.Model = newCarType.Model;
                    selectedCarType.DailyCost = newCarType.DailyCost;
                    selectedCarType.OverdueCostDay = newCarType.OverdueCostDay;
                    selectedCarType.ManufactYear = newCarType.ManufactYear;
                    selectedCarType.IsManual = newCarType.IsManual;
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
        /// DeleteCarType delete a specific CarTyp from the DB by the EF ref
        /// by the `model` parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>returns bool value - if the action was success</returns>
         #region static public bool DeleteCarType(string model)

        static public bool DeleteCarType(string model)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {
                    CarType selectedCarType = ef.CarTypes.FirstOrDefault(dbCarType => dbCarType.Model == model);
                    if (selectedCarType == null)
                        return false;
                    ef.CarTypes.Remove(selectedCarType);
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
