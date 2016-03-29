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
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private Client _addedClient;

        public Client AddedClient
        {
            get { return _addedClient; }
            set { _addedClient = value; }
        }
        

        /// <summary>
        /// Evènement click bouton "Annuler"
        /// </summary>
        private void b_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Evènement click bouton "Ok"
        /// </summary>
        private void b_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbAddress.Text) && !string.IsNullOrEmpty(tbZipCode.Text) && !string.IsNullOrEmpty(tbCity.Text))
            {
                Client newClient = new Client();
                newClient.Name = tbLastName.Text.ToUpper() + " " + tbFirstName.Text.ToUpperInvariant();
                newClient.PhoneNumber = tbPhoneNumber.Text;
                newClient.Address = tbAddress.Text;
                newClient.ZipCode = tbZipCode.Text;
                newClient.City = tbCity.Text;

                try
                {
                    ISessionFactory isessionfactory = MainWindow.CreateSessionFactory("");
                    using (ISession session = isessionfactory.OpenSession())//ouverture
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.Save(newClient);
                                transaction.Commit();
                                AddedClient = newClient;
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    MessageBox.Show("Ajout effectué avec succès ! ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.DialogResult = true;
                this.Close();
            }

            else
            {
                MessageBox.Show("Merci de remplir tous les champs.");
            }
        }
    }
}
