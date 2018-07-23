using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.SqlServer.Server;

namespace SqlServerFunctions
{
    public class ImageFunctions
    {
        /// <summary>
        /// Convert image format.
        /// </summary>
        /// <param name="bytes">Image source.</param>
        /// <param name="type">Image target type. (1 Png;2 Jpg;3 Bmp)</param>
        /// <returns></returns>
        [SqlFunction(IsDeterministic = true, IsPrecise =true)]
        public static SqlBytes ConvertImageFormat(SqlBytes bytes, SqlInt16 type)
        {
            ImageFormat imageFormat;
            switch (type.Value)
            {
                case 1:
                    imageFormat = ImageFormat.Png;
                    break;
                case 2:
                    imageFormat = ImageFormat.Jpeg;
                    break;
                case 3:
                default:
                    imageFormat = ImageFormat.Bmp;
                    break;
            }

            SqlBytes result;
            using (var ms = new MemoryStream())
            {
                Image.FromStream(bytes.Stream).Save(ms, imageFormat);
                result = new SqlBytes(ms.ToArray());
            }
            return result;
        }
    }
}
