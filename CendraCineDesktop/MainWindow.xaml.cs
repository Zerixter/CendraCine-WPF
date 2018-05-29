using CendraCineDesktop.Models;
using CendraCineDesktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CendraCineDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApiService api;
        private List<Movie> Movies;

        public MainWindow()
        {
            InitializeComponent();
            api = new ApiService();
        }

        private async void LoginClicked(object sender, RoutedEventArgs e)
        {
            bool login = await api.Login();

            if (login)
            {
                MessageBox.Show("T'has loguejat sense cap problema!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Ha sorgit un error al intentar fer login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadClicked(object sender, RoutedEventArgs e)
        {
            Movies = await api.GetMovies();

            foreach (Movie movie in Movies)
            {
                MoviesListBox.Items.Add(movie);
            }
        }
    }
}
