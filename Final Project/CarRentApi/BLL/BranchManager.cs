﻿using BOL;
using DAL;
using System;
using System.Linq;


namespace BLL
{
    static public class BranchManager
    {
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



    }
}