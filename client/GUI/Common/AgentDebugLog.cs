using System;
using System.IO;
using System.Text.Json;

namespace GUI
{
    internal static class AgentDebugLog
    {
        private static readonly string LogPath = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "debug-b928cd.log"));

        public static void Write(string hypothesisId, string location, string message, object? data = null, string runId = "pre-fix")
        {
            try
            {
                var line = JsonSerializer.Serialize(new
                {
                    sessionId = "b928cd",
                    runId,
                    hypothesisId,
                    location,
                    message,
                    data,
                    timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                });
                File.AppendAllText(LogPath, line + Environment.NewLine);
            }
            catch { /* ignore */ }
        }
    }
}
