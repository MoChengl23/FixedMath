using System;
using UnityEngine;

namespace FixedMath
{


#if UNITY_ENV
    // public Vector3 = 
#endif

    public struct FixedInt {
        // UnityEngine.Vector3 aa = new UnityEngine.Vector3(1,1,1);
        private long scaledValue;
        public long ScaledValue{
            get => scaledValue;
            set => scaledValue = value;
        }
        
        const int BIT_MOVE_COUNT = 10;
        const long MUTIPLIER_FACTOR = 1<< BIT_MOVE_COUNT;
        //内部使用，已经放大后的数
        private FixedInt(long scaledValue){
            this.scaledValue = scaledValue;
        }
        public FixedInt(int value){
            scaledValue = value * MUTIPLIER_FACTOR;
        }

        public FixedInt(float value){
            scaledValue = (long)Math.Round(value * MUTIPLIER_FACTOR);
        }

        public static explicit operator FixedInt(float f){
            return new FixedInt((long)Math.Round(f * MUTIPLIER_FACTOR));
        }
        public static implicit operator FixedInt(int i){
            return new FixedInt(i);
        }
    
#region 计算符
        public static FixedInt operator -(FixedInt value){
            return  new FixedInt(-value.scaledValue);
        }
        public static bool  operator ==(FixedInt a, FixedInt b){
            return a.scaledValue == b.scaledValue;
        }

        public static bool operator !=(FixedInt a, FixedInt b){
            return a.scaledValue != b.scaledValue;
        }

        public static bool operator <(FixedInt a, FixedInt b){
            return a.scaledValue < b.scaledValue;
        }
        public static bool operator >(FixedInt a, FixedInt b){
            return a.scaledValue > b.scaledValue;
        }
        public static bool operator <=(FixedInt a, FixedInt b){
            return a.scaledValue <= b.scaledValue;
        }
        public static bool operator >=(FixedInt a, FixedInt b){
            return a.scaledValue >= b.scaledValue;
        }
        public static FixedInt operator <<(FixedInt value, int moveCount){
            return new FixedInt(value.scaledValue << moveCount);
        }
        public static FixedInt operator >>(FixedInt value, int moveCount){
            if(value.scaledValue >= 0)
                return new FixedInt(value.scaledValue >> moveCount);
            else
                return new FixedInt(-(-value.scaledValue >> moveCount));
        }
        public static FixedInt operator +(FixedInt a, FixedInt b){
            return new FixedInt(a.scaledValue + b.scaledValue);
        }
        public static FixedInt operator -(FixedInt a, FixedInt b){
            return new FixedInt(a.scaledValue - b.scaledValue);
        }
        public static FixedInt operator *(FixedInt a, FixedInt b){
            long result = a.scaledValue * b.scaledValue;
            if(result >=0)
                result >>= BIT_MOVE_COUNT;
            else 
                result = -(-result >> BIT_MOVE_COUNT);
            return new FixedInt(result);
        }
        public static FixedInt operator /(FixedInt a, FixedInt b){
            if (b.scaledValue == 0) throw new Exception();
            return new FixedInt((long)(a.scaledValue / b.scaledValue)<< BIT_MOVE_COUNT);
        }
        



        #endregion
        /// <summary>
        /// 转化回原始大小的数字，不能再参与运算了
        /// </summary>
        /// <value></value>
        public float RawFloat{
            get => scaledValue *1.0f/MUTIPLIER_FACTOR;
        }
        public int RawInt{
            get {
                if(scaledValue >= 0)
                    return    (int)(scaledValue >> BIT_MOVE_COUNT);
                else
                //将负数转化为正数，使正负数舍入时， 值一样
                    return -(int)(-scaledValue >> BIT_MOVE_COUNT);
            } 
        }

        public override bool Equals(object obj){
            if(obj == null){
                return false;
            }
            FixedInt vint  = (FixedInt)obj;
            return scaledValue == vint.scaledValue;
        }
        public override int GetHashCode(){
            return scaledValue.GetHashCode();
        }


        public override string ToString(){
            return RawFloat.ToString();
        }
        
        }



}
