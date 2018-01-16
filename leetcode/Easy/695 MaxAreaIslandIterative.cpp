class Solution {
public:
    int getArea(vector<vector<int>>& grid, int i, int j) {
        stack<vector<int>> s;
        vector<int> v;
        v.push_back(i);
        v.push_back(j);
        s.push(v);
        grid[i][j] = 0;
        
        int area = 0;
        while(!s.empty()) {
            vector<int> item = s.top();
            s.pop();
            area++;
            
            int i1 = item[0];
            int j1 = item[1];            
            
            // top
            if(i1 > 0 && grid[i1 - 1][j1] == 1)
            {
                vector<int> v1;
                v1.push_back(i1 - 1);
                v1.push_back(j1);
                s.push(v1);
                grid[i1 - 1][j1] = 0;
            }
            
            // bottom
            if(i1 < grid.size() - 1 && grid[i1 + 1][j1] == 1)
            {
                vector<int> v1;
                v1.push_back(i1 + 1);
                v1.push_back(j1);
                s.push(v1);
                grid[i1 + 1][j1] = 0;
            }
            
            // left
            if(j1 > 0 && grid[i1][j1 - 1] == 1)
            {
                vector<int> v1;
                v1.push_back(i1);
                v1.push_back(j1 - 1);
                s.push(v1);
                grid[i1][j1 - 1] = 0;
            }
            
            // right
            if(j1 < grid[0].size() - 1 && grid[i1][j1 + 1] == 1)
            {
                vector<int> v1;
                v1.push_back(i1);
                v1.push_back(j1 + 1);
                s.push(v1);
                grid[i1][j1 + 1] = 0;
            }            
        }
        
        return area;
    }
    
    int maxAreaOfIsland(vector<vector<int>>& grid) {
        int maxArea = 0;
        for(size_t i = 0; i < grid.size(); i++) {
            for(size_t j = 0; j < grid[0].size(); j++) {
                if(grid[i][j] == 1) {
                    maxArea = max(maxArea, getArea(grid, i, j));
                }
            }
        }
        
        return maxArea;
    }
};