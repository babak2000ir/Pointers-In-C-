using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg"; 

        DateTime start = DateTime.Now;
        using (Bitmap image = new(inputPath))
        {
            ConvertToGrayscaleNormal.ConvertToGrayscale(image);
            image.Save("Output-Normal.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        DateTime end = DateTime.Now; 
        Console.WriteLine("Normal .net library took {0} seconds.", (end - start).TotalMilliseconds);
    
        start = DateTime.Now;
        using (Bitmap image = new(inputPath))
        {
            ConvertToGrayscalePointer.ConvertToGrayscale(image);
            image.Save("Output-Pointer.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        end = DateTime.Now; 
        Console.WriteLine("Unsafe pointer took {0} seconds.", (end - start).TotalMilliseconds);

        start = DateTime.Now;
        using (Bitmap image = new(inputPath))
        {
            ConvertToGrayscaleSpan.ConvertToGrayscale(image);
            image.Save("Output-Span.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        end = DateTime.Now; 
        Console.WriteLine("Safe Span method took {0} seconds.", (end - start).TotalMilliseconds);
    }
}