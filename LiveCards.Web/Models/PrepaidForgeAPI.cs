using LiveCards.Data;
using LiveCards.Models;
using RestSharp;
using LiveCards.Models.PrepaidForgeAPI;
using System.Net;
using System.Drawing;

namespace LiveCards.Web.Models
{
    public class PrepaidForgeAPI
    {
        private const string BaseUrl = "https://api.prepaidforge.com/v1/1.0/";
        private readonly string Email;
        private readonly string Password;
        private readonly ApplicationDbContext _context;
        //    private RestClient client;

        public PrepaidForgeAPI(ApplicationDbContext context)
        {
            _context = context;
            Email = getSetting(SettingsKeys.PrepaidForge_Email.ToString());
            Password = getSetting(SettingsKeys.PrepaidForge_Password.ToString()); ;
        }

        public string getSetting(string key)
        {
            var setting = _context.Settings.Find(key);
            var value = string.IsNullOrEmpty(setting?.KVal) ? setting?.DefaultValue : setting?.KVal;

            return value;
        }

        public async Task<LoginResponseModel> SignInWithApiAsync()
        {
            //signInWithApi
            try
            {
                var client = new RestClient(BaseUrl + "signInWithApi");

                LoginModel data = new LoginModel(Email, Password);

                var request = new RestRequest()
                    .AddJsonBody(data)
                    .AddHeader("Accept", "application/json")
                    .AddHeader("Content-Type", "application/json");

                var response = await client.PostAsync<LoginResponseModel>(request);

                return response;
            }
            catch (Exception ex)
            {
                return new LoginResponseModel();
            }
        }



        public async Task<List<ProductAPIDetails>> FindAllProducts()
        {

            var data = new List<ProductAPIDetails>();
            try
            {
                var client = new RestClient(BaseUrl + "findAllProducts");

                var request = new RestRequest();

                data = await client.GetAsync<List<ProductAPIDetails>>(request);

                //response.ForEach(x => { x.languages2 = string.Join(',', x.languages);
                //    x.countries2 = string.Join(',', x.countries);
                //    x.platforms2 = string.Join(',', x.platforms);
                //    x.category2 = string.Join(',', x.category);
                //});


                //_context.ProductAPIDetails.AddRange(response);
                //_context.SaveChanges();

            }
            catch (Exception ex)
            {
                //  return new LoginResponseModel();
            }

            return data;
        }

        public async Task<List<ProductAPIDetails>> FindProductPage(int page = 1, int pageSize = 100)
        {

            var body = new { page, pageSize };

            var data = new List<ProductAPIDetails>();
            try
            {
                var client = new RestClient(BaseUrl + "findAllProducts");

                var request = new RestRequest();

                data = await client.GetAsync<List<ProductAPIDetails>>(request);
            }
            catch (Exception ex)
            {
                //  return new LoginResponseModel();
            }

            return data;
        }


        public async Task<List<ProductAPIStock>> FindStocks(List<string> sku)
        {
            var body = new ProductAPIStocksModel() { Types = { "TEXT", "SCAN" }, Skus = sku };
            var data = new List<ProductAPIStock>();
            try
            {
                var loginData = await SignInWithApiAsync();

                var client = new RestClient(BaseUrl + "findStocks");

                var request = new RestRequest()
                     .AddJsonBody(body)
                     .AddHeader("Accept", "application/json")
                     .AddHeader("X-PrepaidForge-Api-Token", loginData.ApiToken)
                     .AddHeader("Content-Type", "application/json");

                data = await client.PostAsync<List<ProductAPIStock>>(request);
            }
            catch (Exception ex)
            {
                //  return new LoginResponseModel();
            }

            return data;
        }



        public async Task RefreshProductsAsync()
        {
            try
            {
                //_context.Temp_PrepaidForgeStocks.RemoveRange(_context.Temp_PrepaidForgeStocks);
                ////var time = DateTime.Now;

                //var products = await FindAllProducts();
                //_context.Temp_ProductAPIDetails.AddRange(products);

                //var dd = products.OrderBy(x => x.lastUpdate);
                ////var products = new List<ProductAPIDetails>();
                ////for (var i = 1; i <= 1; ++i)
                ////{
                ////products = await FindProductPage(page: i);


                ////foreach (var item in products)
                ////{
                //var skus = products.Select(x => x.sku).ToList();
                //var stocks = await FindStocks(skus);


                //_context.Temp_PrepaidForgeStocks.AddRange(stocks);
                //_context.SaveChanges();

                //var temp_stocks = _context.Temp_PrepaidForgeStocks.GroupBy(x => x.Product)
                //    .Select(x => new { x.Key, price = x.Min(p => p.PurchasePrice), count = x.Count() })
                //    .ToList();

                ////  var updatedProducts = products.Where(x => x.lastUpdate >= DateTime.Today); 


                ////}
                ////}

                //_context.SaveChanges();
                //Console.WriteLine("*****************************************");
                //Console.WriteLine("time 1 seconds = " + (DateTime.Now - time).TotalSeconds);


            }
            catch (Exception ex)
            {
                //  return new LoginResponseModel();
            }
        }



        public async Task SaveProductsandStocks()
        {
            try
            {
                _context.Temp_PrepaidForgeStocks.RemoveRange(_context.Temp_PrepaidForgeStocks);
                var products = new List<ProductAPIDetails1>();


                var client = new RestClient(BaseUrl + "findAllProducts");

                var request = new RestRequest();

                products = await client.GetAsync<List<ProductAPIDetails1>>(request);

                products.ForEach(x =>
                {
                    x.languages2 = string.Join(',', x.languages);
                    x.countries2 = string.Join(',', x.countries);
                    x.platforms2 = string.Join(',', x.platforms);
                    x.category2 = string.Join(',', x.category);
                });

                _context.Temp_ProductAPIDetails.AddRange(products);
 
                var skus = products.Select(x => x.sku).ToList();
                //var stocks = await FindStocks(skus);

                var loginData = await SignInWithApiAsync();

                var body = new ProductAPIStocksModel() { Types = { "TEXT", "SCAN" }, Skus = skus };
                var stocks = new List<ProductAPIStock1>();

                client = new RestClient(BaseUrl + "findStocks");

                request = new RestRequest()
                   .AddJsonBody(body)
                   .AddHeader("Accept", "application/json")
                   .AddHeader("X-PrepaidForge-Api-Token", loginData.ApiToken)
                   .AddHeader("Content-Type", "application/json");

                stocks = await client.PostAsync<List<ProductAPIStock1>>(request);

                _context.Temp_PrepaidForgeStocks.AddRange(stocks);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //  return new LoginResponseModel();
            }
        }


    }
}
