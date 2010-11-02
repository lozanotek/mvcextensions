namespace Mvc {
    public static class StringExt {
        public static int ToInt32(this string value) {
            return int.Parse(value);
        }
    }
}