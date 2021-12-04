const sharp = require('sharp');

// process.argv[2] = input > file path
// process.argv[3] = type > jpg / png
// process.argv[4] = output > file path
// process.argv[5] = bmName > file name
// process.argv[6] = quality > precentage
// process.argv[7] = r  > number 
// process.argv[8] = g > number
// process.argv[9] = b > number

function handler(input,type,output,bmName,quality,r,g,b)
{
  if(type === "jpg")  
    convert(input,output,bmName,quality,r,g,b);
  else if(type === "png")
  compress(input,output,bmName,quality); 
  
}

function compress(input,output,bmName,quality)
{
  sharp(input)
.withMetadata() 
.png({
  quality: parseInt(quality),
})
.toFile(output + bmName +".png"); 
}

function convert(input,output,bmName,quality,r,g,b)
{
     sharp(input).flatten({ background: { r: r, g: g, b: b } })
    .jpeg({
      quality: parseInt(quality),
      chromaSubsampling: '4:4:4'
    })
    .toFile(output + bmName +".jpg");
}

handler(process.argv[2],process.argv[3],process.argv[4],process.argv[5],process.argv[6],process.argv[7],process.argv[8],process.argv[9]);