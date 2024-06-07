using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_frmsaveimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        byte[] signature = saveimage(imgpath + "sig1.jpg");
        byte[] face = saveimage(imgpath + "face1.jpg");
        

        SqlConnection Connection = new SqlConnection();
        string queryforinsert = "Insert into cerpacbiometriclink(cerpac_no,signature,index_right,middle_right,ring_right,little_right,thumb_right,index_left,middle_left,ring_left,little_left,thumb_left,face)";
        queryforinsert += "values (@cerpac_no,@sig,@index_right,@middle_right,@ring_right,@little_right,@thumb_right,@index_left,@middle_left,@ring_left,@little_left,@thumb_left,@face)";
        Connection.ConnectionString = ConfigurationManager.ConnectionStrings["NigeriaConnectionString"].ConnectionString;
       

        SqlParameter cerpac_no = new SqlParameter("@cerpac_no", SqlDbType.VarChar);
        SqlParameter sign = new SqlParameter("@sig", SqlDbType.Image);
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
        SqlParameter face1 = new SqlParameter("@face", SqlDbType.Image);

        // imageFileParameter.Value = ViewState["contentImg"];
        //imageFileParameter.Value = data;
        cerpac_no.Value = "AO123456"; // add textbox field
        sign.Value = signature;
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
        face1.Value = face;
        SqlCommand Command = new SqlCommand(queryforinsert, Connection);
        Command.Parameters.Add(cerpac_no);
        Command.Parameters.Add(sign);
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
        Command.Parameters.Add(face1);

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
}