using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;

namespace pdfreader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading pdf file
            Console.Write("Please enter pdf file name: ");
            string fileName = Console.ReadLine();
            // output html file name
            string outputFile = "data.html";
            //getting current directory
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            //combining current directory and pdf file 
            var fullFileName = Path.Combine(currentDir,fileName);
            var outputFileName = Path.Combine(currentDir,outputFile);
            StringBuilder text = new StringBuilder();

            if (File.Exists(fileName))
            {       
                PdfReader pdfReader = new PdfReader(fullFileName);
                // getting text of all pages of pdf file 
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();

                // saving pdf text
                string outText = text.ToString();
                File.WriteAllText(outputFileName, outText);
                System.Console.WriteLine("Html file created successfully");
            }
            else
            {
                System.Console.WriteLine("File reading error");
            }
    

            //  File.WriteAllText(@"E:\pdfreader\cLAk.htm", htm);
 
   // Console.WriteLine("HTML File created.");

    


        }
    }
}
