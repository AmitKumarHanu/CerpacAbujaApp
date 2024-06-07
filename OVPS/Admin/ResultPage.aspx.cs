using System;
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
using System.Xml;


public partial class _Default : System.Web.UI.Page
{
    List<tessnet2.Word> m_words;

    [DllImport("kernel32.dll")]
    public extern static IntPtr LoadLibrary(string librayName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr FreeLibrary(IntPtr library);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public extern static IntPtr GetProcAddress(IntPtr hwnd, string procedureName);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private delegate int _DecryptImageFromFileType(string chFileName, StringBuilder chDecryptedInfo);

    string filename = "";
    string doc = "";
    string state = "";
    string familyname = "";
    string surname = "";
    string documentno = "";
    string nationality = "";
    string birth = "";
    string gender = "";
    string otherdetail = "";
    int f = 0;
    static string test = "0";
    private void Page_Init(object sender, System.EventArgs e)
    {
        this.EnableViewState = false;
        btnshow.Visible = false;
    }   

    protected void Page_Load(object sender, EventArgs e)
    {
        btnshow.Visible = false;
        Session["test"] = 1;
        if (Page.ClientQueryString.Contains("fp=true") == true)
        {
           
            //this code is executed when the scanned image is uploaded 
            //it receives the file, and saves it ON THE SERVER into the application base directory
            //with file name "scan_img.bmp"
            byte[] a = new Byte[Request.Files["UploadedFile"].ContentLength];
            Request.Files["UploadedFile"].InputStream.Read(a, 0, Request.Files["UploadedFile"].ContentLength);
            img1.Src = "data:image/jpg;base64," + Convert.ToBase64String(a);
            img1.Attributes.Add("style", "width: 600; height:800;");
            img1.DataBind();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(a);
            System.Drawing.Bitmap img = new Bitmap(ms);
            img.Save(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\scan_img.bmp"), System.Drawing.Imaging.ImageFormat.Bmp);
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
            a = LoadPictureFromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\scan_img.bmp"));
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
    protected void OCRBtn_Click(object sender, EventArgs e)
    {
        
        div1.InnerText = div1.InnerText + " " + "ocr1";
        //calling the OCR function with the scanned imge 
        //if (Request.QueryString["id"].ToString() != "")
        //{
        //    filename = Request.QueryString["id"].ToString();
        //}
        filename = "ABC";
        if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + filename.ToString().Trim()+ ".xml")))
        {
            File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + filename.ToString().Trim()+ ".xml"));
        }

