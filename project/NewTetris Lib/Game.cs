using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// Oracle game class controling the entire game
  /// </summary>
  public class Game {
    /// <summary>
    /// Current level the player is on - currently unused
    /// </summary>
    public static Control level;

    /// <summary>
    /// Flag to see if player is currently playing the level
    /// and therefore level code should be running - currently unused
    /// </summary>
    private bool isPlaying;

    /// <summary>
    /// Current player score - currently unused
    /// </summary>
    public static Control score;

    /// <summary>
    /// Random object used to randomly select next shape
    /// to appear in level
    /// </summary>
    private Random random;

    /// <summary>
    /// Current shape dropping onto the playing field
    /// </summary>
    public static Shape curShape;

    /// <summary>
    /// Type of shape of the current shape
    /// </summary>
    public static ShapeType curType;

    /// <summary>
    /// Next shape dropping onto the playing field
    /// </summary>
    public static ShapeType nextType;

    /// <summary>
    /// Stored shape that you can use whenever (current shape and stored shape swap)
    /// </summary>
    public static ShapeType storedType;

    /// <summary>
    /// Able to store? Can only store once per generated shape
    /// </summary>
    public static bool canStore;

    /// <summary>
    /// Has a piece been stored yet?
    /// </summary>
    public static bool storageEmpty;

    /// <summary>
    /// bool to check if its the first piece made of the game
    /// </summary>
    public static bool first;

    /// <summary>
    /// Pic box for storage space
    /// </summary>
    public static Control storage;

    /// <summary>
    /// Pic box for next piece
    /// </summary>
    public static Control next;

    /// <summary>
    /// Link to widget displaying the playing field. 
    /// Used to place pieces and shapes inside of it.
    /// </summary>
    public static Control field;

    /// <summary>
    /// Holds the image for a piece that is used to 
    /// compose a shape. This is used so the New Tetris Library
    /// can retrieve the image for a shape.
    /// </summary>
    public static Image[] imgPiece = new Image[7];

    /// <summary>
    /// second piece pic
    /// </summary>
    public static Image imgPiece2;

    /// <summary>
    /// Holds image of line shape
    /// </summary>
    public static Image imgLine;

    /// <summary>
    /// Holds image of square shape
    /// </summary>
    public static Image imgSquare;

    /// <summary>
    /// Holds image of L shape
    /// </summary>
    public static Image imgL;

    /// <summary>
    /// Holds image of reversed L shape
    /// </summary>
    public static Image imgR;

    /// <summary>
    /// HOlds image of Z shape
    /// </summary>
    public static Image imgZ;

    /// <summary>
    /// Holds image of T shape
    /// </summary>
    public static Image imgT;

    /// <summary>
    /// Holds image of reverse Z shape
    /// </summary>
    public static Image imgRZ;

    /// <summary>
    /// Empty piece block
    /// </summary>
    public static Image emptyPiece;

    /// <summary>
    /// Test image for the empty box
    /// </summary>
    public static Image emptyPieceTest;

    /// <summary>
    /// Image for when you lose
    /// </summary>
    public static Image lostMsg;

    /// <summary>
    /// Default constructor initializing random field and setting
    /// curShape to null
    /// </summary>
    public Game() {
      random = new Random();
      curShape = null;
    }

    /// <summary>
    /// Generates the next shape to be put into the playing field
    /// </summary>
    public void NextShape() {
      int shapeNum;
      //ShapeType shapeType;
      
      if (first) // if first shape of game, execute this
            {
                Console.WriteLine("TEST");
                shapeNum = random.Next(7);
                curType = (ShapeType)shapeNum;
                curShape = ShapeFactory.MakeShape(curType);
                first = false;
            }
      else // use next type to make the new cur shape
            {
                curType = nextType;
                curShape = ShapeFactory.MakeShape(curType);
            }
      shapeNum = random.Next(7);
      nextType = (ShapeType)shapeNum;
      switch (nextType) // determines which picture is displayed to show next shape
                {
                    case ShapeType.LINE:
                        next.BackgroundImage = Game.imgLine;
                        break;
                    case ShapeType.LBLOCK:
                        next.BackgroundImage = Game.imgL;
                        break;
                    case ShapeType.RBLOCK:
                        next.BackgroundImage = Game.imgR;
                        break;
                    case ShapeType.SQUARE:
                        next.BackgroundImage = Game.imgSquare;
                        break;
                    case ShapeType.ZBLOCK:
                        next.BackgroundImage = Game.imgZ;
                        break;
                    case ShapeType.TBLOCK:
                        next.BackgroundImage = Game.imgT;
                        break;
                    case ShapeType.REV_ZBLOCK:
                        next.BackgroundImage = Game.imgRZ;
                        break;
                }
      next.BackgroundImageLayout = ImageLayout.Stretch;
      next.Size = new System.Drawing.Size(120, 107);
      canStore = true;
    }

    /// <summary>
    /// Stores current shape
    /// </summary>
    public void StoreShape()
        {
            if (canStore) // if player is allowed to store (can only store once per cur shape)
            {
                if (storageEmpty) // if first time storing shape
                {
                    storedType = curType;
                    curShape.ErasePiecePic();
                    curShape = ShapeFactory.MakeShape(nextType);
                    int shapeNum = random.Next(7);
                    nextType = (ShapeType)shapeNum;
                    storageEmpty = false;
                    switch (nextType)
                    {
                        case ShapeType.LINE:
                            next.BackgroundImage = Game.imgLine;
                            break;
                        case ShapeType.LBLOCK:
                            next.BackgroundImage = Game.imgL;
                            break;
                        case ShapeType.RBLOCK:
                            next.BackgroundImage = Game.imgR;
                            break;
                        case ShapeType.SQUARE:
                            next.BackgroundImage = Game.imgSquare;
                            break;
                        case ShapeType.ZBLOCK:
                            next.BackgroundImage = Game.imgZ;
                            break;
                        case ShapeType.TBLOCK:
                            next.BackgroundImage = Game.imgT;
                            break;
                        case ShapeType.REV_ZBLOCK:
                            next.BackgroundImage = Game.imgRZ;
                            break;
                    }
                    next.BackgroundImageLayout = ImageLayout.Stretch;
                    next.Size = new System.Drawing.Size(120, 107);
                }
                else
                {
                    curShape.ErasePiecePic();
                    curShape = ShapeFactory.MakeShape(storedType);
                    ShapeType temp;
                    temp = storedType;
                    storedType = curType;
                    curType = temp;
                }
                switch (storedType)
                {
                    case ShapeType.LINE:
                        storage.BackgroundImage = Game.imgLine;
                        break;
                    case ShapeType.LBLOCK:
                        storage.BackgroundImage = Game.imgL;
                        break;
                    case ShapeType.RBLOCK:
                        storage.BackgroundImage = Game.imgR;
                        break;
                    case ShapeType.SQUARE:
                        storage.BackgroundImage = Game.imgSquare;
                        break;
                    case ShapeType.ZBLOCK:
                        storage.BackgroundImage = Game.imgZ;
                        break;
                    case ShapeType.TBLOCK:
                        storage.BackgroundImage = Game.imgT;
                        break;
                    case ShapeType.REV_ZBLOCK:
                        storage.BackgroundImage = Game.imgRZ;
                        break;
                }
                storage.BackgroundImageLayout = ImageLayout.Stretch;
                storage.Size = new System.Drawing.Size(120, 107);
                canStore = false;

            }
        }
  }
}
