using Caliburn.Micro;
using SquaresDesktopUI.HighscoreHelpers;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresDesktopUI.ViewModels
{
    public class HighscoresViewModel : Screen
    {
        private IOrderBy _OrderBy;

        private List<string> _highscores = new List<string>();
        public List<string> Highscores
        {
            get { return _highscores; }
            set 
            { 
                _highscores = value;
                NotifyOfPropertyChange(() => Highscores);
            }
        }

        private List<string> _orderBy = new List<string>();
        public List<string> OrderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                _orderBy = value;
                NotifyOfPropertyChange(() => OrderBy);
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        public HighscoresViewModel(IOrderBy orderBy)
        {
            _OrderBy = orderBy;

            //Add options to combo box
            OrderBy.Add("Newest");
            OrderBy.Add("Oldest");
            OrderBy.Add("Score");
            OrderBy.Add("Alphabetical");
        }

        //When an item is selected
        public async Task ItemSelected()
        {
            switch (SelectedItem)
            {
                case "Score":
                    Highscores = await _OrderBy.OrderByScore();
                    break;
                case "Newest":
                    Highscores = await _OrderBy.OrderByNewest();
                    break;
                case "Oldest":
                    Highscores = await _OrderBy.OrderByOldest();
                    break;
                case "Alphabetical":
                    Highscores = await _OrderBy.OrderByAlpha();
                    break;
            }
        }
    }
}
