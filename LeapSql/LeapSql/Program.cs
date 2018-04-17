using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapSql
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string connectinfo = "server=localhost;User Id=root;password=123456;Database=test1";
            //Arm part test 
            /*
            ArmSql test1 = new ArmSql(new MySql.Data.MySqlClient.MySqlConnection(connectinfo));
            //test1.arm = new Arm(new Vector(-107, 177, 312), new Vector(-83, 232, 72), new Vector(-95, 204, 192), new Vector((float)0.09857, (float)0.2244, (float)-0.9694), (float)247, (float)54, new LeapQuaternion((float)0.1116, (float)-0.0528, (float)0.0284, (float)0.9919));
            //test1.AddArm2DB(1);
            //test1.arm = new Arm();
            test1.GetArmFromDB(1);
            test1.arm.GetType();
            */
            //Bone part test
            BoneSql test2 = new BoneSql(new MySql.Data.MySqlClient.MySqlConnection(connectinfo));
            test2.bone = new Bone(new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(0, 0, 0), 0, (float)16.8, Bone.BoneType.TYPE_METACARPAL, new LeapQuaternion((float)0.1993, (float)-0.2273, (float)-0.4926, (float)0.8160));
            test2.AddBone2DB(111);
            test2.bone = new Bone();
            test2.GetBoneFromDB(111);
        }
    }
}
