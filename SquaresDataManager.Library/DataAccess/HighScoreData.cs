using SquaresDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataManager.Library.DataAccess
{
    public static class HighScoreData
    {
        //Works
        public static List<HighScoreDBModel> GetHighScores()
        {
            return SqlDataAccess.LoadData<HighScoreDBModel, dynamic>("spGetHighScores", new { });
        }

        //Insertion works
        public static void InsertHighScore(HighScoreDBModel highScoreDBModel)
        {
            string LoggedInUser = highScoreDBModel.LoggedInUser;
            string UserName = highScoreDBModel.UserName;
            int BoardSize = highScoreDBModel.BoardSize;
            DateTime Date = highScoreDBModel.Date;
            int HighScore = highScoreDBModel.HighScore;

            List<HighScoreDBModel> tempList = GetHighScores();

            bool EntryExists = false;

            //Check whether entry exists
            foreach (var item in tempList)
            {
                if(item.UserName == highScoreDBModel.UserName)
                {
                    EntryExists = true;
                }
            }

            //If it does call the update method
            if (EntryExists)
            {
                SqlDataAccess.SaveData("spUpdateHighScore", new { LoggedInUser, UserName, BoardSize, Date, HighScore });
            }
            else //If not add normally
            {
                SqlDataAccess.SaveData("spInsertHighScore", new { LoggedInUser, UserName, BoardSize, Date, HighScore });
            }
        }  
    }
}
