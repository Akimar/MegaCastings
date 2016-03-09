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

        private void Button_Click_Quitter(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_AjouterClient(object sender, RoutedEventArgs e)
        {
            AjouterPersonne fenetreAjoutPersonne = new AjouterPersonne();
            fenetreAjoutPersonne.ShowDialog();
            DBLib.MegaCastingsEntities db = new MegaCastingsEntities();


        }

        private void Button_Click_GestionClients(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Clients";
            //MainGridView.Columns.Clear();
            //MainGridView.Columns.Add(new GridViewColumn());
            //MainGridView.Columns[0].Header = "Test";
            //MainGridView.Columns[0].Width = 50;

            if (StackPanelButtons.Children.Count == 0)
            {
                Button b_ajouter = new Button();
                b_ajouter.Content = "Ajouter";
                b_ajouter.Click += new System.Windows.RoutedEventHandler(this.Button_Click_AjouterClient);
                StackPanelButtons.Children.Add(b_ajouter);
            }

        }

        private void Button_Click_GestionCastings(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Castings";
        }

        private void Button_Click_GestionPartenaires(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Partenaires";
        }

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
