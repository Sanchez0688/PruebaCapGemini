using col.Backend.Controllers.Productos;
using col.Backend.Data;
using col.Backend.Repositories.Implementations.Productos;
using col.Backend.Repositories.Interfaces.Productos;
using col.Backend.UnitsOfWork.Implementations.Productos;
using col.Backend.UnitsOfWork.Interfaces.Productos;
using col.Shared.DTOs;
using col.Shared.Entities;
using col.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Text;

namespace col.Test
{
    public class ProductTest
    {
        private readonly ProductoController _controller;
        private readonly DataContext _context;
        private readonly ProductoUnitOfWork _unit;
        private readonly ProductosRepository _repository;

        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public ProductTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS01;Initial Catalog=prueba_capgemini;Integrated Security=True;Persist Security Info=False;Encrypt=False;")
            .Options;

            _context = new DataContext(options);
            _repository = new ProductosRepository(_context);
            _unit = new ProductoUnitOfWork(_repository);
            _controller = new ProductoController(_unit);
        }


        [Fact]
        public async Task Get_OK()
        {
            var result = await _controller.Get();

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, statusCodeResult.StatusCode);


        }

        [Fact]
        public async Task GetById_OK()
        {
            var id = 11;
            var result = await _controller.Get(id);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, statusCodeResult.StatusCode);


        }

        [Fact]
        public async Task Create_OK()
        {
            var data = new ProductDTO
            {
                Name = GenerateRandomString(10),
                Description = "Test",
                Price = 5000,
                Stock = 52
            };
            var result = await _controller.Create(data);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
            Assert.NotNull(statusCodeResult.Value);



        }

        [Fact]
        public async Task Update_OK()
        {
            var data = new ProductDTO
            {
                Id = 11,
                Name = GenerateRandomString(10),
                Description = "Test",
                Price = 5000,
                Stock = 52
            };
            var result = await _controller.Update(data.Id, data);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, statusCodeResult.StatusCode);
            Assert.NotNull(statusCodeResult.Value);

        }

        [Fact]
        public async Task Delete_OK()
        {
            var id = 12;
            var result = await _controller.Delete(id);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, statusCodeResult.StatusCode);
            Assert.NotNull(statusCodeResult.Value);

        }


        public static string GenerateRandomString(int length)
        {
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }



}