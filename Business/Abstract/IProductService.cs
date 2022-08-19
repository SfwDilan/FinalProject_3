using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDto>> GetProductDetails();
    
    }

    

}
