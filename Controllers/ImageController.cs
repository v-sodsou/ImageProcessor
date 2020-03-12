using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImageProcessor.Operations;
using ImageProcessor.Processor;
using Swashbuckle.AspNetCore.Swagger;

namespace ImageProcessor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public ImageController() { }


                   
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public void ProcessImage([FromQuery(Name="operations")] string operations,[FromBody] byte[] image)
        {
            try
            {
               
                if (image == null || image.Count() == 0) {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return;
                }

                if(string.IsNullOrEmpty(operations))
                {
                    Response.ContentType = Request.ContentType;
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    Response.Body.Write(image);
                    return;
                    
                }
                var processor = ProcessorFactory.GetImageProcessor();
                byte[] processedImage = processor.ProcessImage(image,operations);
                if (processedImage == null || processedImage.Count() == 0) {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return;
                }
                Response.ContentType = Request.ContentType;
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                Response.Body.Write(processedImage);
            } 
            catch (InvalidOperationNameException invalidOperationException)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
        }
    }
}
