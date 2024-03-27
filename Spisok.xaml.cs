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
using System.Windows.Shapes;

namespace Practical_3___Player
{
    /// <summary>
    /// Логика взаимодействия для Spisok.xaml
    /// </summary>
    public partial class Spisok : Window
    {
        public string Selected { get; private set; } = null;
        public Spisok(List<string> list)
        {
            InitializeComponent();
            Mylbox.ItemsSource = list;
        }

        private void Mylbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mylbox.SelectedItem != null)
            {
                Selected = (string)Mylbox.SelectedItem;
                DialogResult = true;
                Close();
            }
        }
        private void Mylbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            if (Mylbox.SelectedItem != null)
            {
                Selected = (string)Mylbox.SelectedItem;
                DialogResult = true;
                Close();
            }
        }
    }
}
