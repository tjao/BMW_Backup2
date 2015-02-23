using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;

namespace EEGDatabase
{
    public class Database
    {
        // for table UserFinder
        String user = "Zijian";
        // for table bandpower
        public Queue<double> alpha_o1 = new Queue<double>();
        public Queue<double> beta_o1 = new Queue<double>();
        public Queue<bool> closedEye = new Queue<bool>();

        // for table EEG
        Queue<double> AF3 = new Queue<double>();
        Queue<double> F7 = new Queue<double>();
        Queue<double> F3 = new Queue<double>();
        Queue<double> FC5 = new Queue<double>();
        Queue<double> T7 = new Queue<double>();
        Queue<double> P7 = new Queue<double>();
        Queue<double> O1 = new Queue<double>();
        Queue<double> O2 = new Queue<double>();
        Queue<double> P8 = new Queue<double>();
        Queue<double> T8 = new Queue<double>();
        Queue<double> FC6 = new Queue<double>();
        Queue<double> F4 = new Queue<double>();
        Queue<double> F8 = new Queue<double>();
        Queue<double> AF4 = new Queue<double>();
        Queue<double> TimeStamp = new Queue<double>();

        // for signal table use only
        Queue<double> GYROX = new Queue<double>();
        Queue<double> GYROY = new Queue<double>();
        Queue<double> ES_TIMESTAMP = new Queue<double>();
        Queue<double> FUNC_ID = new Queue<double>();
        Queue<double> FUNC_VALUE = new Queue<double>();
        Queue<double> MARKER = new Queue<double>();
        Queue<double> SYNC_SIGNAL = new Queue<double>();



        Queue<int> section = new Queue<int>();
        Queue<String> ComputerTime = new Queue<String>();


        public Boolean CreateUser()
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            // Let the SQLiteCommand object know our SQL-Query:

            // need to find the user in the databse table userFinder
            // TODO  create table userFinder
            sqlite_cmd.CommandText = "SELECT * FROM UserFinder where UserName='" + user + "';";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            Boolean userExist = true;
            try
            {
                userExist = sqlite_datareader.Read();
                if (userExist)
                {
                    Console.WriteLine("User " + user + " Existed");
                    Console.WriteLine("User" + sqlite_datareader["UserName"]);
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("User " + user + " Not Existed");
                userExist = false;
            }
            sqlite_conn.Close();

            if (!userExist)
            {
                // We use these three SQLite objects:


                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
                // open connecttion to database
                sqlite_conn.Open();
                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "CREATE TABLE " + user + "_EEG( AF3 double , F7 double , F3 double,FC5 double, T7 double,P7 double,O1 double, O2 double,P8 double ,T8 double,FC6 double,F4 double,F8 double,AF4 double,TimeStamp double,section integer, ComputerTime varchar);";
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Creatring Table " + user + "_EEG\n");
                sqlite_cmd.CommandText = "CREATE TABLE " + user + "_BandPower" + "( Alpha double, Beta double, EyeClosed bool);";
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Creatring Table " + user + "_BandPower\n");
                sqlite_cmd.CommandText = "CREATE TABLE " + user + "_Signal" + "(GYROX double ,GYROY double ,ES_TIMESTAMP double ,FUNC_ID double,FUNC_VALUE double,MARKER double,SYNC_SIGNAL double, section integer) ;";
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Creatring Table " + user + "_Signal\n");



                sqlite_cmd.CommandText = "INSERT INTO UserFinder (UserName) VALUES ('" + user + "');";
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("Inserting New User " + user + " To UserFinder\n");

            }
            sqlite_conn.Close();
            return userExist;
        }

        public void CreateUserFinder()
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "CREATE TABLE UserFinder (UserName varchar(50) );";
            try
            {
                sqlite_cmd.ExecuteNonQuery();
                Console.WriteLine("UserFinder Created");
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("UserFinder Exist");
            }
            sqlite_conn.Close();
        }


