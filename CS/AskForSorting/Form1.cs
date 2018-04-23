using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AskForSorting {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e) {
            if(e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            if(view.State != GridState.ColumnDown) return;

            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if(info.HitTest == GridHitTest.Column) {
                if(MessageBox.Show(string.Format("Sort by {0} column?", info.Column.Caption), 
                    "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    ((DevExpress.Utils.DXMouseEventArgs)e).Handled = true;
                    this.BeginInvoke(new MethodInvoker(view.LayoutChanged));
                }
            }
        }
    }
}