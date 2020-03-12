using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessor.Operations
{
    public class FlipHorizontal : ImageOperation
    {
        public FlipHorizontal() {}

        public void Mutate(Image<Rgba32> image)
        {
            image.Mutate(i => i.Flip(FlipMode.Horizontal));
        }
    }
}