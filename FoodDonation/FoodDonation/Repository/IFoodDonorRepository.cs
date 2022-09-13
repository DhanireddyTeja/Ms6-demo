using FoodDonation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonation.Repository
{
    public interface IFoodDonorRepository
    {
        List<FoodDonorModels> Get();
        FoodDonorModels Post(FoodDonorModels fooddonor);
        FoodDonorModels Put(FoodDonorModels fooddonor);
        bool Delete(int employeeId);
    }
}
