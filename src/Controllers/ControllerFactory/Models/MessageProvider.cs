namespace ControllerFactory.Models {
    public class MessageProvider : IMessageProvider {
        public static int ExecutionCount { get; private set; }

        public string GetMessage() {
            return string.Format("I've been called {0} times.", ExecutionCount++);
        }
    }
}