using System;
namespace FixedMath
{
    public class FixedCalculate
    {
        
        /// <summary>
        /// 牛顿迭代法求平方根
        /// </summary>
        /// <param name="a">传入值</param>
        /// <param name="interatorCount">迭代次数</param>
        /// <returns></returns>
        public static FixedInt Sqrt(FixedInt a, int interatorCount = 8){
            if(a == 0)   return 0;
            
            if(a < 0) throw new Exception();

            FixedInt result = a;
           
            FixedInt pre =result;
            for(int i=0;i<interatorCount;i++){
                result = (result + a / result) >>1;
                if(pre == result) break;
              
                pre = result;
            }

            return result;
        }
    
        public static FixedArgs Acos(FixedInt a){
            FixedInt rate = (a * AcosTable.HalfIndexCount) + AcosTable.HalfIndexCount;
            rate = Clamp(rate, 0, AcosTable.IndexCount);
            //rad = 弧度
            // int rad = AcosTable.table[rate.RawInt];
            return new FixedArgs(AcosTable.table[rate.RawInt],AcosTable.Multipler);
            
            
            
        }

        public static FixedInt Clamp(FixedInt input, FixedInt min, FixedInt max){
            if(input < min) return min;
            if(input > max) return max;
            return input;
        }
    
    
    }
}