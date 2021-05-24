using SquaresUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.API.Endpoints
{
    public class HighScoreEndpoint : IHighScoreEndpoint
    {
        private IAPIHelper _apiHelper;

        public HighScoreEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<HighScoreUIModel>> GetHighScores()
        {
            _apiHelper._apiClient.DefaultRequestHeaders.Clear();
            _apiHelper._apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiHelper._apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //If access token is null or empty throw an exception? na reason phrase does it for us
            _apiHelper._apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { _apiHelper._authenticatedUser.Access_Token }");


            using (HttpResponseMessage response = await _apiHelper._apiClient.GetAsync("/api/HighScore/GetHighScores"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<HighScoreUIModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task PostHighScore(HighScoreUIModel highScoreUIModel)
        {
            _apiHelper._apiClient.DefaultRequestHeaders.Clear();
            _apiHelper._apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiHelper._apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //If access token is null or empty throw an exception?
            _apiHelper._apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { _apiHelper._authenticatedUser.Access_Token }");

            using (HttpResponseMessage response = await _apiHelper._apiClient.PostAsJsonAsync("/api/HighScore/PostHighScore", highScoreUIModel))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
