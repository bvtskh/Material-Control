using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class SystemSettings
    {
        public static string path = @"SOFTWARE\Material_System\Configs";

        public static class KeyName
        {
            public static string DefaultScreen = "DefaultScreen";
        }
        public class Port
        {
            public static string PortName = "COM1";
            public static int BaudRate { get; set; }
            public Port()
            {
                PortName = "COM1";
                BaudRate = 9600;
            }
        }
        public class Option
        {
            public static string ProcessName;
            public static int SleepTime = 300;
            public static string SignalOK = "#OK*";
            public static string SignalNG = "#NG*";
        }
        public static void Read()
        {
            var value = Ultils.GetValueRegistryKey(path, "PortName");
            if (value != null)
            {
                Port.PortName = value;
            }
            value = Ultils.GetValueRegistryKey(path, "BaudRate");
            int baudRate = 0;
            if (!int.TryParse(value, out baudRate))
            {
                baudRate = 9600;
            }
            Port.BaudRate = baudRate;
            value = Ultils.GetValueRegistryKey(path, "Process");
            if (value != null)
            {
                Option.ProcessName = value;
            }
            //  Option.SleepTime = Convert.ToInt32(Ultils.GetValueRegistryKey("SleepTime"));
            value = Ultils.GetValueRegistryKey(path, "SignalOK");
            if (value != null)
            {
                Option.SignalOK = value;
            }
            value = Ultils.GetValueRegistryKey(path, "SignalNG");
            if (value != null)
            {
                Option.SignalNG = value;
            }
        }
        public static void Write()
        {
            Ultils.WriteRegistry(path, "PortName", Port.PortName);
            Ultils.WriteRegistry(path, "SignalOK", Option.SignalOK);
            Ultils.WriteRegistry(path, "SignalNG", Option.SignalNG);
        }

    }
}
