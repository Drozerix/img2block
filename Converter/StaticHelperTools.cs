using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class StaticHelperTools
    {
        public static Bitmap mainImage;
        public static Bitmap mainDataImage;
        public static Color[] newColors =
{
                System.Drawing.Color.Black,
                System.Drawing.Color.Gray,
                System.Drawing.Color.White
        };
        //key is black, gray, and white hash code
        //first hash is top pixel
        // +""+
        //second hash is bottom pixel
        public static Dictionary<String, int> colorMap = new Dictionary<String, int>()
        {
            { "ffffffffffffffff",0 }, //System.Drawing.Color.White.Name+""+System.Drawing.Color.White.Name
            { "ff808080ff808080",1 }, //System.Drawing.Color.Gray.Name+""+System.Drawing.Color.Gray.Name
            { "ff000000ff000000",2 },// System.Drawing.Color.Black.Name+""+System.Drawing.Color.Black.Name
            { "ffffffffff808080",3 }, //System.Drawing.Color.White.Name+""+System.Drawing.Color.Gray.Name, 
            { "ff808080ffffffff",4 }, //System.Drawing.Color.Gray.Name+""+System.Drawing.Color.White.Name, 
            { "ffffffffff000000",5 },//System.Drawing.Color.White.Name+""+System.Drawing.Color.Black.Name,
            { "ff000000ffffffff",6 },//System.Drawing.Color.Black.Name+""+System.Drawing.Color.White.Name,
            { "ff808080ff000000",7 }, //System.Drawing.Color.Gray.Name+""+System.Drawing.Color.Black.Name, 
            { "ff000000ff808080",8 }, //System.Drawing.Color.Black.Name+""+System.Drawing.Color.Gray.Name, 
            { "00", 2},
            { "0", 2},
            { "ff8080800",2 },
            { "ffffffff0",2 },
            { "ff0000000",2 },
            { "0ff808080",2 },
            { "0ffffffff",2 },
            { "0ff000000",2 },
        };
        

        public static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(sourceBMP, 0, 0, width, height);
            }
            return result;
        }

        public static String ValidateImage(Bitmap b)
        {
            int height = b.Height;
            int width = b.Width;

            //check image dimensions for valid values
            //return error message if invalid
            if(width > 80)
            {

                return "has a width larger than 80 -- " + width + " pixels to be exact.";
            }
            if (width < 1)
            {

                return "has a width less than 1 -- " + width + " pixels to be exact.";
            }
            if (height > 9999)
            {

                return "has a height larger than 9999 -- " + height + " pixels to be exact.";
            }
            if (height < 2)
            {

                return "has a height less than 2 -- " + height + " pixels to be exact.";
            }
            mainImage = new Bitmap(80, height + (height&0x01));
            Dictionary<Color, int> seenColors = new Dictionary<Color, int>();
            Color prevPix = new Color();
            int index = 0;



            //check colors while loading into memory
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Color pix = b.GetPixel(j, i);
                    
                    if (pix == prevPix) continue;
                    else if(!seenColors.ContainsKey(pix))
                    {
                        seenColors.Add(pix, index);
                        index++;
                    }
                    prevPix = pix;
                }
            }
            if(seenColors.Count > 3)
            {
                //char[] seenColorArray = new char[(seenColors.Count - 3)*3];
                String val = "";
                for(int i = 0; i < seenColors.Count; i++)
                {
                    //seenColorArray[0] = ()seenColors.Keys.ElementAt(i).A;
                    //seenColorArray[0] = seenColors.Keys.ElementAt(i).A;
                    val += seenColors.Keys.ElementAt(i).Name + " ";
                }
                return "has more than 3 colors.";
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color pix = newColors[seenColors[b.GetPixel(j, i)]];
                    mainImage.SetPixel(j, i, pix);
                }
            }
            mainDataImage = new Bitmap(mainImage);
            mainImage = ResizeBitmap(mainImage, width*4, height*4);


            return null;
        }

        public static void resetImageColor(int index1, int index2, int index3)
        {
            if (mainDataImage == null) return;
            Dictionary<int, int> seenColors = new Dictionary<int, int>();
            seenColors.Add(newColors[0].ToArgb(), index1);
            seenColors.Add(newColors[1].ToArgb(), index2);
            seenColors.Add(newColors[2].ToArgb(), index3);
            seenColors.Add(0, index3);

            for (int i = 0; i < mainDataImage.Height; i++)
            {
                for (int j = 0; j < mainDataImage.Width; j++)
                {
                    Color pix = newColors[seenColors[mainDataImage.GetPixel(j, i).ToArgb()]];
                    mainDataImage.SetPixel(j, i, pix);
                }
            }
            //mainDataImage = new Bitmap(mainImage);
            mainImage = mainDataImage;
            mainImage = ResizeBitmap(mainImage, 80 * 4, mainDataImage.Height * 4);

        }


    }
}
