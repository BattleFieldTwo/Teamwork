using System;
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
using BattleField2.Models.Cells;
using BattleField2.Models.Field;
using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class StartUpScreen : Window, INotifyPropertyChanged
    {
        private string fieldSizeInput = "5";
        private string playerNameImput = "YourName";
        private Visibility startUpVisibility = Visibility.Hidden;
        private Visibility gameVisibility = Visibility.Visible;
        private Visibility gameOverVisibility = Visibility.Visible;
        private int detonatedMines;

        private Field battleField;

        private ObservableCollection<ObservableCell> cells;

        public int DetonatedMines
        {
            get { return detonatedMines; }
            set { detonatedMines = value; }
        }
        

        public ObservableCollection<ObservableCell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public RelayCommand DetonateCell { get; set; }

        public StartUpScreen()
        {
            this.DetonateCell = new RelayCommand(this.OnDetonateCellExecute, this.OnDetonateCellCanExecute);
            int fieldSize = 5;
            this.BattleField = new Field(fieldSize);
            this.Cells = new ObservableCollection<ObservableCell>();
            this.DetonatedMines = 0;
            this.BattleField.DetonatedMines = 0;

            this.BattleField.GenerateField();

            this.BattleField.PositionMines();

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.Cells.Add(new ObservableCell(this.BattleField.FieldPositions[i, j], i, j));
                }
            }
            
            // this.SendInitialInfo = new RelayCommand(this.OnSendInitialInfoExecute, this.OnSendInitialInfoCanExecute);
        }



       

        public RelayCommand SendInitialInfo { get; set; }

        //public void SendInitialInfo()
        //{
        //    if (Validator.isValidPlayerName(this.PlayerNameInput) &&
        //        Validator.IsValidInputFieldSize(this.FieldSizeInput))
        //    {
        //    }
        //}

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

        public string PlayerNameInput
        {
            get { return playerNameImput; }
            set
            {
                if (value != playerNameImput)
                {
                    playerNameImput = value;
                    OnPropertyChanged("PlayerNameInput");
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

        public Field BattleField
        {
            get { return battleField; }

            // TODO: Implement checks!
            set { battleField = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool OnSendInitialInfoCanExecute(object sender)
        {
            if (Validator.isValidPlayerName(this.PlayerNameInput) &&
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

            this.InitializeGame();
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

            this.BattleField.FieldPositions = (this.battleField.FieldPositions[row, col] as Explosive).Detonate(
                    this.BattleField.FieldPositions, currentCoordinates);
            ReloadPositions();
        }

        private void ReloadPositions()
        {
            int fieldSize = this.BattleField.FieldPositions.GetLength(0); 
            
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.Cells.Add(new ObservableCell(this.BattleField.FieldPositions[i, j], i, j));
                }
            }
        }

        private void InitializeGame()
        {
            int fieldSize = int.Parse(this.FieldSizeInput);
            this.BattleField = new Field(fieldSize);
            this.Cells = new ObservableCollection<ObservableCell>();

            this.battleField.GenerateField();

            this.battleField.PositionMines();

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
