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
using MegaCastings.DBLib;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace MegaCastings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
          
            
        }


        #region Button Events
        /// <summary>
        /// Ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Ouvre une fenêtre modale pour ajouter un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if(MainGroupBox.Header.Equals("Clients"))
            {
                AddClient AddClientFrame = new AddClient();
                AddClientFrame.ShowDialog();
                //DBLib.MegaCastingsEntities db = new MegaCastingsEntities();
            }
            else if(MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if(MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// <summary>
        /// /// Ouvre une fenêtre modale pour modifier un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Manage(object sender, RoutedEventArgs e)
        {
            if (MainGroupBox.Header.Equals("Clients"))
            {
                
            }
            else if (MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if (MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// Ouvre une fenêtre modale pour supprimer un client ou bien une offre de casting, ou encore un partenaire
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (MainGroupBox.Header.Equals("Clients"))
            {
               
            }
            else if (MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if (MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayClients(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Castings";

            //MegaCastingsEntities db = new MegaCastingsEntities();
            //List<Client> ClientsList = db.Clients.ToList();

           
            //foreach (var client in ClientsList)
            //{
            //    client.FormatPhoneNumberForDisplay();
            //}


            //CustomDataGrid DataGrid = new CustomDataGrid();
            //DataGrid.BuildDataGrid(0);
            //DataGrid.MainDataGrid.ItemsSource = ClientsList;

            //db = null;
        }

        /// <summary>
        /// Affiche via le GridView la liste des castings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayCastings(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Castings";
            //foreach (var item in MainGridView.Columns)
            //{
            //    item.Header = "toto";
            //}
            //MegaCastingsEntities db = new MegaCastingsEntities();
            //List<CastingOffer> CastingsList = db.CastingOffers.ToList();
            //MainListView.ItemsSource = CastingsList;
            //db = null;
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des partenaires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayCollaborators(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Partenaires";
            //MegaCastingsEntities db = new MegaCastingsEntities();
            //List<Client> ClientsList = db..ToList();
            //MainListView.ItemsSource = ClientsList;
            //db = null;
        }

        #endregion

        private void MenuItemXML_Click(object sender, RoutedEventArgs e)
        {
           // MegaCastingsEntities db = new MegaCastingsEntities();
           //Client test =  db.Clients.First();

           // XmlWriter rdr = XmlWriter.Create(@"../../../flux/offres.xml", new XmlWriterSettings() {Indent = true});
           // rdr.WriteProcessingInstruction("xml-stylesheet","type=\"text/xsl\" href=\"style.xsl\"");
           // XElement offres = new XElement("rss", new XAttribute("version", "2.0"));
           // XElement channel = new XElement("channel", new XElement("title", "MegaCastings : liste des offres"), new XElement("description", "Retrouvez en temps réel les propositions d'offres de MégaCastings !"), new XElement("lastBuildDate", DateTime.Now.ToLongTimeString()), new XElement("link", "www.megacastings.fr/rss"));
           // try
           // {
           //     foreach (OffreCasting casting in db.OffreCastings)
           //     {
           //         channel.Add(new XElement("offre", new XElement("title", casting.Intitule +" ("+casting.Reference+")"), new XElement("description",casting.DescriptionPoste+"\n"+casting.DescriptionProfil), new XElement("pubDate", casting.DateDebut), new XElement("link", "www.megacasting.fr/"+casting.Identifiant+".html")));
           //     }

           // }
           // catch(Exception ex)
           // {
           // }

           // offres.Add(channel);

           // offres.WriteTo(rdr);

           // rdr.Flush();
           // rdr.Close();

        }
    }
}
