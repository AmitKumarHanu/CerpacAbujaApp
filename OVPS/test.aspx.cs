using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;


public partial class test : System.Web.UI.Page
{
    #region "Declarations"
    //Session Holder  for Persisting Data Class Object intialization
    BaseLayer.SessionHolderPersistingData objectSessionHolderPersistingData = null;
    BaseLayer.General_function objgenenral = null;
    protected DataSet objDs = new DataSet();
    protected DataTable dt = new DataTable();

    protected BaseLayer.General_function ObjGenBal = null;
    string AppID = "";
    string UserID = null;
    Label LabelMessage = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //objectSessionHolderPersistingData = (BaseLayer.SessionHolderPersistingData)HttpContext.Current.Session["SessionHolderPersistingData"];
        //if (objectSessionHolderPersistingData == null)
        //{
        //    Response.Redirect("../Login.aspx");
        //}


        string queryforzonename = "select cerpac_no,userimage from people where DATALENGTH(userimage)>24800 order by cerpac_no asc";
       // string queryforzonename = "select cerpac_no,userimage from people where people_id>81950 and people_id<=86950";

       // string queryforzonename = "select cerpac_no,userimage from people where people_id>86950 and people_id<=100000";

       // string queryforzonename = "select cerpac_no,userimage from people where people_id>100000 and people_id<=110000";

       // string queryforzonename = "select cerpac_no,userimage from people where people_id>110000 and people_id<=120000";
       // string queryforzonename = "select cerpac_no,userimage,DATALENGTH(userimage) from people where people_id>120000 and people_id<=130000 ";

       // string queryforzonename = "select cerpac_no,userimage,DATALENGTH(userimage) from people where people_id>130000 and people_id<=140000 ";
       
       // string queryforzonename = "select cerpac_no,userimage,DATALENGTH(userimage) from people where people_id>140000 and people_id<=150000 ";

      //  string queryforzonename = "select cerpac_no,userimage,DATALENGTH(userimage) from people where people_id>150000 and people_id<=170000 ";

      //  string queryforzonename = "select cerpac_no,userimage,DATALENGTH(userimage) from people where people_id>87000 and people_id<=170000 and DATALENGTH(userimage)>5000";


        objgenenral = new BaseLayer.General_function();
        DataTable dt = new DataTable();
        try
        {
            dt = objgenenral.FetchData(queryforzonename);
            byte[] picData ;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                picData = dt.Rows[i]["userimage"] as byte[] ?? null;
                imagecom(picData, dt.Rows[i]["cerpac_no"].ToString());
            }
        }
        catch (Exception ex)
        {
        }

    }

    public void imagecom(byte[] picData, string cer_no)
    {
        // byte[] picData = dt.Rows[0]["userimage"] as byte[] ?? null;
        System.Drawing.Image newImage;

        if (picData != null)
        {
            using (MemoryStream ms = new MemoryStream(picData))
            {
                // Load the image from the memory stream. How you do it depends
                // on whether you're using Windows Forms or WPF.
                // For Windows Forms you could write:
                // System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);

                newImage = System.Drawing.Image.FromStream(ms);

                //if (dt.Rows[0]["picture"] == null || dt.Rows[0]["picture"].ToString() == "")
                //    dt.Rows[0]["picture"] = dt.Rows[0]["cerpac_no"] + ".jpg";

                //if (File.Exists(Server.MapPath("~") + "/Images/prod/1.jpg"))
                //    File.Delete(Server.MapPath("~") + "/Images/prod/1.jpg");

                //if (File.Exists(Server.MapPath("~") + "/Images/prod/11.jpg"))
                //    File.Delete(Server.MapPath("~") + "/Images/prod/11.jpg");


                if (!File.Exists(Server.MapPath("~") + "/Images/prod/1_"+cer_no+".jpg"))
                    newImage.Save(Server.MapPath("~") + "/Images/prod/1_"+cer_no+".jpg");
                

                FileStream strm = new FileStream(Server.MapPath("~") + "/Images/prod/1_"+cer_no+".jpg", FileMode.Open, FileAccess.Read);
                GenerateThumbnails(0.5, strm, Server.MapPath("~") + "/Images/prod/11_"+cer_no+".jpg");
                /************* Insert Image in DB **************/
                int Length = 0;
                byte[] data = null;
                FileInfo fInfo = new FileInfo(Server.MapPath("~") + "/Images/prod/11_"+cer_no+".jpg");
                Length = System.Convert.ToInt32(fInfo.Length);
                byte[] Content = new byte[Length];
                /// <summary>
                /// The Read method is used to read the file from the ImageToUpload control </summary>
                //int Content1=ImageToUpload.PostedFile.InputStream.Read(Content,0,Length);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(Server.MapPath("~") + "/Images/prod/11_"+cer_no+".jpg", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);


                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
                SqlCommand Command = new SqlCommand("update people set userImage=@ImageFile where cerpac_no='" + cer_no + "'", Connection);

                SqlParameter imageFileParameter = new SqlParameter("@ImageFile", SqlDbType.Image);
                // imageFileParameter.Value = ViewState["contentImg"];
                imageFileParameter.Value = data;
                Command.Parameters.Add(imageFileParameter);
                Connection.Open();
                /// <summary>
                /// The SQL statement is executed. ExecuteNonQuery is used since no records
                /// will be returned. </summary>
                Command.ExecuteNonQuery();
                /// <summary>
                /// The connection is closed </summary>
                Connection.Close();
                /************* End Insert Image in DB **********/

            }
        }

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
            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("test1.aspx");
    }
}