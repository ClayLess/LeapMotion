using System;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace TestMySQLConnecter
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "server=localhost;User Id=root;password=123456;Database=test1";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            /*
            MySqlCommand mycmd1 = new MySqlCommand("insert into arm values(1,-107,177,312,-83,232,72,-95,204,192,0.09857,0.2244,-0.9694,247,54,0.1116,-0.0528,0.0284,0.9919)", mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine(mycmd.CommandText);
                Console.WriteLine("数据插入成功！");
            }
            */
            MySqlCommand mycmd2 = new MySqlCommand("select * from arm", mycon);
            MySqlDataReader reader = mycmd2.ExecuteReader();
            //Console.WriteLine("id  name");
            while(reader.Read())
            {
                if(reader.HasRows)
                {
                    //Console.WriteLine(reader.GetInt32(0) + "  " + reader.GetString(1) + " "+reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " " + reader.GetString(1) + " ");
                    Console.Write(reader.GetInt32(0));
                    for (int i = 1; i < 18; i++)
                        Console.Write(" "+reader.GetFloat(i));
                    Console.WriteLine(" "+reader.GetFloat(18));
                }
            }
            Console.ReadLine();
            mycon.Close();
        }
    }
}
