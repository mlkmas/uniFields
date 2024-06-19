using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Reflection;

namespace Universities2.Models
{
    public class ClassSubject
    {
        public string SubName { set; get; }
        public int SubCode { set; get; }
      //  public string SubSalary { set; get; }
        public string SubPsyMin { set; get; }
        public int SubSum { set; get; }
        public int SubYE { set; get; }
        //public DateTime Sub { set; get; }
        // public string SubExistIn { set; get; }
        public string SubInfo { set; get; }
        public string SubField { set; get; }
        
        public string UnivID { set; get; }

        public static List<List<ClassSubject>> Search(string q)
        {
            ////students -->Univs
            ///List<List<string>> myList = new List<List<string>>();
           List<ClassSubject> Subs1 = new List<ClassSubject>();
            List<List<ClassSubject>> Subs = new List<List<ClassSubject>>();
            Connector cn = new Connector(Configs.DB_NAME);
            //Connector cn = new Connector("Folder1/database99.accdb");

            //string sql2 = "SELECT * FROM Students WHERE student_name LIKE '%ah%'";
            string sql = " SELECT Subject2.*FROM Subject2";
            //***Universit-->>Subj SELECT Subject2.*FROM Subject2;
           

            // List<ClassSubject> Subj = new List<ClassSubject>();

            ///**********************************
           // if (q != null)
            //{
                // sql += " WHERE SubField Like '%" + q + "%'";
               // sql += " OR SubCode like '%" + q + "%'";
           // }
           for(int i=1;i<8;i++)
           {
                 Subs1 = new List<ClassSubject>();
                cn = new Connector(Configs.DB_NAME);
                if (i != 5)
                {

                    sql = " SELECT Subject2.*FROM Subject2";
                    sql += " WHERE SubField Like '%" + q + "%'";
                    sql += " AND UnivID like '%" + i + "%'";
                    OleDbDataReader result = cn.RunSelect(sql);
                    while (result.Read())
                    {
                        ClassSubject u9 = new ClassSubject
                        {
                            SubCode = int.Parse(result["SubCode"].ToString()),
                            SubField = result["SubField"].ToString(),
                            SubInfo = result["SubInfo"].ToString(),
                            SubName = result["SubName"].ToString(),

                            SubPsyMin = result["SubPsyMin"].ToString(),


                            UnivID = result["UnivID"].ToString()
                        };
                        Subs1.Add(u9);
                    }
                    cn.CloseConnection();
                    Subs.Add(Subs1);
                }


            }
            cn.CloseConnection(); ///Must Close
            return Subs;
            /*
             *  
             *  SubSum = int.Parse(result["SubSum"].ToString()),
               SubYE = int.Parse(result["SubYE"].ToString()),      
             * 
                
                    UserA = int.Parse(result["UserA"].ToString()),
                    UserR = int.Parse(result["UserR"].ToString()),
                    UserC = int.Parse(result["UserC"].ToString()),
                    UserI = int.Parse(result["UserI"].ToString()),
                    UserE = int.Parse(result["UserE"].ToString()),
                    UserS = int.Parse(result["UserS"].ToString()),
            
             */

            //  }

        }













    }
}
