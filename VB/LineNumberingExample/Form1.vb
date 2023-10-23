'using DevExpress.XtraRichEdit.API.Layout;
'using DevExpress.XtraRichEdit.API.Native;
Imports DevExpress.Portable
Imports DevExpress.XtraRichEdit
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace LineNumberingExample

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            ribbonControl1.SelectedPage = exampleRibbonPage1
            AddHandler richEditControl1.DocumentLoaded, AddressOf RichEditControl1_DocumentLoaded
            AddHandler richEditControl1.DocumentLayout.DocumentFormatted, AddressOf Me.DocumentLayout_DocumentFormatted
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            richEditControl1.LoadDocument("Grimm.docx")
        End Sub

        Private Sub RichEditControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
            richEditControl1.ActiveViewType = RichEditViewType.Simple
#Region "#linenumbering"
            richEditControl1.Views.SimpleView.Padding = New PortablePadding(60, 4, 4, 0)
            richEditControl1.Views.DraftView.Padding = New PortablePadding(60, 4, 4, 0)
            richEditControl1.Views.SimpleView.AllowDisplayLineNumbers = True
            richEditControl1.Views.DraftView.AllowDisplayLineNumbers = True
            richEditControl1.Document.Sections(0).LineNumbering.Start = 1
            richEditControl1.Document.Sections(0).LineNumbering.CountBy = 2
            richEditControl1.Document.Sections(0).LineNumbering.Distance = 75F
            richEditControl1.Document.Sections(0).LineNumbering.RestartType = API.Native.LineNumberingRestart.Continuous
            richEditControl1.Document.CharacterStyles("Line Number").FontName = "Courier"
            richEditControl1.Document.CharacterStyles("Line Number").FontSize = 10
            richEditControl1.Document.CharacterStyles("Line Number").ForeColor = Color.DarkGray
            richEditControl1.Document.CharacterStyles("Line Number").Bold = True
#End Region  ' #linenumbering
        End Sub

#Region "#BeforePagePaint"
        Private Sub RichEditControl1_BeforePagePaint(ByVal sender As Object, ByVal e As BeforePagePaintEventArgs)
            If e.CanvasOwnerType = API.Layout.CanvasOwnerType.Printer Then
                Return
            End If

            Dim style As API.Native.CharacterStyle = richEditControl1.Document.CharacterStyles("Line Number")
            Dim customPagePainter As MyPagePainter = New MyPagePainter(richEditControl1, SystemColors.Info, style)
            customPagePainter.LineNumberPadding = 60
            e.Painter = customPagePainter
        End Sub

#End Region  ' #BeforePagePaint
        Private Sub barCheckLineNumberBackColoring_CheckedChanged(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            If barCheckLineNumberBackColoring.Checked Then
                AddHandler richEditControl1.BeforePagePaint, AddressOf RichEditControl1_BeforePagePaint
            Else
                RemoveHandler richEditControl1.BeforePagePaint, AddressOf RichEditControl1_BeforePagePaint
            End If

            richEditControl1.Refresh()
        End Sub

#Region "#DocumentFormatted"
        Private Sub DocumentLayout_DocumentFormatted(ByVal sender As Object, ByVal e As EventArgs)
            BeginInvoke(CType((Sub()
                If Visible Then
                    Dim visitor As MyLayoutVisitor = New MyLayoutVisitor(richEditControl1.Document)
                    Dim pageCount As Integer = richEditControl1.DocumentLayout.GetFormattedPageCount()
                    For i As Integer = 0 To pageCount - 1
                        visitor.Visit(richEditControl1.DocumentLayout.GetPage(i))
                    Next

                    resultBarStaticItem.Caption = String.Format("Document has {0} lines", visitor.RowIndex)
                End If
            End Sub), MethodInvoker))
        End Sub
#End Region  ' #DocumentFormatted
    End Class
End Namespace
