using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Compulsory_PrimeGen;

namespace GUI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ParallelButtonClick(object sender, RoutedEventArgs e)
        {
            if (!long.TryParse(lower.Text, out var l))
                MessageBox.Show($"{lower.Text} is not a number", "Parsing error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            if (!long.TryParse(upper.Text, out var u))
                MessageBox.Show($"{upper.Text} is not a number", "Parsing error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

            List<long> primes = null;
            await Task.Run(() => { primes = Class1.GetPrimesParallel(l, u); }).ConfigureAwait(false);


            Dispatcher.Invoke(() =>
            {
                foreach (var prime in primes) ListBox.Items.Add(prime);
            });
        }

        private async void SequentialButtonClick(object sender, RoutedEventArgs e)
        {
            if (!long.TryParse(lower.Text, out var l))
                MessageBox.Show($"{lower.Text} is not a number", "Parsing error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            if (!long.TryParse(upper.Text, out var u))
                MessageBox.Show($"{upper.Text} is not a number", "Parsing error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

            List<long> primes = null;
            await Task.Run(() => { primes = Class1.GetPrimesSequential(l, u); }).ConfigureAwait(false);


            Dispatcher.Invoke(() =>
            {
                foreach (var prime in primes) ListBox.Items.Add(prime);
            });
        }
    }
}