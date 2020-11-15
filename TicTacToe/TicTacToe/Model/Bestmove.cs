using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TicTacToe.Model
{
    public class Bestmove
    {

        string[,] board;
        int count = 0;
        int[] move = new int[2];
        public Bestmove()
        {
            //mp = new MainPage();
        }
        public Bestmove(ref string[,] board)
        {
            this.board = board;
        }
        public string Movefoai(ref string[,] board)
        {
            asewerewr(board);
            if (board[move[0], move[1]] == "")
            {
                board[move[0], move[1]] = "X";
                if (move[0] == 0 && move[1] == 0)
                {
                    return "A1";
                }
                if (move[0] == 1 && move[1] == 0)
                {
                    return "A2";
                }
                if (move[0] == 2 && move[1] == 0)
                {
                    return "A3";
                }
                if (move[0] == 0 && move[1] == 1)
                {
                    return "B1";
                }
                if (move[0] == 1 && move[1] == 1)
                {
                    return "B2";
                }
                if (move[0] == 2 && move[1] == 1)
                {
                    return "B3";
                }
                if (move[0] == 0 && move[1] == 2)
                {
                    return "C1";
                }
                if (move[0] == 1 && move[1] == 2)
                {
                    return "C2";
                }
                if (move[0] == 2 && move[1] == 2)
                {
                    return "C3";
                }

            }
            return "";
        }
        private void asewerewr(string[,] board){
            MainPage mp = new MainPage(); ;
            int bestScore = -1000;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Is the spot available?
                    if (board[i, j] == "")
                    {
                        board[i, j] = "X";
                        int score1 = minimax(board, 0, false);
                        board[i, j] = "";
                        if (score1 > bestScore)
                        {
                            bestScore = score1;
                            move[0] = i;
                            move[1] = j;
                        }
                    }
                }
            }
            Debug.WriteLine(count);
        }
        public bool isMoveLeftinborad(string[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    // Is the spot available?
                    if (board[i, j] == "")
                        return true;

            return false;
        }
        private int minimax(string[,] board,int deapth, bool isMaximizing)
        {
            count++;
            int res = checkForWinner(board);
            if (res == 10)
                return 10;

            else if (res == -10)
                return -10;

            if (isMoveLeftinborad(board) == false)
                return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Is the spot available?
                        if (board[i, j] == "")
                        {
                            board[i, j] = "X";
                            int score = minimax(board, deapth + 1, false);
                            
                            board[i, j] = "";

                            bestScore = maxNumber(score, bestScore);
                            
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Is the spot available?
                        if (board[i, j] == "")
                        {
                            board[i, j] = "O";
                            int score = minimax(board,deapth + 1, true);
                            board[i, j] = "";
                            bestScore = minNumber(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }

        }
        private int maxNumber(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        private int minNumber(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
        public int checkForWinner(string[,] board)
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
