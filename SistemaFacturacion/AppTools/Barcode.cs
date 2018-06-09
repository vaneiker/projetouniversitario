
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SistemaFacturacion.AppTools
{
  public class Barcode
  {
    public Barcode(){}
    
    //method to Generate a barcode based on input string and picture box.
    public void GenerateBarcode(string barcode, System.Windows.Forms.PictureBox picBox = null)
    {
      	Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
			using(Graphics graphics = Graphics.FromImage(bitmap))
			{
				Font font = new System.Drawing.Font("IDAHC39M Code 39 Barcode", 20);
				PointF point = new PointF(2f, 2f);
				SolidBrush black = new SolidBrush(Color.Black);
				SolidBrush white = new SolidBrush(Color.White);
				graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
				graphics.DrawString("*" + barcode + "*", font, black, point);
			}
			using(MemoryStream ms = new MemoryStream())
			{
                if(picBox == null)
				bitmap.Save("D:\\Todo_Comprimido\\RECURSOS\\" + barcode + ".png", System.Drawing.Imaging.ImageFormat.Png);
                else
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    picBox.Image = bitmap;
                    picBox.Height = bitmap.Height;
                    picBox.Width = bitmap.Width;
                }
                
            }
			}
    }
  }

