using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LiveCards.Models.PrepaidForgeAPI
{

    public class ProductAPIDetails
    {
        [Key]
        public int Id { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public string? gtin { get; set; }
        public string? ean { get; set; }
        public FaceValue faceValue { get; set; }
        public DefaultPrice defaultPrice { get; set; }
        public bool isCurrencyProduct { get; set; }
        public string? imageUrl { get; set; }
        public bool active { get; set; }

        [NotMapped]
        public List<string?> languages { get; set; }
        public string? languages2 { get; set; }

        [NotMapped] public List<string?> countries { get; set; }
        public string? countries2 { get; set; }

        [NotMapped] public List<string?> platforms { get; set; }
        public string? platforms2 { get; set; }

        public int rating { get; set; }
        public string? productType { get; set; }
       [NotMapped]    public List<string?> category { get; set; }
        public  string?   category2 { get; set; }
        public string? lastUpdate { get; set; }
        public string? brand { get; set; }
        public string? currencyCode { get; set; }
    }

    public class DefaultPrice
    {
        [Key]
        public int Id { get; set; }
        public double amount { get; set; }
        public string? currency { get; set; }
        public string? formattedstring  { get; set; }
        public string? csvamount { get; set; }
        public string? roundedFormattedstring  { get; set; }
    }

    public class FaceValue
    {
        [Key]
        public int Id { get; set; }

        public double amount { get; set; }
        public string? currency { get; set; }
        public string? formattedstring { get; set; }
        public string? csvamount { get; set; }
        public string? roundedFormattedstring  { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class ProductAPIStock
    {
         public int Id { get; set; }
         public string Product { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
    }

    public class ProductAPIStocksModel
    {
        
        public ProductAPIStocksModel()
        {
            Types= new List<string>();  
            Skus=new List<string>();
        }
        public List<string> Types { get; set; }
        public List<string> Skus { get; set; }
    }



    public class ProductAPIStock1
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
    }

    public class ProductAPIDetails1
    {
        [Key]
        public int Id { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public string? gtin { get; set; }
        public string? ean { get; set; }
        public FaceValue faceValue { get; set; }
        public DefaultPrice defaultPrice { get; set; }
        public bool isCurrencyProduct { get; set; }
        public string? imageUrl { get; set; }
        public bool active { get; set; }

        [NotMapped]
        public List<string?> languages { get; set; }
        public string? languages2 { get; set; }

        [NotMapped] public List<string?> countries { get; set; }
        public string? countries2 { get; set; }

        [NotMapped] public List<string?> platforms { get; set; }
        public string? platforms2 { get; set; }

        public int rating { get; set; }
        public string? productType { get; set; }
        [NotMapped] public List<string?> category { get; set; }
        public string? category2 { get; set; }
        public string? lastUpdate { get; set; }
        public string? brand { get; set; }
        public string? currencyCode { get; set; }
    }

}