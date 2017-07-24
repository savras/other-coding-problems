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

using std::endl;
using std::cin;
using std::cout;

int main() {


	return 1;
}
