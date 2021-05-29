using amgl.utils;
using System;

namespace amgl.model
{
    public class Status
    {
        public enum StateEnum
        {
            Cancelled,
            Error,
            Ready,
            InstallationRequired,
            Verifying,
        }

        public readonly string InstallDir = Files.InstallDir;
        public readonly StateEnum State;
        public readonly double Progress;
        public readonly string Message;

        private Status(StateEnum state, double progress, string message)
        {
            State = state;
            Progress = progress;
            Message = message;
        }

        private Status(StateEnum state, double progress)
        {
            State = state;
            Progress = progress;
            Message = "";
        }

        public static Status Cancelled()
        {
            return new Status(StateEnum.Cancelled, 0);
        }

        public static Status Error(string message)
        {
            return new Status(StateEnum.Error, 0, message);
        }

        public static Status Verifying(double progress)
        {
            return new Status(StateEnum.Verifying, progress);
        }
        public static Status Ready()
        {
            return new Status(StateEnum.Ready, 1);
        }

        public static Status InstallationRequired()
        {
            return new Status(StateEnum.InstallationRequired, 0);
        }
    }
}
