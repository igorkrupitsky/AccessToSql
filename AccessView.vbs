if WScript.Arguments.Count = 0 then
  MsgBox "Please drag and drop MS Acccess file"
	wscript.Quit
End if

sFile = WScript.Arguments(0)

If Not (lcase(right(sFile,4)) = ".mdb" or lcase(right(sFile,6)) = ".accdb") Then
  MsgBox "Please drag and drop MS Acccess file not: " & sFile
	wscript.Quit
End If

Set fso = CreateObject("Scripting.FileSystemObject")
sLogFile = sFile & ".csv"

If fso.FileExists(sLogFile) Then
  On Error resume next
  fso.DeleteFile sLogFile, True
  
  If Err.Number <> 0 Then
    sLogFile = sFile & "_" & Replace(Replace(Replace(Now(),"/","-"),":","-")," ","_") & ".csv"
    Err.Clear
    On Error goto 0
  End If   
End If

Set oLog = fso.CreateTextFile(sLogFile, True)
oLog.WriteLine "sep=" & vbTab

Dim oApp: Set oApp = createObject("Access.Application")
oApp.visible = False
'oApp.UserControl = true
oApp.OpenCurrentDataBase(sFile)
Dim oDatabase: Set oDatabase = oApp.CurrentDb

Set oNewLinks = CreateObject("Scripting.Dictionary")
Const dbAttachedODBC = 536870912

Dim t 'As TableDef
For Each t In oDatabase.TableDefs
    If (t.Attributes And dbAttachedODBC) And t.SourceTableName <> "" Then 'If the table source is other than a base table
        oLog.WriteLine "Table" & vbTab & t.Name & vbTab & t.SourceTableName & vbTab & t.Connect
    End If
Next

Dim q 'As QueryDef
For Each q In oDatabase.QueryDefs
    If q.Connect <> "" Then 'q.Type 112
      oLog.WriteLine "Query" & vbTab & q.Name & vbTab & """" & Replace(q.SQL,"""","'") & """" & vbTab & q.Connect        
    End If
Next

oApp.Quit
Set oApp = Nothing
oLog.Close 

Set oExcel = CreateObject("Excel.Application")
oExcel.visible = True
Set workbook = oExcel.Workbooks.Open(sLogFile)

MsgBox "Created " & sLogFile

