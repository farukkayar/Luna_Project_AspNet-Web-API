﻿using Luna_Project_AspNet_Web_API.Web.ApiService;
using Luna_Project_AspNet_Web_API.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Web.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly ProductApiService _productApiService;
        public ProductNotFoundFilter(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productApiService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Errors.Add($"There is no such category as id = {id}");

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
