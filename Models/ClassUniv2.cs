using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Universities2.Models
{
    public class ClassUniv2
    {
        public string UnivName { set; get; }//property
        public bool UnivOpen { set; get; }//property
        public string UnivPlace { set; get; }//property
        public string UnivPhoto { set; get; }//property
        public string UnivID { set; get; }//property
        public string UnivEmail { set; get; }//property
       // public string SubsExist { set; get; }
        public string UnivOffWeb { set; get; } // official website
        


        public static List<ClassUniv2> Search(string q)
        {
            ////students -->Univs
            List<ClassUniv2> Univs = new List<ClassUniv2>();

            Connector cn = new Connector(Configs.DB_NAME);
            //Connector cn = new Connector("Folder1/database99.accdb");

            //string sql2 = "SELECT * FROM Students WHERE student_name LIKE '%ah%'";
            string sql = "SELECT Univ2.* FROM Univ2";
           //  List<ClassUniv2> Universit = new List<ClassUniv2>();

            ///**********************************
            if (q != null)
            {
                sql += " WHERE UnivName Like '%" + q + "%'";
                sql += " OR UnivID like '%" + q + "%'";
            }



                OleDbDataReader result = cn.RunSelect(sql);
                while (result.Read())
                {
                    ClassUniv2 u11 = new ClassUniv2
                    {
                        UnivName = result["UnivName"].ToString(),
                        UnivPlace = result["UnivPlace"].ToString(),
                        UnivPhoto = result["UnivPhoto"].ToString(),
                        UnivID = result["UnivID"].ToString(),
                        UnivOpen = bool.Parse(result["UnivOpen"].ToString()),
                        UnivEmail = result["UnivEmail"].ToString()

                    };
                Univs.Add(u11);
                }
                cn.CloseConnection(); ///Must Close
                return Univs;


          //  }

        }

        public static bool AddToDB(ClassUniv2 st)
        {
            if (st == null) return false;

            Connector cn = new Connector(Configs.DB_NAME);
            string sql = "INSERT INTO Univ2(";
            sql += "UnivName,UnivPhoto,UnivOpen,";
            sql += "UnivEmail,UnivPlace,UnivOffWeb";
            sql += ")";
            sql += " VALUES(";
            //sql += "'" + st.UnivID + "'";
            sql += "'" + st.UnivName + "'";
            sql += ",'" + st.UnivPhoto + "'";
            sql += "," + st.UnivOpen + "";
            sql += ",'" + st.UnivEmail + "'";
            sql += ",'" + st.UnivPlace + "'";
            sql += ",'" + st.UnivOffWeb + "'";
            sql += ")";
            int x = cn.RunUpdateInsertDelete(sql);
            //if ok return true else return false......
            //return x>0;  OR....
            if (x > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteByID(string UserID)
        {
            Connector cn = new Connector(Configs.DB_NAME);
            string sql = "DELETE FROM Univ2 WHERE UnivID=" + UserID + "";

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










        public static List<ClassUniv2> Getunivers()
        {
            List<ClassUniv2> Universs = new List<ClassUniv2>();
            //json
            Universs.Add
             (new ClassUniv2
             {
                 UnivName = "Haifa",
                 UnivOpen = true,
                 UnivPlace = "Haifa",
                 UnivPhoto = "uof.png"
             });
            Universs.Add
            (new ClassUniv2
            {
                UnivName = "Technion",
                UnivOpen = false,
                UnivPlace = "Haifa",
                UnivPhoto = "Tech.png"
            });
            Universs.Add
            (new ClassUniv2
            {
                UnivName = "Tel Aviv University",
                UnivOpen = true,
                UnivPlace = "TA",
                UnivPhoto = "tau.png"
            });
            Universs.Add
            (new ClassUniv2
            {
                UnivName = "Open University of Israel",
                UnivOpen = true,
                UnivPlace = "Ra'anana",
                UnivPhoto = "Open.png"
            });

            return Universs;
        }

        public static List<ClassUniv2> Ranlist(List<ClassUniv2> LtoArr)
        {
            int m = 0;
            List<ClassUniv2> Ranlist = new List<ClassUniv2>();
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                m = (rnd.Next(4 - i));
                Ranlist.Add(LtoArr[m]);
                LtoArr.RemoveAt(m);
            }
            return Ranlist;
        }
    }
}
