<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128610217/20.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T531470)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Rich Text Editor for WinForms - How to Enable Line Numbering and Count Document Rows

This example enables line numbering for the first document section. Line numbering starts at number one and restarts at the new section. Numbers are displayed on each second line and are indented from the text at a distance equal to 75 documents (0.25 of an inch).

The **Custom Draw** technique is used to display the line number column with a color background.

![image](./media/64f72e52-60cd-11e7-80c0-00155d624807.png)

## Implementation Details

The [Section.LineNumbering](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.Section.LineNumbering) property enables line numbering for the first document section.

Set the [AllowDisplayLineNumbers](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.RichEditView.AllowDisplayLineNumbers) property to `true` in the [SimpleView](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.SimpleView) and [DraftView](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.DraftView) views to display line numbering. To make line numbers visible, the left padding is increased to `60` points.

The **Line Number** [document style](https://docs.devexpress.com/WindowsForms/117433/controls-and-libraries/rich-text-editor/text-formatting#document-styles) defines the used font and color.

Create a custom [PagePainter](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Layout.PagePainter) descendant which implements the methods required to draw the column background and the line numbers. Handle the [RichEditControl.BeforePagePaint](https://docs.devexpress.com/WindowsForms/DevExpress.XtraRichEdit.RichEditControl.BeforePagePaint) event and set the [BeforePagePaintEventArgs.Painter](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.BeforePagePaintEventArgs.Painter) property to the `PagePainter` descendant instance.

Create an instance of the [LayoutVisitor](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Layout.LayoutVisitor) descendant and let it traverse the page layout. When it encounters a new row, it calls the `VisitRow` method. This method increments the row counter to count the lines on a page. To run the visitor each time after building the document layout, handle the [DocumentLayout.DocumentFormatted](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Layout.DocumentLayout.DocumentFormatted) event.

## Files to Review

* [Form1.cs](./CS/LineNumberingExample/Form1.cs) (VB: [Form1.vb](./VB/LineNumberingExample/Form1.vb))
* [MyLayoutVisitor.cs](./CS/LineNumberingExample/MyLayoutVisitor.cs) (VB: [MyLayoutVisitor.vb](./VB/LineNumberingExample/MyLayoutVisitor.vb))
* [MyPagePainter.cs](./CS/LineNumberingExample/MyPagePainter.cs) (VB: [MyPagePainter.vb](./VB/LineNumberingExample/MyPagePainter.vb))

## Documentation

* [How to: Count the Lines in the Document](https://docs.devexpress.com/WindowsForms/118972/controls-and-libraries/rich-text-editor/examples/layout/how-to-count-the-lines-in-the-document)

* [How To: Add Line Numbering in the Rich Text Editor](https://docs.devexpress.com/WindowsForms/116613/controls-and-libraries/rich-text-editor/examples/layout/how-to-add-line-numbering)
* [How to: Set Background Color for the Line Number Column](https://docs.devexpress.com/WindowsForms/118971/controls-and-libraries/rich-text-editor/examples/layout/how-to-set-background-color-for-the-line-number-column)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-enable-line-numbering-and-count-document-rows&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-enable-line-numbering-and-count-document-rows&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
