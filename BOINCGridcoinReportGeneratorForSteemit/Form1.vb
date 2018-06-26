Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient

Public Class Form1

    Public MySQLString As String = ""
    Private Sub FetchAndPublish_Click(sender As Object, e As EventArgs) Handles FetchAndPublish.Click
        MainRoutine(True)
    End Sub

    Private Sub PublishOnly_Click(sender As Object, e As EventArgs) Handles PublishOnly.Click
        If My.Computer.FileSystem.FileExists(TextBox1.Text & "\report.txt") Then GenerateReport.PublishReport(DateTime.ParseExact(TextBox1.Text, "yyyy-MM-dd", Nothing)) Else MsgBox("report.txt doesn't exist.")
    End Sub

    Private Sub FetchOnly_Click(sender As Object, e As EventArgs) Handles FetchOnly.Click
        MainRoutine(False)
    End Sub
    Private Sub MainRoutine(Publish As Boolean, Optional Silent As Boolean = False)
        'Reads MySQL Config file:
        Dim MySQLFile As StreamReader = New StreamReader("MySQLConfig.txt")
        Dim currentline As String = ""
        Dim MySQLServer As String = ""
        Dim MySQLUser As String = ""
        Dim MySQLPassword As String = ""
        Dim MySQLDatabase As String = ""
        Dim MySQLSSLMode As String = ""
        While MySQLFile.EndOfStream = False
            currentline = MySQLFile.ReadLine
            If currentline.Contains("server") Then
                Dim GetServer As String() = currentline.Split("=")
                MySQLServer = GetServer(1)
            ElseIf currentline.Contains("username") Then
                Dim GetUsername As String() = currentline.Split("=")
                MySQLUser = GetUsername(1)
            ElseIf currentline.Contains("password") Then
                Dim GetPassword As String() = currentline.Split("=")
                MySQLPassword = GetPassword(1)
            ElseIf currentline.Contains("database") Then
                Dim GetDatabase As String() = currentline.Split("=")
                MySQLDatabase = GetDatabase(1)
            ElseIf currentline.Contains("sslmode") Then
                Dim GetSSLMode As String() = currentline.Split("=")
                MySQLSSLMode = GetSSLMode(1)
            End If
        End While
        MySQLString = "server=" & MySQLServer & ";user=" & MySQLUser & ";database=" & MySQLDatabase & ";port=3306;password=" & MySQLPassword & ";sslmode=" & MySQLSSLMode 
        MySQLFile.Close()
        If My.Computer.FileSystem.DirectoryExists(DateTime.Now.ToString("yyyy-MM-dd")) = False Then
            My.Computer.FileSystem.CreateDirectory(DateTime.Now.ToString("yyyy-MM-dd"))
        End If
        GenerateReport.Headers()
        If AN.Checked Then FetchData.Create("https://sech.me/boinc/Amicable/stats/user.gz", "user.gz", "amicablenumbers", "user", "1806")
        If AH.Checked Then FetchData.Create("http://asteroidsathome.net/boinc/stats/user.gz", "user.gz", "asteroidsathome", "user", "2218")
        If CSG.Checked Then FetchData.Create("https://csgrid.org/csg/stats/user.gz", "user.gz", "citizensciencegrid", "user", "154")
        If CC.Checked Then FetchData.Create("https://boinc.thesonntags.com/collatz/stats/user.gz", "user.gz", "collatzconjecture", "user", "3029")
        If DDAH.Checked Then FetchData.Create("https://boinc.drugdiscoveryathome.com/stats/user.gz", "user.gz", "ddathome", "user", "2242")
        If CatH.Checked Then FetchData.Create("https://www.cosmologyathome.org/stats/user.gz", "user.gz", "cosmologyathome", "user", "3637")
        If EatH.Checked Then FetchData.Create("https://einsteinathome.org/stats/user_id.gz", "user_id.gz", "einsteinathome", "user_id", "13630")
        If Enigma.Checked Then FetchData.Create("http://www.enigmaathome.net/stats/user.gz", "user.gz", "enigma", "user", "2937")
        If GG.Checked Then FetchData.Create("http://gpugrid.net/stats/user.gz", "user.gz", "gpugrid", "user", "3493")
        If LC.Checked Then FetchData.Create("http://boinc.gorlaeus.net/stats/user.xml.gz", "user.xml.gz", "leidenclassical", "user.xml", "1629")
        If LHCatH.Checked Then FetchData.Create("https://lhcathome.cern.ch/lhcathome/stats/user.gz", "user.gz", "lhcathomeclassic", "user", "8128")
        If MW.Checked Then FetchData.Create("http://moowrap.net/stats/user.gz", "user.gz", "moowrap", "user", "2190")
        If MatH.Checked Then FetchData.Create("https://milkyway.cs.rpi.edu/milkyway/stats/user.gz", "user.gz", "milkywayathome", "user", "6566")
        If NatH.Checked Then FetchData.Create("https://escatter11.fullerton.edu/nfs/stats/user.gz", "user.gz", "nfsathome", "user", "2353")
        If NFatH.Checked Then FetchData.Create("https://numberfields.asu.edu/NumberFields/stats/user.gz", "user.gz", "numberfieldsathome", "user", "2069")
        If ODLK1.Checked Then FetchData.Create("https://boinc.multi-pool.info/latinsquares/stats/user.gz", "user.gz", "odlk1", "user", "48")
        If PG.Checked Then FetchData.Create("http://primegrid.com/stats/user.gz", "user.gz", "primegrid", "user", "4469")
        If RatH.Checked Then FetchData.Create("http://boinc.bakerlab.org/rosetta/stats/user.gz", "user.gz", "rosettaathome", "user", "12575")
        If SatH.Checked Then FetchData.Create("http://setiathome.berkeley.edu/stats/user.gz", "user.gz", "setiathome", "user", "145340")
        If SF.Checked Then FetchData.Create("https://sourcefinder.theskynet.org/duchamp/stats/user.gz", "user.gz", "sourcefinder", "user", "19")
        If SRBase.Checked Then FetchData.Create("http://srbase.my-firewall.org/sr5/stats/user.gz", "user.gz", "srbase", "user", "99")
        If SDG.Checked Then FetchData.Create("http://szdg.lpds.sztaki.hu/szdg/stats/user.gz", "user.gz", "sdg", "user", "3502")
        If tsnp.Checked Then FetchData.Create("https://pogs.theskynet.org/pogs/stats/user.gz", "user.gz", "tsnp", "user", "2020")
        If TG.Checked Then FetchData.Create("http://gene.disi.unitn.it/test/stats/user.gz", "user.gz", "tngrid", "user", "61")
        If UH.Checked Then FetchData.Create("https://universeathome.pl/universe/stats/user.gz", "user.gz", "universeathome", "user", "1822")
        If VGTU.Checked Then FetchData.Create("https://boinc.vgtu.lt/vtuathome/stats/user.gz", "user.gz", "vgtu", "user", "1981")
        If WCG.Checked Then FetchData.Create("https://download.worldcommunitygrid.org/boinc/stats/user.xml.gz", "user.xml.gz", "worldcommunitygrid", "user.xml", "30513")
        If YAFU.Checked Then FetchData.Create("http://yafu.myfirewall.org/yafu/stats/user.gz", "user.gz", "yafu", "user", "260")
        If YH.Checked Then FetchData.Create("https://www.rechenkraft.net/yoyo/stats/user.gz", "user.gz", "yoyo", "user", "1475")
        If Publish = True Then
            GenerateReport.PublishReport(DateTime.Now, Silent)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AN.Checked = My.Settings.AN
        AH.Checked = My.Settings.AH
        CSG.Checked = My.Settings.CSG
        CC.Checked = My.Settings.CC
        DDAH.Checked = My.Settings.DDAH
        CatH.Checked = My.Settings.CatH
        EatH.Checked = My.Settings.EatH
        Enigma.Checked = My.Settings.Enigma
        GG.Checked = My.Settings.GG
        LC.Checked = My.Settings.LC
        LHCatH.Checked = My.Settings.LHCatH
        MW.Checked = My.Settings.MW
        MatH.Checked = My.Settings.MatH
        NatH.Checked = My.Settings.NatH
        NFatH.Checked = My.Settings.NFatH
        ODLK1.Checked = My.Settings.ODLK1
        PG.Checked = My.Settings.PG
        RatH.Checked = My.Settings.RatH
        SatH.Checked = My.Settings.SatH
        SF.Checked = My.Settings.SF
        SRBase.Checked = My.Settings.SRBase
        SDG.Checked = My.Settings.SDG
        tsnp.Checked = My.Settings.tsnp
        TG.Checked = My.Settings.TG
        UH.Checked = My.Settings.UH
        VGTU.Checked = My.Settings.VGTU
        WCG.Checked = My.Settings.WCG
        YAFU.Checked = My.Settings.YAFU
        YH.Checked = My.Settings.YH
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            If vars(1) = "-s" Then
                MainRoutine(True, True)
                Me.Close()
            End If
        End If
        TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub AN_CheckedChanged(sender As Object, e As EventArgs) Handles AN.CheckedChanged
        My.Settings.AN = AN.Checked
        My.Settings.Save()
    End Sub

    Private Sub AH_CheckedChanged(sender As Object, e As EventArgs) Handles AH.CheckedChanged
        My.Settings.AH = AH.Checked
        My.Settings.Save()
    End Sub

    Private Sub CSG_CheckedChanged(sender As Object, e As EventArgs) Handles CSG.CheckedChanged
        My.Settings.CSG = CSG.Checked
        My.Settings.Save()
    End Sub

    Private Sub CC_CheckedChanged(sender As Object, e As EventArgs) Handles CC.CheckedChanged
        My.Settings.CC = CC.Checked
        My.Settings.Save()
    End Sub

    Private Sub CatH_CheckedChanged(sender As Object, e As EventArgs) Handles CatH.CheckedChanged
        My.Settings.CatH = CatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub EatH_CheckedChanged(sender As Object, e As EventArgs) Handles EatH.CheckedChanged
        My.Settings.EatH = EatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub Enigma_CheckedChanged(sender As Object, e As EventArgs) Handles Enigma.CheckedChanged
        My.Settings.Enigma = Enigma.Checked
        My.Settings.Save()
    End Sub

    Private Sub GG_CheckedChanged(sender As Object, e As EventArgs) Handles GG.CheckedChanged
        My.Settings.GG = GG.Checked
        My.Settings.Save()
    End Sub
    Private Sub LC_CheckedChanged(sender As Object, e As EventArgs) Handles LC.CheckedChanged
        My.Settings.LC = LC.Checked
        My.Settings.Save()
    End Sub

    Private Sub MatH_CheckedChanged(sender As Object, e As EventArgs) Handles MatH.CheckedChanged
        My.Settings.MatH = MatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub MW_CheckedChanged(sender As Object, e As EventArgs) Handles MW.CheckedChanged
        My.Settings.MW = MW.Checked
        My.Settings.Save()
    End Sub

    Private Sub LHCatH_CheckedChanged(sender As Object, e As EventArgs) Handles LHCatH.CheckedChanged
        My.Settings.LHCatH = LHCatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub NatH_CheckedChanged(sender As Object, e As EventArgs) Handles NatH.CheckedChanged
        My.Settings.NatH = NatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub NFatH_CheckedChanged(sender As Object, e As EventArgs) Handles NFatH.CheckedChanged
        My.Settings.NFatH = NFatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub PG_CheckedChanged(sender As Object, e As EventArgs) Handles PG.CheckedChanged
        My.Settings.PG = PG.Checked
        My.Settings.Save()
    End Sub

    Private Sub RatH_CheckedChanged(sender As Object, e As EventArgs) Handles RatH.CheckedChanged
        My.Settings.RatH = RatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub SatH_CheckedChanged(sender As Object, e As EventArgs) Handles SatH.CheckedChanged
        My.Settings.SatH = SatH.Checked
        My.Settings.Save()
    End Sub

    Private Sub DDAH_CheckedChanged(sender As Object, e As EventArgs) Handles DDAH.CheckedChanged
        My.Settings.DDAH = DDAH.Checked
        My.Settings.Save()
    End Sub

    Private Sub SF_CheckedChanged(sender As Object, e As EventArgs) Handles SF.CheckedChanged
        My.Settings.SF = SF.Checked
        My.Settings.Save()
    End Sub

    Private Sub SRBase_CheckedChanged(sender As Object, e As EventArgs) Handles SRBase.CheckedChanged
        My.Settings.SRBase = SRBase.Checked
        My.Settings.Save()
    End Sub

    Private Sub SDG_CheckedChanged(sender As Object, e As EventArgs) Handles SDG.CheckedChanged
        My.Settings.SDG = SDG.Checked
        My.Settings.Save()
    End Sub

    Private Sub Tsnp_CheckedChanged(sender As Object, e As EventArgs) Handles tsnp.CheckedChanged
        My.Settings.tsnp = tsnp.Checked
        My.Settings.Save()
    End Sub

    Private Sub TG_CheckedChanged(sender As Object, e As EventArgs) Handles TG.CheckedChanged
        My.Settings.TG = TG.Checked
        My.Settings.Save()
    End Sub

    Private Sub UH_CheckedChanged(sender As Object, e As EventArgs) Handles UH.CheckedChanged
        My.Settings.UH = UH.Checked
        My.Settings.Save()
    End Sub

    Private Sub VGTU_CheckedChanged(sender As Object, e As EventArgs) Handles VGTU.CheckedChanged
        My.Settings.VGTU = VGTU.Checked
        My.Settings.Save()
    End Sub

    Private Sub WCG_CheckedChanged(sender As Object, e As EventArgs) Handles WCG.CheckedChanged
        My.Settings.WCG = WCG.Checked
        My.Settings.Save()
    End Sub

    Private Sub YAFU_CheckedChanged(sender As Object, e As EventArgs) Handles YAFU.CheckedChanged
        My.Settings.YAFU = YAFU.Checked
        My.Settings.Save()
    End Sub

    Private Sub YH_CheckedChanged(sender As Object, e As EventArgs) Handles YH.CheckedChanged
        My.Settings.YH = YH.Checked
        My.Settings.Save()
    End Sub

    Private Sub ODLK1_CheckedChanged(sender As Object, e As EventArgs) Handles ODLK1.CheckedChanged
        My.Settings.ODLK1 = ODLK1.Checked
        My.Settings.Save()
    End Sub
End Class
