using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class RotateRight : ImageOperation
    {
        public RotateRight() {}
 
        public void Mutate(Image<Rgba32> image)
        {
            image.Mutate(i => i.Rotate(RotateMode.Rotate90));
        }

    }
}