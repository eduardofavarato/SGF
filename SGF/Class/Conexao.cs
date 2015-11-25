using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SGF.Class
{
    class Conexao
    {
        private SQLiteConnection conexao;

        public SQLiteConnection Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }

        public Conexao()
        {
            this.Conexao = new SQLiteConnection("SGF.db");
        }

        public List<object> Select(string QUERY)
        {
            List<object> results = new List<object>();

            using (var statment = Conexao.Prepare(QUERY))
            {
                while (statment.Step() == SQLiteResult.ROW)
                {
                    results.Add(new
                    {
                        Id = statment[0],
                        Name = statment[1],
                        Email = statment[2],
                        Birthday = statment[3],
                        Phone = statment[4],
                        Photo = new Uri(string.Format("ms-appdata:///local/{0}", statment[5].ToString()))
                    });

                }
            }
            return results;
        }

        public bool Delete(string QUERY)
        {
            bool result = false;

            using (var statment = Conexao.Prepare(QUERY))
            {
                if (statment.Step() == SQLiteResult.DONE)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool Update(string QUERY)
        {
            bool result = false;

            using (var statment = Conexao.Prepare(QUERY))
            {
                if (statment.Step() == SQLiteResult.DONE)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool Insert(string QUERY)
        {
            bool result = false;

            using (var statment = Conexao.Prepare(QUERY))
            {
                if (statment.Step() == SQLiteResult.DONE)
                {
                    result = true;
                }
            }

            return result;
        }

        public static async Task CopyDatabase()
        {
            bool isDatabaseExisting = false;

            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("s2b.db");
                isDatabaseExisting = true;
            }
            catch
            {
                isDatabaseExisting = false;
            }

            if (!isDatabaseExisting)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("s2b.db");
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }
        }
    }
}
