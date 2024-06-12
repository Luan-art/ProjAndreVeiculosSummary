using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosSummary.BankAPI.Utils;
using ProjAndreVeiculosSummary.Controllers;
using ProjAndreVeiculosSummary.Data;

 namespace ProjAndreVericulosSummary.Test
{
    public class UnitTestAddress
    {
        private DbContextOptions<ProjAndreVeiculosSummaryContext> options;


        private void InitializDataBase()
        {
            options = new DbContextOptionsBuilder<ProjAndreVeiculosSummaryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                context.Address.Add(new Models.Address { Id = 1, Cep = "14500000", Description = "Rua do beco becozo" });
                context.Address.Add(new Models.Address { Id = 2, Cep = "14500030", Description = "Rua do beco novo" });
                context.Address.Add(new Models.Address { Id = 3, Cep = "14500002", Description = "Avenida do beco becozo" });
                context.Address.Add(new Models.Address { Id = 4, Cep = "14500006", Description = "Rua dourada rubra" });
                context.SaveChanges();
            }

        }
        [Fact]
        public void TestGetAll()
        {
            InitializDataBase();

            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                IEnumerable<Address> addresses = addressesController.GetAddress().Result.Value;

                Assert.Equal(4, addresses.Count());
            }
        }

        [Fact]
        public void TestGetById()
        {
            InitializDataBase();

            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = addressesController.GetAddress(2).Result.Value;
                Assert.Equal(2, address.Id);
            }
        }

        [Fact]
        public void Creat()
        {
            InitializDataBase();


            using (var context = new ProjAndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = new Address { Id = 5, Cep = "1234342", Description = "Dono da Lua" };

                Address add = addressesController.PostAddress(address).Result.Value;

                Assert.Equal("1234342", add.Cep);
            }
        }
    }
}