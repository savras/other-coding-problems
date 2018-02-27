This question requres us to get the largest sum of non-contiguous elements in an array.
For example [4, 6, 2, 1, 1, 2]

The largest non-contiguous sum is 6 + 1 + 2

We approach this problem using two variables that track the following:
1) Sum so far including the current item at arr[i]
2) Sum so far excluding the current item at arr[i]

The motivation behind is is that we are not allowed to pick two items next to each other.

At arr[i] when 
i = 0:
SumInclude = 4
SumExclude = 0

i = 1:
SumInclude = 6
SumExclude = 4
The reason for this is because if we pick arr[i], then we cannot pick arr[i - 1].
Therefore, if we do NOT pick arr[i], then the sum so far is 4 (Really, its Max between 0 and 4 as we will see later.)

i = 2:
SumInclude = SumExclude of arr[i - 1] + arr[i].
This is because if we pick the value at arr[i], then we cannot include the total sum value that includes the value at arr[i - 1].

SumExclude = Max (SumInclude at i - 1, SumExclude at i - 1), and this is because if we exlude the value at arr[i], the it means that we can either:
1) Pick the value at i - 1 including arr[i - 1]or,
2) Pick the value at i - 1 excluding arr[i - 1],
 and we want the largest value between the two.