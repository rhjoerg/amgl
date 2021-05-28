
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace amgl.utils
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessBasicInformation
    {
        internal IntPtr Reserved1;
        internal IntPtr PebBaseAddress;
        internal IntPtr Reserved2_0;
        internal IntPtr Reserved2_1;
        internal IntPtr UniqueProcessId;
        internal IntPtr InheritedFromUniqueProcessId;
    }

    public class Processes
    {
        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass,
            ref ProcessBasicInformation processInformation, int processInformationLength, out int returnLength);

        public static Process GetParentProcess()
        {
            return GetParentProcess(Process.GetCurrentProcess().Handle);
        }

        public static Process GetParentProcess(int id)
        {
            Process process = Process.GetProcessById(id);

            return GetParentProcess(process.Handle);
        }

        public static Process GetParentProcess(IntPtr handle)
        {
            ProcessBasicInformation pbi = new ProcessBasicInformation();
            int returnLength;

            int status = NtQueryInformationProcess(handle, 0, ref pbi, Marshal.SizeOf(pbi), out returnLength);

            if (status != 0)
                throw new Win32Exception(status);

            try
            {
                return Process.GetProcessById(pbi.InheritedFromUniqueProcessId.ToInt32());
            }
            catch
            {
                return null;
            }
        }

        public static Process Start(string exe, string args, bool visible)
        {
            Process process = new Process();

            process.StartInfo.FileName = exe;
            process.StartInfo.WorkingDirectory = Files.InstallDir;
            process.StartInfo.Arguments = args;
            process.StartInfo.WindowStyle = visible ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
            process.Start();

            return process;
        }

        public static void Run(string exe, string args, bool visible)
        {
            using (Process process = Start(exe, args, visible))
            {
                process.WaitForExit();
            }
        }
    }
}