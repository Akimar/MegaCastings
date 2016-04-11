using MegaCastings.Entities;
using NHibernate;
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

namespace MegaCastings
{
    /// <summary>
    /// Logique d'interaction pour Representatives.xaml
    /// </summary>
    public partial class RepresentativesWindow : Window
    {
        public RepresentativesWindow(Client client)
        {
            InitializeComponent();
            TbName.Text = "Représentants de : " + client.Name;
            IList<Representative> list;
            using (ISession session = MainWindow.CreateSessionFactory().OpenSession())
            {
                list = session.QueryOver<Representative>().Where(x => x.Client == client).List();
            }
            DataGrid.ItemsSource = list;
                
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