        void EEG_Insert(String UserName, double AF3, double F7, double F3, double FC5, double T7, double P7, double O1, double O2, double P8, double T8, double FC6, double F4, double F8, double AF4, double TimeStamp, int section, String ComputerTime)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO " + user + "_EEG (AF3 , F7 , F3,FC5 , T7 ,P7,O1, O2 ,P8  ,T8 ,FC6 ,F4 ,F8 ,AF4 ,TimeStamp ,section , ComputerTime ) VALUES('" + UserName + "'," + AF3 + "," + F7 + "," + F3 + "," + FC5 + "," + T7 + "," + P7 + "," + O1 + "," + O2 + "," + P8 + "," + FC6 + "," + F4 + "," + F8 + "," + T8 + "," + AF4 + "," + TimeStamp + "," + section + ",'" + ComputerTime + "');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void BandPowerInsert(String UserName, double Alpha, double Beta, bool EyeClosed)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO " + user + "_BandPower (Alpha , Beta ,EyeClosed ) VALUES( " + Alpha + "," + Beta + ",'" + EyeClosed + "');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }


        void SignalInsert(String user, double GYROX, double GYROY, double ES_TIMESTAMP, double FUNC_ID, double FUNC_VALUE, double MARKER, double SYNC_SIGNAL, int section)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO " + user + "_Signal (GYROX ,GYROY ,ES_TIMESTAMP ,FUNC_ID ,FUNC_VALUE ,MARKER ,SYNC_SIGNAL , section) VALUES(" + GYROX + "," + GYROY + "," + ES_TIMESTAMP + "," + FUNC_ID + "," + FUNC_VALUE + "," + MARKER + "," + SYNC_SIGNAL + "," + section + ");";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }


        public void Load_Signal(String user)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + user + "_Signal";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                GYROX.Enqueue((double)sqlite_datareader["GYROX"]);
                GYROY.Enqueue((double)sqlite_datareader["GYROY"]);
                ES_TIMESTAMP.Enqueue((double)sqlite_datareader["ES_TIMESTAMP"]);
                FUNC_ID.Enqueue((double)sqlite_datareader["FUNC_ID"]);
                FUNC_VALUE.Enqueue((double)sqlite_datareader["FUNC_VALUE"]);
                SYNC_SIGNAL.Enqueue((double)sqlite_datareader["SYNC_SIGNAL"]);
                //section.Enqueue((Int32)sqlite_datareader["section"]);

            }
            sqlite_conn.Close();
            Console.WriteLine("Finish Loading Signal Data");
        }


        void Load_EEGData(String User)
        {
            Console.WriteLine("Start Loading EEG Data");
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + User + "_EEG";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                AF3.Enqueue((double)sqlite_datareader["AF3"]);
                F7.Enqueue((double)sqlite_datareader["F7"]);
                F3.Enqueue((double)sqlite_datareader["F3"]);
                FC5.Enqueue((double)sqlite_datareader["FC5"]);
                T7.Enqueue((double)sqlite_datareader["T7"]);
                P7.Enqueue((double)sqlite_datareader["P7"]);
                O1.Enqueue((double)sqlite_datareader["O1"]);
                O2.Enqueue((double)sqlite_datareader["O2"]);
                P8.Enqueue((double)sqlite_datareader["P8"]);
                T8.Enqueue((double)sqlite_datareader["T8"]);
                FC6.Enqueue((double)sqlite_datareader["FC6"]);
                F4.Enqueue((double)sqlite_datareader["F4"]);
                F8.Enqueue((double)sqlite_datareader["F8"]);
                AF4.Enqueue((double)sqlite_datareader["AF4"]);
                TimeStamp.Enqueue((double)sqlite_datareader["TimeStamp"]);
            }
            sqlite_conn.Close();
            Console.WriteLine("Finish Loading EEG Data");
        }

        public void Load_BandPowerData(String UserName)
        {
            Console.WriteLine("Start Loading BandPower Data");
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=false;Compress=True;");
            // open connecttion to database
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + UserName + "_BandPower";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                alpha_o1.Enqueue((double)sqlite_datareader["Alpha"]);
                beta_o1.Enqueue((double)sqlite_datareader["Beta"]);
                closedEye.Enqueue((bool)sqlite_datareader["EyeClosed"]);
            }
            sqlite_conn.Close();
            Console.WriteLine("Finish Loading BandPower Data\n");
        }

        public Database()
        {
            //need to comment out later
            CreateUserFinder();

        }



        public void SetUserName(String username)
        {
            user = username;
        }


        #region Main function
        static void Main(string[] args)
        {
            Database db = new Database();
            //   db.CreateUserFinder();

            db.SetUserName("Che");
            db.CreateUser();
            db.BandPowerInsert("Che", 23.22, 23.00, true);
            db.SignalInsert("Che", 23.3, 23.4, 12.2, 54.5, 34.3, 3.12, 56.7, 2);
            db.Load_Signal("Che");
            db.Load_BandPowerData("che");
            //  db.GYROX.Peek();
            Console.WriteLine(db.alpha_o1.Peek());
            Console.WriteLine(db.beta_o1.Peek());
            Console.WriteLine(db.closedEye.Peek());
            Console.ReadKey();
        }
        #endregion

    }
}
