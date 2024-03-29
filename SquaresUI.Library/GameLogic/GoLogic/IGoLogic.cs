﻿using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.GameLogic.GoLogic
{
    public interface IGoLogic
    {
        void ActivateLine(PointModel p1, PointModel p2);
        int HasSquareBeenMade();
        void InsertPlayerModel(PlayerModel player1, PlayerModel player2);
        void SwitchGoes();
    }
}