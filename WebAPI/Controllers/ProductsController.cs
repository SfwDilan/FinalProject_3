using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //constructur injection yapıldı
        //loose coupled :Gevşek bağlılık ,bağımlılık

        IProductService _productService;    //field'ların defaultu privatedir. Yani bu privatedir.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //Yukarıdaki Constructur injectionda hangi managerda çalıştığını bilmiyor..birden fazla manager da olabilir.
        //Bunun için WebAPI>Startup.cs altında ConfigureServices metodunda Singleton ile ,Controller IProductService'e bağımlılık isterse onun karşılığını ProdeuctMAnager olarak arka planda new'lenmiş olarak veriyoruz zaten.
        //İşte bu yapıya yani Singleton ile oluşturulan bu sisteme --IOC Container-- diyoruz.
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result=_productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
