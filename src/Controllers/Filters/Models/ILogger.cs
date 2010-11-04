namespace Filters.Models {
    using System.Collections.Generic;

    public interface ILogger {
        void Log(string message);
        IList<string> GetMessages();
    }
}
