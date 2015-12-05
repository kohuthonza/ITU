using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace ITU
{
    static class Plants
    {
        static public List<Plant> plants { get; set; }
        static public Plant ActivePlant { get; set; }
        static public int ActualIndex { get; set; }

        static public void Initialize()
        {
            plants = new List<Plant>();
        }

        static public void serialize()
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(plants.GetType());

                using (StreamWriter sw = new StreamWriter("plants.xml"))
                {

                    serializer.Serialize(sw, plants);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static public void deserialize()
        {
            try
            {
                if (File.Exists("plants.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(plants.GetType());
                    using (StreamReader sr = new StreamReader("plants.xml"))
                    {
                        plants = (List<Plant>)serializer.Deserialize(sr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
