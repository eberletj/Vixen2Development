using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using Vixen;

public class LynxEtherDongle : IEventDrivenOutputPlugIn
{
    public static byte[] Outputvals = new byte[639];
    public static byte[] Outwrite = new byte[640];
    public static byte[,] Universe = new byte[34, 640];
    private static SetupData _lSetupdata = new SetupData();
    public static byte Workval;
    public static byte Prevval;
    public static int Chan;
    public static int Pos;
    public static int Count;
    public static int Baudr;
    public static string Portn;
    public static int Ready;
    public static int Pnum;
    public static int Univcount;
    public static int Temp1;
    public static int Temp2;
    public static int Topchannel;
    public static int Channelcount;
    public static int Startc;
    public static int Endc;
    public static byte Value;
    public static int Outpos;
    public static string Outputstring;
    public static string Ipstring;
    public static string Msgst;
    private static SerialData _setupDialog;
    private static XmlNode _lSetupNode;
    private SerialPort _comport;
    private UdpClient _udpClient;
    private IPAddress _gloip;
    private int _glointport;
    private byte[] _bytCommand;

    public HardwareMap[] HardwareMap
    {
        get
        {
            return new []
      {
        new HardwareMap("Serial", 1)
      };
        }
    }

    public string Author
    {
        get
        {
            return "Robert Jordan";
        }
    }

    public string Description
    {
        get
        {
            return "";
        }
    }

    public string Name
    {
        get
        {
            return "EtherDongle";
        }
    }

    public LynxEtherDongle()
    {
        _comport = new SerialPort();
        _udpClient = new UdpClient();
        _bytCommand = new byte[0];
    }

