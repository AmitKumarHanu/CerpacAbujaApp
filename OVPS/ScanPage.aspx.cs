﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    List<tessnet2.Word> m_words;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
        {
            lblid.Text = Request.QueryString["id"].ToString().Trim();
        }
        
    }

    protected void Do_OCR(object sender, EventArgs e)
    {
        //this button is hidden, and that code is moved to the other page
        Bitmap m_image = new Bitmap(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MRZ_lines\"+TextBox1.Text));

        tessnet2.Tesseract ocr = new tessnet2.Tesseract();
        ocr.Init(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata"), "eng", false);
        ocr.OcrDone = new tessnet2.Tesseract.OcrDoneHandler(Done);
        ocr.DoOCR(m_image, Rectangle.Empty);

        m_image.Dispose();
    }

    public void Done(List<tessnet2.Word> words)
    {
        //callback function for do_scan()
        m_words = words;
        FillResultMethod();
        //Response.Flush();
        //Page.Response.Flush();
        //this.Invoke(new FillResult(FillResultMethod));
    }

    //delegate void FillResult();
    public void FillResultMethod()
    {
        if (m_words != null)
        {
            //converting the OCR result to string
            System.Text.StringBuilder ocrDATA = ocrDATA = new System.Text.StringBuilder();
            for (int i = 0; i < m_words.Count; i++)
            {
                ocrDATA.Append(m_words[i].Text);
                ocrDATA.Append(" ");
            }

            //saving the OCR result to text file
            //this can be rewritten so it would be only passed to other function or visualized on the screen
            //NOTE: there aren't any symbols removed, so the "<" sighn is all over that answer 
            if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OCRText.txt")))
                File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OCRText.txt"));
            //System.IO.StreamWriter s = new StreamWriter(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OCRText.txt"));
            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OCRText.txt"));
            s.WriteLine(ocrDATA.ToString());
            s.Dispose();
            m_words.Clear();
            Page.DataBind();
        }
    }
}