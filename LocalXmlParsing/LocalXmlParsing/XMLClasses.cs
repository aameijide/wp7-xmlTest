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

    using System.Xml.Serialization;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    namespace LocalXmlParsing
    {
        [XmlRoot("tramcelona")]
        public class Tram
        {
            [XmlArray("tram")]
            [XmlArrayItem("parada")]
            public ObservableCollection<Parada> cltParades { get; set; }
        }

        public class Parada
        {
            [XmlElement("id")]
            public decimal paradaId { get; set; }

            [XmlElement("nom")]
            public string paradaNom { get; set; }

            [XmlElement("t1")]
            public bool paradaT1 { get; set; }

            [XmlElement("t2")]
            public bool paradaT2 { get; set; }

            [XmlElement("t3")]
            public bool paradaT3 { get; set; }

            [XmlElement("t4")]
            public bool paradaT4 { get; set; }

            [XmlElement("t5")]
            public bool paradaT5 { get; set; }

            [XmlElement("t6")]
            public bool paradaT6 { get; set; }
        }
    }
