using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PDFCreate_r1
{
    class clsPDFR
    {

        private Font font;
        private PdfReader pdfReader;
        private PdfStamper pdfStamper;
        private PdfContentByte canvas;
        private ColumnText columnText;




        public void SetFont (string strFont, int intPitch)
        {
             font = FontFactory.GetFont(strFont, intPitch, BaseColor.BLACK);
        }
        public void SetControlStructure(string strSource, string strDestination)
        {
            pdfReader = new PdfReader(strSource);
            pdfStamper = new PdfStamper(pdfReader, new FileStream(strDestination, FileMode.Create));
            canvas = pdfStamper.GetOverContent(1);
            canvas.SaveState();
            canvas.SetRGBColorFill(0, 0, 0);
            columnText = new ColumnText(canvas);
            columnText.IgnoreSpacingBefore = true;
        }
        public void CreateTextObjectByChunk( string [] strText, int intBoxLeftMargin, int intBoxStart, int intBoxWidth, int intBoxHeight, float fltBoxLeading, int intBoxSpacingBefore, int intBoxSpacingAfter)
        {
            //==< Heading Name & address >=============================================================================================================
            columnText.SetSimpleColumn(new Rectangle( intBoxLeftMargin, intBoxStart, intBoxWidth, intBoxHeight));

            Chunk c1 = new Chunk(strText[0], font);
            Chunk c2 = new Chunk("\n");
            Chunk c3 = new Chunk(strText[1], font);
            Chunk c4 = new Chunk("\n");
            Chunk c5 = new Chunk(strText[2], font);
            Chunk c6 = new Chunk("\n");
            Chunk c7 = new Chunk(strText[3], font);
            Chunk c8 = new Chunk("\n");
            Chunk c9 = new Chunk(strText[4], font);
            Chunk c10 = new Chunk("\n");
            Chunk c11 = new Chunk(strText[5], font);
            Chunk c12 = new Chunk("\n");
            Chunk c13 = new Chunk(strText[6], font);
            Chunk c14 = new Chunk("\n");

            Phrase ph = new Phrase();
            ph.Add(c1);
            ph.Add(c2);
            ph.Add(c3);
            ph.Add(c4);
            ph.Add(c5);
            ph.Add(c6);
            ph.Add(c7);
            ph.Add(c8);
            ph.Add(c9);
            ph.Add(c10);
            ph.Add(c11);
            ph.Add(c12);
            ph.Add(c13);

            Paragraph pr = new Paragraph();
            pr.Add(ph);
            pr.Leading = fltBoxLeading;
            pr.SpacingBefore = intBoxSpacingBefore;
            pr.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(pr);
            columnText.Go();

        }

        public void CreateTextObjectByParagraph(string[] strText, int intBoxLeftMargin, int intBoxStart, int intBoxWidth, int intBoxHeight, float fltBoxLeading, int intBoxSpacingBefore, int intBoxSpacingAfter)
        {
            //==< Heading Name & address >=============================================================================================================
            columnText.SetSimpleColumn(new Rectangle(intBoxLeftMargin, intBoxStart, intBoxWidth, intBoxHeight));

            Paragraph p1 = new Paragraph(strText[0], font);
            p1.Leading = fltBoxLeading;
            p1.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p1);

            Paragraph p2 = new Paragraph(strText[1], font);
            p2.Leading = fltBoxLeading;
            p2.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p2);

            Paragraph p3 = new Paragraph(strText[2], font);
            p3.Leading = fltBoxLeading;
            p3.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p3);

            Paragraph p4 = new Paragraph(strText[3], font);
            p4.Leading = fltBoxLeading;
            p4.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p4);

            Paragraph p5 = new Paragraph(strText[4], font);
            p5.Leading = fltBoxLeading;
            p5.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p5);

            Paragraph p6 = new Paragraph(strText[5], font);
            p6.Leading = fltBoxLeading;
            p6.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p6);

            Paragraph p7 = new Paragraph(strText[6], font);
            p7.Leading = fltBoxLeading;
            p7.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p7);
            
            columnText.Go();

        }


        public void CreateImageObject(string strImage, int intBoxLeftMargin, int intBoxStart, int intBoxWidth, int intBoxHeight)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(new Uri(strImage));

            image.SetAbsolutePosition(intBoxLeftMargin, intBoxStart);
            image.ScaleToFit(intBoxWidth, intBoxHeight);
            //image.ScalePercent((intBoxWidth/ image.Height) * 100);
            //image.Border = iTextSharp.text.Rectangle.BOX;
            //image.BorderColor = iTextSharp.text.BaseColor.BLACK;
            //image.BorderWidth = 1f;
            canvas.AddImage(image);
            columnText.Go();
        }

        public void CreateTextObjectByLine(string[] strText, int[] intLocations, int intBoxLeftMargin, int intBoxStart, int intBoxWidth, int intBoxHeight, float fltBoxLeading, int intBoxSpacingBefore, int intBoxSpacingAfter)
        {
            //==< >=============================================================================================================
            columnText.SetSimpleColumn(new Rectangle(intLocations[0], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p1 = new Paragraph(strText[0], font);
            p1.Leading = fltBoxLeading;
            p1.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p1);
            columnText.Go();
            
            columnText.SetSimpleColumn(new Rectangle(intLocations[1], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p2 = new Paragraph(strText[1], font);
            p2.Leading = fltBoxLeading;
            p2.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p2);
            columnText.Go();
           
            columnText.SetSimpleColumn(new Rectangle(intLocations[2], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p3 = new Paragraph(strText[1], font);
            p3.Leading = fltBoxLeading;
            p3.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p3);
            columnText.Go();

            columnText.SetSimpleColumn(new Rectangle(intLocations[3], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p4 = new Paragraph(strText[3], font);
            p4.Leading = fltBoxLeading;
            p4.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p4);
            columnText.Go();

            columnText.SetSimpleColumn(new Rectangle(intLocations[4], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p5 = new Paragraph(strText[4], font);
            p5.Leading = fltBoxLeading;
            p5.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p5);
            columnText.Go();

            columnText.SetSimpleColumn(new Rectangle(intLocations[5], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p6 = new Paragraph(strText[5], font);
            p6.Leading = fltBoxLeading;
            p6.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p6);
            columnText.Go();

            columnText.SetSimpleColumn(new Rectangle(intLocations[6], intBoxStart, intBoxWidth, intBoxHeight));
            Paragraph p7 = new Paragraph(strText[6], font);
            p7.Leading = fltBoxLeading;
            p7.SpacingAfter = intBoxSpacingAfter;
            columnText.AddElement(p7);
            columnText.Go();
            
        }




        public void UnsetControlStructure()
        {
            canvas.RestoreState();
            pdfStamper.FormFlattening = true;
            pdfStamper.Writer.CloseStream = false;
            pdfStamper.Close();
            pdfReader.Close();
        }




        //Paragraph object ================================================================================================
        //Paragraph.Alignment -- SetAlignment
        //Paragraph.IndentationRight -- SetIndentationRight
        //Paragraph.IndentationLeft -- SetIndentationLeft
        //Paragraph.SpacingBefore
        //Paragraph.SpacingAfter
        //paragraph.SetLeading(fixed, multiplied); -  the distance between the baseline of two lines is called the leading. default is 1.5 times size of font (i.e. 1.5*11 = 16.5)
        //    fixed  - fixed leading
        //    multiple -  factor to multiple the font size 

    }
}
