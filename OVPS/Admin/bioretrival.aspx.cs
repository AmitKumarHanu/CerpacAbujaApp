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

public partial class Admin_bioretrival : System.Web.UI.Page
{
    string str = string.Empty;
    byte[] Imagebytes = null;
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;
    XmlDocument xmldoc = null;
    XmlNodeList nodeList = null;
    XmlNodeList nodeList1 = null;
   // string cstrl = "data source=WIN-O43O2G4D8JQ;database=NigeriaLatest";
  //  string cstrl = "Data Source=WIN-O43O2G4D8JQ;" + "Initial Catalog=NigeriaLatest;" + "Integrated Security=SSPI;";
  //  string cstrl="Server=WIN-O43O2G4D8JQ;Database=NigeriaLatest;Trusted_Connection=Yes;";

    string cstrl = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
   
    string sqlstr;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"].ToString() != "" || Request.QueryString["id"].ToString() != null)
        {
            appid.Text = Request.QueryString["id"].ToString().Trim();
        }
     //   MainView.ActiveViewIndex = 0;
        getdata();
    }
      public string getBioData()
    {
        sqlstr = "select BiometricPackage from VisaApplicationBiometric where VisaApplicationId=" + int.Parse(appid.Text);
     
        SqlConnection Conn = new SqlConnection(cstrl);
        SqlCommand cmd = new SqlCommand(sqlstr, Conn);
      Conn.Open();
        cmd.CommandText = sqlstr;
        dr = cmd.ExecuteReader();

        if (dr.Read())
        {
           str=dr["BiometricPackage"].ToString();
        }
        Session["BiometricPackage"] = str;
        return str;

    }
    public void getdata()
    {
       // test.Visible = true;
        xmldoc = new XmlDocument();

        xmldoc.LoadXml(getBioData());

        nodeList = xmldoc.SelectNodes("/CentBiometricPackage/Person[ApplicationId='" + appid.Text + "']");
        if (nodeList.Count != 0)
        {
          //  this.getDataBaseData();
            foreach (XmlNode node in nodeList)
            {
              //  appid1.Text = node["ApplicationId"].InnerText;
                fname.Text = node["FirstName"].InnerText+" " +node["LastName"].InnerText;
               // mname.Text = node["MiddleName"].InnerText;
               // Lname.Text = node["LastName"].InnerText;
               // dob.Text = node["BirthDate"].InnerText;

                if (appid.Text == node["ApplicationId"].InnerText)
                {

                    XmlNodeList nodeList1 = xmldoc.SelectNodes("/CentBiometricPackage");
                    foreach (XmlNode node1 in nodeList1)
                    {

                        if ((node1["Face"] != null))
                        {
                            if (node1["Face"]["FaceImageJPG"] != null)
                            {
                                str = node1["Face"]["FaceImageJPG"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                fphoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                        }

                        if (node1["Signature"] != null)
                        {
                            if (node1["Signature"]["SignatureImageBMP"] != null)
                            {
                                str = node1["Signature"]["SignatureImageBMP"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                fsignature.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            if (node1["Signature"]["SignatureImageBMP"] != null)
                            {
                                str = node1["Signature"]["SignatureImageBMP"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                fsignature.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                        }
                        if (node1["Fingerprints"] != null)
                        {
                            if (node1["Fingerprints"]["Fingerprint"]["Bitmap"] != null)
                            {
                              //  Label2.Text = node1["Fingerprints"]["Fingerprint"]["FingerName"].InnerText;
                                str = node1["Fingerprints"]["Fingerprint"]["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            // if (node1["Fingerprints"]["Fingerprint"]["Bitmap"] != null)
                            // {
                            //     Labelf2.Text = node1["Fingerprints"]["Fingerprint"]["FingerName"].InnerText;
                            //     str = node1["Fingerprints"]["Fingerprint"]["Bitmap"].InnerText;
                            //     Imagebytes = Convert.FromBase64String(str);
                            //     ffingerf2.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            // }

                            XmlNodeList nodeList2 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[1]");
                            foreach (XmlNode node2 in nodeList2)
                            {
                             //   Labelf1.Text = node2["FingerName"].InnerText;
                                str = node2["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            XmlNodeList nodeList3 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[2]");
                            foreach (XmlNode node3 in nodeList3)
                            {
                              //  Labelf2.Text = node3["FingerName"].InnerText;
                                str = node3["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger2.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }

                            XmlNodeList nodeList4 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[3]");
                            foreach (XmlNode node4 in nodeList4)
                            {
                              //  Labelf3.Text = node4["FingerName"].InnerText;
                                str = node4["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger3.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            XmlNodeList nodeList5 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[4]");
                            foreach (XmlNode node5 in nodeList5)
                            {
                              //  Labelf4.Text = node5["FingerName"].InnerText;
                                str = node5["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger4.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }

                            XmlNodeList nodeList6 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[5]");
                            foreach (XmlNode node6 in nodeList6)
                            {
                             //   Labelf5.Text = node6["FingerName"].InnerText;
                                str = node6["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger5.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            XmlNodeList nodeList7 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[6]");
                            foreach (XmlNode node7 in nodeList7)
                            {
                             //   Labelf6.Text = node7["FingerName"].InnerText;
                                str = node7["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger6.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }

                            XmlNodeList nodeList8 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[7]");
                            foreach (XmlNode node8 in nodeList8)
                            {
                              //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node8["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger7.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }

                            XmlNodeList nodeList9 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[8]");
                            foreach (XmlNode node9 in nodeList9)
                            {
                                //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node9["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger8.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
                            }
                            XmlNodeList nodeList10 = xmldoc.SelectNodes("/CentBiometricPackage/Fingerprints/Fingerprint[9]");
                            foreach (XmlNode node10 in nodeList10)
                            {
                                //  Labelf7.Text = node8["FingerName"].InnerText;
                                str = node10["Bitmap"].InnerText;
                                Imagebytes = Convert.FromBase64String(str);
                                ffinger9.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
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
                                fdocument.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Imagebytes);
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

}