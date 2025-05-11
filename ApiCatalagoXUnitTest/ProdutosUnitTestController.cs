using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Interfaces.Auxiliar;
using ApiCatalago.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalagoXUnitTest
{   
    public class ProdutosUnitTestController
    {
        public IDbUnitOfWork unitOfwork;

        public IMapper mapper;
        public static DbContextOptions<AppDbContext> options { get; set; }

        public static string connectionString = "Server=localhost\\SQLEXPRESS;Database=ApiCatalagoBD;Trusted_Connection=True;TrustServerCertificate=True;";

        static ProdutosUnitTestController()
        {
            options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public ProdutosUnitTestController()
        {
            var context = new AppDbContext(options);
            unitOfwork = new UnitOfWork(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(ApiCatalago.AutoMapper.MappingProfile));
            });
            mapper = config.CreateMapper();
        }


    }
}
