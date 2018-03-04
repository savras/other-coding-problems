public class Solution {
    public int CountBattleships(char[,] board) {
        
        var result = 0;
        for(var row = 0; row < board.GetLength(0); row++) {
            var isPartOfHorizontalShip = false;
            
            for(var col = 0; col < board.GetLength(1); col++) {
                if(board[row, col] == 'X')
                {
                    // Is Vertical ship.
                    // Check if row and col are within bounds
                    // If they are then check if left, right, and top are empty => its a vertical ship
                    if(((row > 0 && board[row - 1, col] != 'X') || row == 0) && 
                       ((col > 0 && board[row, col - 1] != 'X') || col == 0) &&
                       ((col < board.GetLength(1) - 1 && board[row, col + 1] != 'X') || 
                            col == board.GetLength(1) - 1)
                      )
                    {
                        result++;
                    }
                    // Is Horizontal ship
                    else if(!isPartOfHorizontalShip && 
                            ((row > 0 && board[row - 1, col] != 'X') || row == 0) &&
                            ((col > 0 && board[row, col - 1] != 'X') || col == 0)
                           )
                    {
                        isPartOfHorizontalShip = true;
                        result++;
                    }
                }
                else {
                    isPartOfHorizontalShip = false;
                }                
            }
        }
        return result;        
    }
}