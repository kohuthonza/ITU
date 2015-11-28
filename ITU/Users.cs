using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITU
{
    static class Users
    {
        static public ObservableCollection<User> users { get; set; }

        static public void Initialize()
        {
            users = new ObservableCollection<User>();
        }
    }
}
