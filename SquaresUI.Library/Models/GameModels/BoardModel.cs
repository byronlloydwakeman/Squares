using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models.GameModels
{
    public class BoardModel : IBoardModel
    {
        public int height { get; } = 9;
        public int width { get; } = 9;
        private List<PointModel> Points { get; set; } = new List<PointModel>();
        public List<LineModel> Lines { get; set; } = new List<LineModel>();
        public List<List<LineModel>> Squares { get; set; } = new List<List<LineModel>>();

        public BoardModel()
        {
            //Create points to create lines from and add them to the lines
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Points.Add(new PointModel() { XCoord = x, YCoord = y });
                }
            }

            //Add rows
            for (int i = 0; i < Points.Count; i++)
            {
                if ((i + 1) % width != 0)
                {
                    Lines.Add(new LineModel() { Point1 = Points[i], Point2 = Points[i + 1] });
                }
            }
            //Add columns
            for (int i = 0; i < Points.Count; i++)
            {
                if(i < ((height * width) - width))
                {
                    Lines.Add(new LineModel() { Point1 = Points[i], Point2 = new PointModel() { XCoord = Points[i].XCoord, YCoord = Points[i].YCoord + 1 } });
                }
            }

            //Add lines to the squares
            //Add empty lists
            for (int i = 0; i < (height - 1) * (width - 1); i++)
            {
                Squares.Add(new List<LineModel>());
            }

            //Add the row lines to their respective square
            for (int i = 0; i < Squares.Count; i++)
            {
                Squares[i].Add(Lines[i]);
                Squares[i].Add(Lines[i + width - 1]);
            }

            //Add column lines
            int corrector = 0;
            for (int i = 0; i < Squares.Count; i++)
            {
                if ((i % 8 == 0) && (i != 0))
                {
                    corrector++;
                }
                
                Squares[i].Add(Lines[i + corrector + width + Squares.Count]);
                Squares[i].Add(Lines[i + width - 1 + corrector + Squares.Count]);

            } //I whtink it now works
        }
    }
}

