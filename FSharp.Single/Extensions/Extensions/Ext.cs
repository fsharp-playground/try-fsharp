
namespace Extension1 {
    static class Extension {
        public static string GetFullName(this Person p) {
            return $"{p.FirstName} {p.LastName}";
        }
        public static string GetFullName(this Person p, string x) {
            return p.GetFullName();
        }
    }
}

namespace Extension2 {
    static class Extension {
        public static string GetFullName(this Person p) {
            return $"{p.FirstName} {p.LastName}";
        }
    }
}
