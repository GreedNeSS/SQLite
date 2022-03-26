using LoadAndUploadFiles;
using LoadAndUploadFiles.Models;

Console.WriteLine("***** Saving and Retrieving Files from the Database *****");

Dictionary<string, string> files = new Dictionary<string, string>();
files.Add("Электрический монстр", @"F:\Images\16471157068_f5c546aa32_o.jpg");
files.Add("Тлеющий", @"F:\Images\600921.jpg");
files.Add("Print screen", @"F:\Images\Image.jpg");
files.Add("Лес", @"F:\Images\The-Hall-of-Mosses-23.jpg");

List<Image> images = new List<Image>();

foreach (var file in files)
{
    images.Add(new Image(file.Value, file.Key, ReadFile(file.Value)));
}

images.ForEach(i => Console.WriteLine(i));

SQLliteQuery db = new SQLliteQuery();
db.CreateTableFiles();
db.InsertDataFromDB(images);
images = db.GetFilesFromSQLiteDB();

images.ForEach(i => Console.WriteLine(i));

byte[] ReadFile(string fileName)
{
    byte[] buffer;
    using (FileStream fs = new FileStream(fileName, FileMode.Open))
    {
        buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
    }
    return buffer;
}