
using System;
namespace ImageProcessor.Operations
{
    public class InvalidOperationNameException :Exception
    {
        public InvalidOperationNameException(string op)
        : base(String.Format("Invalid image operation Name: {0}", op))
        {

        }
    }
}