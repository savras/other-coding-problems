1) The O(n) solution uses a a variable to indicate whether a cell contains positive consecutive sum (if the variable contains value > 0). This variable is populated by iterating through the array from left to right and summing it with arr[i]. Lets call this variable max_so_far.

Implications: if this variable changes from positive value to 0, it means that we have iterated through a subarray with positive sum.

2) This brings us to the other variable used to track the maximum cummulative values across all the subarrays. This variable when used together with max_so_far lets us track the largest contiguous subsequence. Using this variable, we can also find the start and end index of the largest continuous subarray.