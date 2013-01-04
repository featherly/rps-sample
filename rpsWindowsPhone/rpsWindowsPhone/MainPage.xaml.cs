using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using rpsWindowsPhone.Controls;
using rpsWindowsPhone.Model;

namespace rpsWindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public string Basics { get { return basics; } }
        private const string basics = "Choose your move using a button below. The computer will pick a move at the bottom.";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private Random rnd = new Random();
        private void RpsChooser_RpsChanged(object sender, EventArgs e)
        {
            RpsChooser playerCtrl = sender as RpsChooser;

            if (playerCtrl == null) return;

            RpsEnum player = playerCtrl.RpsChosen;
            if (player == RpsEnum.Undetermined)
            {
                console.Text = basics;
                return;
            }

            RpsEnum ai = (RpsEnum)rnd.Next(1, 4);

            AiRps.RpsChosen = ai;

            string result = "";
            if (player == ai)
                result = "tied.";
            else if (((int)player % 3) + 1 == (int)ai)
                result = "lost.";
            else
                result = "won!";

            console.Text = "Computer chose " + ai.ToString()
                + System.Environment.NewLine + "You " + result;
        }
    }
}