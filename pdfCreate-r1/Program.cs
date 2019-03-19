using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PDFCreate_r1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Address Block =================================================================================================
            string[] AddressBlock1 = new string[7];
            for (int i = 0; i <= 6; i++)
                AddressBlock1[i] = "";
            AddressBlock1[0] = "Mr. & Mrs. Test Sample"; //strHonorific
            AddressBlock1[1] = "Careof: Test Sample"; //strCareof
            AddressBlock1[2] = "101 Test Street, Apt 239"; //strAddress1
            AddressBlock1[3] = "PO Box 5243"; //strAddress2;
            AddressBlock1[4] = "Toronto, ON  M5D 3F6"; //strAddress3
            
            // Date block ====================================================================================================
            string[] DateBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                DateBlock[i] = "";
            DateBlock[0] = "March 13, 2019"; //strPrintDate

            // Dear block ====================================================================================================
            string[] DearBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                DearBlock[i] = "";
            DearBlock[0] = "Dear Mrs. Test Sample"; //strFullDear

            // Paragraph block ====================================================================================================
            string[] ParagraphBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                ParagraphBlock[i] = "";
            ParagraphBlock[0] = "Thank you so much for your recent donation to Interval House!\n";
            ParagraphBlock[1] = "The returning sunlight reminds me of you, because you are supporting the women and children here at Interval House in bravely finding the light after experiencing their darkest days. Whether living at Interval House, accessing the BESS Program, or both, the women we meet are empowering themselves to build the lives they desire and break the cycle of abuse. We are committed to standing beside survivors of intimate partner violence and we are so grateful to have you on our team!\n";
            ParagraphBlock[2] = "With your continued support, Interval House is not only a safe haven for women and children in times of crisis, but a long term support network for survivors. We are constantly evaluating our programs and evolving to better support the women and children that turn to us. Your generosity provides emergency shelter, specialized counselling, employment workshops, housing options, legal support and more. These resources and services empower women to achieve their goals and gain lasting economic self-sufficiency.\n";
            ParagraphBlock[3] = "Once again, thank you for taking a stand to end violence against women. Enclosed, please find your tax receipt for \n";

            // Sincerely block ====================================================================================================
            string[] SincerelyBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                SincerelyBlock[i] = "";
            SincerelyBlock[0] = "Sincerely"; //strSincerelyLine

            // Signature block ====================================================================================================
            string strSignature1 = @"C:\xmWork\RootPDFTemplates\LeslieAckrillSignature.jpg";
            string strSignature2 = @"C:\xmWork\RootPDFTemplates\NadineChan.jpg";

            // Title block ====================================================================================================
            string[] TitleBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                TitleBlock[i] = "";
            TitleBlock[0] = "Lesley Ackrill and Nadine Chan"; //strTitleLine1
            TitleBlock[1] = "Executive Co-Directors"; //strTitleLine2

            // Receipt Line block ====================================================================================================
            string[] ReceiptLine = new string[7];
            int[] intLocation = new int[7];
            for (int i = 0; i <= 6; i++)
            {
                ReceiptLine[i] = "";
                intLocation[i] = 0;
            }
            ReceiptLine[0] = "10911221";//strReceiptNumber
            intLocation[0] = 150;
            ReceiptLine[1] = "March 1, 2019"; //strDonationDate
            intLocation[1] = 220;
            ReceiptLine[2] = "March 13, 2019"; //strReceiptDate
            intLocation[2] = 320;
            ReceiptLine[3] = "Toronto, ON"; //strIssuedFrom
            intLocation[3] = 410;
            ReceiptLine[4] = "$ 125.34"; //strReceiptAmount
            intLocation[4] = 510;

            // ConID block ====================================================================================================
            string[] ConIDBlock = new string[7];
            for (int i = 0; i <= 6; i++)
                ConIDBlock[i] = "";
            ConIDBlock[0] = "1231234"; //strConID

            // Create PDF  =================================================================
            clsPDFR PDFR = new clsPDFR();

            PDFR.SetFont(@"C:\xmwork\Cambria-01.ttf", 11);

            PDFR.SetControlStructure(@"C:\xmWork\RootPDFTemplates\INTHReceipt-Template1.pdf", @"C:\xmWork\20190313_TestOut.pdf");

            PDFR.CreateTextObjectByChunk(AddressBlock1, 45, 970, 545, 20, 12f, 2, 0);
            PDFR.CreateTextObjectByChunk(DateBlock, 45, 882, 545, 20, 12f, 2, 0);
            PDFR.CreateTextObjectByChunk(DearBlock, 45, 860, 545, 20, 12f, 2, 0);
            PDFR.CreateTextObjectByParagraph(ParagraphBlock, 45, 838, 545, 20, 12, 5, 8);

            PDFR.CreateTextObjectByChunk(SincerelyBlock, 45, 638, 545, 20, 12f, 2, 0);

            PDFR.CreateImageObject(strSignature1, 45, 582, 70, 50);
            PDFR.CreateImageObject(strSignature2, 115, 592, 70, 50);

            PDFR.CreateTextObjectByChunk(TitleBlock, 45, 580, 545, 20, 12f, 2, 0);

            PDFR.CreateTextObjectByLine(ReceiptLine, intLocation, 45, 402, 600, 20, 12f, 2, 0);

            PDFR.CreateTextObjectByChunk(AddressBlock1, 81, 380, 545, 20, 12f, 2, 0);
            PDFR.CreateTextObjectByChunk(ConIDBlock, 200, 300, 545, 20, 12f, 2, 0);

            PDFR.CreateTextObjectByChunk(AddressBlock1, 35, 133, 545, 20, 12f, 2, 0);
            PDFR.CreateTextObjectByChunk(ConIDBlock, 100, 50, 545, 20, 12f, 2, 0);



            PDFR.UnsetControlStructure();





            






            Console.WriteLine("Finsihed");
            //Messagebox("Finished");

        }

        





    }
}
