using BeerEShop.Services.Catalogs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;

namespace BeerEShop.Services.Catalogs.Domain.Entities
{
   public class Beer : EntityBase
    {
        public long BeerId { get; set; }
        public Name Name { get; set; }
        public AlcoholContent AlcoholContent { get; set; }
        public Price Price { get; set; }
        public SellingPrice SellingPrice { get; set; }
        public Volume Volume { get; set; }
        public BeerStatus BeerStatus { get; private set; }
        public long BreweryId { get; set; }
        public Brewery Brewery { get; set; }


        public static Beer Create(
       Name name,
       //BeerStatus status,
       AlcoholContent alcoholContent,
       Volume volume,
       Price price,
       SellingPrice sellingPrice,
       long breweryId
       )
        {
            var beer = new Beer();
            beer.ChangeName(name);
            beer.ChangeVolume(volume);
            beer.ChangePrice(price);
            beer.ChangeSellingPrice(sellingPrice);
            beer.ChangeStatus(BeerStatus.Available);
            beer.ChangeBrewery(breweryId);
            beer.ChangeAlchoolContent(alcoholContent);

            return beer;
        }
        /// <summary>
        ///  Sets beer item status.
        /// </summary>
        /// <param name="status">The status to be changed.</param>
        public void ChangeStatus(BeerStatus status)
        {
            BeerStatus = status;
        }

        /// <summary>
        /// Sets beer item volume.
        /// </summary>
        /// <param name="name">The volume to be changed.</param>
        public void ChangeVolume(Volume Volumes)
        {
            Guard.Against.Null(Volumes, new BeerCatalogDomainException("Volumes cannot be null.").Message);

            Volume = Volumes;
        }


        /// <summary>
        /// Sets beer item alchoolContent.
        /// </summary>
        /// <param name="name">The alchoolContent to be changed.</param>
        public void ChangeAlchoolContent(AlcoholContent alchoolContent)
        {
            Guard.Against.Null(alchoolContent, new BeerCatalogDomainException("AlcoholContent cannot be null.").Message);

            AlcoholContent = alchoolContent;
        }

        /// <summary>
        /// Sets beer item name.
        /// </summary>
        /// <param name="name">The name to be changed.</param>
        public void ChangeName(Name name)
        {
            Guard.Against.Null(name, new BeerCatalogDomainException("Beer name cannot be null.").Message);

            Name = name;
        }


        /// <summary>
        /// Sets beer item price.
        /// </summary>
        /// <remarks>
        /// Raise a <see cref="BeerPriceChanged"/>.
        /// </remarks>
        /// <param name="price">The price to be changed.</param>
        public void ChangePrice(Price price)
        {
            Guard.Against.Null(price, new BeerCatalogDomainException("Price cannot be null.").Message);

            if (Price == price)
                return;

            Price = price;

           
        }



        /// <summary>
        /// Sets Beer item SellingPrice.
        /// </summary>
        /// <remarks>
        /// Raise a <see cref="BeerSellingPriceChanged"/>.
        /// </remarks>
        /// <param name="sellingprice">The Selling price to be changed.</param>
        public void ChangeSellingPrice(SellingPrice sellingprice)
        {
            Guard.Against.Null(sellingprice, new BeerCatalogDomainException("Selling Price cannot be null.").Message);

            if (SellingPrice == sellingprice)
                return;

            SellingPrice = sellingprice;

           
        }

        
        public void Activate() => ChangeStatus(BeerStatus.Available);

        public void DeActive() => ChangeStatus(BeerStatus.Unavailable);

        /// <summary>
        /// Sets Brewer.
        /// </summary>
        /// <param name="supplierId">The supplierId to be changed.</param>
        public void ChangeBrewery(long breweryId)
        {
            Guard.Against.Null(breweryId, new BeerCatalogDomainException("BreweryId cannot be null").Message);
            BreweryId = breweryId;

        }

        
    }
}
