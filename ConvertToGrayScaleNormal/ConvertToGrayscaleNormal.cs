using System.Drawing;

public class ConvertToGrayscaleNormal
{
    public static void ConvertToGrayscale(Bitmap image)
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
}
