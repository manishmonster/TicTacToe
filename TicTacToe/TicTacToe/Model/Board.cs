using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class Board
    {
        public string[,] board;

        public Board()
        {
            board  = new string[,]{
               { "", "", "" },
               { "", "", "" },
               { "", "", "" }
            };
        }
        public Cell computerMove;
        public List<Cell> getAvailableCells()
        {
            List<Cell> availableCells = new List<Cell>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "")
                    {
                        availableCells.Add(new Cell(i, j));
                    }
                }
            }
            return availableCells;
        }
        //checking for avaliable space in a matrix board
        public bool isMoveLeftinborad()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    // Is the spot available?
                    if (board[i, j] == "")
                        return true;

            return false;
        }
        //method to place the variable into cell value as cells are elements of matrix board
        public bool PlaceMove(Cell cell, bool isHuman )
        {
            if (board[cell.x, cell.y] != "")
                return false;
            if (isHuman)
                board[cell.x, cell.y] = "O";
            else
                board[cell.x, cell.y] = "X";
            
            return true;
        }
        public int checkForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                //horizontal checks
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != "")
                {
                    if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] == "X")
                        return 10;
                    else if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] == "O")
                        return -10;
                }
                //vertical checks
                else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != "")
                {
                    if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] == "X")
                        return 10;
                    else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] == "O")
                        return -10;
                }
            }
            //diagonal checks

            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != "") || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] != ""))
            {
                if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == "X") || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == "X"))
                    return 10;
                else if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == "O") || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == "O"))
                    return -10;
            }
            return 0;

        }//end checkForWinner
    }
}
