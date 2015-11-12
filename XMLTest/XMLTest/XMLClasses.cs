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
using System.Xml.Serialization;//add referance
using System.Collections.ObjectModel;////add referance
using System.ComponentModel;////add referance
namespace LocalXmlParsing
{
    [XmlRoot("root")]
    public class States
    {
        [XmlArray("states")]
        [XmlArrayItem("state")]
        public ObservableCollection<State> Collection { get; set; }
    }
    public class State
    {
        [XmlElement("id")]
        public string stateId { get; set; }

        [XmlElement("name")]
        public string stateName { get; set; }

        [XmlArray("cities")]
        [XmlArrayItem("city")]
        public ObservableCollection<City> cityCollection { get; set; }
    }
    public class City
    {
        [XmlElement("cityid")]
        public string cityId { get; set; }

        [XmlElement("cityname")]
        public string cityName { get; set; }

        [XmlElement("pincode")]
        public string pinCode { get; set; }
    }
}