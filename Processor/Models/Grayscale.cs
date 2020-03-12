using System;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace ImageProcessor.Operations
{
    public class Grayscale : ImageOperation
    {
        private float percent = 0;

         public Grayscale(float percentage) 
        {
            percent = percentage;
        }
       
        public void Mutate(Image<Rgba32> image)
        {
            if (percent > 0 && percent < 100)
            {
                image.Mutate(i => i.Grayscale(percent / 100));
            }
            else
            {
                image.Mutate(i => i.Grayscale());
            }
        }

    }
}