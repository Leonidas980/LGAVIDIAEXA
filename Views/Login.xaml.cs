using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace LGAVIDIAEXA.Views
{
    public partial class Login : ContentPage
    {
        private readonly Dictionary<string, string> _valid = new()
        {
            { "estudiante", "moviles" },
            { "uisrael",    "2025"    }
        };

        public Login()
        {
            InitializeComponent();
        }

        // Botón "Iniciar sesión": valida y va a Registro con el usuario correcto
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Usa los nombres reales del XAML: UserBox y PassBox
            var u = (UserBox?.Text ?? string.Empty).Trim();
            var p = PassBox?.Text ?? string.Empty;

            if (_valid.TryGetValue(u, out var expected) && expected == p)
            {
                var usuarioConectado = $"Usuario conectado: {u}";
                await Navigation.PushAsync(new Registro(usuarioConectado));
            }
            else
            {
                await DisplayAlert("Dato incorrecto", "Usuario o contraseña incorrectos.", "OK");
            }
        }

        // Botón "Registro": permite ir directo a Registro (aunque no se haya validado)
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Si no escribió nada, pasa "invitado"
            var u = (UserBox?.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(u)) u = "invitado";

            await Navigation.PushAsync(new Registro($"Usuario conectado: {u}"));
        }
    }
}
