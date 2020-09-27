using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureProc
{
    class Picture
    {
        Bitmap _bitmap;

        public Picture(string path)
        {
            _bitmap = new Bitmap(path);
        }
        public Bitmap ChangePicture()
        {
            Bitmap bitmap = new Bitmap(_bitmap);
            for (int i =0; i<bitmap.Height; i++)
              for (int j=0; j<bitmap.Width; j++)
              {
                 Color px = _bitmap.GetPixel(i, j);
                 bitmap.SetPixel(i, j, ChangeColorToMono(px));
              }
            return bitmap;
        }
        private Color ChangeColorToMono(Color px)
        {
            int rgb = (px.R + px.G + px.B) / 3;
            return Color.FromArgb(rgb, rgb, rgb);
        }
    }
}
