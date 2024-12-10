using System;
using System.Text;
using System.Windows;

namespace z4
{
    public partial class MainWindow : Window
    {
        private string wygenerowaneHaslo = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerujHaslo_Click(object sender, RoutedEventArgs e)
        {
            int ileZnakow;
            if (!int.TryParse(txtIleZnakow.Text, out ileZnakow) || ileZnakow <= 0)
            {
                MessageBox.Show("Wprowadź prawidłową liczbę znaków.");
                return;
            }

            string maleLitery = "abcdefghijklmnopqrstuvwxyz";
            string wielkieLitery = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string znakiSpecjalne = "!@#$%^&*()_+-=";

            StringBuilder haslo = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < ileZnakow; i++)
            {
                haslo.Append(maleLitery[random.Next(maleLitery.Length)]);
            }

            if (chkMaleWielkieLitery.IsChecked == true)
            {
                haslo[0] = wielkieLitery[random.Next(wielkieLitery.Length)];
            }

            if (chkCyfry.IsChecked == true && ileZnakow > 1)
            {
                haslo[1] = cyfry[random.Next(cyfry.Length)];
            }

            if (chkZnakiSpecjalne.IsChecked == true && ileZnakow > 2)
            {
                haslo[2] = znakiSpecjalne[random.Next(znakiSpecjalne.Length)];
            }

            wygenerowaneHaslo = haslo.ToString();
            MessageBox.Show("Wygenerowane hasło: " + wygenerowaneHaslo);
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string stanowisko = (cmbStanowisko.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            string komunikat = $"Imię: {imie}\nNazwisko: {nazwisko}\nStanowisko: {stanowisko}\nHasło: {wygenerowaneHaslo}";
            MessageBox.Show(komunikat);
        }
    }
}
