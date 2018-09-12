using System.Linq;

namespace WEB.ConfirmationCall.Infrastructure.Providers
{
    public class SessionProvider
    {
        private static System.Web.HttpContext SessionUser { get { return System.Web.HttpContext.Current; } }

        public static object Get(string key)
        {
            return SessionUser.Session[key];
        }

        public static void Set(string key, object data)
        {
            Invalidate(key);
            SessionUser.Session.Add(key, data);
        }

        public static bool IsSet(string key)
        {
            return SessionUser != null && SessionUser.Session != null && SessionUser.Session.Cast<object>().Any(o => (o ?? "").ToString() == key);
        }

        public static void Invalidate(string key)
        {
            if (IsSet(key))
                SessionUser.Session.Remove(key);
        }

        public static void InvalidateAll(string except = null)
        {
            if (string.IsNullOrEmpty(except))
                SessionUser.Session.RemoveAll();
            else
                while (true)
                    if (SessionUser.Session.Count > 0 && SessionUser.Session[except] == null)
                        SessionUser.Session.RemoveAt(0);
                    else
                        break;
        }

        /// <summary>
        /// Remove Objects that contains key in his name.
        /// </summary>
        /// <param name="key"></param>
        public static void InvalidateAllContains(string key)
        {
            if (SessionUser == null || SessionUser.Session == null) return;
            var lstSession = SessionUser.Session.Cast<object>().Where(o => (o ?? "").ToString().Contains(key)).ToArray();
            foreach (var session in lstSession)
                SessionUser.Session.Remove(session.ToString());
        }
    }

}
