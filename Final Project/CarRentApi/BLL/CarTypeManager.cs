using BOL;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    static public class CarTypeManager
    {
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

    }
}
