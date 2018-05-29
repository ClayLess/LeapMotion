using System;
using Leap;
using HandDatas;

namespace Compare_Normalized
{
    class Compare
    {
        //plus distance of each joint of 2 bones. 
        public static Double Bone_Compare(BoneKeyData bkd0, BoneKeyData bkd1)
        {
            double an = new double();
            an = bkd0.PrevJoint.DistanceTo(bkd1.PrevJoint);
            an += bkd0.NextJoint.DistanceTo(bkd1.NextJoint);
            return an;
        }
        //plus distance of each bone of 2 fingers. 
        public static Double Finger_Compare(FingerKeyData fkd0, FingerKeyData fkd1)
        {
            double an = new double();
            for (int i = 0; i < 4; i++)
            {
                an += Bone_Compare(fkd0.Bone_[i], fkd1.Bone_[i]);
            }
            return an;
        }
        //plus distance of each finger of 2 hands. 
        public static Double Hand_Compare(HandKeyData hkd0, HandKeyData hkd1)
        {
            double an = new double();
            for (int i = 0; i < 5; i++)
            {
                an += Finger_Compare(hkd0.Finger_[i], hkd1.Finger_[i]);
            }
            //plus distance of plam position
            an += hkd0.PalmPosition.DistanceTo(hkd1.PalmPosition);
            return an;
        }
        //method of using euclidean metric
        public static Double Hand_Euclid(HandKeyData hkd0, HandKeyData hkd1)
        {
            double answer = 0;
            //plus difference of distance of tip-palm of each finger of 2 hands
            for (int i = 0; i < 5; i++)
            {
                
                answer +=Math.Abs(hkd0.PalmPosition.DistanceTo(hkd0.Finger_[i].TipPosition)
                        - hkd1.PalmPosition.DistanceTo(hkd1.Finger_[i].TipPosition));
            }
            return answer;
        }
        //get difference on dot product
        public static Double Hand_Dot_Product(HandKeyData hkd0, HandKeyData hkd1)
        {
            double answer=0f;
            double tmp_dot;
            double fkd0_self_dot;
            double fkd1_self_dot;
            for (int i=0;i<5;i++)
            {
                //get dot metrix answer of finger on different hands
                tmp_dot = hkd0.Finger_[i].TipPosition.Dot(hkd1.Finger_[i].TipPosition);
                //fingertip of each hand do self dot metrix, and the answer is square tip-palm distance
                /*
                fkd0_self_dot = Self_Dot(hkd0.Finger_[i].TipPosition);
                fkd1_self_dot = Self_Dot(hkd1.Finger_[i].TipPosition);
                //chose the bigger one
                fkd0_self_dot = fkd0_self_dot > fkd1_self_dot ? fkd0_self_dot : fkd1_self_dot;
                */
                fkd0_self_dot = hkd0.Finger_[i].TipPosition.DistanceTo(new Vector(0, 0, 0));
                fkd1_self_dot = hkd1.Finger_[i].TipPosition.DistanceTo(new Vector(0, 0, 0));
                fkd0_self_dot *= fkd1_self_dot;
                //get answer of it minus dot metrix.
                answer += fkd0_self_dot - tmp_dot;
            }
            return answer;
        }

        private static Double Self_Dot(Vector v)
        {
            return v.Dot(v);
        }
    }
    //just do size normalized
    class Normalized
    {
        public static void Hand_Normalized(ref HandKeyData hkd0, ref HandKeyData hkd1)
        {
            float changing_parameters;
            //get normalize ratio (middle finger ratio)
            changing_parameters = hkd0.Finger_[2].Length / hkd1.Finger_[2].Length;
            //do size normalize
            Hand_Normalized(ref hkd1, changing_parameters);
        }
        public static void Hand_Normalized(ref HandKeyData hkd, float changing_parameters)
        {
            for (int i = 0; i < 5; i++)
            {
                Finger_Normalized(ref hkd.Finger_[i], changing_parameters);
            }
            hkd.PalmPosition *= changing_parameters;
        }
        public static void Finger_Normalized(ref FingerKeyData fkd, float changing_parameters)
        {
            for (int i = 0; i < 4; i++)
            {
                Bone_Normalized(ref fkd.Bone_[i], changing_parameters);
            }
            fkd.Length *= changing_parameters;
            fkd.TipPosition *= changing_parameters;
        }
        public static void Bone_Normalized(ref BoneKeyData bkd, float changing_parameters)
        {
            bkd.NextJoint *= changing_parameters;
            bkd.PrevJoint *= changing_parameters;
        }
    }
}
