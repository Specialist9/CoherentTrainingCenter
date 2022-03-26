using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//using Aspose.Words;
using NPOI.XWPF.UserModel;


namespace Listeners
{
    public  class WordListener : IListener
    {
        public WordListener(WordListenerConfig wordConfig)
        {
            MinLogLevel = wordConfig.MinLogLevel;
            FileName = wordConfig.FileName;
        }
        public int MinLogLevel { get; set; }
        public string FileName { get; set; }

        public void WriteToLogFile(string message)
        {
            /*
            Document doc1 = new();
            DocumentBuilder builder = new(doc1);
            Font font = builder.Font;
            font.Size = 12;
            font.Bold = true;
            font.Color = System.Drawing.Color.Black;
            font.Name = "Arial";
            builder.Writeln(message);
            builder.Writeln("TESTING WORD");
            doc1.Save("Document.docx");
            */

            var newFile2 = @"WordListener.docx";
            using (var fs = new FileStream(newFile2, FileMode.Create, FileAccess.Write))
            {
                XWPFDocument doc = new XWPFDocument();

                var p1 = doc.CreateParagraph();
                p1.Alignment = ParagraphAlignment.LEFT;
                p1.IndentationFirstLine = 500;
                XWPFRun r1 = p1.CreateRun();
                r1.FontFamily = "arial";
                r1.FontSize = 12;
                r1.IsBold = true;
                r1.SetText(message);

                doc.Write(fs);
                Console.WriteLine("I'm writing to WordListener.docx");
            }

        }
    }
}
