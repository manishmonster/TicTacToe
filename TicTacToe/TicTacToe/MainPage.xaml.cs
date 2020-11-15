using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicTacToe.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Caliburn.Micro;
using System.Diagnostics;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Media.Imaging;

namespace TicTacToe
{
    public sealed partial class MainPage : Page
    {
        Bestmove bm;
        string[,] board = new string[,]
        {
           { "", "", "" },
           { "", "", "" },
           { "", "", "" }
        };

        string WinnerText = "";

        public MainPage()
        {
            this.InitializeComponent();
            bm = new Bestmove(ref board);
            
            
        }
        public void endding(int there_is_a_winner)
        {
            if (there_is_a_winner == 10 || there_is_a_winner == -10)
            {
                disableButtons();
                string winner = "";
                if (there_is_a_winner == -10)
                {
                    if (PlayerBName.Text == "Enter Name")
                        winner = "Player B";
                    else
                        winner = PlayerBName.Text;
                    TotalScoreB.Text = (Int32.Parse(TotalScoreB.Text) + 1).ToString();
                    WinnerText = winner + " is winner!";
                    winText.Text = WinnerText;
                    WinnerText = "Humanlity has been saved.";
                    finalimage.Source = new BitmapImage(new Uri("ms-appx:///Assets/robot faill.gif"));
                    readText(WinnerText);
                    ShowAnimation();
                }
                else if (there_is_a_winner == 10)
                {
                    winner = "AI computer";
                    TotalScoreA.Text = (Int32.Parse(TotalScoreA.Text) + 1).ToString();
                    WinnerText = winner + " is winner!";
                    winText.Text = WinnerText;
                    
                    WinnerText = "You human suck, Compter has won";
                    finalimage.Source = new BitmapImage(new Uri("ms-appx:///Assets/robot dance.gif"));
                    readText(WinnerText);
                    ShowAnimation();
                }

            }
            else if (!bm.isMoveLeftinborad(board))
            {
                disableButtons();
                WinnerText = "It's a draw.";
                winText.Text = WinnerText;
                finalimage.Source = new BitmapImage(new Uri("ms-appx:///Assets/balance.gif"));
                readText(WinnerText);
                ShowAnimation();
            }


        }
        #region placement 
            public void computermov(string Name)
            {
                if (Name != "")
                {
                    switch (Name)
                    {
                        case "A1":
                            A1.Content = "X";
                            A1.IsEnabled = false;
                            break;
                        case "B1":
                            B1.Content = "X";
                            B1.IsEnabled = false;
                            break;
                        case "C1":
                            C1.Content = "X";
                            C1.IsEnabled = false;
                            break;
                        case "A2":
                            A2.Content = "X";
                            A2.IsEnabled = false;
                            break;
                        case "B2":
                            B2.Content = "X";
                            B2.IsEnabled = false;
                            break;
                        case "C2":
                            C2.Content = "X";
                            C2.IsEnabled = false;
                            break;
                        case "A3":
                            A3.Content = "X";
                            A3.IsEnabled = false;
                            break;
                        case "B3":
                            B3.Content = "X";
                            B3.IsEnabled = false;
                            break;
                        case "C3":
                            C3.Content = "X";
                            C3.IsEnabled = false;
                            break;
                    }
                    Debug.WriteLine("After bestmoves");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Debug.Write(board[i, j] + ", ");
                        }
                        Debug.WriteLine("-----------------------------");
                    }
                    int result = bm.checkForWinner(board);
                    endding(result);
                }

            }
            public void computermov(int i, int j)
            {
                if (i == 0 && j == 0)
                {
                    A1.Content = "X";
                    A1.IsEnabled = false;
                }
                if (i == 1 && j == 0)
                {
                    A2.Content = "X";
                    A2.IsEnabled = false;
                }
                if (i == 2 && j == 0)
                {
                    A3.Content = "X";
                    A3.IsEnabled = false;
                }
                if (i == 0 && j == 1)
                {
                    B1.Content = "X";
                    B1.IsEnabled = false;
                }
                if (i == 1 && j == 1)
                {
                    B2.Content = "X";
                    B2.IsEnabled = false;
                }
                if (i == 2 && j == 1)
                {
                    B3.Content = "X";
                    B3.IsEnabled = false;
                }
                if (i == 0 && j == 2)
                {
                    C1.Content = "X";
                    C1.IsEnabled = false;
                }
                if (i == 1 && j == 2)
                {
                    C2.Content = "X";
                    C2.IsEnabled = false;
                }
                if (i == 2 && j == 2)
                {
                    C3.Content = "X";
                    C3.IsEnabled = false;
                }
            }
            public void boradevelation(string Name)
            {
                switch (Name)
                {
                    case "A1":
                        board[0, 0] = "O";
                        break;
                    case "B1":
                        board[0, 1] = "O";
                        break;
                    case "C1":
                        board[0, 2] = "O";
                        break;
                    case "A2":
                        board[1, 0] = "O";
                        break;
                    case "B2":
                        board[1, 1] = "O";
                        break;
                    case "C2":
                        board[1, 2] = "O";
                        break;
                    case "A3":
                        board[2, 0] = "O";
                        break;
                    case "B3":
                        board[2, 1] = "O";
                        break;
                    case "C3":
                        board[2, 2] = "O";
                        break;
                }
            }
        #endregion
        #region mainpage button event
            private void button_click(object sender, RoutedEventArgs e)
            {

                Button b = (Button)sender;
                b.Content = "O";
                b.IsEnabled = false;
                boradevelation(b.Name);
                computermov(bm.Movefoai(ref board));

            }

            private void NewGame_Click(object sender, RoutedEventArgs e)
            {
                Button b = (Button)sender;


                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = "";
                    }
                }
                A1.IsEnabled = true;
                A2.IsEnabled = true;
                A3.IsEnabled = true;
                B1.IsEnabled = true;
                B2.IsEnabled = true;
                B3.IsEnabled = true;
                C1.IsEnabled = true;
                C2.IsEnabled = true;
                C3.IsEnabled = true;


                A1.Content = "";
                A2.Content = "";
                A3.Content = "";
                B1.Content = "";
                B2.Content = "";
                B3.Content = "";
                C1.Content = "";
                C2.Content = "";
                C3.Content = "";
            
                computermov(bm.Movefoai(ref board));
                if (b.Name == "NewGame2" || WinTextButton.Opacity > 0.1)
                {
                    HideAnimation();
                }
            }

            private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            TotalScoreA.Text = "0";
            TotalScoreB.Text = "0";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "";
                }
            }
            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;


            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";
            computermov(bm.Movefoai(ref board));
            if (b.Name == "NewGame2" || WinTextButton.Opacity > 0.1)
            {
                HideAnimation();
            }
        }
        #endregion
        private void disableButtons()
        {

            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
        }
        private void ShowAnimation()
        {
            Canvas.SetZIndex(WinTextButton, 0);
            NewGame2.IsEnabled = true;
            WinTextShow.Begin();
        }

        private void HideAnimation()
        {
            WinTextHide.Begin();
            NewGame2.IsEnabled = false;
            Canvas.SetZIndex(WinTextButton, -1);
        }

        private async void readText(string mytext)
        {
            MediaElement mediaplayer = new MediaElement();
            using (var speech = new SpeechSynthesizer())
            {
                speech.Voice = SpeechSynthesizer.AllVoices.First(gender => gender.Gender == VoiceGender.Female);
                string ssml = @"<speak version='1.0' " + "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" + WinnerText + "</speak>";
                SpeechSynthesisStream stream = await speech.SynthesizeSsmlToStreamAsync(ssml);
                mediaplayer.SetSource(stream, stream.ContentType);
                mediaplayer.Play();
            }
        }

    }
}

