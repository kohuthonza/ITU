using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITU
{
    public class User : INotifyPropertyChanged
    {


        private string name;

        public string Name
        {
            get { return this.name; }
            set {
                    this.name = value;
                    this.NotifyPropertyChanged("name");
                }
        }

        public string passwd { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override bool Equals(object obj)
        {
            
            if (obj == null)
            {
                return false;
            }
            User user = obj as User;
            return Name == user.Name && passwd == user.passwd;

          
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    }
}
