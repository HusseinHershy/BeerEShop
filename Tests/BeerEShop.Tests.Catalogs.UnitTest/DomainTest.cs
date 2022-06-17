using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using BeerEShop.Tests.Catalogs.UnitTest.Models;
using System;
using Xunit;

namespace BeerEShop.Tests.Catalogs.UnitTest
{
    public class DomainTest
    {
        [Fact]
        public void AbeerIsNecessarilyLinkedToABrewer()
        {
           
                TBeer BeerModel = new TBeer();
                BeerModel.Name = "Leffe Blonde";
                BeerModel.BeerStatus = BeerStatus.Available;
                BeerModel.Volume = 5.2m;
                BeerModel.AlcoholContent = 6.6m;
                BeerModel.Price = 3.5m;
                BeerModel.SellingPrice = 100;
                BeerModel.BreweryId = null;
           
                Assert.Throws<InvalidOperationException>(() => Beer.Create(BeerModel.Name,  BeerModel.Volume, BeerModel.AlcoholContent, BeerModel.Price, BeerModel.SellingPrice, BeerModel.BreweryId.Value));
           
        }

        [Fact]
        public void AbeerIsLinked()
        {

            TBeer BeerModel = new TBeer();
            BeerModel.Name = "Leffe Blonde";
            BeerModel.Volume = 5.2m;
            BeerModel.AlcoholContent = 6.6m;
            BeerModel.Price = 3.5m;
            BeerModel.SellingPrice = 100;
            BeerModel.BreweryId = 1;

            Beer Result = Beer.Create(BeerModel.Name,  BeerModel.Volume, BeerModel.AlcoholContent, BeerModel.Price, BeerModel.SellingPrice, BeerModel.BreweryId.Value);
            Assert.Equal(1, Result.BreweryId);

        }

        [Fact]
        public void ABrewerBrewsOneToSeveralBeers()
        {

           var FirstBeer =  Beer.Create("Leffe Blonde", 5.2m, 100, 115, 130, 1);
            var SecondBeer = Beer.Create("Imperial Enchanted Rain Rocket", 6.6m, 70, 80, 130, 1);
            Assert.Equal(FirstBeer.BreweryId, SecondBeer.BreweryId);

        }
    }
}
