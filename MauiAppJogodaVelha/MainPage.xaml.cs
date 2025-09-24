using System;
using Microsoft.Maui.Controls;

namespace MauiAppJogodaVelha
{
    public partial class MainPage : ContentPage
    {
        // De quem é a vez (inicia com X)
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        // Evento de clique em qualquer botão do tabuleiro
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Evita clique duplo
            btn.IsEnabled = false;

            // Coloca o símbolo atual
            btn.Text = vez;

            // Guarda quem jogou agora
            string jogadorAtual = vez;

            // Alterna a vez
            vez = (vez == "X") ? "O" : "X";

            // Verifica vitória para o jogador que acabou de jogar
            await CheckWinAsync(jogadorAtual);
        }

        // Checa todas as combinações de vitória para o jogador passado
        async System.Threading.Tasks.Task<bool> CheckWinAsync(string jogador)
        {
            // Horizontal
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador ||
                btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador ||
                btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador ||
                // Vertical
                btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador ||
                btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador ||
                btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador ||
                // Diagonais
                btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador ||
                btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador)
            {
                // Mostra alerta de vitória
                await DisplayAlert("Parabéns!", $"O {jogador} ganhou!", "Ok");

                // Limpa todo o tabuleiro (chama método seguro)
                LimparTabuleiro();

                return true;
            }

            return false;
        }

        // Limpa todo o tabuleiro com segurança (executa na UI thread e checa nulls)
        void LimparTabuleiro()
        {
            Dispatcher.Dispatch(() =>
            {
                Button[] botoes = new Button[] {
                    btn10, btn11, btn12,
                    btn20, btn21, btn22,
                    btn30, btn31, btn32
                };

                foreach (var b in botoes)
                {
                    if (b == null)
                    {
                        // Log para debug (caso x:Name esteja diferente do XAML)
                        System.Diagnostics.Debug.WriteLine("LimparTabuleiro: encontrado botão null");
                        continue;
                    }
                    b.Text = string.Empty;
                    b.IsEnabled = true;
                }

                // Reset da vez para X
                vez = "X";
            });
        }
    }
}
