using BOL;
using DAL;
using System;
using System.Linq;


namespace BLL
{
    static public class BranchManager
    {

        /// <summary>
        /// SelectAllBranches reads all the Branches from the DB by the EF ref
        /// and maps the DAL objects to BOL objects
        /// </summary>
        #region static public BranchModel[] SelectAllBranches()


        static public BranchModel[] SelectAllBranches()
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    return ef.Branches.Select(dbBranch => new BranchModel
                    {
                        FullAddress = dbBranch.FullAddress,
                        Latitude = dbBranch.Latitude,
                        Longitude = dbBranch.Longitude,
                        BranchName = dbBranch.BranchName

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
        /// SelectBranchByName selects a specific Branch from the DB by the EF ref
        /// by the `branchName` parameter
        /// </summary>
        /// <param name="branchName">gets the name of Branch</param>
        /// <returns>returns a specific Branch Model</returns>
        #region  static public BranchModel SelectBranchByName(string branchName)

        static public BranchModel SelectBranchByName(string branchName)
        {
            try
            {
                using (CarRentDBEntities ef = new CarRentDBEntities())
                {

                    Branch selectedBranch = ef.Branches.FirstOrDefault(dbBranch => dbBranch.BranchName == branchName);
                    if (selectedBranch == null)
                        return null;

                    return new BranchModel
                    {
                        FullAddress = selectedBranch.FullAddress,
                        Latitude = selectedBranch.Latitude,
                        Longitude = selectedBranch.Longitude,
                        BranchName = selectedBranch.BranchName

                    };

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

    }
}
