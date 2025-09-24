namespace MauiAppJogodaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            /* Desabilita o botão ao clicar no mesmo quadrado */
            btn.IsEnabled = false;

            if (vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else 
            {
                btn.Text = "O";
                vez = "X";
            }

            /* Verificando se o X ganhou na primeira linha */
            if (btn10.Text == "X" && btn11.Text == "X" && btn12.Text == "X") 
            {
                DisplayAlert("Parabens!", "O X ganhou!", "Ok");
                Zerar();
            }
        } // Fecha o metodo

        /* Zerar os botões */
        void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";

            /* Habilita os botões ao terminar o jogo */
            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;
        }

    } // Fecha a classe
} // fecha o NameSpace
