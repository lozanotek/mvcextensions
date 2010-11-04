namespace Filters.Models {
    using System.Collections.Generic;

    public class Logger : ILogger {
        public static IList<string> messageList = new List<string>();

        public void Log(string message) {
            if (string.IsNullOrEmpty(message))
                return;

            messageList.Add(message);
        }

        public IList<string> GetMessages() {
            return messageList;
        }
    }
}