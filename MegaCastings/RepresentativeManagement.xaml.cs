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
    /// Logique d'interaction pour RepresentativeManagement.xaml
    /// </summary>
    public partial class RepresentativeManagement : Window
    {
        public Representative CurrentRepresentative{ get; set; }


        public RepresentativeManagement(Client client)
        {
            InitializeComponent();
            CurrentRepresentative = new Representative() {Client = client };
        }

        public RepresentativeManagement(Client client, Representative rp)
        {
            InitializeComponent();
            CurrentRepresentative = rp;
        }

        private void b_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbLastName.Text))
            {
                try
                {
                    ISessionFactory isessionfactory = MainWindow.CreateSessionFactory();
                    using (ISession session = isessionfactory.OpenSession())//ouverture
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.SaveOrUpdate(CurrentRepresentative);
                                transaction.Commit();

                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                        session.Close();
                    }
                    MessageBox.Show("Effectué avec succès !");

                }
                catch
                {
                    throw;
                }

                this.DialogResult = true;
                this.Close();
            }
        }

        private void b_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
