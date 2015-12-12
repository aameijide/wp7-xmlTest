using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Windows.Resources;
using System.IO;

namespace LocalXmlParsing
{
    public partial class MainPage : PhoneApplicationPage
    {
        private XMLParser _parser;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnparse_Click(object sender, RoutedEventArgs e)
        {
            //the foll code needs to be write only once(singalton pattern) ,once xml file is parsed once no need to do parse it again and again
            this._parser = XMLParser.Instance;
            StreamResourceInfo strm = Application.GetResourceStream(new Uri("/LocalXmlParsing;component/States.xml",UriKind.Relative));
            StreamReader reader = new StreamReader(strm.Stream);
            string data = reader.ReadToEnd();
            _parser.DataToParse = data;
            _parser.ParseStateData();
            //till here

            lstStates.ItemsSource = _parser.StateCollection;
        }

        private void lstStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Parada parada = (Parada)lstStates.SelectedItem;
            string linea1 = "";

            foreach (Parada pr in _parser.StateCollection)
            {
                if (pr.paradaT1 == true)
                {
                    linea1 += " \n" + pr.paradaNom;
                }
            }
            MessageBox.Show(linea1);
        }
    }
}