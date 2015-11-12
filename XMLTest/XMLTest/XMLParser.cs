using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using System.Xml.Serialization; //add referance
using System.Xml.Linq;//add referance

namespace LocalXmlParsing
{
    public class XMLParser
    {
        private string _dataToParse;
        private static XMLParser _instance;

        private ObservableCollection<State> _stateCollection;

        private XMLParser()
        {

        }

        public static XMLParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new XMLParser();
                }
                return _instance;
            }
        }


        public string DataToParse
        {
            get
            {
                return _dataToParse;
            }
            set
            {
                this._dataToParse = value;
            }
        }

        public ObservableCollection<State> StateCollection
        {
            get
            {
                return _stateCollection;
            }
            set
            {
                _stateCollection = value;
            }
        }


        public ObservableCollection<State> ParseStateData()
        {
            try
            {
                XmlSerializer serlizer = new XmlSerializer(typeof(States));
                XDocument document = XDocument.Parse(this._dataToParse);

                States rootXML = (States)serlizer.Deserialize(document.CreateReader());

                this._stateCollection = rootXML.Collection;

                return rootXML.Collection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ParseStateData()::" + ex.Message);
            }

            return null;
        }
    }
}