using System;
using MakotoStudio.Logger.Constant;

namespace MakotoStudio.Logger.Utils {
	public static class LogTypeMapper {
		public static UnityEngine.LogType GetUnityLogType(MsLogType msLogType) => msLogType switch {
			MsLogType.Error => UnityEngine.LogType.Error,
			MsLogType.Assert => UnityEngine.LogType.Assert,
			MsLogType.Warning => UnityEngine.LogType.Warning,
			MsLogType.Info => UnityEngine.LogType.Log,
			MsLogType.Exception => UnityEngine.LogType.Exception,
			_ => throw new ArgumentOutOfRangeException(nameof(msLogType), msLogType, "LogType parsing failed")
		};

		public static MsLogType GetMakotoLogType(UnityEngine.LogType logType) => logType switch {
			UnityEngine.LogType.Error => MsLogType.Error,
			UnityEngine.LogType.Assert => MsLogType.Assert,
			UnityEngine.LogType.Warning => MsLogType.Warning,
			UnityEngine.LogType.Log => MsLogType.Info,
			UnityEngine.LogType.Exception => MsLogType.Exception,
			_ => throw new ArgumentOutOfRangeException(nameof(logType), logType, "LogType LogType parsing failed")
		};
	}
}