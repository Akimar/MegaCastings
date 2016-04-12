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
    /// Interaction logic for CollaboratorManagement.xaml
    /// </summary>
    public partial class CollaboratorManagement : Window
    {

        #region Attributes & Properties

        private Collaborator _CurrentCollaborator;


        /// <summary>
        /// Affecte ou obtient le partenaire en cours de modification
        /// </summary>
        public Collaborator CurrentCollaborator
        {
            get { return _CurrentCollaborator; }
            set { _CurrentCollaborator = value; }
        }

        #endregion

        #region Constructors

        public CollaboratorManagement()
        {
            CurrentCollaborator = new Collaborator();
            InitializeComponent();
            TbTitle.Text = "Ajouter un partenaire";
        }



        public CollaboratorManagement(Collaborator toModify)
        {
          
            CurrentCollaborator = toModify;
            InitializeComponent();
            TbTitle.Text = "Modifier un partenaire";

        }

        #endregion

        #region Events
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
           
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbAddress.Text) && !string.IsNullOrEmpty(tbZipCode.Text) && !string.IsNullOrEmpty(tbCity.Text))
            {
              
                if(CurrentCollaborator.Id == 0)
                {
                    //Login => 3 premières lettres du nom + 2 premiers caractères du code postal 
                    //Si le nom fait moins de trois caractères, le nom est pris en entier 
                    if (CurrentCollaborator.Name.Length >= 3)
                    {
                        CurrentCollaborator.Login = String.Format("{0}{1}", CurrentCollaborator.Name.Substring(0, 3), CurrentCollaborator.ZipCode.Substring(0, 2));
                    }
                    else
                    {
                        CurrentCollaborator.Login = String.Format("{0}{1}", CurrentCollaborator.Name, CurrentCollaborator.ZipCode.Substring(0, 2));
                    }
           
                }

                try
                {
                    ISessionFactory isessionfactory = MainWindow.CreateSessionFactory();
                    using (ISession session = isessionfactory.OpenSession())//ouverture
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                if (CurrentCollaborator.Id == 0)
                                {
                                    session.Save(CurrentCollaborator);
                                }

                                else
                                {
                                   
                                    session.Update(CurrentCollaborator);
                                }
                             
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
                    MessageBox.Show("Effectué avec succès ! ");

                }
                catch 
                {
                    throw;
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
