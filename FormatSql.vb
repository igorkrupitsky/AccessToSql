Public Class FormatSql
    Private Sub btnBeautify_Click(sender As Object, e As EventArgs) Handles btnBeautify.Click

		txtOut.Text = ParseSql(txtIn.Text)

	End Sub

	Private Function ParseSql(ByVal sql As String)

		Dim _tokenizer As New PoorMansTSqlFormatterLib.Tokenizers.TSqlStandardTokenizer()
		Dim _parser = New PoorMansTSqlFormatterLib.Parsers.TSqlStandardParser()
		Dim _treeFormatter As New PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter()

		Dim tokenized As PoorMansTSqlFormatterLib.TokenList = _tokenizer.TokenizeSQL(sql)
		Dim parsed As PoorMansTSqlFormatterLib.ParseStructure.Node = _parser.ParseSQL(tokenized)
		Dim sRet As String = _treeFormatter.FormatSQLTree(parsed)

		If sRet.IndexOf("--WARNING! ERRORS ENCOUNTERED DURING SQL PARSING!") <> -1 Then
			Return sql
		End If

		Return sRet
	End Function

	Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
		txtOut.SelectAll()
		txtOut.Focus()
		Clipboard.Clear()
		Clipboard.SetText(txtOut.Text)
	End Sub
End Class