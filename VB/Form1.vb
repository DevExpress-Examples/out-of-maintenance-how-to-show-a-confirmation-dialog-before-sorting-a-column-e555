Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
    End Sub

    Private Sub gridView1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView1.MouseUp
        If e.Button <> MouseButtons.Left OrElse e.Clicks > 1 Then Return
        Dim view As GridView = TryCast(sender, GridView)
        If view.State <> GridState.ColumnDown Then Return

        Dim p As Point = view.GridControl.PointToClient(MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(p)
        If info.HitTest = GridHitTest.Column Then
            If MessageBox.Show(String.Format("Sort by {0} column?", info.Column.Caption), "Confirmation", MessageBoxButtons.YesNo) <> System.Windows.Forms.DialogResult.Yes Then
                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
                Me.BeginInvoke(New MethodInvoker(AddressOf view.LayoutChanged))
            End If
        End If
    End Sub
End Class