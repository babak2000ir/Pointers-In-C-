using System;
using System.Drawing;

class Program
{
    static void ConvertToGrayscale(Bitmap image)
    {
        int width = image.Width;
        int height = image.Height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get the pixel color
                Color pixelColor = image.GetPixel(x, y);

                // Convert to grayscale using luminance formula
                byte gray = (byte)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                // Create a new grayscale color
                Color grayColor = Color.FromArgb(gray, gray, gray);

                // Set the pixel back
                image.SetPixel(x, y, grayColor);
            }
        }
    }

    static void Main()
    {
        string inputPath = "input.jpg";   // Replace with your image path
        string outputPath = "output.jpg"; // Save path

        DateTime start = DateTime.Now;
        using (Bitmap image = new Bitmap(inputPath))
        {
            ConvertToGrayscale(image);
            image.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        DateTime end = DateTime.Now;
        
        Console.WriteLine("Image successfully converted to grayscale, took {0} seconds.", (end - start).TotalMilliseconds);
    }
}