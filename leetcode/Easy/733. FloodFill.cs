public class Solution {
    public void FloodFillRecursive(int[,] image, int sr, int sc, int newColor, int currentColour) {
        if(image[sr, sc] == currentColour) {
            image[sr, sc] = newColor;
            
            if(sr > 0) {
                FloodFillRecursive(image, sr - 1, sc, newColor, currentColour);
            }
            if (sr < image.GetLength(0) - 1) {
                FloodFillRecursive(image, sr + 1, sc, newColor, currentColour);
            }
            if (sc > 0) {
                FloodFillRecursive(image, sr, sc - 1, newColor, currentColour);
            }
            if (sc < image.GetLength(1) - 1) {
                FloodFillRecursive(image, sr, sc + 1, newColor, currentColour);
            }
            
        }
    }
    public int[,] FloodFill(int[,] image, int sr, int sc, int newColor) {
        
        var currentColour = image[sr, sc];
        if(newColor != currentColour)            
        {
            FloodFillRecursive(image, sr, sc, newColor, currentColour);
        }
        return image;
    }
}