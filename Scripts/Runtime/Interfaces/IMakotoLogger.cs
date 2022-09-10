using System;
using MakotoStudio.Logger.Constant;
using MakotoStudio.Logger.Core;
using Object = UnityEngine.Object;

namespace MakotoStudio.Logger.Interfaces {
	public interface IMakotoLogger {
		/// <summary>
		///   <para>Set MakotoLogger.IMakotoLogHandler.</para>
		/// </summary>
		public IMakotoLogHandler MakotoLogHandler { get; set; }

		/// <summary>
		///   <para>To runtime toggle debug logging [ON/OFF].</para>
		/// </summary>
		public bool LogEnabled { get; set; }

		/// <summary>
		///   <para>To selective enable debug log message.</para>
		/// </summary>
		public MsLogType MsLogLevel { get; set; }

		/// <summary>
		///   <para>Check logging is enabled based on the LogType.</para>
		/// </summary>
		/// <param name="msLogType"></param>
		/// <returns>
		///   <para>Retrun true in case logs of LogType will be logged otherwise returns false.</para>
		/// </returns>
		public bool IsLogTypeAllowed(MsLogType msLogType);

		/// <summary>
		///   <para>Logs message to the Unity Console using default logger.</para>
		/// </summary>
		/// <param name="msLogType"></param>
		/// <param name="message"></param>
		public void Log(MsLogType msLogType, object message);


		/// <summary>
		///   <para>Logs message to the Unity Console using default logger.</para>
		/// </summary>
		/// <param name="msLogType"></param>
		/// <param name="message"></param>
		/// <param name="context"></param>
		public void Log(MsLogType msLogType, object message, Object context);
		
		/// <summary>
		///   <para>Standard Information Log</para>
		///		<para>see more MakotoLogger: <see cref="MakotoLogger.Log(object)"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		public void LogInfo(object message);

		/// <summary>
		///		<para>Standard Information Log</para>	
		///		<para>see more MakotoLogger: <see cref="MakotoLogger.Log(object, Object)"/></para>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="context"></param>
		public void LogInfo(object message, Object context);


		/// <summary>
		///   <para>A variant of Logger.Log that logs an warning message.</para>
		/// </summary>
		/// <param name="message"></param>
		public void LogWarning(object message);

		/// <summary>
		///   <para>A variant of Logger.Log that logs an warning message.</para>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="context"></param>
		public void LogWarning(object message, Object context);

		/// <summary>
		///   <para>A variant of ILogger.Log that logs an error message.</para>
		/// </summary>
		/// <param name="message"></param>
		public void LogError(object message);

		/// <summary>
		///   <para>A variant of ILogger.Log that logs an error message.</para>	
		///		<para>see more MakotoLogger: <see cref="MakotoLogger.LogError(object, Object)"/></para>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="context"></param>
		public void LogError(object message, Object context);

		/// <summary>
		///   <para>Logs a formatted message.</para>
		/// </summary>
		/// <param name="msLogType"></param>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public void LogFormat(MsLogType msLogType, string format, params object[] args);

		/// <summary>
		///   <para>A variant of ILogger.Log that logs an exception message.</para>	
		///		<para>see more MakotoLogger: <see cref="MakotoLogger.LogException(Exception)"/></para>
		/// </summary>
		/// <param name="exception"></param>
		public void LogException(Exception exception);
		
		/// <summary>
		///   <para>A variant of ILogger.Log that logs an exception message.</para>	
		///		<para>see more MakotoLogger: <see cref="MakotoLogger.LogException(MsLogType, Exception)"/></para>
		/// </summary>
		/// <param name="msLogType"></param>
		/// <param name="exception"></param>
		public void LogException(MsLogType msLogType, Exception exception);
	}
}