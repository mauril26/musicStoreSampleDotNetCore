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
        private const string API_URL       = "https://api.spotify.com/v1/";
        private const string ACCOUNT_URL   = "https://accounts.spotify.com/";
        private const string CLIENT_ID     = "2badf785ac1d4716a2579b93f8927065";
        private const string CLIENT_SECRET = "98144b190bb84564821bc567d3b4bebf";

        static HttpClient           client = new HttpClient();
        static SpotifyAuthorization auth   = null;

        private bool InitializationRequired()
        {
           return SpotifyController.auth == null;
        }

        public SpotifyController()
        {
            EstablishConnectivity();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery]string type, [FromQuery]string q)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"search?q={q}&type={type}").Result;
            return GetResponse(typeof(SearchModel), response);
        }
       
        [HttpGet("artist/{id}")]
        public IActionResult GetArtist(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"artists/{id}").Result;
            return GetResponse(typeof(Artist), response);
        }

        [HttpGet("artist/{id}/albums")]
        public IActionResult GetArtistAlbums(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"artists/{id}/albums").Result;
            return GetResponse(typeof(Albums), response);
        }

        [HttpGet("artist/{id}/top-tracks")]
        public IActionResult GetArtisttopTracks(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"artists/{id}/top-tracks?country=US").Result;
            return GetResponse(typeof(TopTracks), response);
        }

        [HttpGet("album/{id}")]
        public IActionResult GetAlbum(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"albums/{id}").Result;
            return GetResponse(typeof(Album), response);
        }

        [HttpGet("track/{id}")]
        public IActionResult GetAlbums(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"tracks/{id}").Result;
            return GetResponse(typeof(Track), response);
        }

        [HttpGet("album/{id}/tracks")]
        public IActionResult GetAlbumTracks(string id)
        {
            SetRequestHeader();
            HttpResponseMessage response = client.GetAsync($"albums/{id}/tracks").Result;
            return GetResponse(typeof(Tracks), response);
        }

        private  IActionResult GetResponse(Type type, HttpResponseMessage response)
        {
            object retVal = null;

            if (response.IsSuccessStatusCode)
            {
                JsonResult result = this.Json(response.Content.ReadAsStringAsync().Result);
                retVal = JsonConvert.DeserializeObject(result.Value as string, type);
            }

            return Ok(retVal);
        }

        private static void SetRequestHeader()
        {
            if (client.BaseAddress == null)
                client.BaseAddress = new Uri(API_URL);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SpotifyController.auth.AccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void EstablishConnectivity()
        {
            if (!InitializationRequired())
                return;
            
            string authData = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes($"{CLIENT_ID}:{CLIENT_SECRET}"));
            string requestData = "grant_type=client_credentials";
            
            client = new HttpClient();
            client.BaseAddress = new Uri(ACCOUNT_URL);
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