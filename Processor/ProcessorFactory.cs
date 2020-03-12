namespace ImageProcessor.Processor
{
    public static class ProcessorFactory
    {
        public static IProcessor GetImageProcessor()
        {
            return new ImageProcessor();
        }
    }
}