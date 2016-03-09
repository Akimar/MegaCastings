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
    /// Interaction logic for AjouterPersonne.xaml
    /// </summary>
    public partial class AjouterPersonne : Window
    {
        public AjouterPersonne()
        {
            InitializeComponent();
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
            if (!string.IsNullOrEmpty(tbNom.Text) && !string.IsNullOrEmpty(tbPrenom.Text) && !string.IsNullOrEmpty(tbTel.Text) && !string.IsNullOrEmpty(tbNumRue.Text) && !string.IsNullOrEmpty(tbNomRue.Text) && !string.IsNullOrEmpty(tbCp.Text) && !string.IsNullOrEmpty(tbVille.Text))
            {
                DBLib.MegaCastingsEntities dblib = new DBLib.MegaCastingsEntities();
                DBLib.Client nouveauClient = new DBLib.Client();
                nouveauClient.Nom = tbNom.Text.ToUpper();
                nouveauClient.Prenom = tbPrenom.Text;
                nouveauClient.Telephone = tbTel.Text;
                nouveauClient.NumRue = tbNumRue.Text;
                nouveauClient.NomRue = tbNomRue.Text;
                nouveauClient.CodePostal = tbCp.Text;
                nouveauClient.Ville = tbVille.Text;
                try
                {
                    dblib.Clients.Add(nouveauClient);
                    dblib.SaveChanges();
                    MessageBox.Show("Ajout effectué avec succès ! ");

                }
                catch(Exception ex)
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
