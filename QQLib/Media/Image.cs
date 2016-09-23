using System.IO;
using System.Windows.Media.Imaging;

namespace QQLib.Media
{
    public static class image
    {
        public static System.Windows.Media.ImageSource ConvertDrawingImage2MediaImageSource(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BitmapImage bitmap = new System.Windows.Media.Imaging.BitmapImage();
                bitmap.BeginInit();

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                return bitmap;
            }
        }

        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        public static System.Windows.Media.ImageSource byteArrayToImage(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            return image;    
        }
    }
}