        if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\scan_img.bmp")))
        {
            Bitmap m_image = new Bitmap(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\scan_img.bmp"));

            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            //initializing the OCR DLL with it's language directory path = "tessdata" and used languare for UCR="eng"
            //NOTE: the tessaract OCR engine is now trained for only OCR B Std font
            //with only upper case letters and the "<" sighn
            //any other image, containing different characters or printed with different font
            //WILL FAIL to OCR
            ocr.Init(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\tessdata"), "eng", false);
            
            ocr.OcrDone = new tessnet2.Tesseract.OcrDoneHandler(Done);
            ocr.DoOCR(m_image, System.Drawing.Rectangle.Empty);

            m_image.Dispose();
            btnshow.Visible = true;
            btnshow.CssClass = "bcd";
            div1.InnerText = div1.InnerText + " " + "ocr2";
           // FillResultMethod();
            //Response.Redirect("Details.aspx");
        }
    }

    public void Done(List<tessnet2.Word> words)
    {
        //callback function for OCRBtn_Click()
        div1.InnerText = div1.InnerText + " " + "done";
        m_words = words;
        FillResultMethod();
        //if (f == 1)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('asdf');", true);
        //    //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.location('ass.aspx?a=" + doc.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");
        //    //Response.Redirect("abc.aspx?a=" + doc.ToString() + "");
        //    //sendparam();
        //}
        
    }

    public void sendparam()
    {
        HttpContext.Current.Response.Redirect("abc.aspx?a=" + doc.ToString() + "");
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('asdf'); window.location='asd.aspx?a="+doc.ToString()+"';", true);
        // this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.open('ass.aspx?a=" + doc.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");
    }

    //delegate void FillResult();
    public void FillResultMethod()
    {
        div1.InnerText = div1.InnerText + " " + "fillresult";
        if (m_words != null)
        {
            div1.InnerText = div1.InnerText + " " + "fillresult1";
            //converting the OCR result to string
            System.Text.StringBuilder ocrDATA = ocrDATA = new System.Text.StringBuilder();
            for (int i = 0; i < m_words.Count; i++)
            {
                ocrDATA.Append(m_words[i].Text);
                //ocrDATA.Append(" ");
            }

            //saving the OCR result to text file
            //this can be rewritten so it would be only passed to other function or visualized on the screen
            //NOTE: there aren't any symbols removed, so the "<" sighn is all over that answer
            if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xlsx")))
                File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xlsx"));
            if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + filename.ToString().Trim() + ".xml")))
            {
                File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + filename.ToString().Trim() + ".xml"));
            }
                //System.IO.StreamWriter s = new StreamWriter(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OCRText.txt"));
            System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + filename.ToString().Trim() + ".xml"));
            string TableData = CreateTableFunc(ocrDATA.ToString());
            ViewState["data1"] = TableData;
            Session["data"] = TableData;
            test = TableData;
            div1.InnerText = TableData;
           // ViewState["a"] = doc.ToString();
            s.WriteLine(TableData);
            s.Dispose();
            m_words.Clear();
            Page.DataBind();
            
            //Response.Redirect("Details.aspx?a=" + doc.ToString() + "");
           // this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Onclick", "<script>window.location('Details.aspx?a=" + doc.ToString() + "','PaperVisa','menubar=no,status=yes,Width=1000,Height=600,top=50,left=5');</script>");
        }
    }
    protected void DecryptBtn_Click(object sender, EventArgs e)
    {
        string DLLPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin\\SecMarkRead.dll");
        if (File.Exists(DLLPath))
        {
            IntPtr hndlr = LoadLibrary(DLLPath);
            IntPtr SecMarkReader = GetProcAddress(hndlr, "_DecryptImageFromFile");
            _DecryptImageFromFileType _DecryptImageFromFile = (_DecryptImageFromFileType)Marshal.GetDelegateForFunctionPointer(SecMarkReader, typeof(_DecryptImageFromFileType));
            StringBuilder rzlt = new StringBuilder(1000);
            int i = _DecryptImageFromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\scan_img.bmp"), rzlt);
            if (i == 1)
            {
                if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\DecryptText.txt")))
                    File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\DecryptText.txt"));
                System.IO.StreamWriter s = File.CreateText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\DecryptText.txt"));
                s.WriteLine(rzlt.ToString());
                Session["rzlt"] = rzlt.ToString();
                s.Dispose();
            }
            FreeLibrary(hndlr);
            if (Request.QueryString["id"] != "")
            {
                string id = Request.QueryString["id"].ToString().Trim();
                Response.Redirect("Details.aspx?q=" + rzlt.ToString() + "&id="+id.ToString()+"");
            }
        }
    }

    public string CreateTableFunc(string Data)
    {
        // Session["xyz"] = 1;
        StringBuilder Res = new StringBuilder();
        // Res.Append("<table>");
        string test;
        //Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass(); 
        //excelApp.Visible = false;         
        //Interop params        
        object oMissing = System.Reflection.Missing.Value;
        //The Excel doc paths
        FileInfo newFile = new FileInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xls"));
        string excelFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xls");
        if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xls")))
        {
            File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\OCRText.xls"));
        }
       
            //Add worksheet file      
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(oMissing);
                //Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.ActiveSheet;
                ExcelWorksheet excelSheet = xlPackage.Workbook.Worksheets.Add("Sheet1");
                // Res.Append("<tr><td>Field</td><td>Value</td></tr>");
                excelSheet.Cell(1, 1).Value = "Field";
                excelSheet.Cell(1, 2).Value = "Values";
                // Res.Append("<tr>");//Doc Type
                //  Res.Append("<td>Document type</td>");
                excelSheet.Cell(2, 1).Value = "Document type";
                //  Res.Append("<td>");
                int ODFL = 0;
                if (Data[0] == 'V')
                {
                    ODFL = 16;
                    //   Res.Append("Visa");
                    excelSheet.Cell(2, 2).Value = "Visa";
                }
                else if (Data[0] == 'P')
                {
                    ODFL = 14;
                    //    Res.Append("Passport");
                    excelSheet.Cell(2, 2).Value = "Passport";
                }
                else
                {
                    ODFL = 0;
                    //     Res.Append("Unknown");
                    excelSheet.Cell(2, 2).Value = "Unknown";
                }
                //   Res.Append("</td>");
                //   Res.Append("</tr>");
                test = Data[0].ToString();
                string doc1 = Data[0].ToString();
                //lbldoc.Text = doc1.ToString();
                doc = doc1.ToString();
                //   Res.Append("<tr>");//Issuing State
                //   Res.Append("<td>Issuing State</td>");
                excelSheet.Cell(3, 1).Value = "Issuing State";
                //  Res.Append("<td>" + Data[2] + Data[3] + Data[4] + "</td>");
                string IS = Data[2].ToString() + Data[3].ToString() + Data[4].ToString();
                test = test + "," + Data[2].ToString() + Data[3].ToString() + Data[4].ToString();
                excelSheet.Cell(3, 2).Value = IS;
                //  Res.Append("</tr>");
                state = IS.ToString();

                //  Res.Append("<tr>");//Family name
                //  Res.Append("<td>Family Name</td>");
                excelSheet.Cell(4, 1).Value = "Family Name";
                //   Res.Append("<td>" + GetFamilyName(Data) + "</td>");
                excelSheet.Cell(4, 2).Value = GetFamilyName(Data);
                //    Res.Append("</tr>");
                familyname = GetFamilyName(Data);
                test = test + "," + GetFamilyName(Data);
                //    Res.Append("<tr>");//Sure name
                //   Res.Append("<td>Sure Name</td>");
                excelSheet.Cell(5, 1).Value = "Sure Name";
                //   Res.Append("<td>" + GetSureName(Data) + "</td>");
                excelSheet.Cell(5, 2).Value = GetSureName(Data);
                //   Res.Append("</tr>");
                surname = GetSureName(Data);
                test = test + "," + GetSureName(Data);
                //     Res.Append("<tr>");//Document number
                //    Res.Append("<td>Document Number</td>");
                excelSheet.Cell(6, 1).Value = "Document Number";
                string DN = "";
                for (int i = 44; i <= (52); i++)
                {
                    if (Data[i] != '<')
                        DN += Data[i];
                    else
                        break;
                }
                //   Res.Append("<td>" + DN + "</td>");
                excelSheet.Cell(6, 2).Value = DN;
                //     Res.Append("</tr>");
                documentno = DN.ToString();
                test = test + "," + DN.ToString();
                //    Res.Append("<tr>");//Holders Nationality 
                //    Res.Append("<td>Holders Nationality</td>");
                excelSheet.Cell(7, 1).Value = "Holders Nationality";


                //     Res.Append("<td>" + Data[54] + Data[55] + Data[56] + "</td>");
                string HN = Data[54].ToString() + Data[55].ToString() + Data[56].ToString();
                excelSheet.Cell(7, 2).Value = HN;
                //    Res.Append("</tr>");
                nationality = HN.ToString();
                test = test + "," + HN.ToString();
                //      Res.Append("<tr>");//Date of Birght 
                //     Res.Append("<td>Date of Birth</td>");
                excelSheet.Cell(8, 1).Value = "Date of Birght";
                string DoB = Data[61].ToString() + Data[62].ToString() + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                    Data[59].ToString() + Data[60].ToString() + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                    Data[57].ToString() + Data[58].ToString();
                //    Res.Append("<td>" + Data[61] + Data[62] + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                //        Data[59] + Data[60] + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                //        Data[57] + Data[58] + "</td>");
                excelSheet.Cell(8, 2).Value = DoB;
                //     Res.Append("</tr>");
                birth = DoB.ToString();
                test = test + "," + DoB.ToString();
                //     Res.Append("<tr>");//Sex
                //     Res.Append("<td>Sex</td>");
                excelSheet.Cell(9, 1).Value = "Sex";
                //     Res.Append("<td>");
                if (Data[64] == 'F')
                {
                    //        Res.Append("Female");
                    excelSheet.Cell(9, 2).Value = "Female";
                }
                else if (Data[64] == 'M')
                {
                    //         Res.Append("Male");
                    excelSheet.Cell(9, 2).Value = "Male";
                }
                else
                {
                    //        Res.Append("Unknown");
                    excelSheet.Cell(9, 2).Value = "Unknown";
                }
                //     Res.Append("</td>");
                //     Res.Append("</tr>");
                gender = Data[64].ToString();
                test = test + "," + Data[64].ToString();
                //      Res.Append("<tr>");//Date of Expiry 
                //      Res.Append("<td>Date of Expiry</td>");
                excelSheet.Cell(10, 1).Value = "Date of Expiry";
                string DoE = Data[69].ToString() + Data[70].ToString() + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                    Data[67].ToString() + Data[68].ToString() + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                    Data[65].ToString() + Data[66].ToString();
                //      Res.Append("<td>" + Data[69] + Data[70] + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                //          Data[67] + Data[68] + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator +
                //          Data[65] + Data[66] + "</td>");
                excelSheet.Cell(10, 2).Value = DoE;
                //      Res.Append("</tr>");
                string expiry = DoE.ToString();
                test = test + "," + DoE.ToString();
                //        Res.Append("<tr>");//Optional Data
                //        Res.Append("<td>Optional Data</td>");
                excelSheet.Cell(11, 1).Value = "Optional Data";
                string OD = "";
                for (int i = 72; i <= (72 + ODFL); i++)
                {
                    if (Data[i] != '<')
                        OD += Data[i];
                    else
                        break;
                }
                //     Res.Append("<td>" + OD + "</td>");
                excelSheet.Cell(11, 2).Value = OD;
                //      Res.Append("</tr>");
                otherdetail = OD.ToString();
                test = test + "," + OD.ToString();
                //    Res.Append("</table>");

                //excelApp.Save(excelFile);
                xlPackage.Save();
            
            }

            //return Res.ToString();
            return test;
        
    }

    public string GetFamilyName(string Data)
    {
        int DMF = 0;
        string res = "";
        for (int i = 5; i <= 43; i++)
        {
            if (Data[i] == '<')
            {
                DMF++;
                res += " ";
            }
            else
            {
                DMF = 0;
                res += Data[i];
            }
            if (DMF == 2)
                break;
        }
        return res;
    }

    public string GetSureName(string Data)
    {
        string FN = GetFamilyName(Data);
        int DMF = 0;
        string res = "";
        for (int i = (5+FN.Length); i <= 43; i++)
        {
            if (Data[i] == '<')
            {
                DMF++;
                res += " ";
            }
            else
            {
                DMF = 0;
                res += Data[i];
            }
            if (DMF == 2)
                break;
        }
        return res;
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        String xmlText="";
       // btnshow.CssClass = "abc";
        //if (Request.QueryString["id"].ToString() == "")
       // {
            btnshow.CssClass = "abc";
            string id = "ABC";
            if (File.Exists(Server.MapPath(id + ".xml")))
            {
                xmlText = File.ReadAllText(Server.MapPath(id + ".xml"));
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('Please Click on OCR button again');", true);
                return;
            }
            if (File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + id.ToString().Trim() + ".xml")))
            {
                File.Delete(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Admin\" + id.ToString().Trim() + ".xml"));
            }
            Response.Redirect("PassportDetails.aspx?data=" + xmlText.Replace("\n","").ToString() + "&id=" + id.ToString() + "");

          //  Response.Redirect("PassportDetails.aspx?id=" + id.ToString() + "");
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('You did not scanned the passport correctly');", true);
        //}
        btnshow.CssClass = "abc";
       
    }
}