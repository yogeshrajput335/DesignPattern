using System;
public class Performacetest{
    static void Main(string[] args){
        int sum =0;
        var array = Utils.RandamArray(40_000_000,0,100);
        Utils.Measure(()=>{
            sum  = SumOdd_BranchFree_Parallel_NoChecks4P_BetterPorts(array);
        });
        console.WriteLine(sum);
   }

private static int SumOdd_BranchFree_Parallel_NoChecks4P_BetterPorts(int[] array){
    int counterA=0;
    int counterB=0;
    int counterC=0;
    int counterD=0;

    fixed(int* data = &array[0]){
        var p = (int*)data;
        var n = (int*)data;

        for (int i = 0; i < array.Length; i+=4)
        {
            counterA += (n[0]&1) *p[0];
            counterB += (n[1]&1) *p[1];
            counterC += (n[2]&1) *p[2];
            counterD += (n[3]&1) *p[3];

            p+=4;
            n+=4;

        }
        
    }
} 
}

