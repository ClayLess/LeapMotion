using System;
using Leap;

namespace HandDatas
{
    public class HandKeyData
    {
        public HandKeyData()
        {
            Finger_ = new FingerKeyData[5];
            for (int i = 0; i < 5; i++)
            {
                Finger_[i] = new FingerKeyData();
            }
        }
        //copy data from class Hand (3-level depth recursion)
        public void Load(Hand hand)
        {

            Finger_Count = hand.Fingers.Count;
            int f = 0;
            foreach (Finger finger in hand.Fingers)
            {
                Finger_[f].Load(finger);
                f++;
            }

            PalmPosition = hand.PalmPosition;
            normal = hand.PalmNormal;
            direction = hand.Direction;
        }
        //get the rigid matrix for mirror left hand to right one
        public Matrix MirrorXRI()
        {
            Vector handXBasis = normal.Cross(direction).Normalized;
            Vector handYBasis = normal;
            Vector handZBasis = direction;
            //new center
            Vector handOri = PalmPosition;
            Matrix MX = new Matrix(handXBasis * -1, handYBasis, handZBasis, handOri);
            MX = MX.RigidInverse();
            return MX;
        }
        //transform method
        public void Transform(Matrix M)
        {
            foreach (FingerKeyData tmp_fkd in Finger_)
            {
                tmp_fkd.Transform(M);
            }
            PalmPosition = M.TransformPoint(PalmPosition);
            normal = M.TransformDirection(normal);
            direction = M.TransformDirection(direction);
        }
        //get the rigid matrix to transform coordinate system to palm position ,Z is hand direction, Y is the normal of the palm
        public Matrix GetRIMatrix()
        {
            Vector handXBasis = normal.Cross(direction).Normalized;
            Vector handYBasis = normal;
            Vector handZBasis = direction;
            Vector handOri = PalmPosition;
            Matrix M = new Matrix(handXBasis, handYBasis, handZBasis, handOri);
            M = M.RigidInverse();
            return M;
        }
        //overload method of GetRIMatrix() with Hand data input
        public Matrix GetRIMatrix(Hand hand)
        {
            Vector handXBasis = hand.PalmNormal.Cross(hand.Direction).Normalized;
            Vector handYBasis = hand.PalmNormal;
            Vector handZBasis = hand.Direction;
            Vector handOri = hand.PalmPosition;
            Matrix M = new Matrix(handXBasis, handYBasis, handZBasis, handOri);
            M = M.RigidInverse();
            return M;
        }
        public FingerKeyData[] Finger_;
        public int Finger_Count;
        public Vector PalmPosition;
        public Vector normal;
        public Vector direction;
    }
    //level-2 recursion
    public class FingerKeyData
    {
        public enum FingerType
        {
            THUMB=0,
            INDEX=1,
            MIDDLE=2,
            RING=3,
            PINKY=4
        }

        

        public FingerKeyData()
        {
            Bone_ = new BoneKeyData[4];
            for (int b = 0; b < 4; b++)
            {
                Bone_[b] = new BoneKeyData();
            }
        }
        public void Load(Finger finger)
        {

            Bone bone;
            for (int b = 0; b < 4; b++)
            {
                bone = finger.Bone((Bone.BoneType)b);
                Bone_[b].Load(bone);
            }
            type = (FingerType)(int)finger.Type;
            Length = finger.Length;
            TipPosition = finger.TipPosition;
        }
        public void Transform(Matrix M)
        {
            foreach (BoneKeyData tmp_bky in Bone_)
            {
                tmp_bky.Transform(M);
            }
            TipPosition = M.TransformPoint(TipPosition);
        }
        public BoneKeyData[] Bone_;
        public float Length;
        public Vector TipPosition;
        public FingerType type;
    }
    //level-3 recursion
    public class BoneKeyData
    {
        public void Load(Bone bone)
        {
            PrevJoint = bone.PrevJoint;
            NextJoint = bone.NextJoint;
            Direction = bone.Direction;
        }
        public void Transform(Matrix M)
        {
            PrevJoint = M.TransformPoint(PrevJoint);
            NextJoint = M.TransformPoint(NextJoint);
            Direction = M.TransformDirection(Direction);
        }
        public Vector PrevJoint;
        public Vector NextJoint;
        public Vector Direction;
    }
    //method for print
    //translate the finger number to chinese finger name
    public static class FT_Extension
    {
        public static string ToChinese(this FingerKeyData.FingerType ft)
        {
            string answer;
            switch (ft)
            {
                case FingerKeyData.FingerType.THUMB:
                    answer = "大拇指";
                    break;
                case FingerKeyData.FingerType.INDEX:
                    answer = "食指";
                    break;
                case FingerKeyData.FingerType.MIDDLE:
                    answer = "中指";
                    break;
                case FingerKeyData.FingerType.RING:
                    answer = "无名指";
                    break;
                case FingerKeyData.FingerType.PINKY:
                    answer = "小拇指";
                    break;
                default:
                    answer = "";
                    break;
            }
            return answer;
        }
    }
}

