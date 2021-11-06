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
            if(a == (FixedInt)0)   return 0;
            
            if(a < (FixedInt)0) throw new Exception();

            FixedInt result = a;
            FixedInt pre =result;
            for(int i=0;i<interatorCount;i++){
                result = (result + a / result) >>1;
                if(pre == result) break;
                pre = result;
            }

            return result;
        }
    
        public static FixedInt Acos(FixedInt a){
            return 0;
        }
    
    
    }
}