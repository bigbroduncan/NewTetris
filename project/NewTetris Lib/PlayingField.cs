﻿using System;
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

    public PictureBox pic;
    public PictureBox pic2;

    public int score = 0;
    public int level = 1;
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

    public void MakeFreeSpace(int xSize, int ySize, int xPos, int yPos) { 
        pic = new PictureBox();
        pic.BackgroundImage = Game.emptyPiece;
        pic.BackgroundImageLayout = ImageLayout.Stretch;
        pic.Size = new System.Drawing.Size(xSize, ySize);
        Game.field.Controls.Add(pic);
        if (xPos == 21)
        {
            pic.Top = (20 * 30) + 29;
            pic.Left = yPos * 30;
        }
        else
        {
            pic.Top = xPos * 30;
            pic.Left = yPos * 30;
        }
        pic.BringToFront();
    }
        
    public void MakeFilledSpace(int xSize, int ySize, int xPos, int yPos) { 
        pic2 = new PictureBox();
        pic2.BackgroundImage = Game.imgPiece;
        pic2.BackgroundImageLayout = ImageLayout.Stretch;
        pic2.Size = new System.Drawing.Size(xSize, ySize);
        Game.field.Controls.Add(pic2);
        if (xPos == 21)
        {
            pic2.Top = (20 * 30) + 29;
            pic2.Left = yPos * 30;
        }
        else
        {
            pic2.Top = xPos * 30;
            pic2.Left = yPos * 30;
        }
        pic2.BringToFront();
    }

    public void IncreaseScore(int rowsCleared) { 
        if (rowsCleared == 2)
            score += 2000 * rowsCleared;
        else if (rowsCleared == 3)
            score += 3000 * rowsCleared;
        else if (rowsCleared == 4)
            score += 4000 * rowsCleared;
        else
            score += 1000 * rowsCleared;
        Game.score.Text = score.ToString();
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
        //txt = "I control this box";

        //sBox = new Label();
        //Game.field.Controls.Add(sBox);
        //sBox.ForeColor = Color.Red;
        //Game.score.Text = txt;


        for (int a = 0; a < emptyRows.Length; a++)
            emptyRows[a] = 0;

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

            if (fullRow == true)
            {
                emptyRows[row] = 1;
                tetrisCount++;
                //Console.WriteLine("A full row has been detected!");
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
                        if (field[p - 1, col] == 1 && field[p, col] != 1)
                        {
                            field[p, col] = 1;
                            if (p == 21)
                                MakeFilledSpace(30, 29, p, col);
                            else
                                MakeFilledSpace(30, 30, p, col);
                        }
                        else if (field[p - 1, col] == 0 && field[p, col] != 0) 
                        {
                            field[p, col] = 0;
                            if (p == 21)
                                MakeFreeSpace(30, 29, p, col);
                            else
                                MakeFreeSpace(30, 30, p, col);
                        }
                        field[0, col] = 0;
                        MakeFreeSpace(30, 30, 0, col);
                    }
                        
                }
            }
        }
        score += 1000 * tetrisCount * tetrisCount;
        while (score >= levelThreshold){
            level++;
            levelThreshold += 5000;
        }
        Game.score.Text = score.ToString();
        Game.level.Text = level.ToString();
    }
  }
}
