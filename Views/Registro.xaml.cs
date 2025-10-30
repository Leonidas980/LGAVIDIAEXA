using Microsoft.Maui.Controls;
using System;

using Microsoft.Maui.Controls;
using System;

namespace LGAVIDIAEXA.Views
{
    public partial class Registro : ContentPage
    {
        private const decimal CostoCurso = 1500m;

        // Constructor vacío requerido por XAML
        public Registro()
        {
            InitializeComponent();

            // Buscar por nombre (evita problemas de campos generados)
            var fecha = this.FindByName<DatePicker>("FechaPick");
            if (fecha != null) fecha.Date = DateTime.Today;
        }

        // Constructor que recibe el "Usuario conectado"
        public Registro(string usuarioConectado) : this()
        {
            if (this.FindByName<Label>("UsuarioConectadoLbl") is Label lbl)
                lbl.Text = usuarioConectado;
        }


        private static decimal CalcularPagoMensual(decimal inicial)
        {
            var restante = Math.Max(0m, CostoCurso - inicial);
            var cuota = restante / 4m;
            var recargo = 0.04m * CostoCurso;
            return Math.Round(cuota + recargo, 2);
        }

        private async void OnVerResumenClicked(object sender, EventArgs e)
        {
            var fechaPick = this.FindByName<DatePicker>("FechaPick");
            var paisPick = this.FindByName<Picker>("PaisPick");
            var ciudadPick = this.FindByName<Picker>("CiudadPick");
            var inicialEnt = this.FindByName<Entry>("InicialEntry");
            var pagoRO = this.FindByName<Entry>("PagoMensualEntryRO");
            var nomEnt = this.FindByName<Entry>("NombreEntryBox");
            var apeEnt = this.FindByName<Entry>("ApellidoEntryBox");
            var edadEnt = this.FindByName<Entry>("EdadEntryBox");

            if (inicialEnt == null || !decimal.TryParse(inicialEnt.Text, out var inicial)
                || inicial < 0 || inicial > CostoCurso)
            {
                await DisplayAlert("Dato inválido", "Ingresa un monto inicial entre 0 y 1500.", "OK");
                return;
            }

            var pagoMensual = CalcularPagoMensual(inicial);
            if (pagoRO != null) pagoRO.Text = pagoMensual.ToString("0.00");
            var total = inicial + 4 * pagoMensual;

            await Navigation.PushAsync(new Resumen(
                this.FindByName<Label>("UsuarioConectadoLbl")?.Text ?? "",
                nomEnt?.Text ?? "", apeEnt?.Text ?? "", edadEnt?.Text ?? "",
                fechaPick?.Date ?? DateTime.Today,
                paisPick?.SelectedItem?.ToString() ?? "",
                ciudadPick?.SelectedItem?.ToString() ?? "",
                inicial, pagoMensual, total));
        }
    }
}
