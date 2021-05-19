using NewTetris.Properties;
using NewTetris_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTetris {
  public partial class FrmMain : Form {
    public Game game;
    private bool d_was_pressed = false;
    private int defSpeed;

    public FrmMain() {
      InitializeComponent();
      Game.emptyPiece = Resources.empty_space;
      Game.emptyPieceTest = Resources.empty_space_test;
      Game.imgPiece2 = Resources.block_piece2;
      game = new Game();
      Game.field = lblPlayingField;
      Game.storage = pictureBox1;
      Game.next = pictureBox3;
      Game.imgLine = Resources.line_shape;
      Game.imgSquare = Resources.square_shape;
      Game.imgL = Resources.L_shape;
      Game.imgR = Resources.R_shape;
      Game.imgZ = Resources.Z_shape;
      Game.imgT = Resources.T_shape;
      Game.imgRZ = Resources.RZ_shape;
      Game.level = lblLevel;
      Game.score = label4;
      Game.imgPiece[0] = Resources.c;
      Game.imgPiece[1] = Resources.y;
      Game.imgPiece[2] = Resources.o;
      Game.imgPiece[3] = Resources.b;
      Game.imgPiece[4] = Resources.l;
      Game.imgPiece[5] = Resources.p;
      Game.imgPiece[6] = Resources.r;
      Game.lostMsg = Resources.lost;
      game.NextShape();
    }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
      if (Game.curShape != null) {
        if (!Game.curShape.TryMoveDown()) {
          Game.curShape.DissolveIntoField();
          Game.curShape = null;
          game.NextShape();
        }
      }
    }

    private void FrmMain_KeyUp(object sender, KeyEventArgs e) {
      if ((d_was_pressed) && (e.KeyCode != Keys.Down)) // ret speed to norm releasing down
        {
            d_was_pressed = false;
            this.tmrCurrentPieceFall.Interval = defSpeed;
        }
      else if (e.KeyCode == Keys.Left) {
        Game.curShape.TryMoveLeft();
      }
      else if (e.KeyCode == Keys.Right) {
        Game.curShape.TryMoveRight();
      }
      else if (e.KeyCode == Keys.Up)
      {
        Game.curShape.PlaceUnder();
      }
      else if (e.KeyCode == Keys.Z) {
        Game.curShape.RotateCCW();
      }
      else if (e.KeyCode == Keys.X) {
        Game.curShape.RotateCW();
      }
      else if (e.KeyCode == Keys.Q) { 
        Environment.Exit(0);
      }
      else if (!(d_was_pressed) && (e.KeyCode == Keys.Down)) // inc speed pressing down
        {
            d_was_pressed = true;
            defSpeed = this.tmrCurrentPieceFall.Interval;
            this.tmrCurrentPieceFall.Interval = 100;
        }
      else if (e.KeyCode == Keys.Space) // store shapes
        {
            game.StoreShape();
        }
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblLevel_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayingField_Click(object sender, EventArgs e)
        {

        }

    }
}
