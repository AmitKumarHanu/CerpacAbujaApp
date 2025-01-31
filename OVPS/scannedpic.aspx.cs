﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Globalization;
using OfficeOpenXml;

public partial class Admin_scannedpic : System.Web.UI.Page
{
    string picname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //-----------------------------for checking of querystring variable--------------------
        if (Request.QueryString["id"] == null || Request.QueryString["id"] == "")
        {
            return;
        }
        else
        {
            picname = Request.QueryString["id"].ToString().Trim();
        }
        //--------------------------------------end------------------------------------
        if (Page.ClientQueryString.Contains("fp=true") == true)
        {
           
           
            //this code is executed when the scanned image is uploaded 
            //it receives the file, and saves it ON THE SERVER into the application base directory
            //with file name "scan_img.bmp"
            byte[] a = new Byte[Request.Files["UploadedFile"].ContentLength];
            Request.Files["UploadedFile"].InputStream.Read(a, 0, Request.Files["UploadedFile"].ContentLength);
            //img1.Src = "data:image/jpg;base64," + Convert.ToBase64String(a);
            //img1.Attributes.Add("style", "width: 600; height:800;");
            //img1.DataBind();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(a);
            System.Drawing.Bitmap img = new Bitmap(ms);
            img.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\Logo\" + picname.Trim() + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Dispose();
            img.Dispose();
        }
        else
        {
            //this code is executed when the page is actually loaded on the screen, after the delayed page redirect
            //it only loads the uploaded image on the screen
            // ... for some reason, the uploaded image in the file is looking fine, but it does not load properly
            // on my browser ... don't know why ;)
            byte[] a;
            a = LoadPictureFromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Images\Logo\" + picname.Trim() + ".jpg"));
            img1.Src = "data:image/bmp;base64," + Convert.ToBase64String(a);
            img1.DataBind();
            /*if you uncomment this code, it will delete the uploaded scanned image, wich is source
             * for the OCR option ... so, the OCR will fail with Null Reference
             * if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scan_img.jpg")))
              {
                  File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scan_img.jpg"));
              }*/
        }

    }

    public byte[] LoadPictureFromFile(string ValidFilePath)
    {
        byte[] SourceImage;
        FileStream jpgImage = new FileStream(ValidFilePath, FileMode.Open, FileAccess.Read);
        SourceImage = new Byte[jpgImage.Length];
        jpgImage.Read(SourceImage, 0, SourceImage.Length);
        jpgImage.Dispose();

        return SourceImage;
    }
}