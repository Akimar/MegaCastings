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
    public partial class ClientManagement : Window
    {

        #region Attributes & Properties


        private Client _AddedClient;

        public Client AddedClient
        {
            get { return _AddedClient; }
            set { _AddedClient = value; }
        }

        #endregion

        #region Constructors

        public ClientManagement()
        {
            InitializeComponent();
            TbTitle.Text = "Ajouter un client";
        }

        public ClientManagement(Client toModifie)
        {
            InitializeComponent();

            AddedClient = toModifie;
            tbName.Text = toModifie.Name;
            tbPhoneNumber.Text = toModifie.PhoneNumber;
            tbAddress.Text = toModifie.Address;
            tbZipCode.Text = toModifie.ZipCode;
            tbCity.Text = toModifie.City;
            TbTitle.Text = "Modifier un client";
        }

        #endregion

        #region Methods
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
            Client newClient = null;
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbAddress.Text) && !string.IsNullOrEmpty(tbZipCode.Text) && !string.IsNullOrEmpty(tbCity.Text))
            {
                if (AddedClient == null)
                {
                    newClient = new Client();
                }

                else
                {
                    newClient = AddedClient;
                }

                newClient.Name = tbName.Text;
                newClient.PhoneNumber = tbPhoneNumber.Text;
                newClient.Address = tbAddress.Text;
                newClient.ZipCode = tbZipCode.Text;
                newClient.City = tbCity.Text;

                try
                {
                    ISessionFactory isessionfactory = MainWindow.CreateSessionFactory();
                    using (ISession session = isessionfactory.OpenSession())//ouverture
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.SaveOrUpdate(newClient);
                                transaction.Commit();
                                AddedClient = newClient;
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                        session.Close();
                    }
                    MessageBox.Show("Effectué avec succès ! ");

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

        #endregion
    }
}
