using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Northwind.Bll;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.EntityFramework.Context;
using Northwind.Dal.Concrete.EntityFramework.Repository;
using Northwind.Dal.Concrete.EntityFramework.UnitOfWork;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WebAPI
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
            #region JwtTokenService
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;

                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    RoleClaimType = "Roles",
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Audience"],
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            #endregion

            #region AppContext
            //services.AddDbContext<NORTHWNDContext>();
            //services.AddScoped<DbContext, NORTHWNDContext>();
            services.AddScoped<DbContext, NORTHWNDContext>();
            services.AddDbContext<NORTHWNDContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConStr"), sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly("Northwind.Dal");
                }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            #endregion

            #region ServiceSection
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAlphabeticalListOfProductService, AlphabeticalListOfProductService>();
            services.AddScoped<ICategorySalesFor1997Service, CategorySalesFor1997Service>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICurrentProductListService, CurrentProductListService>();
            services.AddScoped<ICustomerAndSuppliersByCityService, CustomerAndSuppliersByCityService>();
            services.AddScoped<ICustomerCustomerDemoService, CustomerCustomerDemoService>();
            services.AddScoped<ICustomerDemographicService, CustomerDemographicService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeTerritoryService, EmployeeTerritoryService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailsExtendedService, OrderDetailsExtendedService>();
            services.AddScoped<IOrdersQryService, OrdersQryService>();
            services.AddScoped<IOrderSubtotalService, OrderSubtotalService>();
            services.AddScoped<IProductsAboveAveragePriceService, ProductsAboveAveragePriceService>();
            services.AddScoped<IProductSalesFor1997Service, ProductSalesFor1997Service>();
            services.AddScoped<IProductsByCategoryService, ProductsByCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IQuarterlyOrderService, QuarterlyOrderService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ISalesByCategoryService, SalesByCategoryService>();
            services.AddScoped<ISalesTotalsByAmountService, SalesTotalsByAmountService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<ISummaryOfSalesByQuarterService, SummaryOfSalesByQuarterService>();
            services.AddScoped<ISummaryOfSalesByYearService, SummaryOfSalesByYearService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ITerritoryService, TerritoryService>();
            #endregion

            #region RepositorySection
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlphabeticalListOfProductRepository, AlphabeticalListOfProductRepository>();
            services.AddScoped<ICategorySalesFor1997Repository, CategorySalesFor1997Repository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICurrentProductListRepository, CurrentProductListRepository>();
            services.AddScoped<ICustomerAndSuppliersByCityRepository, CustomerAndSuppliersByCityRepository>();
            services.AddScoped<ICustomerCustomerDemoRepository, CustomerCustomerDemoRepository>();
            services.AddScoped<ICustomerDemographicRepository, CustomerDemographicRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTerritoryRepository, EmployeeTerritoryRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailsExtendedRepository, OrderDetailsExtendedRepository>();
            services.AddScoped<IOrdersQryRepository, OrdersQryRepository>();
            services.AddScoped<IOrderSubtotalRepository, OrderSubtotalRepository>();
            services.AddScoped<IProductsAboveAveragePriceRepository, ProductsAboveAveragePriceRepository>();
            services.AddScoped<IProductSalesFor1997Repository, ProductSalesFor1997Repository>();
            services.AddScoped<IProductsByCategoryRepository, ProductsByCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IQuarterlyOrderRepository, QuarterlyOrderRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISalesByCategoryRepository, SalesByCategoryRepository>();
            services.AddScoped<ISalesTotalsByAmountRepository, SalesTotalsByAmountRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISummaryOfSalesByQuarterRepository, SummaryOfSalesByQuarterRepository>();
            services.AddScoped<ISummaryOfSalesByYearRepository, SummaryOfSalesByYearRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITerritoryRepository, TerritoryRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind.WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
