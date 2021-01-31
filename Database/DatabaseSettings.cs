using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class DatabaseSettings
    {
        public static string GetConnectionString()
        {
            return "Data Source=.;Integrated Security=True;MultipleActiveResultSets=True;Initial Catalog=MyTestDB";
        }
    }
}
