using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void resolvePeak(int count, int peak, int i, int[] arr, long[] result) {
        if(peak != -1) {
            for(var j = i - 1; j > peak; j--) {
                result[j] = count--;
            }
            if(result[peak + 1] >= result[peak])
            {
                result[peak] = result[peak + 1] + 1;
            }
        }        
    }
    
    static long candies(int n, int[] arr) {
        var result = new long[n];
        result[0] = 1;
        var peak = -1;
        var count = 0;
        for(var i = 1; i < n; i++) {            
            if(arr[i] > arr[i - 1]) {
                if(peak != -1) {
                    resolvePeak(count, peak, i, arr, result);
                    peak = -1;
                    count = 0;
                }
                
                result[i] = result[i - 1] + 1;
            }
            else if (arr[i] == arr[i - 1]) {
                resolvePeak(count, peak, i, arr, result);
                peak = -1;
                count = 0;
                
                result[i] = result[i - 1] - 1;
                if(result[i] == 0) {
                    result[i] = 1;
                }
            }
            else {
                if(peak == -1)
                {
                    peak = i - 1;
                }
                count++;                
            }
            
            if(i == n - 1){
                resolvePeak(count, peak, i + 1, arr, result);                
            }
        }
        
        long ways = 0;
        for(var i = 0; i < result.Length; i++) {
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
