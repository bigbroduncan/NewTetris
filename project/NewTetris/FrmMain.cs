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

    public FrmMain() {
      InitializeComponent();
      Game.imgPiece = Resources.block_piece;
      Game.emptyPiece = Resources.empty_space; ///// added
      Game.emptyPieceTest = Resources.empty_space_test; ///// added
      game = new Game();
      Game.field = lblPlayingField;
      Game.score = label4;
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
      if (e.KeyCode == Keys.Left) {
        Game.curShape.TryMoveLeft();
      }
      else if (e.KeyCode == Keys.Right) {
        Game.curShape.TryMoveRight();
      }
      else if (e.KeyCode == Keys.Down) {
        while (Game.curShape.TryMoveDown());
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
