using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
   
    static long candies(int n, int[] arr) {
        var offset = 1;
        var result = new long[n];
        result[0] = 1;
        result[n - offset] = 1;
        
        for(var i = 1; i < n; i++) {
           if(arr[i] > arr[i - 1]) {
               result[i] = result[i - 1] + 1;
           }
           else {
               result[i] = 1;
           }
        }
        
        for(var i = n - 1 - offset; i >= 0; i--) {            
           if(arr[i] > arr[i + 1]) {
               var val = result[i + 1] + 1;
               if(val > result[i]) {
                   result[i] = val;
               }
           }
        }
        
        long ways = 0;
        for(var i = 0; i < n; i++) {
            ways += result[i];
        }
        return ways;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        for(int arr_i = 0; arr_i < n; arr_i++){
           arr[arr_i] = Convert.ToInt32(Console.ReadLine());   
        }
        long result = candies(n, arr);
        Console.WriteLine(result);
    }
}
