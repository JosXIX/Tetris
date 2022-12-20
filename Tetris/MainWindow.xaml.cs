using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.CodeDom;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileEmpty.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileCyan.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileBlue.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileOrange.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileYellow.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileGreen.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tilePurple.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/tileRed.png", UriKind.Absolute))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockEmpty.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockI.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockJ.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockL.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockO.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockS.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockT.png", UriKind.Absolute)),
            new BitmapImage(new Uri("E:/Schule/Tetris/Tetris/assets/blockZ.png", UriKind.Absolute))
        };

        private readonly Image[,] imageControls;
        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayDecrease = 25;
        private int[] highscores = new int[9];
        private string[] players = new string[9];
        private string[] highscorelines = new string[9];

        private GameState gameState = new GameState();
        private MoveCursor moveCursor = new MoveCursor();
        private MoveOnKeyBoard moveOnKeyBoard = new MoveOnKeyBoard();
        private KeyBoard keyBoard = new KeyBoard();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }

        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.row, grid.colum];
            int cellSize = 25;

            for (int r = 0; r < grid.row; r++)
            {
                for (int c = 0; c < grid.colum; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
            return imageControls;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.row; r++)
            {
                for (int c = 0; c < grid.colum; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePosition())
            {
                imageControls[p.row, p.colum].Opacity = 1;
                imageControls[p.row, p.colum].Source = tileImages[block.Id];
            }
        }

        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        private void DrawStorageBlock(Block heldBlock)
        {
            if (heldBlock == null)
            {
                HoldImage.Source = blockImages[0];
            }
            else
            {
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }

        private void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            foreach (Position p in block.TilePosition())
            {
                imageControls[p.row + dropDistance, p.colum].Opacity = 0.25;
                imageControls[p.row + dropDistance, p.colum].Source = tileImages[block.Id];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.FallingBlock);
            DrawBlock(gameState.FallingBlock);
            DrawNextBlock(gameState.BlockQueue);
            ScoreText.Text = $"Score: {gameState.Score}";
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
            DrawStorageBlock(gameState.StorageBlock);
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
        }

        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gameState.Score * delayDecrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string sPlayerName = "";

            if (gameState.GameOver)
            {
                #region Highscore
                if (btn_Highscore.Tag.ToString() == "1" && HighscoreMenu.Tag.ToString() == "0")
                {
                    btn_PlayAgain.Background = new SolidColorBrush(Colors.Green);
                    btn_NameForHighscore.Background = new SolidColorBrush(Colors.Green);
                    btn_PlayAgain.Tag = "0";
                    btn_NameForHighscore.Tag = "0";

                    switch (e.Key)
                    {
                        case Key.A:
                            ShowHighscoreMenu(gameState.Score, sPlayerName);
                            break;
                        case Key.Down:
                            moveCursor.MoveToNameForHighscore();
                            break;
                        case Key.Up:
                            moveCursor.MoveToPlayAgain();
                            break;
                    }
                }
                else if (btn_Highscore.Tag.ToString() == "1" && HighscoreMenu.Tag.ToString() == "1")
                {
                    switch (e.Key)
                    {
                        case Key.B:
                            ShowGameOverMenu();
                            break;
                    }
                }
                #endregion

                #region PlayAgain
                if (btn_PlayAgain.Tag.ToString() == "1")
                {
                    btn_Highscore.Background = new SolidColorBrush(Colors.Green);
                    btn_NameForHighscore.Background = new SolidColorBrush(Colors.Green);
                    btn_Highscore.Tag = "0";
                    btn_NameForHighscore.Tag = "0";

                    switch (e.Key)
                    {
                        case Key.A:
                            PlayAgain();
                            break;
                        case Key.Down:
                            moveCursor.MoveToHighscore();
                            break;
                    }
                }
#endregion

                #region NameForHighscore
                if (btn_NameForHighscore.Tag.ToString() == "1" && NameForHighscoreMenu.Tag.ToString() == "0")
                {
                    btn_PlayAgain.Background = new SolidColorBrush(Colors.Green);
                    btn_Highscore.Background = new SolidColorBrush(Colors.Green);
                    btn_PlayAgain.Tag = "0";
                    btn_Highscore.Tag = "0";

                    switch (e.Key)
                    {
                        case Key.A:
                            ShowNameForHighscoreMenu();
                            break;
                        case Key.Up:
                            moveCursor.MoveToHighscore();
                            break;
                    }
                }
                else if (btn_NameForHighscore.Tag.ToString() == "1" && NameForHighscoreMenu.Tag.ToString() == "1")
                {
                    #region Uppercase
                    if (btn_Uppercase.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetUppercase();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToBackToMainMenu();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToQ();
                                break;
                        }
                    }
                    #endregion

                    #region Space
                    if (btn_Space.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetSpace();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToBackToMainMenu();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToB();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToAgree();
                                break;
                        }
                    }
                    #endregion

                    #region Agree
                    if (btn_Agree.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                sPlayerName = keyBoard.GetAgree();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToBack();
                                break;
                        }
                    }
                    #endregion

                    #region Back
                    if (btn_Back.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetBack();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToUE();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToAgree();
                                break;
                        }
                    }
                    #endregion

                    #region BackToMainMenu
                    if (btn_BackToMainMenu.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                ShowGameOverMenu();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToUppercase();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                        }
                    }
                    #endregion

                    #region Letters

                    #region Q
                    if (btn_Q.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetQ();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToUppercase();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToA();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToW();
                                break;
                        }
                    }
                    #endregion

                    #region W
                    if (btn_W.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetW();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToQ();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToS();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToE();
                                break;
                        }
                    }
                    #endregion

                    #region E
                    if (btn_E.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetE();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToW();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToD();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToR();
                                break;
                        }
                    }
                    #endregion

                    #region R
                    if (btn_R.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetR();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToE();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToF();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToT();
                                break;
                        }
                    }
                    #endregion

                    #region T
                    if (btn_T.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetT();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToR();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToG();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToZ();
                                break;
                        }
                    }
                    #endregion

                    #region Z
                    if (btn_Z.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetZ();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToT();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToH();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToU();
                                break;
                        }
                    }
                    #endregion

                    #region U
                    if (btn_U.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetU();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToZ();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToJ();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToI();
                                break;
                        }
                    }
                    #endregion

                    #region I
                    if (btn_I.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetI();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToU();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToK();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToUE();
                                break;
                        }
                    }
                    #endregion

                    #region Ü
                    if (btn_UE.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetUE();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToI();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToL();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToBack();
                                break;
                        }
                    }
                    #endregion

                    #region A
                    if (btn_A.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetA();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToUppercase();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToY();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToS();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToQ();
                                break;
                        }
                    }
                    #endregion

                    #region S
                    if (btn_S.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetS();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToA();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToX();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToD();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToW();
                                break;
                        }
                    }
                    #endregion

                    #region D
                    if (btn_D.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetD();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToS();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToC();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToF();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToE();
                                break;
                        }
                    }
                    #endregion

                    #region F
                    if (btn_F.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetF();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToD();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToV();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToG();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToR();
                                break;
                        }
                    }
                    #endregion

                    #region G
                    if (btn_G.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetG();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToF();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToB();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToH();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToT();
                                break;
                        }
                    }
                    #endregion

                    #region H
                    if (btn_H.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetH();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToG();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToN();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToJ();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToZ();
                                break;
                        }
                    }
                    #endregion

                    #region J
                    if (btn_J.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetJ();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToH();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToM();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToK();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToU();
                                break;
                        }
                    }
                    #endregion

                    #region K
                    if (btn_K.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetK();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToJ();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToO();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToL();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToI();
                                break;
                        }
                    }
                    #endregion

                    #region L
                    if (btn_L.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetL();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToK();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToP();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToOE();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToUE();
                                break;
                        }
                    }
                    #endregion

                    #region Ö
                    if (btn_OE.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetOE();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToL();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToAE();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToAgree();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToBack();
                                break;
                        }
                    }
                    #endregion

                    #region Y
                    if (btn_Y.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetY();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToUppercase();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToX();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToA();
                                break;
                        }
                    }
                    #endregion

                    #region X
                    if (btn_X.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetX();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToY();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToC();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToS();
                                break;
                        }
                    }
                    #endregion

                    #region C
                    if (btn_C.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetC();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToX();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToV();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToD();
                                break;
                        }
                    }
                    #endregion

                    #region V
                    if (btn_V.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetV();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToC();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToB();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToF();
                                break;
                        }
                    }
                    #endregion

                    #region B
                    if (btn_B.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetB();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToV();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToN();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToG();
                                break;
                        }
                    }
                    #endregion

                    #region N
                    if (btn_N.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetN();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToB();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToM();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToH();
                                break;
                        }
                    }
                    #endregion

                    #region M
                    if (btn_M.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetM();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToN();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToO();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToJ();
                                break;
                        }
                    }
                    #endregion

                    #region O
                    if (btn_O.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetO();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToM();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToP();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToK();
                                break;
                        }
                    }
                    #endregion

                    #region P
                    if (btn_P.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetP();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToO();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToAE();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToL();
                                break;
                        }
                    }
                    #endregion

                    #region Ä
                    if (btn_AE.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                            case Key.A:
                                keyBoard.GetAE();
                                break;
                            case Key.Left:
                                moveOnKeyBoard.MoveToP();
                                break;
                            case Key.Down:
                                moveOnKeyBoard.MoveToSpace();
                                break;
                            case Key.Right:
                                moveOnKeyBoard.MoveToAgree();
                                break;
                            case Key.Up:
                                moveOnKeyBoard.MoveToOE();
                                break;
                        }
                    }
                    #endregion

                    #endregion
                }
                #endregion
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Left:
                        gameState.MoveBlockLeft();
                        break;
                    case Key.Right:
                        gameState.MoveBlockRight();
                        break;
                    case Key.Down:
                        gameState.MoveBlockDown();
                        break;
                    case Key.A:
                        gameState.RotateBlockCW();
                        break;
                    case Key.B:
                        gameState.RotateBlockCCW();
                        break;
                    case Key.Up:
                        gameState.StoreBlock();
                        break;
                    case Key.Space:
                        gameState.DropBlock();
                        break;
                    default:
                        return;
                }
                Draw(gameState);
            }
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        private async void PlayAgain()
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }

        public void ShowGameOverMenu()
        {
            GameOverMenu.Visibility = Visibility.Visible;
            HighscoreMenu.Visibility = Visibility.Hidden;
            NameForHighscoreMenu.Visibility = Visibility.Hidden;
            HighscoreMenu.Tag = "0";
            NameForHighscoreMenu.Tag = "0";
        }

        public void ShowHighscoreMenu(int Score, string Player)
        {
            int value;
            int count = 0;
            string name;
            string path = @"E:/Schule/Tetris/Tetris/assets/highscore.txt";
            using System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            for (int i = highscores.Length; i < 0; i--)
            {
                if (Score > highscores[i])
                {
                    value = highscores[i];
                    highscores[i] = Score;
                    Score = value;

                    name = players[i];
                    players[i] = Player;
                    Player = name;

                    highscorelines[i] = $"#{i}{players[i]}: {Convert.ToString(highscores[i])}";

                    break;
                }
                count++;
            }

            for (int i = highscores.Length - count; i < highscores.Length; i++)
            {
                value = highscores[i];
                highscores[i] = Score;
                Score = value;

                name = players[i];
                players[i] = Player;
                Player = name;

                highscorelines[i] = $"#{i}{players[i]}: {Convert.ToString(highscores[i])}";
            }

            for (int i = 0; i < highscorelines.Length; i++)
            {
                file.WriteLine(highscorelines[i]);
            }

            HighscoreMenu.Visibility = Visibility.Visible;
            HighscoreMenu.Tag = "1";
            GameOverMenu.Visibility = Visibility.Hidden;

            string sHighscores = System.IO.File.ReadAllText("E:/Schule/Tetris/Tetris/assets/highscore.txt");

            tb_HighscoreRanking.Text = sHighscores;
        }

        public void ShowNameForHighscoreMenu()
        {
            NameForHighscoreMenu.Visibility = Visibility.Visible;
            NameForHighscoreMenu.Tag = "1";
            GameOverMenu.Visibility = Visibility.Hidden;
        }
    }
}
