using System;
using System.IO;
using MakotoStudio.Logger.Interfaces;
using MakotoStudio.Logger.Utils;
using MakotoStudio.Logger.Constant;
using UnityEngine;
using ILogHandler = UnityEngine.ILogHandler;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace MakotoStudio.Logger.Core {
	/// <summary>
	///		<para>Compare to the default MakotoLogFileHandler, the MakotoUnityLogFileHandler
	///		implements the Unity ILogHandler and override the Debug.unityLogger.logHandler</para>
	/// </summary>
	public class MakotoUnityLogFileHandler : IMakotoLogHandler, ILogHandler {
		/// <summary>
		///		<para>Returns new MakotoUnityLogFileHandler if null otherwise existing will be returned</para>
		/// </summary>
		public static MakotoUnityLogFileHandler Current = new();

		private readonly StreamWriter m_StreamWriter;
		private readonly ILogHandler m_DefaultLogHandler = Debug.unityLogger.logHandler;

		private MakotoUnityLogFileHandler() {
			if (Current != null) {
				Current = this;
			}


			var timeStamp = DateTime.Now;
			string filePath = Path.Combine(Application.persistentDataPath +
			                               $"/Log_{timeStamp.Year}-{timeStamp.Month}-{timeStamp.Day}.log");

			var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			m_StreamWriter = new StreamWriter(fileStream);
			Debug.unityLogger.logHandler = this;
		}


		public void LogFormat(MsLogType msLogType, Object context, string format, params object[] args) {
			m_StreamWriter.WriteLine(String.Format(format, args));
			m_StreamWriter.Flush();
			LogFormat(LogTypeMapper.GetUnityLogType(msLogType), context, format, args);
		}

		public void LogFormat(LogType logType, Object context, string format, params object[] args) {
			m_StreamWriter.WriteLine(String.Format(format, args));
			m_StreamWriter.Flush();
			m_DefaultLogHandler.LogFormat(logType, context, format, args);
		}

		public void LogException(Exception exception, Object context) {
			m_DefaultLogHandler.LogException(exception, context);
		}
	}
}