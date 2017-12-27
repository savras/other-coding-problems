#include <vector>
#include <queue>
#include <iostream>
#include <algorithm>

using std::vector;
using std::cin;
using std::cout;
using std::endl;
using std::min;
using std::queue;

vector<int> Bfs(vector<vector<int>> adjList, int s, int size) {
	vector<int> result(size);
	for (int i = 0; i < size; i++)
	{
		result[i] = -1;
	}

	vector<int> visited(size);
	for (int i = 0; i < size; i++) {
		visited[i] = false;
	}	
	visited[s] = true;

	queue<int> q;
	q.push(s);
	q.push(-1);

	int distance = 0;
	while (!q.empty())
	{
		int node = q.front();
		q.pop();
		if (node == -1) {
			distance += 6;
			if (!q.empty() && q.front() != -1)
			{
				q.push(-1);
			}
		}
		else {
			result[node] = distance;

			for (int i = 0; i < adjList[node].size(); i++) {
				if (!visited[adjList[node][i]])
				{
					q.push(adjList[node][i]);
					visited[adjList[node][i]] = true;
				}
			}
		}
	}

	return result;
}

int main() {
	int q;
	cin >> q;

	for (int a0 = 0; a0 < q; a0++) {
		int n;
		int m;
		cin >> n >> m;

		vector<vector<int>> adjList(n + 1);
		for (int a1 = 0; a1 < m; a1++) {
			int u;
			int v;
			cin >> u >> v;

			adjList[u].push_back(v);
			adjList[v].push_back(u);
		}

		int s;
		cin >> s;

		vector<int> result = Bfs(adjList, s, n + 1);
		for (int i = 1; i < result.size(); i++) {
			if (i == s) {
				continue;
			}

			if (i == result.size() - 1) {
				cout << result[i];
			}
			else {
				cout << result[i] << " ";
			}
		}
		cout << endl;
	}
	return 0;
}
