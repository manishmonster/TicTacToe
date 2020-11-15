using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    class Winner
    {

        public string Name { get; set; }
        public string WinnerText { get; set; }

        public Winner(string name)
        {
            Name = name;

            WinnerText = (name + " is winner!");
        }

        public Winner()
        {
        }

        
    }
}
