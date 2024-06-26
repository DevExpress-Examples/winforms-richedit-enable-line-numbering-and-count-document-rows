<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128610217/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T531470)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/LineNumberingExample/Form1.cs) (VB: [Form1.vb](./VB/LineNumberingExample/Form1.vb))
* [MyLayoutVisitor.cs](./CS/LineNumberingExample/MyLayoutVisitor.cs) (VB: [MyLayoutVisitor.vb](./VB/LineNumberingExample/MyLayoutVisitor.vb))
* [MyPagePainter.cs](./CS/LineNumberingExample/MyPagePainter.cs) (VB: [MyPagePainter.vb](./VB/LineNumberingExample/MyPagePainter.vb))
<!-- default file list end -->
# How to enable line numbering and count the document rows


This example enables line numbering for the first section in the loaded document using the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSection_LineNumberingtopic">DevExpress.XtraRichEdit.API.Native.Section.LineNumbering</a> property. Line numbering starts at number one and restarts at the new section. Numbers are displayed on each second line and are indented from the text at a distance equal to 75 documents (0.25 of an inch).<br><br>Line numberings are allowed to display by setting the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditView_AllowDisplayLineNumberstopic">AllowDisplayLineNumbers</a> property to <strong>true </strong>in the <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditSimpleViewtopic">DevExpress.XtraRichEdit.SimpleView</a> and <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditDraftViewtopic">DevExpress.XtraRichEdit.DraftView</a> views. To make line numbers visible, the left padding is increased to 60 points.<br><br>Font face and color are specified using the Line Number <a href="http://help.devexpress.com/#WindowsForms/CustomDocument9555">document style</a>.<br><br>The <strong>Custom Draw</strong> technique is used to display the line number column with a color background. To do so, handle the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditDocumentServer_BeforePagePainttopic">DevExpress.XtraRichEdit.RichEditControl.BeforePagePaint</a> event. Create a custom <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditAPILayoutPagePaintertopic">DevExpress.XtraRichEdit.API.Layout.PagePainter</a> descendant which implements the methods required to draw the column background and the line numbers themselves. Specify an instance of the custom painter using the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraRichEditBeforePagePaintEventArgs_Paintertopic">DevExpress.XtraRichEdit.BeforePagePaintEventArgs.Painter</a> property. <br><br>To count the lines in the document (document rows), create an instance of the <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditAPILayoutLayoutVisitortopic">DevExpress.XtraRichEdit.API.Layout.LayoutVisitor</a> descendant and let it traverse the page layout. When it encounters a new row, it calls the <strong>VisitRow</strong> method. This method increments the row counter to count the lines on a page. To run the visitor each time after building the document layout, handle the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPILayoutDocumentLayout_DocumentFormattedtopic">DevExpress.XtraRichEdit.API.Layout.DocumentLayout.DocumentFormatted</a> event.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-enable-line-numbering-and-count-the-document-rows-t531470/17.1.3+/media/64f72e52-60cd-11e7-80c0-00155d624807.png"><br><br>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-enable-line-numbering-and-count-document-rows&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-enable-line-numbering-and-count-document-rows&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
