// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET01._1Task;

try
{
    TrainingLesson training1 = new("training1description");
    //TrainingLesson training2 = new("training2descriptionxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxccccccccccccc");
    TextMaterial textm1 = new("textmdescription", "XYZ");
    VideoMaterial video1 = new("videodescription", "http://www.videourl.com", "http://www.splashscreen.com", VideoMaterial.VideoFormat.Avi);
    NetworkResource networkLink1 = new("networkResourceDescription", "http://www.content.com", NetworkResource.LinkType.Audio);
    NetworkResource networkLink2 = new("networkResourceDescription2", "http://www.content2.com", NetworkResource.LinkType.Video);


    Console.WriteLine(training1);
    //Console.WriteLine(training2);
    Console.WriteLine(textm1);
    Console.WriteLine(video1);
    Console.WriteLine(networkLink1);
    Console.WriteLine("////////////////////////");
    Console.WriteLine(networkLink1.ID);
    Console.WriteLine(networkLink2.ID);
    Console.WriteLine(networkLink1.Equals(networkLink2));

    networkLink1.CreateUniqueEntityID();
    Console.WriteLine(networkLink1.ID);
    Console.WriteLine(networkLink1.Equals(networkLink2));





}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch (ArgumentNullException ex1)
{
    Console.WriteLine(ex1.Message);

}




