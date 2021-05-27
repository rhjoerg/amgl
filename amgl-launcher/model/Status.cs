
namespace amgl.model
{
    public class Status
    {
        public delegate void ChangedHandler();

        public static event ChangedHandler Changed;

        private static bool updateRequired = false;

        public static bool UpdateRequired
        {
            get { return updateRequired; }
        }

        public static void Update(bool updateRequired)
        {
            Status.updateRequired = updateRequired;
            Status.Changed.Invoke();
        }
    }
}
