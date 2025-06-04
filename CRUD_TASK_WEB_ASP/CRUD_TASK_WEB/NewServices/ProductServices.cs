using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.NewServices.INewServices;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TASK_WEB.NewServices
{
    public class ProductServices : IProductServices
    {
        private readonly ApiContext _Pd;

        public ProductServices( ApiContext Pd)
        {
            _Pd = Pd;

        }

       

        public async Task<Product> GetProduct(int id)
        {
            var product = await _Pd.Products.FindAsync(id);


            return product;
        }

    }
}
