using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageProcessor.Operations
{
    public interface ImageOperation
    {
        void Mutate(Image<Rgba32> image);
    }
}