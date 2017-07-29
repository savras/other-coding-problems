/*
 * Explanation:  OPT(j) = max(vj + OPT(p(j)), OPT(j−1))
 * OPT(j): the optimal solution at index j
 *
 * If an optimal solution includes the interval at index j, then:
 * vj: the value of j, that is, the reward for taking into consideration an interval at index j
 * OPT(p(j)): the optimal value before the interval at j. This is because if j part of an optimal solution, O, then
 * we must not have any other intervals in O that intersects with interval j
 *
 * Otherwise, the optimal solution when considering the interval at index j is the same as
 * the optimal solution without considering interval at j.
 * OPT(j - 1): the optimal solution without interval at j
 */
#include<iostream>
#include<utility>
#include<algorithm>
#include<vector>

using std::endl;
using std::cin;
using std::cout;
using std::pair;
using std::vector;
using std::max;

// Doesn't work for intervals with different weights because its not guaranteed that 
// the largest (non-overlapping) indexed interval before currrent will give max.
// The optimal selection might be the earlier interval. In this case better to start from i = 0 to m, where m is the latest interval
// that doesn't overlap.
int getOptForLargestIndexOfIntervalEndTimeBeforeStartOfCurrentInterval(const vector<pair<int, int>>& intervals, int currentIndex) {
	int result = -1;
	int currentStartValue = intervals[currentIndex].first;

	for (int i = currentIndex - 1; i >= 0; i--) {
		if (currentStartValue >= intervals[i].second) {
			result = i;
			break;
		}
	}
	return result;
}

int solveRecursive(const vector<pair<int, int>>& intervals, int index, vector<int>& memo) {
	if (index == 0) {
		return 1;
	}

	// index is part of optimal solution
	int previousOptIfCurrentIsPartOfOpt = getOptForLargestIndexOfIntervalEndTimeBeforeStartOfCurrentInterval(intervals, index);
	if (previousOptIfCurrentIsPartOfOpt >= 0) {
		if (memo[index] == 0) {
			int optIncludesCurrent = 1 + solveRecursive(intervals, previousOptIfCurrentIsPartOfOpt, memo);
			memo[index] = optIncludesCurrent;
		}
	}
	else {
		memo[index] = 1;
	}

	// index is not part of optimal solution
	if (memo[index - 1] == 0) {
		int optExcludesCurrent = solveRecursive(intervals, index - 1, memo);
		memo[index - 1] = optExcludesCurrent;
	}

	int value = max(memo[index], memo[index - 1]);
	return value;
}

int solveDp(const vector<pair<int, int>>& intervals, const int& size) {
	vector<int> dp(size);
	
	dp[0] = 1;	// Can easily grap the value of intervals[0] if we want to use the weight instead.
	for (size_t i = 1; i < size; i++) {
		int previousOptIfCurrentIsPartOfOpt = getOptForLargestIndexOfIntervalEndTimeBeforeStartOfCurrentInterval(intervals, i);
		previousOptIfCurrentIsPartOfOpt = previousOptIfCurrentIsPartOfOpt == -1 ? 0 : previousOptIfCurrentIsPartOfOpt;
		int value = max(1 + dp[previousOptIfCurrentIsPartOfOpt], dp[i - 1]);
		dp[i] = value;
	}

	return dp[size - 1];
}

// Random test input ordered by end time asc:
// 1		-- t	: No. of test cases
// 1 4		-- s e	: Start and end time respectively
// 2 5
// 4 7
// 3 8
// 6 9
// 7 9
// 8 10
int main() {	
	vector<pair<int, int>> intervals({
		pair<int, int>(1, 4),
		pair<int, int>(2, 5),
		pair<int, int>(4, 7),
		pair<int, int>(3, 8),
		pair<int, int>(6, 9),
		pair<int, int>(7, 9),
		pair<int, int>(8, 10),
	});
	int size = intervals.size();

	const int arrayOffset = 1;
	vector<int> memo(size);
	//cout << solveRecursive(intervals, size - arrayOffset, memo) << endl;;
	cout << solveDp(intervals, size) << endl;;

	return 1;
}
