﻿Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace DeleteAllBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new Pdf document.
			Dim document As New PdfDocument()

			'Load the file from disk.
			document.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			'Remove all bookmarks.
			document.Bookmarks.Clear()

			Dim result As String = "DeleteAllBookmarks_out.pdf"

			'Save the document
			document.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
