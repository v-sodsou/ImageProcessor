using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class FlipVertical : ImageOperation 
    {
        public FlipVertical() {}
    
        public void Mutate(Image<Rgba32> image)
        {
            image.Mutate(i => i.Flip(FlipMode.Vertical));
        }

    }
}