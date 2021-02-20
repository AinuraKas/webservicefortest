using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

using System.Runtime.Serialization.Json;
using System.IO;
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
/// <summary>
/// Summary description for getdata
/// </summary>
//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class getdata : System.Web.Services.WebService {
    
    public getdata () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetDeptJSON()
    {
        string query = "SELECT  * from Kafedra";
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Dept> q = new List<Dept>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Dept e = new Dept();
            e.IdKaf = Convert.ToInt16(item["IdKaf"].ToString());
            e.Kafedra = item["Kafedra"].ToString();
            q.Add(e);
            i = i + 1;
        }
        


        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));



    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetDiscJSON(String idk)
    {
        string query = "SELECT [IdPredm],[Predm]  FROM  [Predm] where [IdKaf]=" + idk;
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Disc> q = new List<Disc>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Disc e = new Disc();
            e.IdPredm = Convert.ToInt16(item["IdPredm"].ToString());
            e.Predm = item["Predm"].ToString();
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }



    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetTestJSON(String idk)
    {
        string query = "SELECT [IdTest],[NazvTest]  FROM [Test] where [IdPredm]=" + idk;
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Test> q = new List<Test>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Test e = new Test();
            e.IdTest = Convert.ToInt16(item["IdTest"].ToString());
            e.NazvTest = item["NazvTest"].ToString();
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));



    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetQstJSON(String idk)
    {
        string query = "select distinct IdVopr , newid() ,putrisunka  from ( SELECT top 30 [IdVopr],[putrisunka] FROM  [Vopros] where   [IdTest]=" + idk + ")y order by newid()";
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Qsts> q = new List<Qsts>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Qsts e = new Qsts();
            e.IdVopr = Convert.ToInt16(item["IdVopr"].ToString());
            e.putrisunka = item["putrisunka"].ToString();
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }

   


   
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetQstTextJSON(String idk)
    {
        string query = " SELECT  [IdVopr], Vopros,putrisunka FROM  [Vopros] where [IdVopr]=" + idk ;
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Qsts> q = new List<Qsts>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Qsts e = new Qsts();
            e.IdVopr = Convert.ToInt16(item["IdVopr"].ToString());
            e.Vopros = item["Vopros"].ToString();
            e.putrisunka = item["putrisunka"].ToString();
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetAnswJSON(String idk)
    {
        string query = "SELECT [IdOtvet]  ,[Otvet]         FROM [Otvet]where [IdVopr]=" + idk ;
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Answ> q = new List<Answ>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Answ e = new Answ();
            e.IdOtvet = Convert.ToInt16(item["IdOtvet"].ToString());
            e.Otvet = item["Otvet"].ToString();
            


            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetRezJSON(String idk)
    {
        string query = "SELECT sum([Ball])GBall  FROM  [Otvet] where IdVopr in(" + idk+")";
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Ball> q = new List<Ball>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Ball e = new Ball();
            e.GBall = Convert.ToInt32(item["GBall"].ToString());
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetRezIJSON(String idk)
    {
        string query = "SELECT sum([Ball])GBall  FROM  [Otvet] where IdOtvet in(" + idk + ")";
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=dbtest11;User ID=sa;Password=Ise123123;Persist Security Info=True;");


        cn.Open();
        DataTable tbl = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, cn);
        da.Fill(tbl);
        List<Ball> q = new List<Ball>();
        int i = 0;
        foreach (DataRow item in tbl.Rows)
        {
            Ball e = new Ball();
            e.GBall = Convert.ToInt32(item["GBall"].ToString());
            q.Add(e);
            i = i + 1;
        }
        cn.Close();

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(q));




    }
}
