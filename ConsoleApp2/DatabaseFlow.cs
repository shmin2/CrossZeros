using System.Linq.Expressions;

namespace ConsoleApp2
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class DatabaseFlow
    {
        public void WriteSnapshot(char[,] field)
        {
            List<char[,]> db;

            using (StreamReader fileReader = new StreamReader("c:\\debug\\Snapshots.json"))
            {
                db = JsonConvert.DeserializeObject<List<char[,]>>(fileReader.ReadToEnd());

                db?.ForEach(item =>
                    {
                        if (item.ArrayEquals(field) == false)
                        {
                            db.Add(field);
                        }
                    }
                );
            }

            using (StreamWriter fileWriter = new StreamWriter("c:\\debug\\Snapshots.json"))
            {
                fileWriter.Write(JsonConvert.SerializeObject(db));
            }
        }
    }
}
