using System.Drawing;

namespace Application.Common
{
    public class ToBase64
    {
        public static string Image(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            byte[] imageBytes = ms.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
