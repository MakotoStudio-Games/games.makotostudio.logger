using System;
using System.IO;
using MakotoStudio.Logger.Interfaces;
using MakotoStudio.Logger.Constant;
using MakotoStudio.Logger.Utils;
using ILogHandler = UnityEngine.ILogHandler;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace MakotoStudio.Logger.Core {
	/// <summary>
	///		<para>Default MakotoLogFileHandler</para>
	/// </summary>
	public class MakotoLogFileHandler : IMakotoLogHandler {
		/// <summary>
		///		<para>Returns new MakotoLogFileHandler if null otherwise existing will be returned</para>
		/// </summary>
		public static MakotoLogFileHandler Current = new();

		private readonly StreamWriter m_StreamWriter;
		private readonly ILogHandler m_DefaultLogHandler = Debug.unityLogger.logHandler;

		private MakotoLogFileHandler() {
			if (Current != null) {
				Current = this;
			}

			var timeStamp = DateTime.Now;
			var filePath = Path.Combine(Application.persistentDataPath +
			                            $"/Log_{timeStamp.Year}-{timeStamp.Month}-{timeStamp.Day}.log");

			var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			m_StreamWriter = new StreamWriter(fileStream);
		}


		public void LogFormat(MsLogType msLogType, Object context, string format, params object[] args) {
			m_StreamWriter.WriteLine(format, args);
			m_StreamWriter.Flush();

#if UNITY_EDITOR
			// Also log to the unity logHandler to display in console
			m_DefaultLogHandler.LogFormat(LogTypeMapper.GetUnityLogType(msLogType), context, format, args);
#endif
		}

		public void LogException(Exception exception, Object context) {
			m_DefaultLogHandler.LogException(exception, context);
		}
	}
}