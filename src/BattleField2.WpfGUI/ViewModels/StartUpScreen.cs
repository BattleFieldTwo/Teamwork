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

namespace BattleField2.WpfGUI.ViewModels
{

    using BattleField2.Common;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class StartUpScreen : Window, INotifyPropertyChanged
    {
        private string fieldSizeInput = "5";
        private string playerNameImput = "YourName";
        private Visibility startUpVisibility = Visibility.Visible;
        private Visibility gameVisibility = Visibility.Hidden;
        private Visibility gameOverVisibility = Visibility.Visible; 

        public StartUpScreen()
        {
            this.SendInitialInfo = new RelayCommand(this.OnSendInitialInfoExecute, this.OnSendInitialInfoCanExecute);
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
        }
    }
}
