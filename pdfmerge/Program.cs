using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfmerge
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument outPdf = new PdfDocument();
            FileInfo[] fis = new DirectoryInfo("input").GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.ToLower() == ".pdf")
                {
                    PdfDocument pdf = PdfReader.Open(fi.FullName, PdfDocumentOpenMode.Import);
                    CopyPages(pdf, outPdf);
                }
            }
            outPdf.Save("out.pdf");
        }
        static void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
