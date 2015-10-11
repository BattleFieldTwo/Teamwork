namespace BattleField2.WpfGUI.ViewModels
{
    using System.ComponentModel;
    using System.Windows;
    using System.Collections.ObjectModel;

    using BattleField2.Models.Coordinates;
    using BattleField2.Models.Mines;
    using BattleField2.Common;
    using BattleField2.Models.Field;
    using BattleField2.Models.Player;
    using BattleField2.WpfGUI.CellDecorator;

    /// <summary>
    /// Interaction logic for BattlefieldView.xaml
    /// This is the game ViewModel class.
    /// Implements MVVM Architectural pattern.
    /// It also implements Observer design pattern as
    /// its public properties are observed by elements from XAML View bound to them.
    /// </summary>
    public class BattlefieldViewModel : Window, INotifyPropertyChanged
    {
        private string fieldSizeInput;
        private string playerName;
        private int playerScore;

        private Visibility startUpVisibility;
        private Visibility gameVisibility;
        private Visibility gameOverVisibility;

        private int detonatedMines;
        private int remainingMines;

        private Field battleField;
        private ObservableCollection<ObservableCellDecorator> cells;
        private Player currentPlayer;

        /// <summary>
        /// BattlefieldViewModel constructor
        /// </summary>
        public BattlefieldViewModel()
        {
            this.FieldSizeInput = "5";
            this.PlayerName = "YourName";

            this.StartUpVisibility = Visibility.Visible;
            this.GameVisibility = Visibility.Hidden;
            this.GameOverVisibility = Visibility.Hidden;

            this.Cells = new ObservableCollection<ObservableCellDecorator>(); 

            this.SendInitialInfo = new RelayCommand(this.OnSendInitialInfoExecute, this.OnSendInitialInfoCanExecute);
            this.DetonateCell = new RelayCommand(this.OnDetonateCellExecute, this.OnDetonateCellCanExecute);
        }

        /// <summary>
        /// The size of the field property defined by the user
        /// </summary>
        public string FieldSizeInput
        {
            get { return fieldSizeInput; }
            set
            {
                if (value != fieldSizeInput)
                {
                    fieldSizeInput = value;
                    OnPropertyChanged("FieldSizeInput");
                }
            }
        }

        /// <summary>
        /// The name of the player property defined by the user
        /// </summary>
        public string PlayerName
        {
            get { return playerName; }
            set
            {
                if (value != playerName)
                {
                    playerName = value;
                    OnPropertyChanged("PlayerName");
                }
            }
        }

        /// <summary>
        /// The current score of the player property defined by the user
        /// </summary>
        public int PlayerScore
        {
            get { return playerScore; }
            set
            {
                if (value != playerScore)
                {
                    playerScore = value;
                    OnPropertyChanged("PlayerScore");
                }
            }
        }

        /// <summary>
        /// Property defining if the start screen is visible
        /// On the start of the App it is visible
        /// It is changed to hidden when the user gives appropriate FieldSize and PlayerName input
        /// </summary>
        public Visibility StartUpVisibility
        {
            get { return startUpVisibility; }
            set
            {
                if (value != startUpVisibility)
                {
                    startUpVisibility = value;
                    OnPropertyChanged("StartUpVisibility");
                }
            }
        }

        /// <summary>
        /// Property defining if the game field is visible
        /// On the start of the App it is hidden
        /// It is changed to visible after user gives appropriate FieldSize and PlayerName input
        /// </summary>
        public Visibility GameVisibility
        {
            get { return gameVisibility; }
            set
            {
                if (value != gameVisibility)
                {
                    gameVisibility = value;
                    OnPropertyChanged("GameVisibility");
                }
            }
        }

        /// <summary>
        /// Property defining if the game over screen is visible
        /// On the start of the App it is hidden
        /// It is changed to visible after the player clears all the mines on the field
        /// </summary>
        public Visibility GameOverVisibility
        {
            get { return gameOverVisibility; }
            set
            {
                if (value != gameOverVisibility)
                {
                    gameOverVisibility = value;
                    OnPropertyChanged("GameOverVisibility");
                }
            }
        }

        /// <summary>
        /// The number of detonated mines property
        /// </summary>
        public int DetonatedMines
        {
            get { return detonatedMines; }
            set
            {
                if (value != detonatedMines)
                {
                    detonatedMines = value;
                    OnPropertyChanged("DetonatedMines");
                }
            }
        }

        /// <summary>
        /// The number of remaining mines property
        /// </summary>
        public int RemainingMines
        {
            get { return remainingMines; }
            set
            {
                if (value != remainingMines)
                {
                    remainingMines = value;
                }
            }
        }

        /// <summary>
        /// Public Field property, holding information about the field
        /// the positioning of mines, detonated and empty cells
        /// </summary>
        public Field BattleField
        {
            get { return battleField; }

            // TODO: Implement checks!
            set { battleField = value; }
        }

        /// <summary>
        /// Observable collection to which the XAML game view is binded
        /// </summary>
        public ObservableCollection<ObservableCellDecorator> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        /// <summary>
        /// Property holding information about the player
        /// </summary>
        public Player CurrentPlayer
        {
            get { return currentPlayer; }

            // TODO: Implement checks!
            set { currentPlayer = value; }
        }

        /// <summary>
        /// Command, triggered when the initial user input is send
        /// Part of the implementation of Command design pattern
        /// </summary>
        public RelayCommand SendInitialInfo { get; set; }

        /// <summary>
        /// Command, triggered when a mine is clicked (detonated)
        /// Part of the implementation of Command design pattern
        /// </summary>
        public RelayCommand DetonateCell { get; set; }

        /// <summary>
        /// Event handler for a change in the public property of the BattlefieldViewModel object instance
        /// It is part of Observer design pattern as
        /// elements of the XAML View are binded to properties from current class
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool OnSendInitialInfoCanExecute(object sender)
        {
            if (Validator.isValidPlayerName(this.PlayerName) &&
                Validator.IsValidInputFieldSize(this.FieldSizeInput))
            {
                return true;
            }
            return false;
        }

        private void OnSendInitialInfoExecute(object sender)
        {
            this.StartUpVisibility = Visibility.Hidden;
            this.GameVisibility = Visibility.Visible;

            this.InitializeGame(int.Parse(this.FieldSizeInput));
        }

        private bool OnDetonateCellCanExecute(object sender)
        {
            if (sender is ObservableCellDecorator)
            {
                return true;
            }
            return false;
        }

        private void OnDetonateCellExecute(object sender)
        {
            int row = (sender as ObservableCellDecorator).Row;
            int col = (sender as ObservableCellDecorator).Col;
            Coordinates currentCoordinates = new Coordinates(row, col);

            this.BattleField.FieldPositions = (this.battleField.FieldPositions[row, col] as IExplosive).Detonate(
                    this.BattleField.FieldPositions, currentCoordinates);
            ReloadPositions();
            this.DetonatedMines ++;

            this.CurrentPlayer.Score += this.CurrentPlayer.CalculateScore(this.RemainingMines, this.battleField.CountRemainingMines());
            this.PlayerScore = this.CurrentPlayer.Score;
            this.RemainingMines = this.battleField.CountRemainingMines();

            if (this.RemainingMines == 0)
            {
                this.GameVisibility = Visibility.Hidden;
                this.GameOverVisibility = Visibility.Visible;
            }
        }

        private void ReloadPositions()
        {
            int fieldSize = this.BattleField.FieldPositions.GetLength(0); 
            this.Cells.Clear();
            FillObservableCollection(fieldSize);
        }

        private void InitializeGame(int fieldSize)
        {
            this.BattleField = new Field(fieldSize);
            this.BattleField.GenerateField();
            this.BattleField.PositionMines();
            this.DetonatedMines = 0;
            this.RemainingMines = this.BattleField.CountRemainingMines();
            FillObservableCollection(fieldSize);
            this.CurrentPlayer = new Player(this.PlayerName);
        }

        private void FillObservableCollection(int fieldSize)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.Cells.Add(new ObservableCellDecorator(this.BattleField.FieldPositions[i, j], i, j));
                }
            }
        }
    }
}
