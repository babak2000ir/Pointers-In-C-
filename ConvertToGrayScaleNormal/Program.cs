using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg";   // Replace with your image path
        string outputPath = "output.jpg"; // Save path

        DateTime start = DateTime.Now;
        using (Bitmap image = new Bitmap(inputPath))
        {
            ConvertToGrayscaleNormal.ConvertToGrayscale(image);
            image.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        DateTime end = DateTime.Now;
        
        Console.WriteLine("Image successfully converted to grayscale, took {0} seconds.", (end - start).TotalMilliseconds);
    }
}