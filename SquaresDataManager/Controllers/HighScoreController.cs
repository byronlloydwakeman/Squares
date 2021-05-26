using SquaresDataManager.Library.DataAccess;
using SquaresDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace SquaresDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/HighScore")]
    public class HighScoreController : ApiController
    {
        [Route("GetHighScores")]
        public List<HighScoreDBModel> GetHighScores()
        {
            return HighScoreData.GetHighScores();
        }

        [Route("PostHighScore")]
        public void PostHighScore(HighScoreDBModel highScoreDBModel)
        {
            highScoreDBModel.LoggedInUser = RequestContext.Principal.Identity.Name;
            HighScoreData.InsertHighScore(highScoreDBModel);
        }

    }
}
