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

int solveRecursive(const vector<pair<int, int>>& intervals, int index) {
	int value = 0;
	if (index == 0) {
		value =  1;
	}

	int previousOptIfCurrentIsPartOfOpt = getOptForLargestIndexOfIntervalEndTimeBeforeStartOfCurrentInterval(intervals, index);
	if (previousOptIfCurrentIsPartOfOpt >= 0) {
		int value = max(value + solveRecursive(intervals, previousOptIfCurrentIsPartOfOpt), solveRecursive(intervals, index - 1));
	}
	
	return value;
}

// Random test input ordered by end time asc:
// 1		-- t	: No. of test cases
// 1 4		-- s e	: Start and end time respectively
// 2 5
// 4 7
// 3 8
// 6 9
// 7 9
int main() {
	int size = 6;
	vector<pair<int, int>> intervals({
		pair<int, int>(1, 4),
		pair<int, int>(2, 5),
		pair<int, int>(4, 7),
		pair<int, int>(3, 8),
		pair<int, int>(6, 9),
		pair<int, int>(7, 9),
	});

	solveRecursive(intervals, 6);

	return 1;
}
