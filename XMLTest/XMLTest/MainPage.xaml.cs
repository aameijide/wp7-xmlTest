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
using System.IO;
using System.Windows.Resources;
using LocalXmlParsing;

namespace XMLTest
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
            this._parser = XMLParser.Instance;
            StreamResourceInfo strm = Application.GetResourceStream(new Uri("/LocalXmlParsing;component/States.xml", UriKind.Relative));
            StreamReader reader = new StreamReader(strm.Stream);
            string data = reader.ReadToEnd();
            _parser.DataToParse = data;
            _parser.ParseStateData();


            lstStates.ItemsSource = _parser.StateCollection;
        }

        private void lstStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            State state = (State)lstStates.SelectedItem;
            string cities = "";

            foreach (State st in _parser.StateCollection)
            {
                if (state.stateId.Equals(st.stateId))
                {
                    foreach (City cc in st.cityCollection)
                    {
                        cities += " \n" + cc.cityName;
                    }
                }
            }
            MessageBox.Show(cities);
        }
    }
}