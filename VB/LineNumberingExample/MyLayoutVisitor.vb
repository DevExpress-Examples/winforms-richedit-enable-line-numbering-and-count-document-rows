Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.XtraRichEdit.API.Native

Namespace LineNumberingExample

#Region "#MyLayoutVisitor"
    Public Class MyLayoutVisitor
        Inherits LayoutVisitor

        Private _RowIndex As Integer

        Private document As Document

        Public Property RowIndex As Integer
            Get
                Return _RowIndex
            End Get

            Private Set(ByVal value As Integer)
                _RowIndex = value
            End Set
        End Property

        Public Sub New(ByVal doc As Document)
            document = doc
            RowIndex = 0
        End Sub

        Protected Overrides Sub VisitRow(ByVal row As LayoutRow)
            RowIndex += 1
            MyBase.VisitRow(row)
        End Sub
    End Class
#End Region  ' #MyLayoutVisitor
End Namespace
