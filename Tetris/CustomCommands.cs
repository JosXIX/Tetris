using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris
{
    public static class CustomCommands
    {
        static RoutedUICommand a = new RoutedUICommand("Agree", "A", typeof(CustomCommands));

        public static RoutedUICommand A { get { return a; } }
    }
}
