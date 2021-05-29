using amgl.utils;
using System;

namespace amgl.model
{
    public class Status
    {
        public enum StateEnum
        {
            Cancelled,
            Verifying,
            Ready,
        }

        public readonly string InstallDir = Files.InstallDir;
        public readonly StateEnum State;
        public readonly double Progress;

        private Status(StateEnum state, double progress)
        {
            State = state;
            Progress = progress;
        }

        public static Status Cancelled()
        {
            return new Status(StateEnum.Cancelled, 1);
        }

        public static Status Verifying(double progress)
        {
            return new Status(StateEnum.Verifying, progress);
        }
        public static Status Ready()
        {
            return new Status(StateEnum.Ready, 1);
        }
    }
}