    public void Event(byte[] channelValues)
    {
        Outpos = checked(Endc - 1);
        Temp1 = checked((int)Math.Round(Conversion.Int(unchecked(checked(Outpos + 1) / 512.0))));
        Temp2 = checked(Outpos - Temp1 * 512 + 1);
        if (Temp2 > 0)
        {
            checked { ++Temp1; }
            Topchannel = Temp2;
        }
        else
            Topchannel = 512;
        Univcount = Temp1;
        int num1 = 1;
        int num2 = Univcount;
        int num3 = num1;
        while (num3 <= num2)
        {
            Outwrite[114] = checked((byte)num3);
            Ipstring = "239.255.0." + num3.ToString();
            _gloip = IPAddress.Parse(Ipstring);
            Channelcount = 637;
            if (num3 < Univcount)
            {
                try
                {
                    Chan = 126;
                    do
                    {
                        Outwrite[Chan] = channelValues[checked((num3 - 1) * 512 + Chan - 126)];
                        checked { ++Chan; }
                    }
                    while (Chan <= 638);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
            }
            else
            {
                try
                {
                    int num4 = 126;
                    int num5 = checked(Topchannel + 126);
                    Chan = num4;
                    while (Chan <= num5)
                    {
                        Outwrite[Chan] = channelValues[checked((num3 - 1) * 512 - 1 + Chan - 126)];
                        checked { ++Chan; }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
                try
                {
                    int index = checked(Topchannel + 126);
                    while (index <= 638)
                    {
                        Outwrite[index] = 0;
                        checked { ++index; }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
            }
            SendMessage(_gloip);
            checked { ++num3; }
        }
    }

    public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode)
    {
        Pnum = 0;
        Ready = 0;
        _lSetupNode = setupNode;
        _lSetupdata = setupData;
        Startc = Conversions.ToInteger(_lSetupNode.Attributes["from"].Value);
        Endc = Conversions.ToInteger(_lSetupNode.Attributes["to"].Value);
        int index1 = 0;
        do
        {
            Outwrite[index1] = 0;
            checked { ++index1; }
        }
        while (index1 <= 630);
        Outwrite[0] = 0;
        Outwrite[1] = 16;
        Outwrite[2] = 0;
        Outwrite[3] = 0;
        Outwrite[4] = 65;
        Outwrite[5] = 83;
        Outwrite[6] = 67;
        Outwrite[7] = 45;
        Outwrite[8] = 69;
        Outwrite[9] = 49;
        Outwrite[10] = 46;
        Outwrite[11] = 49;
        Outwrite[12] = 55;
        Outwrite[13] = 0;
        Outwrite[14] = 0;
        Outwrite[15] = 0;
        Outwrite[16] = 114;
        Outwrite[17] = 110;
        Outwrite[18] = 0;
        Outwrite[19] = 0;
        Outwrite[20] = 0;
        Outwrite[21] = 4;
        Outwrite[22] = 49;
        Outwrite[23] = 32;
        Outwrite[24] = 79;
        Outwrite[25] = 92;
        Outwrite[26] = 43;
        Outwrite[27] = 169;
        Outwrite[28] = 15;
        Outwrite[29] = 72;
        Outwrite[30] = 156;
        Outwrite[31] = 2;
        Outwrite[32] = 254;
        Outwrite[33] = 221;
        Outwrite[34] = 242;
        Outwrite[35] = 221;
        Outwrite[36] = 177;
        Outwrite[37] = 231;
        Outwrite[38] = 114;
        Outwrite[39] = 88;
        Outwrite[40] = 0;
        Outwrite[41] = 0;
        Outwrite[42] = 0;
        Outwrite[43] = 2;
        Outwrite[108] = 100;
        Outwrite[113] = 0;
        Outwrite[114] = 1;
        Outwrite[115] = 114;
        Outwrite[116] = 11;
        Outwrite[117] = 2;
        Outwrite[118] = 161;
        Outwrite[122] = 1;
        Outwrite[123] = 2;
        Outwrite[124] = 1;
        Outwrite[44] = 80;
        Outwrite[45] = 73;
        Outwrite[46] = 88;
        Outwrite[47] = 69;
        Outwrite[48] = 76;
        Outwrite[49] = 78;
        Outwrite[50] = 69;
        Outwrite[51] = 84;
        Outwrite[52] = 0;
        Outwrite[53] = 69;
        Outwrite[54] = 84;
        Outwrite[55] = 72;
        Outwrite[56] = 69;
        Outwrite[57] = 82;
        Outwrite[58] = 68;
        Outwrite[59] = 79;
        Outwrite[60] = 78;
        Outwrite[61] = 71;
        Outwrite[62] = 76;
        Outwrite[63] = 69;
        int index2 = 0;
        do
        {
            int index3 = 0;
            do
            {
                Universe[index2, index3] = Outwrite[index3];
                checked { ++index3; }
            }
            while (index3 <= 630);
            checked { ++index2; }
        }
        while (index2 <= 32);
        int index4 = 0;
        do
        {
            Universe[index4, 114] = checked((byte)index4);
            checked { ++index4; }
        }
        while (index4 <= 32);
        _udpClient.Ttl = 1;
    }

    public void Startup()
    {
        Application.DoEvents();
        int index1 = 0;
        do
        {
            Outwrite[index1] = 0;
            checked { ++index1; }
        }
        while (index1 <= 630);
        Outwrite[0] = 0;
        Outwrite[1] = 16;
        Outwrite[2] = 0;
        Outwrite[3] = 0;
        Outwrite[4] = 65;
        Outwrite[5] = 83;
        Outwrite[6] = 67;
        Outwrite[7] = 45;
        Outwrite[8] = 69;
        Outwrite[9] = 49;
        Outwrite[10] = 46;
        Outwrite[11] = 49;
        Outwrite[12] = 55;
        Outwrite[13] = 0;
        Outwrite[14] = 0;
        Outwrite[15] = 0;
        Outwrite[16] = 114;
        Outwrite[17] = 110;
        Outwrite[18] = 0;
        Outwrite[19] = 0;
        Outwrite[20] = 0;
        Outwrite[21] = 4;
        Outwrite[22] = 49;
        Outwrite[23] = 32;
        Outwrite[24] = 79;
        Outwrite[25] = 92;
        Outwrite[26] = 43;
        Outwrite[27] = 169;
        Outwrite[28] = 15;
        Outwrite[29] = 72;
        Outwrite[30] = 156;
        Outwrite[31] = 2;
        Outwrite[32] = 254;
        Outwrite[33] = 221;
        Outwrite[34] = 242;
        Outwrite[35] = 221;
        Outwrite[36] = 177;
        Outwrite[37] = 231;
        Outwrite[38] = 114;
        Outwrite[39] = 88;
        Outwrite[40] = 0;
        Outwrite[41] = 0;
        Outwrite[42] = 0;
        Outwrite[43] = 2;
        Outwrite[108] = 100;
        Outwrite[113] = 0;
        Outwrite[114] = 1;
        Outwrite[115] = 114;
        Outwrite[116] = 11;
        Outwrite[117] = 2;
        Outwrite[118] = 161;
        Outwrite[122] = 1;
        Outwrite[123] = 2;
        Outwrite[124] = 1;
        Outwrite[44] = 80;
        Outwrite[45] = 73;
        Outwrite[46] = 88;
        Outwrite[47] = 69;
        Outwrite[48] = 76;
        Outwrite[49] = 78;
        Outwrite[50] = 69;
        Outwrite[51] = 84;
        Outwrite[52] = 0;
        Outwrite[53] = 69;
        Outwrite[54] = 84;
        Outwrite[55] = 72;
        Outwrite[56] = 69;
        Outwrite[57] = 82;
        Outwrite[58] = 68;
        Outwrite[59] = 79;
        Outwrite[60] = 78;
        Outwrite[61] = 71;
        Outwrite[62] = 76;
        Outwrite[63] = 69;
        int index2 = 0;
        do
        {
            int index3 = 0;
            do
            {
                Universe[index2, index3] = Outwrite[index3];
                checked { ++index3; }
            }
            while (index3 <= 630);
            checked { ++index2; }
        }
        while (index2 <= 32);
        int index4 = 0;
        do
        {
            Universe[index4, 114] = checked((byte)index4);
            checked { ++index4; }
        }
        while (index4 <= 32);
        _udpClient.Ttl = 1;

    }

    public void Setup()
    {
    }

    public void SendMessage(IPAddress toIp)
    {
        _gloip = toIp;
        _glointport = 5568;
        _udpClient.Connect(_gloip, _glointport);
        _udpClient.Send(Outwrite, 638);
    }

    public void Shutdown()
    {
    }

    public string ToString1()
    {
        return "";
    }

    public string ToString2()
    {
        return "";
    }
}