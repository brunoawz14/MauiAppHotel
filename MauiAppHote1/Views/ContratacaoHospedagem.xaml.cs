using MauiAppHote1.Models;

namespace MauiAppHote1.Views;

public partial class ContrataçãoHospedagem : ContentPage
{

    App PropriedadesApp;

    public ContrataçãoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QtnAdultos = Convert.ToInt32(stp_adultos.Value),
                QtnCriancas = Convert.ToInt32(stp_criancas.Value),
                DatacheckIn = dtpck_checkin.Date,
                DatacheckOut = dtpck_checkout.Date

            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h 
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime dataSelecionada = elemento.Date;

        dtpck_checkout.MinimumDate = dataSelecionada.AddDays(1);
        dtpck_checkout.MaximumDate = dataSelecionada.AddMonths(6);
    }
}