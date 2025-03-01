using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    unsafe static void ConvertToGrayscale(Bitmap image)
    {
        // Lock the bitmap's memory for direct access
        BitmapData bmpData = image.LockBits(
            new Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);  // 24-bit RGB format

        int height = image.Height;
        int width = image.Width;
        int stride = bmpData.Stride; // Width including padding
        byte* ptr = (byte*)bmpData.Scan0; // Pointer to pixel data

        for (int y = 0; y < height; y++)
        {
            byte* row = ptr + (y * stride); // Get the row pointer

            for (int x = 0; x < width; x++)
            {
                // Extract RGB components
                byte blue = row[x * 3];
                byte green = row[x * 3 + 1];
                byte red = row[x * 3 + 2];

                // Convert to grayscale (using luminance formula)
                byte gray = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);

                // Set grayscale value (same for R, G, and B)
                row[x * 3] = gray;
                row[x * 3 + 1] = gray;
                row[x * 3 + 2] = gray;
            }
        }

        // Unlock the bitmap
        image.UnlockBits(bmpData);
    }

    unsafe static void Main()
    {
        string inputPath = "input.jpg";   // Replace with your image path
        string outputPath = "output.jpg"; // Save path

        DateTime start = DateTime.Now;

        using (Bitmap image = new Bitmap(inputPath))
        {
            ConvertToGrayscale(image);
            image.Save(outputPath, ImageFormat.Jpeg);
        }

        DateTime end = DateTime.Now;

        Console.WriteLine("Image successfully converted to grayscale. Took {0} seconds.", (end - start).TotalMilliseconds);
    }
}

