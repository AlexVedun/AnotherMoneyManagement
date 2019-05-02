using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Desktop_Client.WebAPIClientWPF
{
    public class WebAPIClient
    {
        static HttpClient client  = new HttpClient();

        static WebAPIClient() {

            RunAsync().Wait();
        }

        public static HttpClient Client { get => client; set => client = value; }

        static async Task RunAsync()
        {
            Client.BaseAddress = new Uri("https://anothermoneymanagement.azurewebsites.net/");
            //Client.BaseAddress = new Uri("https://amm2-239308.appspot.com/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //public static async Task<Product> GetProductAsync(string id)
        //{
        //    Product product = null;
        //    HttpResponseMessage response = await client.GetAsync("api/products/" + id);
        //    Console.WriteLine(response);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Product>();
        //    }
        //    return product;
        //}

        //public static async Task<ObservableCollection<Product>> GetProductsAsync()
        //{
        //    ObservableCollection<Product> products = null;
        //    Console.WriteLine("start");
        //    HttpResponseMessage response = await client.GetAsync("api/products");
        //    Console.WriteLine(response);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        products = await response.Content.ReadAsAsync<ObservableCollection<Product>>();
        //    }
        //    return products;
        //}

        //public static async Task<Product> CreateProductAsync(Product product)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
        //    response.EnsureSuccessStatusCode();

        //    // Return the URI of the created resource.
        //    //return response.Headers.Location;
        //    Console.WriteLine(response);
        //    return await response.Content.ReadAsAsync<Product>();
        //}

        //public static async Task<bool> DeleteProductAsync(string id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync($"api/products/{id}");
        //    return response.IsSuccessStatusCode;
        //}
    }
}
