using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace ITU
{
    static class Users
    {
        static public List<User> users { get; set; }
        static public User ActiveUser { get; set; }
        static public User Admin { get; set; }

        static public void Initialize()
        {
            users = new List<User>();
        }

        static public void serialize()
        {
            try
            {

                users.Add(Users.Admin);
                XmlSerializer serializer = new XmlSerializer(users.GetType());

                using (StreamWriter sw = new StreamWriter("users.xml"))
                {

                    serializer.Serialize(sw, users);
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
                if (File.Exists("users.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(users.GetType());
                    using (StreamReader sr = new StreamReader("users.xml"))
                    {
                        users = (List<User>)serializer.Deserialize(sr);
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
