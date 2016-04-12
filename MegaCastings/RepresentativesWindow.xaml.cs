using MegaCastings.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MegaCastings
{
    /// <summary>
    /// Logique d'interaction pour Representatives.xaml
    /// </summary>
    public partial class RepresentativesWindow : Window
    {
        private BindingList<Representative> BindingRepresentatives;

        private Client _Client;

        public RepresentativesWindow(Client client)
        {
            InitializeComponent();
            _Client = client;
            TbName.Text = "Représentants de : " + client.Name;

            using (ISession session = MainWindow.CreateSessionFactory().OpenSession())
            {
                BindingRepresentatives = new BindingList<Representative>(session.QueryOver<Representative>().Where(x => x.Client == client).List());
            }
            DataGrid.ItemsSource = BindingRepresentatives;

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            RepresentativeManagement windows = new RepresentativeManagement(_Client);
            if (windows.ShowDialog() == true)
            {
                BindingRepresentatives.Add(windows.CurrentRepresentative);
            }

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                Representative toModify = DataGrid.SelectedItem as Representative;

                RepresentativeManagement windows = new RepresentativeManagement(_Client, toModify);
                if (windows.ShowDialog() == true)
                {
                    try
                    {
                        BindingRepresentatives[BindingRepresentatives.IndexOf(toModify)] = windows.CurrentRepresentative;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
