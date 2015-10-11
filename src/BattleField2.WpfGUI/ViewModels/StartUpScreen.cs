﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BattleField2.Models.Coordinates;
using BattleField2.Models.Mines;

namespace BattleField2.WpfGUI.ViewModels
{

    using BattleField2.Common;
    using BattleField2.Models.Field;
    using System.Collections.ObjectModel;
    using BattleField2.Models.Player;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class StartUpScreen : Window, INotifyPropertyChanged
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
        private ObservableCollection<ObservableCell> cells;
        private Player currentPlayer;

        public StartUpScreen()
        {
            this.FieldSizeInput = "5";
            this.PlayerName = "YourName";

            this.StartUpVisibility = Visibility.Visible;
            this.GameVisibility = Visibility.Hidden;
            this.GameOverVisibility = Visibility.Hidden;

            this.Cells = new ObservableCollection<ObservableCell>(); 

            this.SendInitialInfo = new RelayCommand(this.OnSendInitialInfoExecute, this.OnSendInitialInfoCanExecute);
            this.DetonateCell = new RelayCommand(this.OnDetonateCellExecute, this.OnDetonateCellCanExecute);
        }

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

        public Field BattleField
        {
            get { return battleField; }

            // TODO: Implement checks!
            set { battleField = value; }
        }

        public ObservableCollection<ObservableCell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Player CurrentPlayer { get; set; }

        public RelayCommand SendInitialInfo { get; set; }
        public RelayCommand DetonateCell { get; set; }

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
            if (sender is ObservableCell)
            {
                return true;
            }
            return false;
        }

        private void OnDetonateCellExecute(object sender)
        {
            int row = (sender as ObservableCell).Row;
            int col = (sender as ObservableCell).Col;
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
                    this.Cells.Add(new ObservableCell(this.BattleField.FieldPositions[i, j], i, j));
                }
            }
        }
    }
}
