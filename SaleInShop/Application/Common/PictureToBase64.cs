using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Common
{
    public class ToBase64
    {
        public static string Image(IFormFile picture, ImageFormat format = null)
        {
            if (picture == null) return null;
            var image = System.Drawing.Image.FromStream(picture.OpenReadStream(), true, true);
            format ??= ImageFormat.Jpeg;
            using var ms = new MemoryStream();
            image.Save(ms, format);
            var imageBytes = ms.ToArray();
            var base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
