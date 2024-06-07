using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Configuration;

public partial class Admin_compressXML : System.Web.UI.Page
{
    string str = string.Empty;
    byte[] Imagebytes = null;
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;
    XmlDocument xmldoc = null;
    XmlNodeList nodeList = null;
    XmlNodeList nodeList1 = null;
    string sqlstr;
    string cstrl = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
    int Length = 0;
    BaseLayer.General_function objgenenral = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        // string cstrl = "data source=WIN-O43O2G4D8JQ;database=NigeriaLatest";
        //  string cstrl = "Data Source=WIN-O43O2G4D8JQ;" + "Initial Catalog=NigeriaLatest;" + "Integrated Security=SSPI;";
        //  string cstrl="Server=WIN-O43O2G4D8JQ;Database=NigeriaLatest;Trusted_Connection=Yes;";

        string sql_qry;
        sql_qry = "select * from VisaApplicationBiometric where (VisaApplicationId not in (select App_id from cerpacbiometriclink) or Version not in (select Version from cerpacbiometriclink))";
         objgenenral = new BaseLayer.General_function();
            DataTable dt = new DataTable();
            dt = objgenenral.FetchData(sql_qry);
            if (dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    getdata(Convert.ToInt32(dt.Rows[i]["VisaApplicationId"].ToString()), Convert.ToInt32(dt.Rows[i]["version"].ToString()));
                    saveImage(Convert.ToInt32(dt.Rows[i]["VisaApplicationId"].ToString()), Convert.ToInt32(dt.Rows[i]["version"].ToString()));
            }}

   }

    public string getBioData(int id, int ver)
    {
        //sqlstr = "select BiometricPackage from VisaApplicationBiometric where VisaApplicationId=" + int.Parse(txtAppid.Text);

        sqlstr = "select BiometricPackage from VisaApplicationBiometric where VisaApplicationId=" + id + " and version=" + ver;

        SqlConnection Conn = new SqlConnection(cstrl);
        SqlCommand cmd = new SqlCommand(sqlstr, Conn);
        Conn.Open();
        cmd.CommandText = sqlstr;
        dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            str = dr["BiometricPackage"].ToString();
        }
        Session["BiometricPackage"] = str;
        return str;

    }

     
    private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            // can given width of image as we want
            var newWidth = (int)(image.Width * scaleFactor);
            // can given height of image as we want
            var newHeight = (int)(image.Height * scaleFactor);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
           // if (File.Exists(Server.MapPath("~") + "/Images/BIO/face.jpg"))
             //   File.Delete(Server.MapPath("~") + "/Images/BIO/face.jpg");
            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
    public void getdata(int Appid, int ver)
    {
        // test.Visible = true;
        xmldoc = new XmlDocument();

        xmldoc.LoadXml(getBioData(Appid,ver));

       // nodeList = xmldoc.SelectNodes("/CentBiometricPackage/Person[ApplicationId='" + txtAppid.Text + "']");
        nodeList = xmldoc.SelectNodes("/CentBiometricPackage/Person[ApplicationId='" + Appid + "']");
        if (nodeList.Count != 0)
        {
            //  this.getDataBaseData();
            foreach (XmlNode node in nodeList)
            {
                
                //fname.Text = node["FirstName"].InnerText + " " + node["LastName"].InnerText;
                // mname.Text = node["MiddleName"].InnerText;
                // Lname.Text = node["LastName"].InnerText;
                // dob.Text = node["BirthDate"].InnerText;

              //  if (txtAppid.Text == node["ApplicationId"].InnerText)
                if (Convert.ToString(Appid) == node["ApplicationId"].InnerText)
                {

                    XmlNodeList nodeList1 = xmldoc.SelectNodes("/CentBiometricPackage");
                    foreach (XmlNode node1 in nodeList1)
                    {

                        if ((node1["Face"] != null))
                        {
                            if (node1["Face"]["FaceImageJPG"] != null)
                            {
                                str = node1["Face"]["FaceImageJPG"].InnerText;
                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                            //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                              // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;



                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                       

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/face.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/face.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/face.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/face.jpg");

                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/face.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/face1.jpg");





                                        ////////////////

                                        byte[] data = null;
                                        FileInfo fInfo = new FileInfo(Server.MapPath("~") + "/Images/BIO/face1.jpg");
                                        Length = System.Convert.ToInt32(fInfo.Length);
                                        byte[] Content = new byte[Length];
                                        /// <summary>
                                        /// The Read method is used to read the file from the ImageToUpload control </summary>
                                        //int Content1=ImageToUpload.PostedFile.InputStream.Read(Content,0,Length);
                                        long numBytes = fInfo.Length;
                                        FileStream fStream = new FileStream(Server.MapPath("~") + "/Images/BIO/face1.jpg", FileMode.Open, FileAccess.Read);
                                        BinaryReader br = new BinaryReader(fStream);
                                        data = br.ReadBytes((int)numBytes);

                                        node1["Face"]["FaceImageJPG"].InnerText = data.ToString();
                                    }
                                }
                            }
                        }

                        if (node1["Signature"] != null)
                        {
                            
                            if (node1["Signature"]["SignatureImageBMP"] != null)
                            {
                                str = node1["Signature"]["SignatureImageBMP"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                //fsignature.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);



                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/sig.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/sig.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/sig.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/sig.jpg");

                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/sig.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/sig1.jpg");

                                    }
                                }
                            }
                        }
                        if (node1["Fingerprints"] != null)
                        {
                            if (node1["Fingerprints"]["Fingerprint"] != null)
                            {
                                if (node1["Fingerprints"]["Fingerprint"]["Bitmap"] != null)
                                {

                                    str = node1["Fingerprints"]["Fingerprint"]["Bitmap"].InnerText;
                                    Imagebytes = Convert.FromBase64String(str);





                                    Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                    //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                    // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                    System.Drawing.Image newImage;


                                    if (Imagebytes != null)
                                    {
                                        using (MemoryStream ms = new MemoryStream(Imagebytes))
                                        {
                                            // Load the image from the memory stream. How you do it depends
                                            // on whether you're using Windows Forms or WPF.
                                            // For Windows Forms you could write:
                                            // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                            newImage = System.Drawing.Image.FromStream(ms);

                                            if (File.Exists(Server.MapPath("~") + "/Images/BIO/f1.jpg"))
                                                File.Delete(Server.MapPath("~") + "/Images/BIO/f1.jpg");

                                            if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f1.jpg"))
                                                newImage.Save(Server.MapPath("~") + "/Images/BIO/f1.jpg");

                                            FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f1.jpg", FileMode.Open, FileAccess.Read);
                                            GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f11.jpg");
                                        }

                                    }
                                }
                            }
                            
                            XmlNodeList nodeList2 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[1]");

                            foreach (XmlNode node2 in nodeList2)
                            {

                                str = node2["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                // ffinger1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f2.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f2.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f2.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f2.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f2.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f21.jpg");

                                    }
                                }
                            }
                            XmlNodeList nodeList3 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[2]");
                            foreach (XmlNode node3 in nodeList3)
                            {
                                //  Labelf2.Text = node3["FingerName"].InnerText;
                                str = node3["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger2.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f3.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f3.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f3.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f3.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f3.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f31.jpg");

                                    }
                                }
                            }

                            XmlNodeList nodeList4 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[3]");
                            foreach (XmlNode node4 in nodeList4)
                            {
                                //  Labelf3.Text = node4["FingerName"].InnerText;
                                str = node4["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger3.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f4.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f4.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f4.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f4.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f4.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f41.jpg");

                                    }
                                }
                            }
                            XmlNodeList nodeList5 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[4]");
                            foreach (XmlNode node5 in nodeList5)
                            {
                                //  Labelf4.Text = node5["FingerName"].InnerText;
                                str = node5["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger4.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f5.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f5.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f5.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f5.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f5.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f51.jpg");

                                    }
                                }
                            }

                            XmlNodeList nodeList6 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[5]");
                            foreach (XmlNode node6 in nodeList6)
                            {
                                //   Labelf5.Text = node6["FingerName"].InnerText;
                                str = node6["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger5.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null && Imagebytes.Length>0)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f6.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f6.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f6.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f6.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f6.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f61.jpg");

                                    }
                                }
                            }
                            XmlNodeList nodeList7 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[6]");
                            foreach (XmlNode node7 in nodeList7)
                            {
                                //   Labelf6.Text = node7["FingerName"].InnerText;
                                str = node7["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger6.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null && Imagebytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f7.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f7.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f7.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f7.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f7.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f71.jpg");

                                    }
                                }
                            }

                            XmlNodeList nodeList8 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[7]");
                            foreach (XmlNode node8 in nodeList8)
                            {
                                //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node8["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger7.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null && Imagebytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f8.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f8.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f8.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f8.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f8.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f81.jpg");

                                    }
                                }
                            }

                            XmlNodeList nodeList9 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[8]");
                            foreach (XmlNode node9 in nodeList9)
                            {
                                //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node9["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                //ffinger8.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null && Imagebytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f9.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f9.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f9.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f9.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f9.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f91.jpg");

                                    }
                                }
                            }
                            XmlNodeList nodeList10 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[9]");
                            foreach (XmlNode node10 in nodeList10)
                            {
                                //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node10["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // ffinger9.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);

                                Imagebytes = Convert.FromBase64String(str) as byte[] ?? null;
                                //    fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);


                                // Imagebytes= Dt.Rows[0]["userimage"] as byte[] ?? null;
                                System.Drawing.Image newImage;


                                if (Imagebytes != null && Imagebytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(Imagebytes))
                                    {
                                        // Load the image from the memory stream. How you do it depends
                                        // on whether you're using Windows Forms or WPF.
                                        // For Windows Forms you could write:
                                        // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                                        newImage = System.Drawing.Image.FromStream(ms);

                                        if (File.Exists(Server.MapPath("~") + "/Images/BIO/f10.jpg"))
                                            File.Delete(Server.MapPath("~") + "/Images/BIO/f10.jpg");

                                        if (!File.Exists(Server.MapPath("~") + "/Images/BIO/f10.jpg"))
                                            newImage.Save(Server.MapPath("~") + "/Images/BIO/f10.jpg");


                                        FileStream strm = new FileStream(Server.MapPath("~") + "/Images/BIO/f10.jpg", FileMode.Open, FileAccess.Read);
                                        GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/BIO/f101.jpg");

                                    }
                                }
                            }

                            // foreach (XmlNode node2 in nodeList2)
                            //{

                            //  Labelf2.Text = node2["FingerName"].InnerText;
                            //  string fingername = node2["FingerName"].InnerText;
                            // Labelf3.Text=node2["FingerName"].InnerText;
                            //  Labelf3.Text = node2.FirstChild.ChildNodes[2].InnerText;
                            // Labelf4.Text = node2.FirstChild.ChildNodes[3].InnerText;
                            //  Console.WriteLine(node2["Fingerprint"]["FingerName"].InnerText);
                            //Console.WriteLine(node2["FingerName"].InnerText);
                            //  Response.Write(node2["FingerName"].InnerText);
                            //  Console.WriteLine("FingerName: {0} {1}", fingername , fingername);
                            //    Response.Write(fingername);
                            //    Response.Write("<br>");
                            // }



                        }
                        if (node1["Documentation"] != null)
                        {
                            if (node1["Documentation"]["DocumentJPG"] != null)
                            {
                                str = node1["Documentation"]["DocumentJPG"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                               // fdocument.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                        }
                    }


                }


            }
        }
        else
        {
            Response.Write("<script> alert('no record with this id');</script>");

        }

    }

    public void saveImage(int app, int ver)
    {
        string imgpath = Server.MapPath("~") + "/Images/BIO/";
        byte[] index_left = saveimage(imgpath + "f11.jpg");
        byte[] middle_left = saveimage(imgpath + "f21.jpg");
        byte[] ring_left = saveimage(imgpath + "f31.jpg");
        byte[] little_left = saveimage(imgpath + "f41.jpg");
        byte[] index_right = saveimage(imgpath+"f51.jpg");
        byte[] middle_right = saveimage(imgpath + "f61.jpg");
        byte[] ring_right = saveimage(imgpath + "f71.jpg");
        byte[] little_right = saveimage(imgpath + "f81.jpg");
        byte[] thumb_right = saveimage(imgpath + "f91.jpg");
        byte[] thumb_left = saveimage(imgpath + "f101.jpg");
        byte[] face = saveimage(imgpath + "face1.jpg");
        
        byte[] signature = saveimage(imgpath + "sig1.jpg");
        

        SqlConnection Connection = new SqlConnection();
        string queryforinsert = "Insert into cerpacbiometriclink(App_id,signature,index_right,middle_right,ring_right,little_right,thumb_right,index_left,middle_left,ring_left,little_left,thumb_left,face,version)";
        queryforinsert += "values (@App_id,@sig,@index_right,@middle_right,@ring_right,@little_right,@thumb_right,@index_left,@middle_left,@ring_left,@little_left,@thumb_left,@face," + ver + ")";
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
       

        SqlParameter App_id = new SqlParameter("@App_id", SqlDbType.Int);
        SqlParameter sign = new SqlParameter("@sig", SqlDbType.Image);
        SqlParameter face1 = new SqlParameter("@face", SqlDbType.Image);
        SqlParameter index_rt = new SqlParameter("@index_right", SqlDbType.Image);
        SqlParameter middle_rt = new SqlParameter("@middle_right", SqlDbType.Image);
        SqlParameter ring_rt = new SqlParameter("@ring_right", SqlDbType.Image);
        SqlParameter little_rt = new SqlParameter("@little_right", SqlDbType.Image);
        SqlParameter thumb_rt = new SqlParameter("@thumb_right", SqlDbType.Image);
        SqlParameter index_lt = new SqlParameter("@index_left", SqlDbType.Image);
        SqlParameter middle_lt = new SqlParameter("@middle_left", SqlDbType.Image);
        SqlParameter ring_lt = new SqlParameter("@ring_left", SqlDbType.Image);
        SqlParameter little_lt = new SqlParameter("@little_left", SqlDbType.Image);
        SqlParameter thumb_lt = new SqlParameter("@thumb_left", SqlDbType.Image);
        
        // imageFileParameter.Value = ViewState["contentImg"];
        //imageFileParameter.Value = data;
        App_id.Value = app; // add textbox field
        sign.Value = signature;
        face1.Value = face;
        index_rt.Value = index_right;
        middle_rt.Value = middle_right;
        ring_rt.Value = ring_right;
        little_rt.Value = little_right;
        thumb_rt.Value = thumb_right;
        index_lt.Value = index_left;
        middle_lt.Value = middle_left;
        ring_lt.Value = ring_left;
        little_lt.Value = little_left;
        thumb_lt.Value = thumb_left;
        
        SqlCommand Command = new SqlCommand(queryforinsert, Connection);
        Command.Parameters.Add(App_id);
        Command.Parameters.Add(sign);
        Command.Parameters.Add(face1);

        Command.Parameters.Add(index_rt);
        Command.Parameters.Add(middle_rt);
        Command.Parameters.Add(ring_rt);
        Command.Parameters.Add(little_rt);
        Command.Parameters.Add(thumb_rt);
        Command.Parameters.Add(index_lt);
        Command.Parameters.Add(middle_lt);
        Command.Parameters.Add(ring_lt);
        Command.Parameters.Add(little_lt);
        Command.Parameters.Add(thumb_lt);
        
        Connection.Open();
        /// <summary>
        /// The SQL statement is executed. ExecuteNonQuery is used since no records
        /// will be returned. </summary>
        Command.ExecuteNonQuery();
        /// <summary>
        /// The connection is closed </summary>
        Connection.Close();

       // System.Threading.Thread.Sleep(30000);
        Response.Redirect("compressXML.aspx");
        //if (File.Exists(Server.MapPath("~") + "/Images/BIO/face.jpg"))
        //    File.Delete(Server.MapPath("~") + "/Images/BIO/face.jpg");

        //if (File.Exists(Server.MapPath("~") + "/Images/BIO/face1.jpg"))
        //    File.Delete(Server.MapPath("~") + "/Images/BIO/face1.jpg");

        /************* End Insert Image in DB **********/
          
    }

    public byte[] saveimage(string path)
    {
        byte[] data = new byte[0];
        if (File.Exists(path))
        {
            int Length = 0;
            FileInfo fInfo = new FileInfo(path);
            Length = System.Convert.ToInt32(fInfo.Length);
            byte[] Content = new byte[Length];
            /// <summary>
            /// The Read method is used to read the file from the ImageToUpload control </summary>
            //int Content1=ImageToUpload.PostedFile.InputStream.Read(Content,0,Length);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        else
        {
            return data;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       // getdata(txtAppid.Text);
    }
}