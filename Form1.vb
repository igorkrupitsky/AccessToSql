Imports System.Text.RegularExpressions

Public Class Form1

	Dim dicViews As New Hashtable
	Dim dicProcs As New Hashtable
	Dim dicTables As New Hashtable

	Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click

		If txtFilePath.Text = "" Then
			OpenFileDialog1.InitialDirectory = ""
		Else
			Dim oFileInfo As New IO.FileInfo(txtFilePath.Text)
			OpenFileDialog1.InitialDirectory = oFileInfo.DirectoryName
			OpenFileDialog1.FileName = oFileInfo.Name
		End If

		OpenFileDialog1.Filter = "Access Files|*.mdb;*.accdb"
		OpenFileDialog1.ShowDialog()
		txtFilePath.Text = OpenFileDialog1.FileName
		LoadViews()
	End Sub

	Private Function GetConnection() As Data.OleDb.OleDbConnection

		Dim cn As New Data.OleDb.OleDbConnection
		Dim sError As String = ""

		If System.IO.Path.GetExtension(txtFilePath.Text).ToLower() = ".mdb" And Environment.Is64BitProcess = False Then
			Try
				cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & txtFilePath.Text & ";"
				cn.Open()
				Return cn
			Catch ex As Exception
				sError = ex.Message
			End Try
		End If

		Try
			cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtFilePath.Text & ";"
			cn.Open()
			Return cn
		Catch ex As Exception
			'The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine.
			If ex.Message.IndexOf("Microsoft.ACE.OLEDB") <> -1 Then
				If MsgBox("Error: " & ex.Message & " Install Microsoft Access Database Engine 2016 Redistributable?", MsgBoxStyle.YesNo) = vbYes Then
					Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=54920&WT.mc_id=rss_alldownloads_all")
				End If
				Me.Close()
			Else
				MsgBox("Error: " & ex.Message)
			End If
		End Try

		Return Nothing
	End Function

	Private cnOleDb As Data.OleDb.OleDbConnection = Nothing

	Private Sub LoadViews()
		If IO.File.Exists(txtFilePath.Text) = False Then
			Exit Sub
		End If

		CloseConnectionIfOpen()

		cnOleDb = GetConnection()
		If cnOleDb Is Nothing Then
			Exit Sub
		End If

		dicViews = New Hashtable

		SetViews()
		LoadProcs()

		'Update Views Listbox
		Dim oList As New SortedList
		For Each oEntry As DictionaryEntry In dicViews
			oList.Add(oEntry.Key, oEntry.Value)
		Next

		cmViews.Items.Clear()
		For Each oEntry As DictionaryEntry In oList
			cmViews.Items.Add(oEntry.Key)
		Next

		SetTables()
	End Sub

	Private Sub LoadProcs()

		Dim sSetProcsError As String = ""
		Try
			SetProcs()
		Catch ex As Exception
			sSetProcsError = ex.Message
		End Try

		If sSetProcsError <> "" Then
			If MsgBox("Application encounted an error reading procedures: " & sSetProcsError & vbCrLf &
				" Application will now attempt to read procedures by opening Access.  This might take several minutes. OK?", vbYesNo) = vbYes Then
				SetProcsFromAccess()
			End If
		End If

		'Update Procs Listbox
		Dim oList As New SortedList
		For Each oEntry As DictionaryEntry In dicProcs
			oList.Add(oEntry.Key, oEntry.Value)
		Next

		lbProcs.Items.Clear()
		For Each oEntry As DictionaryEntry In oList
			lbProcs.Items.Add(oEntry.Key)
		Next

	End Sub

	Private Sub SetProcsFromAccess()
		Dim oStopwatch As Stopwatch = Stopwatch.StartNew()

		Dim oApp As Microsoft.Office.Interop.Access.Application = CreateObject("Access.Application")
		oApp.visible = False
		oApp.UserControl = False
		oApp.OpenCurrentDataBase(txtFilePath.Text)
		Dim oDatabase As Object = oApp.CurrentDb

		'Dim i As Integer = 0
		For Each oQuery As Object In oDatabase.QueryDefs
			'i += 1
			Dim sName As String = oQuery.Name
			Dim sSql As String = ""

			'If i > 190 Then
			'	i = i
			'End If

			Try
				sSql = oQuery.SQL
			Catch ex As Exception
				txtSQL.AppendText("sSql = oQuery.SQL, Name: " & sName & ", " & ex.Message & vbCrLf)
			End Try

			If sSql <> "" AndAlso GetLeft(sName, 4) <> "~sq_" AndAlso dicProcs.ContainsKey(sName) = False Then
				dicProcs(sName) = sSql
			End If
		Next

		oApp.CloseCurrentDatabase()
		oApp.Quit()

		oStopwatch.Stop()
		If oStopwatch.Elapsed.TotalSeconds() > 10 Then
			txtSQL.AppendText("It took " & oStopwatch.Elapsed.TotalSeconds() & " seconds to SetProcsFromAccess()" & vbCrLf)
		End If

	End Sub

	Private Sub SetTables()
		dicTables = New Hashtable
		Dim oTable As DataTable = cnOleDb.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Tables, Nothing)
		For i As Long = 0 To oTable.Rows.Count - 1
			Dim sType As String = oTable.Rows(i)("TABLE_TYPE") & ""
			Dim sName As String = oTable.Rows(i)("TABLE_NAME") & ""
			If sType = "TABLE" Then
				dicTables(sName) = ""
			End If
		Next
	End Sub

	Private Sub SetViews()
		Dim oStopwatch As Stopwatch = Stopwatch.StartNew()
		Dim oTable As DataTable = cnOleDb.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Views, Nothing)

		oStopwatch.Stop()
		If oStopwatch.Elapsed.TotalSeconds() > 10 Then
			txtSQL.AppendText("It took " & oStopwatch.Elapsed.TotalSeconds() & " seconds to cnOleDb.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Views, Nothing)" & vbCrLf)
		End If

		For i As Long = 0 To oTable.Rows.Count - 1
			Dim sName As String = oTable.Rows(i)("TABLE_NAME") & ""
			Dim sSql As String = oTable.Rows(i)("VIEW_DEFINITION") & ""
			dicViews(sName) = sSql
		Next
	End Sub

	Private Sub SetProcs()
		Dim oStopwatch As Stopwatch = Stopwatch.StartNew()
		Dim oTable As DataTable = cnOleDb.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Procedures, Nothing)
		If oStopwatch.Elapsed.TotalSeconds() > 10 Then
			txtSQL.AppendText("It took " & oStopwatch.Elapsed.TotalSeconds() & " seconds to cnOleDb.GetOleDbSchemaTable(Data.OleDb.OleDbSchemaGuid.Procedures, Nothing)" & vbCrLf)
		End If

		For i As Long = 0 To oTable.Rows.Count - 1
			Dim sName As String = oTable.Rows(i)("PROCEDURE_NAME") & ""
			Dim sSql As String = oTable.Rows(i)("PROCEDURE_DEFINITION") & ""

			If GetLeft(sName, 4) <> "~sq_" AndAlso dicProcs.ContainsKey(sName) = False Then
				dicProcs(sName) = sSql
			End If

			If GetLeft(sName, 4) <> "~sq_" Then
				dicViews(sName) = sSql
			End If
		Next
	End Sub

	Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
		Dim sViewName As String = cmViews.Text

		If sViewName = "" Then
			Dim oAppSetting As New AppSetting
			cmViews.SelectedItem = oAppSetting.GetValue("View")
			sViewName = cmViews.Text
		End If

		If sViewName = "" Then
			MsgBox("Please select a view")
		Else
			txtSQL.Text = ShowView(sViewName, True)
		End If
	End Sub

	Private Function PadTempTableNames(ByVal sSql As String, dicDepTables As Hashtable, dicDepViews As Hashtable) As String

		If chkCTE.Checked Then
			Return sSql
		End If

		For Each oEntry As Collections.DictionaryEntry In dicDepTables
			Dim sTable As String = oEntry.Key
			sSql = ReplaceTempTable(sSql, sTable)
		Next

		For Each oEntry As Collections.DictionaryEntry In dicDepViews
			Dim sTable As String = oEntry.Key
			sSql = ReplaceTempTable(sSql, sTable)
		Next

		Return sSql
	End Function

	Private Function PadTempTableNames(ByVal sSql As String, dicDepTables As System.Windows.Forms.ListBox.ObjectCollection, dicDepViews As System.Windows.Forms.ListBox.ObjectCollection) As String

		If chkCTE.Checked Then
			Return sSql
		End If

		For Each sDisplayTable As String In dicDepTables

			Dim sTable As String = ""
			If sDisplayTable.IndexOf(" - [") <> -1 Then
				sTable = System.Text.RegularExpressions.Regex.Split(sDisplayTable, " - [")(0)
			Else
				sTable = sDisplayTable
			End If

			sSql = ReplaceTempTable(sSql, sTable)
		Next

		For Each sTable As String In dicDepViews
			sSql = ReplaceTempTable(sSql, sTable)
		Next

		Return sSql
	End Function

	Private Function ReplaceTempTable(ByVal sSql As String, ByVal sTable As String) As String
		Return Replace(sSql, "[" & sTable & "]", "[#" & sTable & "]")
	End Function

	Private Function GetTableCount(ByVal sTable As String) As Integer
		If cnOleDb Is Nothing Then
			Return 0
		End If

		Try
			Dim iRet As Integer = 0
			Dim sSql As String = "select count(*) from [" & sTable & "]"
			Dim cmd As New OleDb.OleDbCommand(sSql, cnOleDb)
			Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader()
			If dr.Read Then
				iRet = dr.GetValue(0)
			End If
			dr.Close()
			Return iRet
		Catch ex As Exception

		End Try

		Return -1
	End Function

	Private Function PadTableName(ByVal s As String) As String

		If s.IndexOf("[") <> -1 Then
			Return s
		End If

		Return "[" & s & "]"
	End Function

	Private Function ShowView(ByVal sViewName As String, ByVal bUpdateList As Boolean) As String

		Dim sVewSql As String = ""

		If dicViews.ContainsKey(sViewName) Then
			sVewSql = dicViews(sViewName)
		ElseIf dicProcs.ContainsKey(sViewName) Then
			sVewSql = dicProcs(sViewName)
		Else
			txtSQL.AppendText("Could not find view or proc: " & sViewName & vbCrLf)
		End If

		If sVewSql = "" Then
			Return ""
		End If

		Dim bShowWith As Boolean = False
		Dim sSql As String = ""
		Dim dicDepTables As New Hashtable
		Dim dicDepViews As New Hashtable

		If chkScriptDepView.Checked Then
			GetDepViews(sVewSql, dicDepTables, dicDepViews, 1)

			If bUpdateList Then
				lbDepTables.Items.Clear()
			End If

			For Each oEntry As Collections.DictionaryEntry In dicDepTables
				If chkDepTables.Checked Then

					Dim sTable As String = oEntry.Key

					If bUpdateList Then
						Dim iRecordCount As Integer = GetTableCount(sTable)
						Dim sDisplayTable As String = sTable & " - [" & Format(iRecordCount, "#,#") & "]"

						If txtRowLimit.Text <> "" AndAlso IsNumeric(txtRowLimit.Text) Then
							Dim iMaxRecCount As Integer = txtRowLimit.Text
							If iMaxRecCount < iRecordCount Then
								sDisplayTable = sTable & " - [" & Format(iRecordCount, "#,#") & " !!!]"
							End If
						End If

						lbDepTables.Items.Add(sDisplayTable)
					End If

					Dim sTableSql As String = GetTableSql(sTable)
					If sTableSql <> "" Then
						If chkCTE.Checked Then

							If sSql <> "" Then
								sSql += ", "
							End If

							sSql += " [" & sTable & "] AS (" & vbCrLf & sTableSql & ")" & vbCrLf
							bShowWith = True
						Else
							sSql += "IF OBJECT_ID('tempdb..[#" & sTable & "]') is not null drop table [#" & sTable & "]" & vbCrLf
							sSql += "select * into [#" & sTable & "] from (" & vbCrLf & sTableSql & vbCrLf & ") xx" & vbCrLf & vbCrLf
						End If
					End If
				End If
			Next

			If bUpdateList Then
				lbDepViews.Items.Clear()
			End If

			Dim oSortedViews As ArrayList = GetSortedViews(dicDepViews)
			For Each sDepViewName In oSortedViews

				If bUpdateList Then
					lbDepViews.Items.Add(sDepViewName)
				End If

				Dim sDepSql As String = dicViews(sDepViewName)
				sDepSql = PadSql(sDepSql)
				sDepSql = AddTabs(sDepSql)

				If chkCTE.Checked Then
					If sSql <> "" Then
						sSql += ", "
					End If

					sSql += " [" & sDepViewName & "] AS (" & vbCrLf & sDepSql & ")" & vbCrLf
					bShowWith = True
				Else
					sSql += "IF OBJECT_ID('tempdb..[#" & sDepViewName & "]') is not null drop table [#" & sDepViewName & "]" & vbCrLf
					sSql += "select * into [#" & sDepViewName & "] from (" & vbCrLf & PadTempTableNames(sDepSql, dicDepTables, dicDepViews) & vbCrLf & ") xx" & vbCrLf
				End If
			Next
		End If

		Dim sSqlPrefix As String = ""
		If chkCreateProc.Checked Then
			If dicProcs.ContainsKey(sViewName) Then
				sSqlPrefix = "create proc " & PadTableName(sViewName) & " as " & vbCrLf & vbCrLf
			ElseIf dicViews.ContainsKey(sViewName) Then 
				sSqlPrefix = "create view " & PadTableName(sViewName) & " as " & vbCrLf & vbCrLf
			End If
		End If

		If chkCTE.Checked = False Then
			Return sSqlPrefix & sSql & PadTempTableNames(PadSql(sVewSql), dicDepTables, dicDepViews)

		ElseIf bShowWith Then
			Return sSqlPrefix & "WITH " & sSql & PadSql(sVewSql)
		Else
			Return sSqlPrefix & PadSql(sVewSql)
		End If

	End Function

	Private Function GetSortedViews(ByVal oHash As Hashtable) As ArrayList
		'Sort list based on recursion level - views at the bottom are lsted first
		Dim oTable As New Data.DataTable
		oTable.Columns.Add(New Data.DataColumn("key"))
		oTable.Columns.Add(New Data.DataColumn("level", System.Type.GetType("System.Int32")))

		Dim oDepList As New Hashtable

		For Each oEntry As Collections.DictionaryEntry In oHash
			Dim sView As String = oEntry.Key

			Dim oDataRow As DataRow = oTable.NewRow()
			oDataRow("key") = sView
			oDataRow("level") = oEntry.Value
			oTable.Rows.Add(oDataRow)

			Dim dicSubDepViews As New Hashtable
			Dim sDepVewSql As String = dicViews(sView)
			GetDepViews(sDepVewSql, Nothing, dicSubDepViews, 1)
			If dicSubDepViews.ContainsKey(sView) Then
				'Exclude youself from the dep list
				dicSubDepViews.Remove(sView)
			End If
			oDepList(sView) = dicSubDepViews
		Next

		Dim oTempList As New Hashtable
		Dim oDeleteList As New Hashtable
		Dim oRet As New ArrayList()
		Dim oDataView As DataView = New DataView(oTable)
		oDataView.Sort = "level DESC"

		For iRow As Long = 0 To oDataView.Count - 1

			For Each oTempEntry As Collections.DictionaryEntry In oTempList
				Dim sView As String = oTempEntry.Key
				If oDeleteList.ContainsKey(sView) = False Then
					Dim oViews As Hashtable = oDepList(sView)
					If HashNotInList(oViews, oRet) = False Then
						oRet.Add(sView)
						oDeleteList(sView) = True
					End If
				End If
			Next

			Dim sDepViewName As String = oDataView(iRow)("key")
			Dim dicSubDepViews As Hashtable = oDepList(sDepViewName)

			If HashNotInList(dicSubDepViews, oRet) Then
				'View has dependenies not listed above
				oTempList(sDepViewName) = True
			Else
				oRet.Add(sDepViewName)
			End If
		Next

		'Flush remaining items in temp list
		For Each oTempEntry As Collections.DictionaryEntry In oTempList
			Dim sView As String = oTempEntry.Key
			If oDeleteList.ContainsKey(sView) = False Then
				Dim oViews As Hashtable = oDepList(sView)
				If HashNotInList(oViews, oRet) = False Then
					oRet.Add(sView)
					oDeleteList(sView) = True
				End If
			End If
		Next

		Return oRet
	End Function

	Private Function HashNotInList(ByRef oHash As Hashtable, ByRef oList As ArrayList) As Boolean

		If oHash.Count = 0 Then
			Return False
		End If

		For Each oEntry As Collections.DictionaryEntry In oHash
			Dim sKey As String = oEntry.Key
			Dim bKeyInList As Boolean = False
			For j As Integer = 0 To oList.Count - 1
				If oList(j) = sKey Then
					bKeyInList = True
				End If
			Next

			If bKeyInList = False Then
				Return True
			End If
		Next

		Return False
	End Function

	Private Function GetTableSql(ByVal sTableName As String) As String
		If txtRowLimit.Text = "" Then
			Return ""
		End If

		Dim iMaxRows As Integer = txtRowLimit.Text
		If iMaxRows = 0 Then
			Return ""
		End If

		Dim cn As Data.OleDb.OleDbConnection = GetConnection()
		Dim iRow As Integer = 0
		Dim oRet As New System.Text.StringBuilder()
		Dim sSql As String = "select * from [" & sTableName & "]"


		Dim cmd As New Data.OleDb.OleDbCommand(sSql, cn)
		Dim dr As Data.OleDb.OleDbDataReader

		Try
			dr = cmd.ExecuteReader()
		Catch ex As Exception
			Return "GetTableSql for " & sTableName & ". Error: " & Err.Description
		End Try

		Dim oSchemaRows As Data.DataRowCollection = dr.GetSchemaTable.Rows

		While dr.Read()
			iRow += 1

			If iRow <= iMaxRows Then
				Dim sRow As String = ""

				For iCol As Integer = 0 To oSchemaRows.Count - 1
					Dim sDataType As String = oSchemaRows(iCol).Item("DATATYPE").FullName
					Dim sVal As String = ""
					If sDataType = "System.Byte[]" Then
						sVal = GetBinaryData(dr, iCol)
					Else
						sVal = dr.GetValue(iCol) & ""
					End If

					Dim sColumn As String = oSchemaRows(iCol).Item("ColumnName")

					If sRow <> "" Then
						sRow += ", "
					End If

					Select Case sDataType
						Case "System.Short", "System.Integer", "System.Long", "System.Decimal", "System.Int32", "System.Int64"
							If sVal = "" Then
								sRow += "NULL"
							Else
								sRow += sVal
							End If
						Case Else
							sRow += "'" & Replace(sVal, "'", "''") & "'"
					End Select

					sRow += " as [" & sColumn & "]"
				Next

				If iRow > 1 Then
					oRet.Append(" union all" & vbCrLf)
				End If

				oRet.Append(vbTab & "select " & sRow)
			End If

		End While

		dr.Close()
		cn.Close()

		If iRow > 1 Then
			Return oRet.ToString() & vbCrLf
		Else
			Return ""
		End If

	End Function

	Private Function GetBinaryData(ByRef dr As Data.OleDb.OleDbDataReader, ByVal iCol As Integer) As String

		Dim iBufferSize As Integer = 1000
		Dim oBuffer(iBufferSize - 1) As Byte
		Dim iByteCount As Long   'The bytes returned from GetBytes.
		Dim iStartIndex As Long = 0  'The starting position in the BLOB output

		Dim oMemoryStream As IO.MemoryStream = Nothing
		Dim oBinaryWriter As IO.BinaryWriter = Nothing
		Dim sRet As String = ""

		If IsDBNull(dr.GetValue(iCol)) = False Then

			oMemoryStream = New IO.MemoryStream()
			oBinaryWriter = New IO.BinaryWriter(oMemoryStream)

			iByteCount = dr.GetBytes(iCol, iStartIndex, oBuffer, 0, iBufferSize)

			'Continue reading and writing while there are bytes beyond the size of the buffer.
			While (iByteCount = iBufferSize)
				oBinaryWriter.Write(oBuffer)

				iStartIndex += iBufferSize
				iByteCount = dr.GetBytes(iCol, iStartIndex, oBuffer, 0, iBufferSize)
			End While

			If iByteCount > 2 Then
				ReDim Preserve oBuffer(iByteCount - 2)
				oBinaryWriter.Write(oBuffer)
			End If

			oBinaryWriter.Flush()
			oMemoryStream.Position = 0
			Dim oStreamReader As New IO.StreamReader(oMemoryStream, System.Text.Encoding.Unicode)
			sRet = oStreamReader.ReadToEnd()
			oStreamReader.Close()
			oMemoryStream.Close()
		End If

		Return sRet
	End Function

	Private Function AddTabs(ByVal sSql As String) As String
		Dim sRet As String = ""

		Dim oSql As String() = Regex.Split(sSql, vbCrLf)
		For i As Integer = 0 To oSql.Length - 1
			sRet += vbTab & oSql(i)

			If i < oSql.Length - 1 Then
				sRet += vbCrLf
			End If
		Next

		Return sRet
	End Function

	Private Function RegexReplace(ByRef sText As String, ByRef sPattern As String, ByRef sReplace As String) As String
		Return Regex.Replace(sText, sPattern, sReplace, RegexOptions.IgnoreCase)
	End Function

	Private Function PadSql(ByVal sSql As String) As String

		If chkReplace.Checked Then

			sSql = Replace(sSql, "dbo_", "")
			sSql = Replace(sSql, "DBO_", "")

			sSql = Replace(sSql, """", "'")
			sSql = Replace(sSql, "#", "'")
			sSql = Replace(sSql, ";", "")

			sSql = RegexReplace(sSql, "\bDISTINCTROW\b", "DISTINCT")

			sSql = RegexReplace(sSql, "\bCCur\(", "Convert(money,")
			sSql = RegexReplace(sSql, "\bCDbl\(", "Convert(decimal,")
			sSql = RegexReplace(sSql, "\bCInt\(", "Convert(int,")
			sSql = RegexReplace(sSql, "\bCVDate\(", "Convert(date,")
			sSql = RegexReplace(sSql, "\bCDate\(", "Convert(date,")
			sSql = RegexReplace(sSql, "\bNz\(", "IsNull(")

			sSql = RegexReplace(sSql, "\bDATE\(\)", "GetDate()")
			sSql = RegexReplace(sSql, "\bDATE \(\)", "GetDate()")

			sSql = RegexReplace(sSql, "\bVal\(", "Convert(decimal,")
			sSql = RegexReplace(sSql, "\bMid\(", "substring(")
			sSql = RegexReplace(sSql, "\bLast\(", "Max(") 'LAST_VALUE - SQL Server 2016

			'IsNull([Original_Salary]) = - 1  => [Original_Salary] IS NULL

			Dim oDepViews As Hashtable = GetDepViews(sSql)
			For Each oEntry As Collections.DictionaryEntry In oDepViews
				Dim sView As String = oEntry.Key
				sSql = Replace(sSql, "[" & sView & "]!", "[" & sView & "].")
			Next

			'IIf( -> case when
			Dim oRegEx As New Regex("IIf\(([^,]*),([^,]*),([^,]*)\)", RegexOptions.IgnoreCase)
			Dim oMatches As MatchCollection = oRegEx.Matches(sSql)
			For Each oMatch As Match In oMatches
				If oMatch.Groups.Count > 2 Then
					Dim sFind As String = oMatch.Groups(0).Value
					Dim a As String = oMatch.Groups(1).Value
					Dim b As String = oMatch.Groups(2).Value
					Dim c As String = oMatch.Groups(3).Value
					Dim sReplace As String = "case when " & a & " then " & b & " else " & c & " end "
					sSql = Replace(sSql, sFind, sReplace)
				End If
			Next

			'IsNull([Original_Salary])=-1
			oRegEx = New Regex("IsNull\(([^,]*)\)=-1", RegexOptions.IgnoreCase)
			oMatches = oRegEx.Matches(sSql)
			For Each oMatch As Match In oMatches
				If oMatch.Groups.Count > 1 Then
					Dim sFind As String = oMatch.Groups(0).Value
					Dim a As String = oMatch.Groups(1).Value
					Dim sReplace As String = a & " is null"
					sSql = Replace(sSql, sFind, sReplace)
				End If
			Next

			For Each oEntry As DictionaryEntry In dicTables
				Dim sName As String = oEntry.Key
				If GetLeft(sName, 4).ToLower() = "dbo_" Then
					sName = sName.Substring(4)
					sSql = Replace(sSql, "[" & sName & "]!", "[" & sName & "].")
					sSql = Replace(sSql, sName & "!", sName & ".")
				End If
			Next

			For Each oEntry As DictionaryEntry In dicViews
				Dim sName As String = oEntry.Key
				sSql = Replace(sSql, "[" & sName & "]!", "[" & sName & "].")
				sSql = Replace(sSql, sName & "!", sName & ".")
			Next

		End If

		sSql = ParseSql(sSql)
		Return sSql
	End Function

	Private Function ParseSql(ByVal sql As String)

		If chkFormatSql.Checked = False Then
			Return sql
		End If

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

	Private Sub GetDepViews(ByVal sSql As String, ByRef dicDepTables As Hashtable, ByRef dicDepViews As Hashtable, ByRef iLevel As Integer)
		If iLevel > 1000 Then
			'prevent infinate recursive loops
			Exit Sub
		End If

		If Not dicDepTables Is Nothing Then
			For Each oEntry As DictionaryEntry In dicTables
				Dim sName As String = oEntry.Key
				If GetLeft(sName, 4).ToLower() <> "dbo_" Then
					Dim oRegEx As New Regex("\b" & sName & "\b", RegexOptions.IgnoreCase)
					If sSql.ToLower().IndexOf("[" & sName.ToLower() & "]") <> -1 OrElse oRegEx.IsMatch(sSql) Then
						If sSql.ToLower().IndexOf("into [" & sName.ToLower() & "]") = -1 Then
							dicDepTables(sName) = True
						End If
					End If
				End If
			Next
		End If

		For Each oEntry As DictionaryEntry In dicViews
			Dim sName As String = oEntry.Key

			Dim oRegEx As New Regex("\b" & Replace(sName, ")", "\)") & "\b", RegexOptions.IgnoreCase)

			If sSql.ToLower().IndexOf("[" & sName.ToLower() & "]") <> -1 OrElse oRegEx.IsMatch(sSql) Then
				If dicDepViews.ContainsKey(sName) = False Then
					dicDepViews.Add(sName, iLevel)

					GetDepViews(oEntry.Value, dicDepTables, dicDepViews, iLevel + 1)
				End If

			End If
		Next
	End Sub


	Private Function GetDepViews(ByVal sSql As String) As Hashtable
		Dim oRet As New Hashtable

		For Each oEntry As DictionaryEntry In dicViews
			Dim sName As String = oEntry.Key

			Dim oRegEx As New Regex("\b" & Replace(sName, ")", "\)") & "\b", RegexOptions.IgnoreCase)

			If sSql.ToLower().IndexOf("[" & sName.ToLower() & "]") <> -1 OrElse oRegEx.IsMatch(sSql) Then
				If oRet.ContainsKey(sName) = False Then
					oRet.Add(sName, True)

				End If
			End If
		Next

		Return oRet
	End Function

	Private Sub txtFilePath_LostFocus(sender As Object, e As EventArgs) Handles txtFilePath.LostFocus
		If txtFilePath.Text <> "" Then
			btnLoad.Visible = True
		End If
	End Sub

	Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Dim oAppSetting As New AppSetting
		oAppSetting.SetValue("FilePath", txtFilePath.Text)
		oAppSetting.SetValue("RowLimit", txtRowLimit.Text)
		oAppSetting.SetValue("View", cmViews.SelectedItem)

		oAppSetting.SetValue("FormatSql", IIf(chkFormatSql.Checked, "1", "0"))
		oAppSetting.SetValue("Replace", IIf(chkReplace.Checked, "1", "0"))
		oAppSetting.SetValue("CTE", IIf(chkCTE.Checked, "1", "0"))

		oAppSetting.SaveData()

		CloseConnectionIfOpen()

	End Sub

	Private Sub CloseConnectionIfOpen()
		If (Not cnOleDb Is Nothing) AndAlso cnOleDb.State = ConnectionState.Open Then
			cnOleDb.Close()
		End If
	End Sub


	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
		Dim oAppSetting As New AppSetting
		txtFilePath.Text = oAppSetting.GetValue("FilePath")
		txtRowLimit.Text = oAppSetting.GetValue("RowLimit", "1000")

		chkFormatSql.Checked = oAppSetting.GetValue("FormatSql", "1") = "1"
		chkReplace.Checked = oAppSetting.GetValue("Replace", "1") = "1"
		chkCTE.Checked = oAppSetting.GetValue("CTE", "1") = "1"

		If txtFilePath.Text <> "" Then
			btnLoad.Visible = True
		End If
	End Sub

	Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
		Dim oAppSetting As New AppSetting
		LoadViews()
		cmViews.SelectedItem = oAppSetting.GetValue("View")
	End Sub

	Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click

		If txtSQL.Text = "" Then
			Exit Sub
		End If

		txtSQL.SelectAll()
		txtSQL.Focus()
		Clipboard.Clear()
		Clipboard.SetText(txtSQL.Text)
	End Sub

	Private Function GetFolderPath(ByVal sName As String, ByVal bDeleteIfExisits As Boolean) As String
		Dim sAssPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
		Dim sPath As String = System.IO.Path.GetDirectoryName(sAssPath)
		Dim sFolderPath As String = System.IO.Path.Combine(sPath, sName)

		If bDeleteIfExisits Then
			DeleteFileInFolder(sFolderPath)
		End If

		Try
			If IO.Directory.Exists(sFolderPath) = False Then
				IO.Directory.CreateDirectory(sFolderPath)
			End If
		Catch ex As Exception
			txtSQL.AppendText("Could not create folder: " & sFolderPath & ", " & ex.Message & vbCrLf)
		End Try


		Return sFolderPath
	End Function

	Sub DeleteFileInFolder(sFolderPath)
		If IO.Directory.Exists(sFolderPath) = False Then
			Exit Sub
		End If

		Dim oFiles As String() = IO.Directory.GetFiles(sFolderPath)

		For Each sFilePath As String In oFiles
			Try
				If IO.File.Exists(sFilePath) Then
					IO.File.Delete(sFilePath)
				End If
			Catch ex As Exception
				txtSQL.AppendText("Could not delete file: " & sFilePath & ", " & ex.Message & vbCrLf)
			End Try

		Next

	End Sub

	Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
		Dim sFolderPath As String = GetFolderPath("Views", True)

		txtSQL.Text = ""
		ProgressBar1.Visible = True
		ProgressBar1.Minimum = 1
		ProgressBar1.Maximum = dicViews.Count
		Dim iCount As Integer = 0

		For Each oEntry As DictionaryEntry In dicViews
			Dim sViewName As String = oEntry.Key
			Dim sSql As String = ShowView(sViewName, False)
			Dim sFilePath As String = System.IO.Path.Combine(sFolderPath, sViewName & ".sql")
			Dim oFile As New IO.StreamWriter(sFilePath, True)
			oFile.Write(sSql)
			oFile.Close()

			iCount += 1
			ProgressBar1.Value = iCount
			System.Windows.Forms.Application.DoEvents()
		Next

		ProgressBar1.Visible = False

		Process.Start("explorer.exe", String.Format("/n, /e, {0}", sFolderPath & "\"))
	End Sub

	Private Sub btnBeautify_Click(sender As Object, e As EventArgs) Handles btnBeautify.Click
		FormatSql.ShowDialog()
	End Sub


	Private Sub btnLoadMacros_Click(sender As Object, e As EventArgs) Handles btnLoadMacros.Click
		LoadMacrosFromAccess()
	End Sub

	Private Sub LoadMacrosFromAccess()

		Dim sFolderPath As String = GetFolderPath("RawMacros", True)
		Dim oApp As Microsoft.Office.Interop.Access.Application = CreateObject("Access.Application")
		oApp.Visible = True
		oApp.UserControl = False
		oApp.OpenCurrentDatabase(txtFilePath.Text)
		Dim oDatabase As Microsoft.Office.Interop.Access.Dao.Database = oApp.CurrentDb
		Dim oMacros As New Hashtable

		'Dim i As Integer = 0
		For Each oMacro As Object In oApp.CurrentProject.AllMacros
			'i += 1
			Dim sName As String = oMacro.Name
			Dim sFilePath As String = System.IO.Path.Combine(sFolderPath, sName & ".sql")
			'acMacro As Microsoft.Office.Interop.Access.AcObjectType = 4
			oApp.SaveAsText(Microsoft.Office.Interop.Access.AcObjectType.acMacro, sName, sFilePath)
			oMacros(sName) = True
		Next

		oApp.CloseCurrentDatabase()
		oApp.Quit()

		'Update Views Listbox
		Dim oList As New SortedList
		For Each oEntry As DictionaryEntry In oMacros
			oList.Add(oEntry.Key, oEntry.Value)
		Next

		lbMacros.Items.Clear()
		For Each oEntry As DictionaryEntry In oList
			lbMacros.Items.Add(oEntry.Key)
		Next

		Process.Start("explorer.exe", String.Format("/n, /e, {0}", sFolderPath & "\"))
	End Sub


	Private Sub btnMarcoCreate_Click(sender As Object, e As EventArgs) Handles btnMarcoCreate.Click
		Dim sName As String = lbMacros.SelectedItem
		If sName = "" Then
			MsgBox("Please select a macro")
			Exit Sub
		End If

		If dicViews.Count = 0 And dicProcs.Count = 0 Then
			MsgBox("Please load views and procs before exporting macros.")
			Exit Sub
		End If

		txtSQL.Text = ""

		Dim sInFolderPath As String = GetFolderPath("RawMacros", False)
		Dim sBaseOutFolderPath As String = GetFolderPath("Macros", False)
		Dim sOutFolderPath As String = System.IO.Path.Combine(sBaseOutFolderPath, sName)

		DeleteFileInFolder(sOutFolderPath)

		If IO.Directory.Exists(sOutFolderPath) = False Then
			IO.Directory.CreateDirectory(sOutFolderPath)
		End If

		txtSQL.Text = ReadMacroFile(sName, sInFolderPath, sOutFolderPath)

		Process.Start("explorer.exe", String.Format("/n, /e, {0}", sOutFolderPath & "\"))
	End Sub

	Private Function CreateMacroOuputFile(ByVal sName As String, ByVal sInFilePath As String, ByVal sOutputFilePath As String,
			ByRef oMacroList As Hashtable, ByRef oQueryList As Hashtable) As String

		If IO.File.Exists(sInFilePath) = False Then
			txtSQL.AppendText("Could not find input file: " & sInFilePath & vbCrLf)
			Return ""
		End If

		Dim sr As System.IO.StreamReader = New System.IO.StreamReader(sInFilePath)
		Dim sRecord As String = sr.ReadLine
		Dim bStartFound As Boolean = False
		Dim sActionStart As String = "    Action ="""
		Dim sArgumentStart As String = "    Argument ="""
		Dim sSql As String = ""
		Dim sAction As String = ""

		Do Until sRecord Is Nothing
			sRecord = sr.ReadLine
			If sRecord <> "" Then

				If bStartFound Then
					If GetLeft(sRecord, sArgumentStart.Length) = sArgumentStart Then
						Dim sView As String = Replace(sRecord, sArgumentStart, "")
						sView = Replace(sView, """", "")

						Select Case sAction
							Case "OpenQuery"
								sSql += "exec [" & sView & "]" & vbCrLf
								oQueryList(sView) = True

							Case "RunMacro"
								sSql += "exec [" & sView & "] --Macro" & vbCrLf
								oMacroList(sView) = True

							Case "RunCode"
								sSql += "exec [" & sView & "] --VBA Function" & vbCrLf

						End Select

					End If

					bStartFound = False
				ElseIf GetLeft(sRecord, sActionStart.Length) = sActionStart Then
					bStartFound = True
					sAction = Replace(sRecord, sActionStart, "")
					sAction = Replace(sAction, """", "") 'OpenQuery,RunMacro
				End If


			End If
		Loop

		sr.Close()

		If sSql <> "" Then
			sSql = "create proc [" & sName & "] as " & vbCrLf & sSql
			Dim oFile As New IO.StreamWriter(sOutputFilePath, True)
			oFile.Write(sSql)
			oFile.Close()
		End If

		Return sSql
	End Function

	Private Function ReadMacroFile(ByVal sName As String, sInFolderPath As String, sOutFolderPath As String) As String
		Dim sInFilePath As String = System.IO.Path.Combine(sInFolderPath, sName & ".sql")

		Dim sOutputFilePath As String = System.IO.Path.Combine(sOutFolderPath, sName & ".sql")
		If IO.File.Exists(sOutputFilePath) Then
			txtSQL.AppendText("Output file already exists: " & sOutputFilePath & vbCrLf)
			Return ""
		End If

		Dim sRetSql As String = ""
		Dim oQueryList As New Hashtable
		Dim oMacroList As New Hashtable
		sRetSql = CreateMacroOuputFile(sName, sInFilePath, sOutputFilePath, oMacroList, oQueryList)

		For Each oEntry As Collections.DictionaryEntry In oMacroList
			Dim sMacroName As String = oEntry.Key
			ReadMacroFile(sMacroName, sInFolderPath, sOutFolderPath)
		Next

		Dim dicDepTables As New Hashtable
		Dim dicDepViews As New Hashtable

		For Each oEntry As DictionaryEntry In oQueryList
			Dim sViewName As String = oEntry.Key
			Dim sFilePath As String = System.IO.Path.Combine(sOutFolderPath, sViewName & ".sql")
			If IO.File.Exists(sFilePath) = False Then
				Dim sViewSql As String = ""

				If dicViews.ContainsKey(sViewName) Then
					sViewSql = ShowView(sViewName, False)
				ElseIf dicProcs.ContainsKey(sViewName) Then
					sViewSql = ShowView(sViewName, False)
				Else
					txtSQL.AppendText("Could not find view or proc: " & sViewName & vbCrLf)
				End If

				If sViewSql <> "" Then
					Dim oFile As New IO.StreamWriter(sFilePath, True)
					oFile.Write(sViewSql)
					oFile.Close()

					If chkScriptDepView.Checked Then
						GetDepViews(sViewSql, dicDepTables, dicDepViews, 1)
					End If
				End If
			End If
		Next

		If chkScriptDepView.Checked Then
			For Each oEntry As DictionaryEntry In dicDepViews
				Dim sViewName As String = oEntry.Key
				Dim sFilePath As String = System.IO.Path.Combine(sOutFolderPath, sViewName & ".sql")
				If IO.File.Exists(sFilePath) = False Then
					Dim sViewSql As String = ShowView(sViewName, False)
					Dim oFile As New IO.StreamWriter(sFilePath, True)
					oFile.Write(sViewSql)
					oFile.Close()
				End If
			Next
		End If

		Return sRetSql
	End Function

	Private Function GetLeft(ByVal s As String, i As Integer) As String
		Return Microsoft.VisualBasic.Left(s, i)
	End Function

	Private Sub btnGetProcSQL_Click(sender As Object, e As EventArgs) Handles btnGetProcSQL.Click
		Dim sName As String = lbProcs.Text

		If sName = "" Then
			MsgBox("Please select a view")
		Else
			txtSQL.Text = ShowView(sName, False)
		End If
	End Sub

	Private Sub btnSaveAllProcs_Click(sender As Object, e As EventArgs) Handles btnSaveAllProcs.Click
		Dim sFolderPath As String = GetFolderPath("Procs", True)

		txtSQL.Text = ""
		ProgressBar1.Visible = True
		ProgressBar1.Minimum = 1
		ProgressBar1.Maximum = dicProcs.Count
		Dim iCount As Integer = 0

		For Each oEntry As DictionaryEntry In dicProcs
			Dim sProcName As String = oEntry.Key
			Dim sSql As String = ShowView(sProcName, False)
			Dim sFilePath As String = System.IO.Path.Combine(sFolderPath, sProcName & ".sql")
			Dim oFile As New IO.StreamWriter(sFilePath, True)
			oFile.Write(sSql)
			oFile.Close()

			iCount += 1
			ProgressBar1.Value = iCount
			System.Windows.Forms.Application.DoEvents()
		Next

		ProgressBar1.Visible = False

		Process.Start("explorer.exe", String.Format("/n, /e, {0}", sFolderPath & "\"))
	End Sub

	Private Sub btnSaveAllMacros_Click(sender As Object, e As EventArgs) Handles btnSaveAllMacros.Click
		Dim sInFolderPath As String = GetFolderPath("RawMacros", False)
		Dim sOutFolderPath As String = GetFolderPath("Macros", True)
		Dim oFiles As String() = System.IO.Directory.GetFiles(sInFolderPath)

		txtSQL.Text = ""
		ProgressBar1.Visible = True
		ProgressBar1.Minimum = 1
		ProgressBar1.Maximum = oFiles.Count
		Dim iCount As Integer = 0

		For Each sFilePath As String In oFiles
			Dim sMacroName As String = IO.Path.GetFileNameWithoutExtension(sFilePath)
			Dim sOutputFilePath As String = System.IO.Path.Combine(sOutFolderPath, sMacroName & ".sql")
			CreateMacroOuputFile(sMacroName, sFilePath, sOutputFilePath, New Hashtable, New Hashtable)

			iCount += 1
			ProgressBar1.Value = iCount
			System.Windows.Forms.Application.DoEvents()
		Next

		ProgressBar1.Visible = False

		Process.Start("explorer.exe", String.Format("/n, /e, {0}", sOutFolderPath & "\"))
	End Sub
End Class
