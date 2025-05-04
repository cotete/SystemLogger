using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogger.Util
{
    internal static class ImageConv
    {
        
        public static string ConverterToBase64(string path)
        {
            Image img = Image.FromFile(path);

            MemoryStream m = new MemoryStream();
            img.Save(m, img.RawFormat);
            byte[] data = m.ToArray();
            return Convert.ToBase64String(data);
        }

    }
}
