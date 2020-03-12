using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class Thumbnail : ImageOperation
    {
        public Thumbnail() {}
 
        public void Mutate(Image<Rgba32> image)
        {
            image.Mutate(i => i.Resize(100, 100));
        }

    }
}