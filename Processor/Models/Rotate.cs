using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class Rotate : ImageOperation
    {
        private float degrees = 0;

        public Rotate(int deg) 
        {
            degrees = deg;
        }
 
        public void Mutate(Image<Rgba32> image)
        {
            if (degrees > -360 && degrees < 360) 
            {
                image.Mutate(i => i.Rotate(degrees));
            }
        }

    }
}