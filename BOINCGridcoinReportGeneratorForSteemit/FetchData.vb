Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class FetchData
    Public Shared Sub Create(link As String, downloadfilename As String, table As String, userxmlfile As String, teamid As String)
        Dim DataToWrite As String = String.Empty
        Try
            Dim FileDownloadedAndExtracted As Boolean = False
            Try
                If My.Computer.FileSystem.FileExists(downloadfilename) Then My.Computer.FileSystem.DeleteFile(downloadfilename)
                If My.Computer.FileSystem.FileExists(userxmlfile) Then My.Computer.FileSystem.DeleteFile(userxmlfile)
                My.Computer.Network.DownloadFile(link, downloadfilename)
                Dim objProcess = New System.Diagnostics.Process()
                objProcess.StartInfo.FileName = "7za.exe"
                objProcess.StartInfo.Arguments = "x " & downloadfilename
                objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                objProcess.Start()
                'Wait until the process passes back an exit code 
                objProcess.WaitForExit()
                'Free resources associated with this process
                objProcess.Close()
                FileDownloadedAndExtracted = True
            Catch ex As Exception
                FileDownloadedAndExtracted = False
            End Try
            If FileDownloadedAndExtracted = True And My.Computer.FileSystem.FileExists(userxmlfile) Then
                Dim xmlDoc As New XmlDocument()
                Dim MySQLServer As String = Form1.MySQLString
                xmlDoc.Load(userxmlfile)
                Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/users/user")
                Dim id As String = ""
                Dim previousCredits As Double = 0.0, TotalCredits As Double = 0.0
                Dim SQLQuery As String = ""
                Dim Connection As MySqlConnection = New MySqlConnection(MySQLServer)
                Connection.Open()
                Dim Connection2 As MySqlConnection = New MySqlConnection(MySQLServer)
                Dim Connection3 As MySqlConnection = New MySqlConnection(MySQLServer)
                Dim Command As MySqlCommand
                Try
                    SQLQuery = "UPDATE " & table & " SET yesterday = '0' WHERE yesterday = 'new'"
                    Try
                        Connection2.Open()
                        Dim Command2 = New MySqlCommand(SQLQuery, Connection2)
                        Command2.ExecuteNonQuery()
                        Connection2.Close()
                    Catch ex As Exception

                    End Try

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                For Each node As XmlNode In nodes
                    Try
                        If node.SelectSingleNode("teamid").InnerText = teamid Then
                            Try
                                Connection.Open()
                            Catch ex As Exception
                            End Try
                            id = node.SelectSingleNode("id").InnerText
                            TotalCredits = node.SelectSingleNode("total_credit").InnerText
                            SQLQuery = "SELECT totalcredits FROM " & table & " WHERE id = '" & id & "'"
                            Command = New MySqlCommand(SQLQuery, Connection)
                            Dim reader As MySqlDataReader = Command.ExecuteReader
                            If reader.HasRows = True Then
                                While reader.Read
                                    previousCredits = reader("totalcredits")
                                    Dim CalculateYesterday = TotalCredits - previousCredits
                                    Try
                                        SQLQuery = "UPDATE " & table & " SET name = '" & node.SelectSingleNode("name").InnerText.Replace("'", "\'") & "', totalcredits = '" & TotalCredits & "', yesterday = '" & CalculateYesterday & "', average = '" & node.SelectSingleNode("expavg_credit").InnerText & "',  cpid = '" & node.SelectSingleNode("cpid").InnerText & "' WHERE id = '" & id & "'"
                                        Try
                                            Connection2.Open()
                                            Dim Command2 = New MySqlCommand(SQLQuery, Connection2)
                                            Command2.ExecuteNonQuery()
                                            Connection2.Close()
                                        Catch ex As Exception
                                        End Try
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try
                                End While
                            Else
                                Try
                                    SQLQuery = "INSERT INTO " & table & " (name, totalcredits, yesterday, average, cpid, id) VALUES ('" & node.SelectSingleNode("name").InnerText.Replace("'", "\'") & "', '" & TotalCredits & "', 'new', '" & node.SelectSingleNode("expavg_credit").InnerText & "', '" & node.SelectSingleNode("cpid").InnerText & "', '" & node.SelectSingleNode("id").InnerText & "')"
                                    Try
                                        Connection3.Open()
                                        Dim Command3 = New MySqlCommand(SQLQuery, Connection3)
                                        Command3.ExecuteNonQuery()
                                        Connection3.Close()
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            End If
                            Connection.Close()
                        End If
                    Catch ex As Exception
                        If ex.ToString.ToLower.Contains("nullreferenceexception") = False Then
                            MsgBox(ex.ToString)
                        End If
                    End Try
                Next
                Connection.Close()
                Try
                    Connection.Open()
                Catch ex As Exception

                End Try
                SQLQuery = "SELECT * FROM " & table & " WHERE yesterday = 'new' ORDER BY name"
                Dim Command4 = New MySqlCommand(SQLQuery, Connection)
                Dim reader2 As MySqlDataReader = Command4.ExecuteReader
                Dim counter As Integer = 0
                If reader2.HasRows Then
                    While reader2.Read
                        counter = counter + 1
                    End While
                End If
                DataToWrite = counter.ToString
                Dim CurrentDateTime = Now()
                Dim RenamedXMLFile As String = table & " - " & Format(CurrentDateTime, "yyyy-MM-dd hh-mm-ss tt - ") & userxmlfile
                Dim RenamedDownloadFile As String = table & " - " & Format(CurrentDateTime, "yyyy-MM-dd hh-mm-ss tt - ") & downloadfilename
                My.Computer.FileSystem.MoveFile(userxmlfile, DateTime.Now.ToString("yyyy-MM-dd") & "\" & RenamedXMLFile)
                My.Computer.FileSystem.MoveFile(downloadfilename, DateTime.Now.ToString("yyyy-MM-dd") & "\" & RenamedDownloadFile)
            Else
                My.Computer.FileSystem.WriteAllText("error.log", Now().ToString() & " | Cannot process data from " & table & Environment.NewLine, True)
            End If
        Catch ex As Exception
            DataToWrite = "Could not fetch export stats from the project server."
            My.Computer.FileSystem.WriteAllText("error.log", Now().ToString() & " | Cannot process data from " & table & ": " & ex.ToString & Environment.NewLine, True)
        End Try
        Dim ReportFile As New System.IO.StreamWriter(DateTime.Now.ToString("yyyy-MM-dd") & "\report.txt", True)
        Dim ProjectName As String = String.Empty
        If table = "worldcommunitygrid" Then
            ProjectName = "World Community Grid | "
        ElseIf table = "setiathome" Then
            ProjectName = "SETI@home | "
        ElseIf table = "amicablenumbers" Then
            ProjectName = "Amicable Numbers | "
        ElseIf table = "asteroidsathome" Then
            ProjectName = "Asteroids@home | "
        ElseIf table = "citizensciencegrid" Then
            ProjectName = "Citizen Science Grid | "
        ElseIf table = "collatzconjecture" Then
            ProjectName = "Collatz Conjecture | "
        ElseIf table = "cosmologyathome" Then
            ProjectName = "Cosmology@Home | "
        ElseIf table = "ddathome" Then
            ProjectName = "DrugDiscovery@Home | "
        ElseIf table = "einsteinathome" Then
            ProjectName = "einstein@home | "
        ElseIf table = "enigma" Then
            ProjectName = "Enigma@Home | "
        ElseIf table = "gpugrid" Then
            ProjectName = "GPUGRID | "
        ElseIf table = "leidenclassical" Then
            ProjectName = "Leiden Classical | "
        ElseIf table = "lhcathomeclassic" Then
            ProjectName = "LHC@home | "
        ElseIf table = "milkywayathome" Then
            ProjectName = "Milkyway@Home | "
        ElseIf table = "moowrap" Then
            ProjectName = "Moo! Wrapper | "
        ElseIf table = "nfsathome" Then
            ProjectName = "NFS@Home | "
        ElseIf table = "numberfieldsathome" Then
            ProjectName = "NumberFields@Home | "
        ElseIf table = "odlk1" Then
            ProjectName = "ODLK1 | "
        ElseIf table = "primegrid" Then
            ProjectName = "PrimeGrid | "
        ElseIf table = "rosettaathome" Then
            ProjectName = "Rosetta@home | "
        ElseIf table = "srbase" Then
            ProjectName = "SRBase | "
        ElseIf table = "sourcefinder" Then
            ProjectName = "Sourcefinder | "
        ElseIf table = "sdg" Then
            ProjectName = "SZTAKI Desktop Grid | "
        ElseIf table = "tsnp" Then
            ProjectName = "theSkyNet POGS | "
        ElseIf table = "tngrid" Then
            ProjectName = "TN-Grid | "
        ElseIf table = "universeathome" Then
            ProjectName = "Universe@Home | "
        ElseIf table = "vgtu" Then
            ProjectName = "VGTU project@Home | "
        ElseIf table = "yafu" Then
            ProjectName = "YAFU | "
        ElseIf table = "yoyo" Then
            ProjectName = "yoyo@home | "
        End If
        ReportFile.WriteLine(ProjectName + DataToWrite)
        ReportFile.Close()
    End Sub
End Class
