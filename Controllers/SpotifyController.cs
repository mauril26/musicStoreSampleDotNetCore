using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using musicStoreSampleModels;
using Newtonsoft.Json;

namespace musicStoreSample.Controllers
{
    [Route("[controller]")]
    public class SpotifyController : Controller
    {
        private const string CLIENT_ID     = "2badf785ac1d4716a2579b93f8927065";
        private const string CLIENT_SECRET = "98144b190bb84564821bc567d3b4bebf";

        static HttpClient client = new HttpClient();
        static SpotifyAuthorization auth = null;

        private bool InitializationRequired()
        {
           return SpotifyController.auth == null;
        }

        public SpotifyController()
        {
            EstablishConnectivity();
        }

        [HttpGet("artist/{id=1}")]
        public string GetArtist(string id)
        {
            return "Artist " + id;
        }

        [HttpGet("artist/{id}/albums")]
        public string GetAlbum(string album)
        {
            return "Album " + album;
        }

        [HttpGet("album/{id}")]
        public string GetAlbums(string artist)
        {
            return "Album from artist " + artist;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery]string type, [FromQuery]string q)
        {
            SearchModel searchResult = null;
            if (client.BaseAddress==null)
                client.BaseAddress = new Uri("https://api.spotify.com/");
                
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SpotifyController.auth.AccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"v1/search?q={q}&type={type}").Result;

            if (response.IsSuccessStatusCode)
            {
                JsonResult result = this.Json(response.Content.ReadAsStringAsync().Result);
                searchResult = JsonConvert.DeserializeObject(result.Value as string, typeof(SearchModel)) as SearchModel;
            }

            return Ok(searchResult);
        }

        private void EstablishConnectivity()
        {
            if (!InitializationRequired())
                return;
            
            string authData = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes($"{CLIENT_ID}:{CLIENT_SECRET}"));
            string requestData = "grant_type=client_credentials";
            
            client = new HttpClient();
            client.BaseAddress = new Uri("https://accounts.spotify.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authData);

            System.Net.Http.HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = client.PostAsync("api/token", content).Result;

            if (response.IsSuccessStatusCode)
            {
                JsonResult result = this.Json(response.Content.ReadAsStringAsync().Result);
                SpotifyController.auth = JsonConvert.DeserializeObject(result.Value as string, typeof(SpotifyAuthorization)) as SpotifyAuthorization;
            }

            client = new HttpClient(); //release the Base Address for new requests
        }
    }
}