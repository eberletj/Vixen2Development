Imports System.Net.Sockets
Imports Vixen
Imports System.Xml
Imports System.IO.Ports
Imports System.Net

Public Class Lynx_EtherDongle
    Implements IEventDrivenOutputPlugIn


    Public Shared WORKVAL As Byte
    Public Shared VALUE As Byte
    Public Shared Universe As Byte(,)
    Public Shared univcount As Integer
    Private udpClient As UdpClient
    Public Shared topchannel As Integer
    Public Shared temp2 As Integer
    Public Shared temp1 As Integer
    Public Shared startc As Integer
    Private Shared SetupDialog As SerialData
    Public Shared ready As Integer
    Public Shared PREVVAL As Byte
    Public Shared POS As Integer
    Public Shared portn As String
    Public Shared pnum As Integer
    Public Shared OUTWRITE As Byte()
    Public Shared OUTPUTVALS As Byte()
    Public Shared outputstring As String
    Public Shared outpos As Integer
    Public Shared msgst As String
    Private Shared LSetupNode As XmlNode
    Private Shared LSetupdata As SetupData
    Public Shared ipstring As String
    Private GLOIP As IPAddress
    Private GLOINTPORT As Integer
    Public Shared endc As Integer
    Public Shared COUNT As Integer
    Private comport As SerialPort
    Public Shared channelcount As Integer
    Public Shared CHAN As Integer
    Private bytCommand As Byte()
    Public Shared baudr As Integer

    Public Sub New()
        Me.comport = New SerialPort()
        Me.udpClient = New UdpClient()
        Me.bytCommand = New Byte(0 - 1) {}
    End Sub

    Shared Sub New()
        Lynx_EtherDongle.OUTPUTVALS = New Byte(639 - 1) {}
        Lynx_EtherDongle.OUTWRITE = New Byte(640 - 1) {}
        Lynx_EtherDongle.Universe = New Byte(34 - 1, 640 - 1) {}
        Lynx_EtherDongle.LSetupdata = New SetupData()
    End Sub

    Public Sub [Event](channelValues As Byte()) Implements IEventDrivenOutputPlugIn.Event
        ' The following expression was wrapped in a checked-statement

        Lynx_EtherDongle.outpos = Lynx_EtherDongle.endc - 1
        Lynx_EtherDongle.temp1 = CInt(Math.Round(Conversion.Int(CDec((Lynx_EtherDongle.outpos + 1)) / 512.0)))
        Lynx_EtherDongle.temp2 = Lynx_EtherDongle.outpos - Lynx_EtherDongle.temp1 * 512 + 1
        If Lynx_EtherDongle.temp2 > 0 Then
            Lynx_EtherDongle.temp1 += 1
            Lynx_EtherDongle.topchannel = Lynx_EtherDongle.temp2
        Else
            Lynx_EtherDongle.topchannel = 512
        End If
        Lynx_EtherDongle.univcount = Lynx_EtherDongle.temp1
        Dim arg_82_0 As Integer = 1
        Dim num As Integer = Lynx_EtherDongle.univcount
        Dim i As Integer = arg_82_0
        While i <= num
            Lynx_EtherDongle.OUTWRITE(114) = CByte(i)
            Lynx_EtherDongle.ipstring = "239.255.0." + i.ToString()
            Me.GLOIP = IPAddress.Parse(Lynx_EtherDongle.ipstring)
            Lynx_EtherDongle.channelcount = 637
            If i < Lynx_EtherDongle.univcount Then
                Try
                    Lynx_EtherDongle.CHAN = 126
                    Do
                        Lynx_EtherDongle.OUTWRITE(Lynx_EtherDongle.CHAN) = channelValues((i - 1) * 512 + (Lynx_EtherDongle.CHAN - 126))
                        Lynx_EtherDongle.CHAN += 1
                    Loop While Lynx_EtherDongle.CHAN <= 638

                    Me.SendMessage(Me.GLOIP)
                    i += 1
                    Continue While
                Catch expr_10D As Exception
                    ProjectData.SetProjectError(expr_10D)
                    ProjectData.ClearProjectError()

                    Me.SendMessage(Me.GLOIP)
                    i += 1
                    Continue While
                End Try
            Else
                Try

                    Dim arg_12A_0 As Integer = 126
                    Dim num2 As Integer = Lynx_EtherDongle.topchannel + 126
                    Lynx_EtherDongle.CHAN = arg_12A_0
                    While Lynx_EtherDongle.CHAN <= num2
                        Lynx_EtherDongle.OUTWRITE(Lynx_EtherDongle.CHAN) = channelValues((i - 1) * 512 - 1 + (Lynx_EtherDongle.CHAN - 126))
                        Lynx_EtherDongle.CHAN += 1
                    End While
                Catch expr_169 As Exception
                    ProjectData.SetProjectError(expr_169)
                    ProjectData.ClearProjectError()
                End Try
                Try
                    For j As Integer = Lynx_EtherDongle.topchannel + 126 To 638
                        Lynx_EtherDongle.OUTWRITE(j) = 0
                    Next
                Catch expr_198 As Exception
                    ProjectData.SetProjectError(expr_198)
                    ProjectData.ClearProjectError()

                    Me.SendMessage(Me.GLOIP)
                    i += 1
                    Continue While
                End Try
            End If



        End While
    End Sub

    Public Sub Initialize(executableObject As IExecutable, setupData As SetupData, setupNode As XmlNode) Implements IEventDrivenOutputPlugIn.Initialize

        Lynx_EtherDongle.pnum = 0
        Lynx_EtherDongle.ready = 0
        Lynx_EtherDongle.LSetupNode = setupNode
        Lynx_EtherDongle.LSetupdata = setupData
        Lynx_EtherDongle.startc = Conversions.ToInteger(Lynx_EtherDongle.LSetupNode.Attributes("from").Value)
        Lynx_EtherDongle.endc = Conversions.ToInteger(Lynx_EtherDongle.LSetupNode.Attributes("to").Value)
        Dim num As Integer = 0
        ' The following expression was wrapped in a checked-statement
        Do
            Lynx_EtherDongle.OUTWRITE(num) = 0
            num += 1
        Loop While num <= 630
        Lynx_EtherDongle.OUTWRITE(0) = 0
        Lynx_EtherDongle.OUTWRITE(1) = 16
        Lynx_EtherDongle.OUTWRITE(2) = 0
        Lynx_EtherDongle.OUTWRITE(3) = 0
        Lynx_EtherDongle.OUTWRITE(4) = 65
        Lynx_EtherDongle.OUTWRITE(5) = 83
        Lynx_EtherDongle.OUTWRITE(6) = 67
        Lynx_EtherDongle.OUTWRITE(7) = 45
        Lynx_EtherDongle.OUTWRITE(8) = 69
        Lynx_EtherDongle.OUTWRITE(9) = 49
        Lynx_EtherDongle.OUTWRITE(10) = 46
        Lynx_EtherDongle.OUTWRITE(11) = 49
        Lynx_EtherDongle.OUTWRITE(12) = 55
        Lynx_EtherDongle.OUTWRITE(13) = 0
        Lynx_EtherDongle.OUTWRITE(14) = 0
        Lynx_EtherDongle.OUTWRITE(15) = 0
        Lynx_EtherDongle.OUTWRITE(16) = 114
        Lynx_EtherDongle.OUTWRITE(17) = 110
        Lynx_EtherDongle.OUTWRITE(18) = 0
        Lynx_EtherDongle.OUTWRITE(19) = 0
        Lynx_EtherDongle.OUTWRITE(20) = 0
        Lynx_EtherDongle.OUTWRITE(21) = 4
        Lynx_EtherDongle.OUTWRITE(22) = 49
        Lynx_EtherDongle.OUTWRITE(23) = 32
        Lynx_EtherDongle.OUTWRITE(24) = 79
        Lynx_EtherDongle.OUTWRITE(25) = 92
        Lynx_EtherDongle.OUTWRITE(26) = 43
        Lynx_EtherDongle.OUTWRITE(27) = 169
        Lynx_EtherDongle.OUTWRITE(28) = 15
        Lynx_EtherDongle.OUTWRITE(29) = 72
        Lynx_EtherDongle.OUTWRITE(30) = 156
        Lynx_EtherDongle.OUTWRITE(31) = 2
        Lynx_EtherDongle.OUTWRITE(32) = 254
        Lynx_EtherDongle.OUTWRITE(33) = 221
        Lynx_EtherDongle.OUTWRITE(34) = 242
        Lynx_EtherDongle.OUTWRITE(35) = 221
        Lynx_EtherDongle.OUTWRITE(36) = 177
        Lynx_EtherDongle.OUTWRITE(37) = 231
        Lynx_EtherDongle.OUTWRITE(38) = 114
        Lynx_EtherDongle.OUTWRITE(39) = 88
        Lynx_EtherDongle.OUTWRITE(40) = 0
        Lynx_EtherDongle.OUTWRITE(41) = 0
        Lynx_EtherDongle.OUTWRITE(42) = 0
        Lynx_EtherDongle.OUTWRITE(43) = 2
        Lynx_EtherDongle.OUTWRITE(108) = 100
        Lynx_EtherDongle.OUTWRITE(113) = 0
        Lynx_EtherDongle.OUTWRITE(114) = 1
        Lynx_EtherDongle.OUTWRITE(115) = 114
        Lynx_EtherDongle.OUTWRITE(116) = 11
        Lynx_EtherDongle.OUTWRITE(117) = 2
        Lynx_EtherDongle.OUTWRITE(118) = 161
        Lynx_EtherDongle.OUTWRITE(122) = 1
        Lynx_EtherDongle.OUTWRITE(123) = 2
        Lynx_EtherDongle.OUTWRITE(124) = 1
        Lynx_EtherDongle.OUTWRITE(44) = 80
        Lynx_EtherDongle.OUTWRITE(45) = 73
        Lynx_EtherDongle.OUTWRITE(46) = 88
        Lynx_EtherDongle.OUTWRITE(47) = 69
        Lynx_EtherDongle.OUTWRITE(48) = 76
        Lynx_EtherDongle.OUTWRITE(49) = 78
        Lynx_EtherDongle.OUTWRITE(50) = 69
        Lynx_EtherDongle.OUTWRITE(51) = 84
        Lynx_EtherDongle.OUTWRITE(52) = 0
        Lynx_EtherDongle.OUTWRITE(53) = 69
        Lynx_EtherDongle.OUTWRITE(54) = 84
        Lynx_EtherDongle.OUTWRITE(55) = 72
        Lynx_EtherDongle.OUTWRITE(56) = 69
        Lynx_EtherDongle.OUTWRITE(57) = 82
        Lynx_EtherDongle.OUTWRITE(58) = 68
        Lynx_EtherDongle.OUTWRITE(59) = 79
        Lynx_EtherDongle.OUTWRITE(60) = 78
        Lynx_EtherDongle.OUTWRITE(61) = 71
        Lynx_EtherDongle.OUTWRITE(62) = 76
        Lynx_EtherDongle.OUTWRITE(63) = 69
        Dim num2 As Integer = 0
        Do
            num = 0
            Do
                Lynx_EtherDongle.Universe(num2, num) = Lynx_EtherDongle.OUTWRITE(num)
                num += 1
            Loop While num <= 630
            num2 += 1
        Loop While num2 <= 32
        num2 = 0
        Do
            Lynx_EtherDongle.Universe(num2, 114) = CByte(num2)
            num2 += 1
        Loop While num2 <= 32
        Me.udpClient.Ttl = 1
    End Sub

    Public Sub SendMessage(ToIP As IPAddress)
        Me.GLOIP = ToIP
        Me.GLOINTPORT = 5568
        Me.udpClient.Connect(Me.GLOIP, Me.GLOINTPORT)
        Dim num As Integer = Me.udpClient.Send(Lynx_EtherDongle.OUTWRITE, 638)
    End Sub

    Public Sub Setup() Implements ISetup.Setup
    End Sub

    Public Sub Shutdown() Implements IHardwarePlugin.Shutdown
    End Sub

    Public Sub Startup() Implements IHardwarePlugin.Startup
        Application.DoEvents()
        Dim num As Integer = 0
        ' The following expression was wrapped in a checked-statement
        Do
            Lynx_EtherDongle.OUTWRITE(num) = 0
            num += 1
        Loop While num <= 630
        Lynx_EtherDongle.OUTWRITE(0) = 0
        Lynx_EtherDongle.OUTWRITE(1) = 16
        Lynx_EtherDongle.OUTWRITE(2) = 0
        Lynx_EtherDongle.OUTWRITE(3) = 0
        Lynx_EtherDongle.OUTWRITE(4) = 65
        Lynx_EtherDongle.OUTWRITE(5) = 83
        Lynx_EtherDongle.OUTWRITE(6) = 67
        Lynx_EtherDongle.OUTWRITE(7) = 45
        Lynx_EtherDongle.OUTWRITE(8) = 69
        Lynx_EtherDongle.OUTWRITE(9) = 49
        Lynx_EtherDongle.OUTWRITE(10) = 46
        Lynx_EtherDongle.OUTWRITE(11) = 49
        Lynx_EtherDongle.OUTWRITE(12) = 55
        Lynx_EtherDongle.OUTWRITE(13) = 0
        Lynx_EtherDongle.OUTWRITE(14) = 0
        Lynx_EtherDongle.OUTWRITE(15) = 0
        Lynx_EtherDongle.OUTWRITE(16) = 114
        Lynx_EtherDongle.OUTWRITE(17) = 110
        Lynx_EtherDongle.OUTWRITE(18) = 0
        Lynx_EtherDongle.OUTWRITE(19) = 0
        Lynx_EtherDongle.OUTWRITE(20) = 0
        Lynx_EtherDongle.OUTWRITE(21) = 4
        Lynx_EtherDongle.OUTWRITE(22) = 49
        Lynx_EtherDongle.OUTWRITE(23) = 32
        Lynx_EtherDongle.OUTWRITE(24) = 79
        Lynx_EtherDongle.OUTWRITE(25) = 92
        Lynx_EtherDongle.OUTWRITE(26) = 43
        Lynx_EtherDongle.OUTWRITE(27) = 169
        Lynx_EtherDongle.OUTWRITE(28) = 15
        Lynx_EtherDongle.OUTWRITE(29) = 72
        Lynx_EtherDongle.OUTWRITE(30) = 156
        Lynx_EtherDongle.OUTWRITE(31) = 2
        Lynx_EtherDongle.OUTWRITE(32) = 254
        Lynx_EtherDongle.OUTWRITE(33) = 221
        Lynx_EtherDongle.OUTWRITE(34) = 242
        Lynx_EtherDongle.OUTWRITE(35) = 221
        Lynx_EtherDongle.OUTWRITE(36) = 177
        Lynx_EtherDongle.OUTWRITE(37) = 231
        Lynx_EtherDongle.OUTWRITE(38) = 114
        Lynx_EtherDongle.OUTWRITE(39) = 88
        Lynx_EtherDongle.OUTWRITE(40) = 0
        Lynx_EtherDongle.OUTWRITE(41) = 0
        Lynx_EtherDongle.OUTWRITE(42) = 0
        Lynx_EtherDongle.OUTWRITE(43) = 2
        Lynx_EtherDongle.OUTWRITE(108) = 100
        Lynx_EtherDongle.OUTWRITE(113) = 0
        Lynx_EtherDongle.OUTWRITE(114) = 1
        Lynx_EtherDongle.OUTWRITE(115) = 114
        Lynx_EtherDongle.OUTWRITE(116) = 11
        Lynx_EtherDongle.OUTWRITE(117) = 2
        Lynx_EtherDongle.OUTWRITE(118) = 161
        Lynx_EtherDongle.OUTWRITE(122) = 1
        Lynx_EtherDongle.OUTWRITE(123) = 2
        Lynx_EtherDongle.OUTWRITE(124) = 1
        Lynx_EtherDongle.OUTWRITE(44) = 80
        Lynx_EtherDongle.OUTWRITE(45) = 73
        Lynx_EtherDongle.OUTWRITE(46) = 88
        Lynx_EtherDongle.OUTWRITE(47) = 69
        Lynx_EtherDongle.OUTWRITE(48) = 76
        Lynx_EtherDongle.OUTWRITE(49) = 78
        Lynx_EtherDongle.OUTWRITE(50) = 69
        Lynx_EtherDongle.OUTWRITE(51) = 84
        Lynx_EtherDongle.OUTWRITE(52) = 0
        Lynx_EtherDongle.OUTWRITE(53) = 69
        Lynx_EtherDongle.OUTWRITE(54) = 84
        Lynx_EtherDongle.OUTWRITE(55) = 72
        Lynx_EtherDongle.OUTWRITE(56) = 69
        Lynx_EtherDongle.OUTWRITE(57) = 82
        Lynx_EtherDongle.OUTWRITE(58) = 68
        Lynx_EtherDongle.OUTWRITE(59) = 79
        Lynx_EtherDongle.OUTWRITE(60) = 78
        Lynx_EtherDongle.OUTWRITE(61) = 71
        Lynx_EtherDongle.OUTWRITE(62) = 76
        Lynx_EtherDongle.OUTWRITE(63) = 69
        Dim num2 As Integer = 0
        Do
            num = 0
            Do
                Lynx_EtherDongle.Universe(num2, num) = Lynx_EtherDongle.OUTWRITE(num)
                num += 1
            Loop While num <= 630
            num2 += 1
        Loop While num2 <= 32
        num2 = 0
        Do
            Lynx_EtherDongle.Universe(num2, 114) = CByte(num2)
            num2 += 1
        Loop While num2 <= 32
        Me.udpClient.Ttl = 1

    End Sub

    Public Overrides Function ToString() As String Implements IPlugIn.ToString
        Return ""
    End Function


    Public ReadOnly Property Author() As String Implements IPlugIn.Author
        Get
            Return "Robert Jordan"
        End Get
    End Property

    Public ReadOnly Property Description() As String Implements IPlugIn.Description

        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property HardwareMap() As HardwareMap() Implements IHardwarePlugin.HardwareMap
        Get
            Return New HardwareMap() {New HardwareMap("Serial", 1)}
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements IPlugIn.Name
        Get
            Return "EtherDongle"
        End Get
    End Property

End Class
