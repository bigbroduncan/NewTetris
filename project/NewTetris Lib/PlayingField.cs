using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// Encodes information about the playing
  /// field of the game. Uses a grid of rows
  /// and cols storing 1 for occupied and 0
  /// for vacant
  /// </summary>
  public class PlayingField {
    /// <summary>
    /// Singleton pattern instance
    /// </summary>
    private static PlayingField instance = null;

    /// <summary>
    /// Grid holding 1 for occupied, 0 for vacant
    /// </summary>
    public int[,] field;

    /// <summary>
    /// Grid that will hold the piece images
    /// </summary>
    public PictureBox[,] pBox;

    /// <summary>
    /// Keeps track of the score
    /// </summary>
    public int score = 0;

    /// <summary>
    /// Keeps track of the level
    /// </summary>
    public int level = 1;

    /// <summary>
    /// Number of points needed for level increase
    /// </summary>
    public int levelThreshold = 5000;

    /// <summary>
    /// Observer pattern event for when a row is 
    /// cleared - currently unused
    /// </summary>
    public event Action OnRowClear;

    /// <summary>
    /// Default constructor initializing the field
    /// to 22 rows and 15 columns
    /// </summary>
    private PlayingField() {
      field = new int[22, 15];
      pBox = new PictureBox[22, 15];
      MakePBoxes(22, 15);
      
    }
        
    /// <summary>
    /// Goes through the 2D pBox array and fills the board with pictureBoxes
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="col"></param>
    public void MakePBoxes(int rows, int col) { 
        for (int r = 0; r < rows; r++) { 
            for (int c = 0; c < col; c++) { 
                pBox[r,c] = new PictureBox();
                pBox[r,c].BackgroundImage = Game.emptyPiece;
                pBox[r,c].BackgroundImageLayout = ImageLayout.Stretch;
                pBox[r,c].Size = new System.Drawing.Size(30, 30);
                Game.field.Controls.Add(pBox[r, c]);
                pBox[r,c].Top = r * 30;
                pBox[r,c].Left = c * 30;
                pBox[r,c].SendToBack();
            }
        }
    }
    

    /// <summary>
    /// Retrieves the Singleton pattern instance
    /// </summary>
    /// <returns>The Singleton instance</returns>
    public static PlayingField GetInstance() {
      if (instance == null) {
        instance = new PlayingField();
      }
      return instance;
    }

    /// <summary>
    /// Checks if a location in the field is empty (i.e. vacant)
    /// </summary>
    /// <param name="r">Row</param>
    /// <param name="c">Column</param>
    /// <returns>True if empty, False otherwise</returns>
    public bool IsEmpty(int r, int c) {
      if (r < 0 || r >= field.GetLength(0) || c < 0 || c >= field.GetLength(1)) {
        return false;
      }
      return field[r, c] == 0;
    }


    /// <summary>
    /// Checks each row to see if any of them are filled and
    /// needs to be cleared, then clears those rows - currently
    /// unused and not implemented
    /// </summary>
    public void CheckClearAllRows()
    {
        int row;
        int col;
        int tetrisCount = 0;
        bool fullRow = true;
        int[] emptyRows = new int[22];

        for (int a = 0; a < emptyRows.Length; a++)
            emptyRows[a] = 0;

        // Goes through and identifes all the rows that need to be cleared
        for (row = 0; row < 22; row++)
        {
            for (col = 0; col < 15; col++)
            {
                if (field[row, col] == 0)
                {
                    fullRow = false;
                    break;
                }
            }

            // 
            if (fullRow == true)
            {
                emptyRows[row] = 1;
                tetrisCount++;
            }
            fullRow = true;
        }

        for (int b = 0; b < emptyRows.Length; b++)
        {
            if (emptyRows[b] == 1)
            {
                for (col = 0; col < 15; col++)
                {
                    for (int p = b; p > 0; p--)
                    {
                        if (field[p-1, col] == 0) { 
                            
                            field[p, col] = 0;
                            pBox[p, col].BackgroundImage = Game.emptyPiece;
                            pBox[p, col].BringToFront();
                            
                        }
                        else {
                            pBox[p, col].BackgroundImage = pBox[p - 1, col].BackgroundImage;
                            field[p, col] = 1;
                            pBox[p, col].BringToFront();
                        }
                    }
                        
                }
            }
        }
            score += 1000 * tetrisCount * tetrisCount;
            while (score >= levelThreshold)
            {
                level++;
                levelThreshold += 5000;
            }
            Game.score.Text = score.ToString();
            Game.level.Text = level.ToString();
        }
  }
}
