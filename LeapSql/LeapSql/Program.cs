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
            /*
            BoneSql test2 = new BoneSql(new MySql.Data.MySqlClient.MySqlConnection(connectinfo));
            test2.bone = new Bone(new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(0, 0, 0), 0, (float)16.8, Bone.BoneType.TYPE_METACARPAL, new LeapQuaternion((float)0.1993, (float)-0.2273, (float)-0.4926, (float)0.8160));
            test2.AddBone2DB(111);
            test2.bone = new Bone();
            test2.GetBoneFromDB(111);
            */
            //Finger part test
            /*
            FingerSql test3 = new FingerSql(new MySql.Data.MySqlClient.MySqlConnection(connectinfo));
            Bone bone00 = new Bone(new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(-55, 226, 59), new Vector(0, 0, 0), 0, (float)16.8, Bone.BoneType.TYPE_METACARPAL, new LeapQuaternion((float)0.1993, (float)-0.2273, (float)-0.4926, (float)0.8160));
            Bone bone01 = new Bone(new Vector(-55, 226, 59), new Vector(-23, 226, 27), new Vector(-39, 226, 43), new Vector((float)0.7, (float)-0.018, (float)-0.7131), 45, (float)16.8, Bone.BoneType.TYPE_PROXIMAL, new LeapQuaternion((float)0.1934, (float)-0.3256, (float)-0.492954, (float)0.7832813));
            Bone bone02 = new Bone(new Vector(-23, 226, 27), new Vector(-4, 224, 4), new Vector(-13, 225, 16), new Vector((float)0.6434, (float)-0.553, (float)-0.7635), 29, (float)16.8, Bone.BoneType.TYPE_INTERMEDIATE, new LeapQuaternion((float)0.1599, (float)-0.3044, (float)-0.5064, (float)0.7908));
            Bone bone03 = new Bone(new Vector(-4, 224, 4), new Vector(9, 223, -10), new Vector(3, (float)223.5, -3), new Vector((float)0.6689, (float)-0.0392, (float)0.7423), 20, (float)16.8, Bone.BoneType.TYPE_DISTAL, new LeapQuaternion((float)0.1744, (float)-0.3136, (float)-0.5, (float)0.7877));
            test3.finger = new Finger(1, 11, 110, 10000, new Vector(9, 223, -10), new Vector(-132, -101, 2), new Vector((float)0.6434, (float)-0.0552, (float)-0.7635), new Vector(5, 220, -7), 17, 90, true, Finger.FingerType.TYPE_THUMB, bone00, bone01, bone02, bone03);
            test3.AddFinger2DB(11);
            test3.finger = new Finger();
            test3.GetFingerFromDB(11);
            */
        }
    }
}
