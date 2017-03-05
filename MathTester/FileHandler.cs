using MathTester.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MathTester
{
    public class FileHandler
    {
        private string file = "MathTesterSavedData.txt";
        private Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;

        public void Write(List<RecordModel> records)
        {
            string json = JsonConvert.SerializeObject(records.ToArray(), Formatting.Indented);
            DirectoryInfo di = Directory.CreateDirectory(installedLocation + @"\Data");
            File.WriteAllText(di.FullName + file, json);
        }

        public List<RecordModel> Read()
        {
            var text = File.ReadAllText(installedLocation + file);
            return JsonConvert.DeserializeObject<List<RecordModel>>(text);
        }

        public bool FileExists()
        {
            return File.Exists(installedLocation + file);
        }

    }
}
