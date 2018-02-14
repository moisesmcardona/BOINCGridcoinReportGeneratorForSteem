Imports System.IO
Imports System.Net
Imports System.Text

Public Class GenerateReport
    Public Shared Sub Headers()
        Dim ReportFile As New System.IO.StreamWriter(DateTime.Now.ToString("yyyy-MM-dd") & "\report.txt", False)
        ReportFile.WriteLine("<center>![https://raw.githubusercontent.com/gridcoin-community/Gridcoin-Branding_Package/master/Images/gridcoin-blocks-header.png](https://raw.githubusercontent.com/gridcoin-community/Gridcoin-Branding_Package/master/Images/gridcoin-blocks-header.png)</center>" & vbCrLf)
        ReportFile.WriteLine("Hi everyone," & vbCrLf)
        ReportFile.WriteLine("This report includes new users that has joined Team Gridcoin on each project since yesterday's report. Reported here is their username, total credits, and their average credit. If a project didn't had any new user, it will not be reported here." & vbCrLf)
        ReportFile.WriteLine("Gridcoin is a decentralized cryptocurrency that rewards you for your contribution toward Science, Medicine, Math, Astronomy, and more! [Learn more about Gridcoin by clicking here and start getting rewarded for your BOINC computations now!](https://gridcoin.us)" & vbCrLf)
        ReportFile.WriteLine("The following data has been fetched directly from their respective BOINC server stats location." & vbCrLf)
        ReportFile.Close()
    End Sub
    Public Shared Sub PublishReport(DateToUse As DateTime, Optional Silent As Boolean = False)
        Dim AccountFile As StreamReader = New StreamReader("account.txt")
        Dim currentline As String = ""
        Dim Account As String = ""
        Dim Key As String = ""
        While AccountFile.EndOfStream = False
            currentline = AccountFile.ReadLine
            If currentline.Contains("account") Then
                Dim GetAccount As String() = currentline.Split("=")
                Account = GetAccount(1)
            ElseIf currentline.Contains("key") Then
                Dim GetKey As String() = currentline.Split("=")
                Key = GetKey(1)
            End If
        End While
        Try
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("https://api.steem.place/postToSteem/")
            request.Method = "POST"
            Dim postData As String = "title=New Users Statistics for Team Gridcoin - " + DateToUse.ToString("MM/dd/yyyy") + "&body=" + My.Computer.FileSystem.ReadAllText(DateToUse.ToString("yyyy-MM-dd") & "\report.txt") + "&author=" & Account & "&permlink=stats-" + DateToUse.ToString("yyyy-MM-dd") + "&tags=gridcoin,mining,stats,technology,cryptocurrency&pk=" & Key
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
            If Silent Then
                If responseFromServer.Contains("ok") Then
                    MessageBox.Show("Report has been posted successfully")
                Else
                    MessageBox.Show("An error occured while posting the report: " & Environment.NewLine & responseFromServer)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error has occurred trying to post the report.")
        End Try
    End Sub
End Class
