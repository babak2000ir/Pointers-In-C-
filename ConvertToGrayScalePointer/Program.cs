using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    unsafe static void Main()
    {
        string inputPath = "input.jpg";   // Replace with your image path
        string outputPath = "output.jpg"; // Save path

        DateTime start = DateTime.Now;

        using (Bitmap image = new Bitmap(inputPath))
        {
            ConvertToGrayscalePointer.ConvertToGrayscale(image);
            image.Save(outputPath, ImageFormat.Jpeg);
        }

        DateTime end = DateTime.Now;

        Console.WriteLine("Image successfully converted to grayscale. Took {0} seconds.", (end - start).TotalMilliseconds);
    }
}

