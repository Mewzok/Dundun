using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;

namespace Dundun
{
    class Sprites
    {
        private String sheetLoc;

        public Sprites(String sheetLoc)
        {
            this.sheetLoc = sheetLoc;
        }

        public void SetSprites()
        {
            List<Bitmap> bmps = new List<Bitmap>(8) {};
            Rectangle rect = new Rectangle(0, 0, 16, 16);
            Bitmap src = Image.FromFile(sheetLoc) as Bitmap;

            // Sprites are:
            // 0 = Standing Forward
            // 1 = Standing Backward
            // 2 = Standing Left
            // 3 = Standing Right
            // 4 = Walking Forward
            // 5 = Walking Backward
            // 6 = Walking Left
            // 7 = Walking Right
            for (int i = 0; i <= bmps.Capacity; i++)
            {
                MessageBox.Show(bmps.Capacity.ToString());
                bmps[i] = CropImage(src, rect);
                rect.X += 16;
            }

            List<BitmapImage> bmpImg = BitmapToImage(bmps);
            InitImage(bmpImg);
        }

        public void InitImage(List<BitmapImage> bmpImg)
        {
            MainWindow.AppWindow.player.Source = bmpImg[0];
        }

        private void Move()
        {

        }

        private static Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private List<BitmapImage> BitmapToImage(List<Bitmap> bmps)
        {
            List<BitmapImage> bmpImg = new List<BitmapImage> { };
            for (int i = 0; i <= 7; i++)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bmps[i].Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();

                    bmpImg[i] = bitmapimage;
                }
            }
            return bmpImg;
        }
    }
}