using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Data_Layer
{
    public class Data_Object
    {
        private string _ConnectionString;

        public Data_Object()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public string ConnectionString => _ConnectionString;
    }
}