using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class Resize : ImageOperation
    {
        private int percent = 0;

        public Resize(int resizePercentage) 
        {
            percent = resizePercentage;
        }

        public void Mutate(Image<Rgba32> image)
        {
            //Can resize up to times 10 times
            if (percent > 0 && percent < 1000) 
            {
                var resizeWidth = (int)(image.Size().Width * (percent / 100.0));
                var resizeHeight = (int)(image.Size().Height * (percent / 100.0));

                image.Mutate(i => i.Resize(resizeWidth, resizeHeight));
            }
        }

    }
}