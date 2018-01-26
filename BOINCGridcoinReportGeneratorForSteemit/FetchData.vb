Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class FetchData
    Public Shared Sub Create(link As String, downloadfilename As String, table As String, userxmlfile As String, teamid As String)
        Dim FileDownloadedAndExtracted As Boolean = False
        Try
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
        If FileDownloadedAndExtracted = True Then
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
            If reader2.HasRows Then
                Dim ReportFile As New System.IO.StreamWriter(DateTime.Now.ToString("yyyy-MM-dd") & "\report.txt", True)
                Dim ProjectMoreStatsURL As String = ""
                If table = "worldcommunitygrid" Then
                    ReportFile.WriteLine("# World Community Grid")
                    ReportFile.WriteLine("World Community Grid is a project that aims to solve real world issues like fighting disieases and researching new materials to provide clean water and energy. [Learn more about World Community Grid by clicking here.](https://worldcommunitygrid.org)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/world%20community%20grid"
                ElseIf table = "setiathome" Then
                    ReportFile.WriteLine("# SETI@home")
                    ReportFile.WriteLine("SETI@home is a project based at the University of California, Berkeley that aims to find extraterrestrial life. [Learn more about SETI@home by clicking here.](http://setiathome.berkeley.edu/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/seti@home"
                ElseIf table = "amicablenumbers" Then
                    ReportFile.WriteLine("# Amicable Numbers")
                    ReportFile.WriteLine("Amicable Numbers is a project that aims to find new Amicable Pairs. [Learn more about Amicable Numbers by clicking here.](https://sech.me/boinc/Amicable/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/amicable%20numbers"
                ElseIf table = "asteroidsathome" Then
                    ReportFile.WriteLine("# Asteroids@home")
                    ReportFile.WriteLine("Asteroids@home is a project that researches asteroids. [Learn more about Asteroids@home by clicking here.](http://asteroidsathome.net/boinc/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/asteroids@home"
                ElseIf table = "citizensciencegrid" Then
                    ReportFile.WriteLine("# Citizen Science Grid")
                    ReportFile.WriteLine("Citizen Science Grid is a project that does educational research in several areas. [Learn more about Citizen Science Grid by clicking here.](https://csgrid.org/csg/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/citizen%20science%20grid"
                ElseIf table = "collatzconjecture" Then
                    ReportFile.WriteLine("# Collatz Conjecture")
                    ReportFile.WriteLine("Collatz Conjecture is a project that aims to solve the Collatz Conjecture. [Learn more about Collatz Conjecture by clicking here.](https://boinc.thesonntags.com/collatz/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/collatz%20conjecture"
                ElseIf table = "cosmologyathome" Then
                    ReportFile.WriteLine("# Cosmology@Home")
                    ReportFile.WriteLine("Cosmology@Home is a project that aims to find the model that best describes the Universe. [Learn more about Cosmology@Home by clicking here.](https://www.cosmologyathome.org/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/cosmology@home"
                ElseIf table = "ddathome" Then
                    ReportFile.WriteLine("# DrugDiscovery@Home")
                    ReportFile.WriteLine("DrugDiscovery@Home is a project that aims to discover new drugs for several widespread and dangerous diseases. [Learn more about DrugDiscovery@Home by clicking here.](http://boinc.drugdiscoveryathome.com/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/drugdiscovery@home"
                ElseIf table = "einsteinathome" Then
                    ReportFile.WriteLine("# einstein@home")
                    ReportFile.WriteLine("einstein@home is a project that searches for gravitational waves from spinning isolated compact objects using data from the LIGO detector. [Learn more about einstein@home by clicking here.](https://einsteinathome.org/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/einstein@home"
                ElseIf table = "enigma" Then
                    ReportFile.WriteLine("# Enigma@Home")
                    ReportFile.WriteLine("Enigma@Home is a wrapper that aims to break the original Enigma messages. [Learn more about Enigma@Home by clicking here.](http://enigmaathome.net)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/enigma@home"
                ElseIf table = "gpugrid" Then
                    ReportFile.WriteLine("# GPUGRID")
                    ReportFile.WriteLine("GPUGRID is a project that does biomedical research. [Learn more about GPUGRID by clicking here.](http://gpugrid.net/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/gpugrid"
                ElseIf table = "leidenclassical" Then
                    ReportFile.WriteLine("# Leiden Classical")
                    ReportFile.WriteLine("Leiden Classical is a project that aims to build a computing grid for Classical Dynamics computation. [Learn more about Leiden Classical by clicking here.](http://boinc.gorlaeus.net/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/leiden%20classical"
                ElseIf table = "lhcathomeclassic" Then
                    ReportFile.WriteLine("# LHC@home")
                    ReportFile.WriteLine("LHC@home Classic is a project from CERN. [Learn more about LHC@home Classic by clicking here.](http://lhcathomeclassic.cern.ch/sixtrack/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/lhc@home%20classic"
                ElseIf table = "milkywayathome" Then
                    ReportFile.WriteLine("# Milkyway@Home")
                    ReportFile.WriteLine("Milkyway@Home is a project that aims to create a highly accurate three dimensional model from our Milkyway Galaxy. [Learn more about Milkyway@Home by clicking here.](https://milkyway.cs.rpi.edu/milkyway/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/milkyway@home"
                ElseIf table = "moowrap" Then
                    ReportFile.WriteLine("# Moo! Wrapper")
                    ReportFile.WriteLine("Moo! Wrapper is a wrapper for the distributed.net project and currently wraps their RC5-72 subproject. [Learn more about Moo! Wrapper by clicking here.](https://moowrap.net)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/moowrap"
                ElseIf table = "nfsathome" Then
                    ReportFile.WriteLine("# NFS@Home")
                    ReportFile.WriteLine("NFS@Home is a project that does number factorization. [Learn more about NFS@Home by clicking here.](https://escatter11.fullerton.edu/nfs/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/nfs@home"
                ElseIf table = "numberfieldsathome" Then
                    ReportFile.WriteLine("# NumberFields@Home")
                    ReportFile.WriteLine("NumberFields@Home Is a project that does research in number theory. [Learn more about NumberFields@Home by clicking here.](https://numberfields.asu.edu/NumberFields/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/numberfields@home"
                ElseIf table = "odlk1" Then
                    ReportFile.WriteLine("# ODLK1")
                    ReportFile.WriteLine("ODLK1 is a project that investigates Latin squares. [Learn more about ODLK1 by clicking here.](https://boinc.multi-pool.info/latinsquares/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/odlk1"
                ElseIf table = "primegrid" Then
                    ReportFile.WriteLine("# PrimeGrid")
                    ReportFile.WriteLine("PrimeGrid is a project that aims to find new prime numbers. [Learn more about PrimeGrid by clicking here.](http://primegrid.com/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/primegrid"
                ElseIf table = "rosettaathome" Then
                    ReportFile.WriteLine("# Rosetta@home")
                    ReportFile.WriteLine("Rosetta@home is a project that designs new proteins and predict 3rd-dimensional shapes. [Learn more about Rosetta@home by clicking here.](http://boinc.bakerlab.org/rosetta/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/rosetta@home"
                ElseIf table = "srbase" Then
                    ReportFile.WriteLine("# SRBase")
                    ReportFile.WriteLine("SRBase is a project that aims to solve Sierpinski/Riesel Bases up to 1030. [Learn more about SRBase by clicking here.](http://srbase.my-firewall.org/sr5/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/srbase"
                ElseIf table = "sourcefinder" Then
                    ReportFile.WriteLine("# Sourcefinder")
                    ReportFile.WriteLine("Sourcefinder tests the performance and quality of the Duchamp Sourcefinding application. [Learn more about Sourcefinder by clicking here.](https://sourcefinder.theskynet.org/duchamp/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/srbase"
                ElseIf table = "sdg" Then
                    ReportFile.WriteLine("# SZTAKI Desktop Grid")
                    ReportFile.WriteLine("SZTAKI Desktop Grid is a grid located at Budapest, Hungary. They run a variety of applications. [Learn more about SZTAKI Desktop Grid by clicking here.](http://szdg.lpds.sztaki.hu/szdg/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/sztaki%20desktop%20grid"
                ElseIf table = "tsnp" Then
                    ReportFile.WriteLine("# theSkyNet POGS")
                    ReportFile.WriteLine("theSkyNet POGS is a project that does research in Astronomy. [Learn more about theSkyNet POGS by clicking here.](https://pogs.theskynet.org/pogs/index.php)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/theskynet%20pogs"
                ElseIf table = "tngrid" Then
                    ReportFile.WriteLine("# TN-Grid")
                    ReportFile.WriteLine("TN-Grid is a grid located in Italy, currently running the gene@home application. [Learn more about TN-Grid by clicking here.](https://gene.disi.unitn.it/test/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/tn-grid"
                ElseIf table = "universeathome" Then
                    ReportFile.WriteLine("# Universe@Home")
                    ReportFile.WriteLine("Universe@Home is a project that researches fundamental problems of the Universe. [Learn more about Universe@Home by clicking here.](http://universeathome.pl/universe/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/universe@home"
                ElseIf table = "vgtu" Then
                    ReportFile.WriteLine("# VGTU project@Home")
                    ReportFile.WriteLine("VGTU project@Home is a project that aims to create a powerful supercomputer for scientists of VGTU and help them in their researches. [Learn more about VGTU project@Home by clicking here.](https://boinc.vgtu.lt/vtuathome/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/vgtu%20project@home"
                ElseIf table = "yafu" Then
                    ReportFile.WriteLine("# YAFU")
                    ReportFile.WriteLine("YAFU is a project that runs the YAFU software and factorizes numbers. [Learn more about YAFU by clicking here.](http://yafu.myfirewall.org/yafu/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/yafu"
                ElseIf table = "yoyo" Then
                    ReportFile.WriteLine("# yoyo@home")
                    ReportFile.WriteLine("yoyo@home is a project that acts as a wrapper of other distributed computing projects. [Learn more about yoyo@home by clicking here.](http://www.rechenkraft.net/yoyo/)" & vbCrLf)
                    ProjectMoreStatsURL = "https://gridcoinstats.eu/project/yoyo@home"
                End If
                Dim counter As Integer = 0
                Dim TableDataStream As MemoryStream = New MemoryStream
                Dim TableData As StreamWriter = New StreamWriter(TableDataStream)
                TableData.WriteLine("Name | Total Credits | Average Credit")
                TableData.WriteLine("---- | ------------- | --------------")
                While reader2.Read
                    counter = counter + 1
                    TableData.WriteLine(reader2("name") + " | " + Decimal.Round(reader2("totalcredits"), 2, MidpointRounding.AwayFromZero).ToString + " | " + Decimal.Round(reader2("average"), 2, MidpointRounding.AwayFromZero).ToString, True)
                End While
                TableData.WriteLine(vbCrLf & "More stats from this project: ")
                TableData.WriteLine("[" & ProjectMoreStatsURL.Replace(" ", "%20") & "](" & ProjectMoreStatsURL.Replace(" ", "%20") & ")")
                TableData.Flush()
                TableDataStream.Position = 0
                If counter = 1 Then
                    ReportFile.WriteLine("1 user has joined Team Gridcoin:" & vbCrLf)
                    ReportFile.WriteLine(New StreamReader(TableDataStream).ReadToEnd)
                Else
                    ReportFile.WriteLine(counter & " users have joined Team Gridcoin:" & vbCrLf)
                    ReportFile.WriteLine(New StreamReader(TableDataStream).ReadToEnd)
                End If
                TableData.Close()
                ReportFile.Close()
            End If
            Dim CurrentDateTime = Now()
            Dim RenamedXMLFile As String = table & " - " & Format(CurrentDateTime, "yyyy-MM-dd hh-mm-ss tt - ") & userxmlfile
            Dim RenamedDownloadFile As String = table & " - " & Format(CurrentDateTime, "yyyy-MM-dd hh-mm-ss tt - ") & downloadfilename
            My.Computer.FileSystem.MoveFile(userxmlfile, DateTime.Now.ToString("yyyy-MM-dd") & "\" & RenamedXMLFile)
            My.Computer.FileSystem.MoveFile(downloadfilename, DateTime.Now.ToString("yyyy-MM-dd") & "\" & RenamedDownloadFile)
        End If
    End Sub
End Class
