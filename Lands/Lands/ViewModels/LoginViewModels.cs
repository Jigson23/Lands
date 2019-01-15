
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System;
    using Views;


    public class LoginViewModels : BaseViewModels
    {


        #region Atributes
        private string pwd;
        private string email;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Pwd
        {
            get { return this.pwd; }
            set { SetValue(ref this.pwd, value); }
        }
        public bool IsRunning {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRecordar { get; set; }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Comandos
        public ICommand LoginComand { get { return new RelayCommand(Login); } }


        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No ha ingresado su Email.",
                    "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(this.Pwd))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No ha ingresado su Password.",
                    "Aceptar");
                return;
            }

            this.IsEnabled = false;
            this.IsRunning = true;

            if (this.Email != "nitrojaker@gmail.com" || this.Pwd != "12345")
            {
                this.IsEnabled = true;
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email y Pwd incorectos.",
                    "Aceptar");
                this.Pwd = String.Empty;
                return;
            }

            this.IsEnabled = true;
            this.IsRunning = false;


            //await Application.Current.MainPage.DisplayAlert(
            //         "Ok",
            //          "Correcto!!",
            //          "Aceptar");
            //return;

            this.Email = string.Empty;
            this.Pwd = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }

        public ICommand RegistarComand { get; set; }
        #endregion

        #region constructores
        public LoginViewModels()
        {
            this.IsRecordar = true;
            this.IsEnabled = true;

            Email = "nitrojaker@gmail.com";
            Pwd = "12345";

            // http:restcountries.eu/rest/v2/all
        }
        #endregion
    }
}
