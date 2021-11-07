using System;
using UnityEngine;
using Unity.Mathematics;


namespace FixedMath
{
    class Program
    {
        static void Main(string[] args)
        {
            // float3 f  = new float3(1,1,1);
            // float3 g = new float3(2.4f,2.6f,1.4f);
            // var aa = f+g;
            // Console.WriteLine(math.distance(g,f));
            // Console.WriteLine(math.dot(f,g));
            FixedVector3 ang1 = new FixedVector3(1,0,0);
            FixedVector3 ang2 = new FixedVector3(1,(FixedInt)1.732f,0);
            Console.WriteLine(FixedVector3.Angle(ang1,ang2).ConvertToViewAngle());
            Console.WriteLine(FixedVector3.Angle(ang1,ang2).ConvertToFloat());
            Console.WriteLine(FixedVector3.Angle(ang1,ang2));
            FixedInt s = 12;
            Console.WriteLine(FixedCalculate.Sqrt(3));
           
            FixedInt a = 0;
            FixedInt q = FixedCalculate.Sqrt(a);
            // Console.WriteLine(q);
            FixedInt b = (FixedInt)0.3f;
            
            FixedInt c = (FixedInt)(-0.3f);
            // FixedInt c = a/b;
            // Console.WriteLine((a*b).RawInt.ToString()+" "+(a*c).RawInt.ToString());

        Console.ReadKey();


        }
        //  void MathematicTest(){
        //       var v1 = float3(1,2,3);
        //         var v2 = float3(4,5,6);
        //         v1 = normalize(v1);
        //         v2 = normalize(v2);
        //         var v3 = dot(v1, v2);
        //         Console.WriteLine(v3);
        //  }
    }
}
