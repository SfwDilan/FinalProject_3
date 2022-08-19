using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //AutoFac, Ninject , CastleWindsor, StructureMap, LightInject, DryInject --> IOC Conteiner olmadan önce onunla ayný iþi yapýyorlardý.
            //IOC Container den daha iyi bir yapý ise AOP 'dir. Bunu da .Net Projemize AutoFac'i enjecte ederek AOP'yi kullanýyor olucaz. 

            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();  //Eðer içinde data yoksa singleton kullanýrýz.
            services.AddSingleton<IProductDal, EfProductDal>();
            
            //Singleton: Ne kadar client gelirse gelsin(1 milyon vs..) hepsine ayný instance'i veriyor.Hepsi ayný referansý kullanýr.1 milyon instance almaktan kurtulmuþ oluyoruz.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
