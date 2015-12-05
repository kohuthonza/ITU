using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITU
{
    public class User
    {



        public string Login { get; set; }
        public string Passwd { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string Email { get; set; }





        public override bool Equals(object obj)
        {
            
            if (obj == null)
            {
                return false;
            }
            User user = obj as User;
            return Login == user.Login && Passwd == user.Passwd;

          
        }
        public override int GetHashCode()
        {
            return Login.GetHashCode();
        }

    }
}
