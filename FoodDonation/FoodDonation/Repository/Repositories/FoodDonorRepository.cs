using FoodDonation.DataAccess;
using FoodDonation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonation.Repository.Repositories
{
   
        public class FoodDonorRepository : IFoodDonorRepository
        {
            private readonly FoodDonorDbContext _context;
            public FoodDonorRepository(FoodDonorDbContext context)
            {
                _context = context;
            }
            public List<FoodDonorModels> Get()
            {
                var list = _context.fooddonor.ToList();
                return list;
            }

            public FoodDonorModels Post(FoodDonorModels model)
            {
                _context.fooddonor.AddAsync(model);
                _context.SaveChangesAsync();
                return model;
            }

            public FoodDonorModels Put(FoodDonorModels model)
            {
                var fooddonorsToEdit = _context.fooddonor.Where(x => x.Id == model.Id).FirstOrDefault();
                fooddonorsToEdit.Number = model.Number;
                fooddonorsToEdit.Name = model.Name;
                fooddonorsToEdit.Location = model.Location;

                _context.SaveChanges();
                return fooddonorsToEdit;
            }


            public bool Delete(int id)
            {
                var employees = _context.fooddonor.Where(x => x.Id == id).FirstOrDefault();
                _context.fooddonor.Remove(employees);
                _context.SaveChanges();

                return true;
            }

/*List<FoodDonorModels> IFoodDonorRepository.Get()
            {
                throw new NotImplementedException();
            }

            public FoodDonorModels Post(FoodDonorModels fooddonor)
            {
                throw new NotImplementedException();
            }

            public FoodDonorModels Put(FoodDonorModels fooddonor)
            {
                throw new NotImplementedException();
            }*/
        }
}
