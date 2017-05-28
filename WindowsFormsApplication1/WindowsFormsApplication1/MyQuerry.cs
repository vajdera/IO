using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{

    [XmlRoot("MyQuerry")]
    public class MyQuerry
    {
        [XmlAttributeAttribute("Adres")]
        public string Adres;
        [XmlAttributeAttribute("Telefon")]
        public string Telefon;
        [XmlAttributeAttribute("Nip")]
        public string Nip;
        [XmlAttributeAttribute("Regon")]
        public string Regon;


        [XmlElement("Pracownicy")]    
        public List<Pracownik> Pracownicy;

        [XmlElement("SoftB")]
        public List<Soft> SoftB;

        [XmlElement("SoftZ")]
        public List<Soft> SoftZ;



        public MyQuerry()
        {
            Pracownicy = new List<Pracownik>();
            SoftB = new List<Soft>();
            SoftZ = new List<Soft>();
        }

    }



    public enum Ocena
    {
        niedostateczny,
        dostateczny,
        dobry,
        bardzo_dobry
    };



    [XmlRoot("Soft")]
    public class Soft
    {

        [XmlAttributeAttribute("Nazwa")]
        public string Nazwa { get; set; }


        [XmlAttributeAttribute("Autor")]
        public string Autor { get; set; }


        [XmlAttributeAttribute("Przydatnosc")]
        public Ocena Przydatnosc { get; set; }


        [XmlAttributeAttribute("Wydajnosc")]
        public Ocena Wydajnosc { get; set; }

        [XmlAttributeAttribute("Poziom")]
        public Ocena Poziom { get; set; }
    }




    [XmlRoot("Pracownik")]
    public class Pracownik
    {

        [XmlAttributeAttribute("Imię")]
        public string Imie_p { get; set; }


        [XmlAttributeAttribute("Nazwisko")]
        public string Nazwisko_p { get; set; }


        [XmlAttributeAttribute("Telefon")]
        public string Telefon_p { get; set; }


        [XmlAttributeAttribute("Email")]
        public string Email_p { get; set; }
    }

}
