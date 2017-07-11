using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AI
    {
        public char[,] snapshot;

        public void AddSnapshot(Field field)
        {
            snapshot = (field._field);
            WriteDB();
        }

        public void doMyTurn(Field field)
        {
            throw new NotImplementedException();
        }

        public void WriteDB()
        {
            StreamReader fileReader = new StreamReader("c:\\debug\\Snapshots.json");
            var db = JsonConvert.DeserializeObject<List<char[,]>>(fileReader.ReadToEnd());
            fileReader.Close();

            if (db != null)
            {
                foreach (var item in db)
                {
                    if (db.Any(qq => JsonConvert.SerializeObject(qq).Equals(JsonConvert.SerializeObject(snapshot))))
                    {
                        return;
                    }
                }
                db.Add(snapshot);
            }

            StreamWriter file = new StreamWriter("c:\\debug\\Snapshots.json");

            if (db == null)
            {
                file.WriteLine(JsonConvert.SerializeObject(new List<char[,]>() { snapshot }));
            }
            else
            {
                file.WriteLine(JsonConvert.SerializeObject(db));
            }
            file.Close();
        }
    }
}
