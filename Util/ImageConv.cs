using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogger.Util
{
    internal static class ImageConv
    {
        

        /// <summary>
        /// Método utilizado para converter a imagem para base64
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string ImageBase64</returns>
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
