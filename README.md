# Image Processor 

API Usage Example:

curl      "http://localhost:5000/image?operations=resize(10),rotateleft,rotateright,thumbnail,grayscale(0)"      --header "Content-Type: image/jpg"      --data-binary "@Seattle.jpg"      --output "output.png"      --dump-header -

Implemented Image Operation Details:

  * `horizontalflip` flips the image horizontally
  * `verticalflip`  flips the image vertically
  * `rotate(x)` rotates the image x degrees
  * `resize(x)` resizes the image x percent
  * `grayscale(x)` adds a grayscale color to x percent saturation to the image
  * `grayscale` adds a default grayscale color change to the image
  * `rotateright` rotates the image 90 degrees to the right in clockwise
  * `rotateleft` rotates the image 90 degrees to the left in anti clockwise direction
  * `thumbnail` produces a thumbnail image size (100x100 pixels)
