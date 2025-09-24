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
        }
    }
}
