using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlitterApi.Session
{
    public class Session
    {
       // public static List<int> SessionList = new List<int>();
        public static Dictionary<string, int> Guid = new Dictionary<string, int>();

        public string CreateSession(int id) {
            if (Guid.ContainsValue(id)) {
                return null;
            }
            string key = System.Guid.NewGuid().ToString().Replace("-", "");
                Guid.Add(key, id);
                return key;
                        
        }

        public static bool Validate(string SessionId) {

            if (Guid.ContainsKey(SessionId)) {
                return true;
            }
           
            return false;
        }

        public bool DestroySession(string SessionId) {
            if (Guid.ContainsKey(SessionId)) {
                Guid.Remove(SessionId);
                return true;
            }
            return false;

        }

    }
}