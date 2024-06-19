using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Universities2.Models
{
    public class ClassUser2
    {
        public string UserName { set; get; }
        public string UserID { set; get; }
        public string UserEmail { set; get; }
        public int UserAge { set; get; }
        public string UserPassword { set; get; }
        public string UserGender { set; get; }
        public double  UserBgrtSum { set; get; }
        public int UserPsySum{ set; get; }
        public int UserA { set; get; }
        public int UserR { set; get; }
        public int UserC { set; get; }
        public int UserI { set; get; }
        public int UserE { set; get; }
        public int UserS { set; get; }
        public string UserSh { set; get; }
        public int[] Q {set ; get; }
        public double Rs0 { set; get; }
        public double Rs1 { set; get; }
        public double Rs2 { set; get; }
        public double Rs3 { set; get; }
        public double Rs4 { set; get; }
        public double Rs5 { set; get; }

        //**************************************************************************************
        //SEARCH--SEARCHUSER00
        public static List<ClassUser2> SearchUser(string q)
        {
            ////students -->Univs-->Users
            List<ClassUser2> Users = new List<ClassUser2>();

            Connector cn = new Connector(Configs.DB_NAME);
            //Connector cn = new Connector("Folder1/database99.accdb");

            //string sql2 = "SELECT * FROM Students WHERE student_name LIKE '%ah%'";
            string sql = "SELECT User2.* FROM User2";
            // Universit--> Userr
            List<ClassUser2> Userr = new List<ClassUser2>();

            ///**********************************
            if (q != null)
            {
                sql += " WHERE UserName Like '%" + q + "%'";
                sql += " OR UserID like '%" + q + "%'";
            }



            OleDbDataReader result = cn.RunSelect(sql);
            while (result.Read())
            {
                //u11-->us11
                ClassUser2 us11 = new ClassUser2
                {
                    UserID = result["UserID"].ToString()
                    ,
                    UserAge = int.Parse(result["UserAge"].ToString())
                    ,
                    UserBgrtSum = double.Parse(result["UserBgrtSum"].ToString())
                    ,
                    UserPsySum = int.Parse(result["UserPsySum"].ToString())
                    ,
                    UserEmail = result["UserEmail"].ToString()
                    ,
                    UserName = result["UserName"].ToString()
                    ,
                    UserI = int.Parse(result["UserI"].ToString())
                    ,
                    UserE = int.Parse(result["UserE"].ToString())
                   ,
                    UserC = int.Parse(result["UserC"].ToString())
                    ,
                    UserA = int.Parse(result["UserA"].ToString())
                    ,
                    UserGender = result["UserGender"].ToString()
                    ,
                    UserR = int.Parse(result["UserR"].ToString())
                    ,
                    UserPassword = result["UserPassword"].ToString()
                    ,

                    UserS = int.Parse(result["UserS"].ToString())
                   

                };
                
                Userr.Add(us11);
            }
            cn.CloseConnection(); ///Must Close
            return Userr;


            //  }

        }
        //**************************************************************************************
        public static bool AddToDB(ClassUser2 st)
        {
            if (st == null) return false;


            Connector cn = new Connector(Configs.DB_NAME);
            //string sql = "INSERT INTO User2(";
            string sql = "INSERT INTO User2(";
            sql += "UserName,UserID,UserEmail,";
            sql += "UserAge,UserPassword,UserGender";
            sql += ")";
            sql += " VALUES(";
            //sql += "'" + st.UnivID + "'";
            sql += "'" + st.UserName + "'";
            sql += ",'" + st.UserID + "'";
            sql += ",'" + st.UserEmail + "'";
            sql += ",'" + st.UserAge + "'";
            sql += ",'" + st.UserPassword + "'";
            sql += ",'" + st.UserGender + "'";
            sql += ")";
            int x = cn.RunUpdateInsertDelete(sql);
            //if ok return true else return false......
            //return x>0;  OR....
            if (x > 0)
                return true;
            else
                return false;
        }
        //**************************************************************************************************

        public static bool DeleteByID(string UserID)
        {
            Connector cn = new Connector(Configs.DB_NAME);
            string sql = "DELETE FROM User2 WHERE UserID='" + UserID + "'";

            int x = cn.RunUpdateInsertDelete(sql);

            //if ok return true else return false......
            //return x>0;  OR....
            if (x > 0)
                return true;
            /*else
            {
                Student.MyError = cn.GetError(); ///the_exception
                return false;
            }*/
            return false;
        }
        //*************************************************
        public static ClassUser2 GetByID(string UserID)
        {
            ClassUser2 st = null;
            Connector cn = new Connector(Configs.DB_NAME);

            string sql = "SELECT * FROM User2";
            sql += " WHERE UserID ='" + UserID + "'";

            //  string sql = "SELECT * FROM Students";
            // sql += " WHERE student_ID ='" + student_ID + "'";

            OleDbDataReader result = cn.RunSelect(sql); /// matrix כאילו 

            if (result == null)
            {
                //  ClassUser.MyError = cn.GetError();
                return null;
            }

            while (result.Read())
            {
                st = new ClassUser2
                {
                    UserID = result["UserID"].ToString()
                    ,
                    UserAge = int.Parse(result["UserAge"].ToString())
                  
                   ,
                    UserBgrtSum = double.Parse(result["UserBgrtSum"].ToString())
                    ,
                    UserPsySum = int.Parse(result["UserPsySum"].ToString())
                    ,
                    UserEmail = result["UserEmail"].ToString()
                    ,
                    UserName = result["UserName"].ToString()
                    ,
                    UserSh = result["UserSh"].ToString()
                    ,
                    UserI = int.Parse(result["UserI"].ToString())
                    ,
                    UserE = int.Parse(result["UserE"].ToString())
                   ,
                    UserC = int.Parse(result["UserC"].ToString())
                    ,
                    UserA = int.Parse(result["UserA"].ToString())
                    ,
                    UserGender = result["UserGender"].ToString()
                    ,
                    UserR = int.Parse(result["UserR"].ToString())
                    ,
                    UserPassword = result["UserPassword"].ToString()
                    ,
                 
                    UserS = int.Parse(result["UserS"].ToString())

                };
            }

            cn.CloseConnection(); ///Must Close
            return st;
        }
            //************************************************************************************************
            public static bool Update(ClassUser2 st)
        {
            Connector cn = new Connector(Configs.DB_NAME);
            string sql = "UPDATE User2 SET ";
            sql += "UserName='" + st.UserName + "'";
            sql += ",UserEmail='" + st.UserEmail + "'";
            sql += ",UserAge=" + st.UserAge + "";
          //  sql += ",UserPassword='" + st.UserPassword + "'";
            // sql += ",UserGender='" + st.UserGender + "'";
           // sql += " WHERE UserID='" + st.UserID + "'";
            int x = cn.RunUpdateInsertDelete(sql);

            //if ok return true else return false......
            //return x>0;  OR....
            if (x > 0)
                return true;
            /*else
            {
                Student.MyError = cn.GetError(); ///the_exception
                return false;
            }*/
            return false;
        }
        //*****************************************************************************
        public static ClassUser2 AddPoints(ClassUser2 st)
        {

            for (int i = 0; i < 19; i += 6)
            { st.UserI += st.Q[i];
                st.UserA += st.Q[i + 1];
                st.UserS += st.Q[i + 2];
                st.UserE += st.Q[i + 3];
                st.UserC += st.Q[i + 4];
                st.UserR += st.Q[i + 5];

            }
            Connector cn = new Connector(Configs.DB_NAME);
            string sql = "UPDATE User2 SET ";
            // sql += " WHERE UserID='" + st.UserID + "'";
            sql += "UserI=" + st.UserI + "";
            sql += ",UserS=" + st.UserS + "";
            sql += ",UserR=" + st.UserR + "";
            sql += ",UserE=" + st.UserE + "";
            sql += ",UserC=" + st.UserC + "";
            sql += ",UserA=" + st.UserA + "";

            /*
            sql += ",UserPsySum=" + st.UserPsySum + "";
            sql += ",UserBgrtSum=" + st.UserBgrtSum + "";
            sql += ",UserName='" + st.UserName + "'";
              sql += ",UserEmail='" + st.UserEmail + "'";
             sql += ",UserAge=" + st.UserAge + "";
              sql += ",UserPassword='" + st.UserPassword + "'";
              sql += ",UserGender='" + st.UserGender + "'";
            */

            int x = cn.RunUpdateInsertDelete(sql);

            //if ok return true else return false......
            //return x>0;  OR....
            //  double[] Rs = new double[6];
            if (x > 0)
            {
                int max2 = st.UserA; st.UserSh = "Artistic"; 
                if (st.UserC > max2) { max2 = st.UserC; st.UserSh = "Conventional"; }
                if (st.UserR > max2) { max2 = st.UserR; st.UserSh = "Realistic"; }
                if (st.UserE > max2) { max2 = st.UserE; st.UserSh = "Enterprising"; }
                if (st.UserS > max2) {max2 = st.UserS; st.UserSh = "Social"; }
                if (st.UserI > max2) {max2 = st.UserI; st.UserSh = "Investigative"; }

                double sum = (double)(st.UserA + st.UserC + st.UserE + st.UserI + st.UserR + st.UserS);
              //  int[] a = { st.UserC,st.UserC,st.UserC,st.UserC,st.UserC,st.UserC};
                    st.Rs0 =(double) ((st.UserI/sum)*100) ;
                st.Rs1 = (double)((st.UserC / sum) * 100);
                st.Rs2 = (double)((st.UserR / sum) * 100);
                st.Rs5 = (double)((st.UserE / sum) * 100);
                st.Rs3 = (double)((st.UserS / sum) * 100);
                st.Rs4 = (double)((st.UserA / sum) * 100);

                cn = new Connector(Configs.DB_NAME);
                sql = "UPDATE User2 SET ";
                // sql += " WHERE UserID='" + st.UserID + "'";
                sql += "UserSh='" + st.UserSh + "'";
                sql += "Rs0=" + st.Rs0 + "";
                sql += ",Rs1=" + st.Rs1 + "";
                sql += ",Rs2=" + st.Rs2 + "";
                sql += ",Rs3=" + st.Rs3 + "";
                sql += ",Rs4=" + st.Rs4 + "";
                sql += ",Rs5=" + st.Rs5 + "";

                /*
                sql += ",UserPsySum=" + st.UserPsySum + "";
                sql += ",UserBgrtSum=" + st.UserBgrtSum + "";
                sql += ",UserName='" + st.UserName + "'";
                  sql += ",UserEmail='" + st.UserEmail + "'";
                 sql += ",UserAge=" + st.UserAge + "";
                  sql += ",UserPassword='" + st.UserPassword + "'";
                  sql += ",UserGender='" + st.UserGender + "'";
                */

               x = cn.RunUpdateInsertDelete(sql);
                return st;
            }
           
            return st;
        }
        //****************************************************************************
        //we will use this method when making authentication - LOgin SignIn
        public static ClassUser2 TryLogin(string UserEmail, string UserPassword)
        {
            ClassUser2 st = null;
            Connector cn = new Connector(Configs.DB_NAME);

            string sql = "SELECT * FROM User2";
            sql += " WHERE UserEmail ='" + UserEmail + "'";
            sql += " AND UserPassword='" + UserPassword + "'";

            OleDbDataReader result = cn.RunSelect(sql); /// matrix כאילו 

            if (result == null)
            {
                //Student.MyError = cn.GetError();
                return null;
            }

            while (result.Read())
            {

                st = new ClassUser2
                {
                    UserName = result["UserName"].ToString(),
                    UserID = result["UserID"].ToString(),
                    UserEmail = result["UserEmail"].ToString(),
                    UserAge = int.Parse(result["UserAge"].ToString()),
                    UserPassword = result["UserPassword"].ToString(),
                    UserGender = result["UserGender"].ToString()

                };
                // Universit.Add(u11);
            }

            cn.CloseConnection(); ///Must Close
            return st;
        }

       




    }
}
