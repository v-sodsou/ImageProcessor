using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageProcessor.Operations;
using SixLabors.ImageSharp;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ImageProcessor.Processor
{
    public class ImageProcessor : IProcessor
    {
        private IDictionary<String, String> map = 
            new Dictionary<String, String>()
            {
                { @"grayscale\((?<percentage>[0-9]+)\)", "Grayscale"},
                { @"rotate\((?<deg>[-]?[0-9]+)\)", "Rotate" },
                { @"resize\((?<percentage>[0-9]+)\)", "Resize"},
            };

        public byte[] ProcessImage(byte[] image, string operations)
        {
            var operationsList = this.GetOperationList(operations);
            return Process(image,operationsList);
        }

        private byte[] Process(byte[] img, List<ImageOperation> operationsList)
        {
            
            if (operationsList == null || operationsList.Count() == 0)
            {
                if (img == null)
                {
                    return null;
                }
                return img;
            }

            using (var image = Image.Load(img))
            {

                foreach (var operation in operationsList)
                {
                    operation.Mutate(image);
                }

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, Image.DetectFormat(img));
                    return ms.ToArray();
                }
            }
        }

        
        private List<ImageOperation> GetOperationList(string operations)
        {
            var operationsList = new List<ImageOperation>();

            if (!string.IsNullOrEmpty(operations))
            {
                var operation_list = operations.ToLower().Split(',');
                var thumbOp = false;
                foreach (var operation in operation_list)
                {
                    var matched = false;

                    if(operation == "fliphorizontal") {
                        operationsList.Add(new FlipHorizontal());
                        continue;
                    }

                    if(operation == "flipvertical") {
                        operationsList.Add(new FlipVertical());
                        continue;
                    }

                    if(operation == "rotateright") {
                        operationsList.Add(new RotateRight());
                        continue;
                    }

                    if(operation == "rotateleft") {
                        operationsList.Add(new RotateLeft());
                        continue;
                    }

                    if(operation == "thumbnail") {
                        thumbOp = true;
                        continue;
                    }

                    if(operation == "grayscale") {
                        operationsList.Add(new Grayscale(0));
                        continue;
                    }

                    foreach (var entry in map)
                    {

                        var regex = new Regex(entry.Key);
                        var match = regex.Match(operation);

                       if (match.Success)
                        {
                            var op = map[entry.Key];
                            if (op == "Rotate") {
                                var degrees = Int32.Parse(match.Groups["deg"].Value);
                                operationsList.Add(new Rotate(degrees));
                                matched = true;
                                break;
                            }

                            if (op=="Resize") {
                                var percentage = Int32.Parse(match.Groups["percentage"].Value);
                                operationsList.Add(new Resize(percentage));
                                matched = true;
                                 break;
                            }

                            if (op=="Grayscale") {
                                var percentage = Int32.Parse(match.Groups["percentage"].Value);
                                operationsList.Add(new Grayscale(percentage));
                                matched = true;
                                 break;
                            }

                        }
                    }

                    if (!matched)
                    {
                        throw new InvalidOperationNameException(operation);
                    }
                }
                if(thumbOp){
                    operationsList.Add(new Thumbnail());
                }

            return operationsList;
          }
         return operationsList;
        }
    }
}