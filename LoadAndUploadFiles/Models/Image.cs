using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAndUploadFiles.Models
{
    public class Image
    {
        public int Id { get; private set; }
        public string FileName { get; private set; }
        public string Title{ get; private set; }
        public byte[] Data{ get; private set; }

        public Image(int id, string filename, string title, byte[] data)
        {
            Id = id;
            FileName = filename;
            Title = title;
            Data = data;
        }

        public Image(string filename, string title, byte[] data)
        {
            FileName = filename;
            Title = title;
            Data = data;
        }

        public override string ToString()
        {
            return $"Id: {Id}, FileName: {FileName}, Title: {Title}, Size: {Data.Length}";
        }
    }
}
