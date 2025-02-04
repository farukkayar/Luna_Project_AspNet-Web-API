﻿using Luna_Project_AspNet_Web_API.Core.Models;
using Luna_Project_AspNet_Web_API.Core.Repositories;
using Luna_Project_AspNet_Web_API.Core.Services;
using Luna_Project_AspNet_Web_API.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
