Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace SplitDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\SplitDocument.pdf")

			Dim pattern As String = "SplitDocument-{0}.pdf"
			'Split document
			doc.Split(pattern)

			Dim lastPageFileName As String = String.Format(pattern, doc.Pages.Count - 1)

			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(lastPageFileName)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
