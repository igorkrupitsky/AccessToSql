sConnect = "ODBC;DRIVER=SQL Server;Server=NewServer1;Database=NewDb1;Uid=User1;Pwd=Password123;"

if WScript.Arguments.Count = 0 then
  MsgBox "Please drag and drop MS Acccess file"
	wscript.Quit
End if

sFile = WScript.Arguments(0)

If Not (lcase(right(sFile,4)) = ".mdb" or lcase(right(sFile,6)) = ".accdb") Then
  MsgBox "Please drag and drop MS Acccess file not: " & sFile
	wscript.Quit
End If

Dim oApp: Set oApp = createObject("Access.Application")
oApp.visible = False
oApp.UserControl = true
oApp.OpenCurrentDataBase(sFile)
Dim oDatabase: Set oDatabase = oApp.CurrentDb

oApp.DoCmd.NavigateTo "acNavigationCategoryObjectType"
'oApp.DoCmd.RunCommand 2 'acCmdWindowHide
oApp.DoCmd.SelectObject 0, , True 'cTable = 0

Set oTables = CreateObject("Scripting.Dictionary")
Set oNewLinks = CreateObject("Scripting.Dictionary")
Const dbAttachedODBC = 536870912
Const dbAttachSavePWD = 131072

Dim t 'As TableDef
For Each t In oDatabase.TableDefs
    If (t.Attributes And dbAttachedODBC) And t.SourceTableName <> "" Then 'If the table source is other than a base table

      sTableConnect = sConnect
      If lcase(right(t.SourceTableName,5)) = "_view" Then
        sTableConnect = Replace(sConnect,";Database=LSLMDB",";Database=LSCUSTDB")
      End If

      If Right(t.Name,7) <> "_delete" And t.Connect <> sTableConnect Then
     
        bNewLink = False

        If InStr(1, t.SourceTableName, "ls_apps.") = 0 Then
          oTables(Replace(t.SourceTableName, "dbo.", "")) = True
        End If

        sSourceTableName = Replace(t.SourceTableName, "dbo.", "ls_apps.")             
        If sSourceTableName <> t.SourceTableName Then
        
          sName = t.Name
          t.Name = sName & "_delete"
          
          Set n = oDatabase.CreateTableDef()
          n.Name = sName
          n.Connect = sTableConnect
          n.Attributes = (n.Attributes Or dbAttachSavePWD)
          n.SourceTableName = sSourceTableName            
          oNewLinks.Add oNewLinks.Count, n
          
          bNewLink = True
        End If

        If bNewLink = False Then
        
          t.Connect = sTableConnect
          
          On Error Resume Next
          t.RefreshLink
          If Err.Number <> 0 Then
            MsgBox "t.RefreshLink - Name: " & t.Name & ", Error: " & Err.Description
            Err.Clear
            On Error GoTo 0
          End If
          
        End If
        
      End If      
    End If
Next

For i = 0 To oNewLinks.Count - 1  
  bSuccess = True
  
  On Error Resume Next
  Set t = oNewLinks.Item(i)    
  oDatabase.TableDefs.Append t
  
  If Err.Number <> 0 Then
    MsgBox "t.RefreshLink - Name: " & t.Name & ", Error: " & Err.Description
    bSuccess = False
    Err.Clear
  End If

  On Error GoTo 0
  
  If bSuccess Then
    oDatabase.TableDefs.Delete t.Name & "_delete"
  End If
Next

Dim q 'As QueryDef
For Each q In oDatabase.QueryDefs
    If q.Connect <> "" Then 'q.Type 112
        q.Connect = sConnect

        If InStr(1, q.SQL, "ls_apps.") = 0 Then
          q.SQL = Replace(q.SQL, "dbo.", "ls_apps.")
          
          For Each sTable in oTables.Keys 
            If sTable <> "" Then
              q.SQL = Replace(q.SQL, vbCrLf & "FROM " & sTable, vbCrLf & "FROM ls_apps." & sTable)
            End If
          Next
          
          q.SQL = Replace(q.SQL, vbCrLf & "FROM EMP", vbCrLf & "FROM ls_apps.EMP")
          q.SQL = Replace(q.SQL, vbCrLf & "FROM GM", vbCrLf & "FROM ls_apps.GM")          
        End If          

    End If
Next

MsgBox "Updated " & sFile
