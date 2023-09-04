using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebVeriAlma.Classes
{
    public class cGenel
    {
        public static int _userId;
        public static SqlConnection connection = new SqlConnection("Data Source=BERF;Initial Catalog=WebDeneme;Integrated Security=True");

        public string conString = ("Data Source=BERF;Initial Catalog=WebDeneme;Integrated Security=True");
        public static void CheckConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
            else
            {

            }
        }

       
    }
    public class urlAlClass
    {
        public string id;
        public string htmlVeri;
        public string name;
    }
    public class UserInfo
    {
        public String nameSurname;
        public String email;
        public String id;
        public String password;
        public String username;
        public String created_at;
    }
    public class İsAraligi
    {
        public string aralik;
    }
}
