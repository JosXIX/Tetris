using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris
{
    public class MoveCursor
    {
        private MainWindow mainWindow = new MainWindow();

        public void MoveToPlayAgain()
        {
            mainWindow.btn_PlayAgain.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_PlayAgain.Tag = "1";

            mainWindow.btn_Highscore.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Highscore.Tag = "0";
        }

        public void MoveToHighscore()
        {
            mainWindow.btn_Highscore.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_Highscore.Tag = "1";

            mainWindow.btn_PlayAgain.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_NameForHighscore.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_PlayAgain.Tag = "0";
            mainWindow.btn_NameForHighscore.Tag = "0";
        }

        public void MoveToNameForHighscore()
        {
            mainWindow.btn_NameForHighscore.Background = new SolidColorBrush(Colors.LightGreen);
            mainWindow.btn_NameForHighscore.Tag = "1";

            mainWindow.btn_Highscore.Background = new SolidColorBrush(Colors.Green);
            mainWindow.btn_Highscore.Tag = "0";
        }
    }
}
