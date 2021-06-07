﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Exporting;

namespace DeleteImageByBounds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Input and output file paths
            string input = @"..\..\..\..\..\..\Data\DeleteImageByBounds.pdf";
            string result = "DeleteImageByBounds_result.pdf";
            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            //Load file from disk
            pdf.LoadFromFile(input);
            //Get the first page
            PdfPageBase p = pdf.Pages[0];
            //Get the information of all images in this page 
            PdfImageInfo[] images = p.ImagesInfo;
            //Traverse the array
            for (int i = 0; i < images.Length; i++)
            {
                //Case 1: delete the image if it's bounds contains a certain point
                if (images[i].Bounds.Contains(49.68f,72.75f))
                {
                    p.DeleteImage(images[i].Image);
                }
                //Case 2: delete the image if it's bounds intersects with a certain rectangle
                if (images[i].Bounds.IntersectsWith(new RectangleF(100f,500f,30f,40f)))
                {
                    p.DeleteImage(images[i].Image);
                }
                
            }
            //Save the pdf file
            pdf.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
