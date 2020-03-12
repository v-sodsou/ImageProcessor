
namespace ImageProcessor.Processor
{
    public interface IProcessor
    {
        byte[] ProcessImage(byte[] image,string operations);
    }
}