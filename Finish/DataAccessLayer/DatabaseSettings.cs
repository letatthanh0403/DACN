using Day1.DataAccessLayer;
using System.Data.Entity;

namespace DataAccessLayer
{

    public class DatabaseSettings
    {
        public static void SetDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesERPDAL>());
            
        }

    }
}
