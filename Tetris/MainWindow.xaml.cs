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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("./Tetris/assets/tileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/tileRed.png", UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("./Tetris/assets/blockEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockI.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockJ.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockL.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockO.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockS.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockT.png", UriKind.Relative)),
            new BitmapImage(new Uri("./Tetris/assets/blockZ.png", UriKind.Relative))
        };

        private readonly Image[,] imageControls;
        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayDecrease = 25;

        private GameState gameState = new GameState();

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
            if (gameState.GameOver)
            {
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
                            MoveToHighscore();
                            break;
                    }
                }
                if (btn_Highscore.Tag.ToString() == "1")
                {
                    btn_PlayAgain.Background = new SolidColorBrush(Colors.Green);
                    btn_NameForHighscore.Background = new SolidColorBrush(Colors.Green);
                    btn_PlayAgain.Tag = "0";
                    btn_NameForHighscore.Tag = "0";

                    switch (e.Key)
                    {
                        case Key.A:
                            ShowHighscoreMenu();
                            break;
                        case Key.Down:
                            MoveToNameForHighscore();
                            break;
                        case Key.Up:
                            MoveToPlayAgain();
                            break;
                    }

                    if (HighscoreMenu.Tag.ToString() == "1")
                    {
                        switch (e.Key)
                        {
                            case Key.B:
                                ShowGameOverMenu();
                                break;
                        }
                    }
                }
                if (btn_NameForHighscore.Tag.ToString() == "1")
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
                            MoveToHighscore();
                            break;
                    }
                }
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
            HighscoreMenu.Tag = "0";
        }

        public void ShowHighscoreMenu()
        {
            HighscoreMenu.Visibility = Visibility.Visible;
            HighscoreMenu.Tag = "1";
            GameOverMenu.Visibility = Visibility.Hidden;

            string sHighscores = System.IO.File.ReadAllText(". - Kopie (2)/Tetris/assets/highscore.txt");

            tb_HighscoreRanking.Text = sHighscores;
        }

        public void ShowNameForHighscoreMenu()
        {

        }

        public void MoveToPlayAgain()
        {
            btn_PlayAgain.Background = new SolidColorBrush(Colors.LightGreen);
            btn_PlayAgain.Tag = "1";

            btn_Highscore.Background = new SolidColorBrush(Colors.Green);
            btn_Highscore.Tag = "0";
        }

        public void MoveToHighscore()
        {
            btn_Highscore.Background = new SolidColorBrush(Colors.LightGreen);
            btn_Highscore.Tag = "1";

            btn_PlayAgain.Background = new SolidColorBrush(Colors.Green);
            btn_NameForHighscore.Background = new SolidColorBrush(Colors.Green);
            btn_PlayAgain.Tag = "0";
            btn_NameForHighscore.Tag = "0";
        }

        public void MoveToNameForHighscore()
        {
            btn_NameForHighscore.Background = new SolidColorBrush(Colors.LightGreen);
            btn_NameForHighscore.Tag = "1";

            btn_Highscore.Background = new SolidColorBrush(Colors.Green);
            btn_Highscore.Tag = "0";
        }
    }
}
