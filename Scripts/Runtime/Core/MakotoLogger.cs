using System;
using System.Globalization;
using MakotoStudio.Logger.Constant;
using MakotoStudio.Logger.Interfaces;
using Object = UnityEngine.Object;


// TODO: Rework description -> here and in @IMakotoLogger
namespace MakotoStudio.Logger.Core {
	/// <summary>
	///   Initializes a new instance of the MakotoLogger.
	/// </summary>
	public class MakotoLogger : IMakotoLogger, IMakotoLogHandler {
		/// <summary>
		///   Set new IMakotoLogHandler
		/// </summary>
		public IMakotoLogHandler MakotoLogHandler { get; set; }

		/// <summary>
		///   To runtime toggle debug logging [ON/OFF].
		/// </summary>
		public bool LogEnabled { get; set; }

		/// <summary>
		///   To selective enable debug log message.
		/// </summary>
		public MsLogType MsLogLevel { get; set; }

		private const string CStandardLogFormat = "[{0}] [{1}] [{2}] - Message: {3}";

		private const string CExceptionLogFormat = "[{0}] [{1}] [{2}] - [{3}]\n		{4} \n		{5} \n		{6}";

		private readonly Type m_TypeOf;

		/// <summary>
		///   Create default Makoto Studio Logger with a type of reference and default MakotoStudioLogHandler
		///		<seealso cref="MakotoLogFileHandler"/>
		/// </summary>
		/// <param name="type">Type of class which to the current logger is logging</param>
		public MakotoLogger(Type type) {
			MakotoLogHandler = MakotoLogFileHandler.Current;
			m_TypeOf = type;
			LogEnabled = true;
			MsLogLevel = MsLogType.Info;
		}

		/// <summary>
		///   Create a custom Makoto Studio Logger with a type of reference
		/// </summary>
		/// <param name="type">Type of class which to the current logger is logging</param>
		/// <param name="makotoLogHandler">Pass in default log handler or custom log handler.</param>
		/// <seealso cref="IMakotoLogHandler"/>
		public MakotoLogger(Type type, IMakotoLogHandler makotoLogHandler) {
			m_TypeOf = type;
			this.MakotoLogHandler = makotoLogHandler;
			LogEnabled = true;
			MsLogLevel = MsLogType.Info;
		}


		/// <summary>
		///   Check logging is enabled based on the LogType.
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <returns>
		///   <para>Retrun true in case logs of LogType will be logged otherwise returns false.</para>
		/// </returns>
		public bool IsLogTypeAllowed(MsLogType msLogType) {
			if (!LogEnabled)
				return false;
			if (msLogType == MsLogType.Exception)
				return true;
			if (MsLogLevel != MsLogType.Exception)
				return msLogType <= MsLogLevel;

			return false;
		}

		private static string GetString(object message) {
			if (message == null)
				return "Null";
			return message is IFormattable formattable
				? formattable.ToString(null, CultureInfo.InvariantCulture)
				: message.ToString();
		}

		/// <summary>
		///   Logs message to the Unity Console using default logger.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		public void Log(MsLogType msLogType, object message) {
			if (!IsLogTypeAllowed(msLogType))
				return;
			MakotoLogHandler.LogFormat(msLogType, null, CStandardLogFormat,
				msLogType, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   Logs message to the Unity Console using default logger.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		/// <param name="context">Object to which the message applies.</param>
		public void Log(MsLogType msLogType, object message, Object context) {
			if (!IsLogTypeAllowed(msLogType))
				return;
			MakotoLogHandler.LogFormat(msLogType, context, CStandardLogFormat,
				msLogType, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   Standard Information Log
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		public void LogInfo(object message) {
			if (!IsLogTypeAllowed(MsLogType.Info))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Info, null, CStandardLogFormat,
				MsLogType.Info, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   Standard Information Log
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		///		Log Format see: <see cref="CStandardLogFormat"/>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		/// <param name="context">Object to which the message applies.</param>
		public void LogInfo(object message, Object context) {
			if (!IsLogTypeAllowed(MsLogType.Info))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Info, context, CStandardLogFormat,
				MsLogType.Info, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   A variant of Logger.Log that logs an warning message.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		public void LogWarning(object message) {
			if (!IsLogTypeAllowed(MsLogType.Warning))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Warning, null, CStandardLogFormat,
				MsLogType.Warning, DateTime.Now, m_TypeOf, GetString(message));
		}


		/// <summary>
		///   A variant of Logger.Log that logs an warning message.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		/// <param name="context">Object to which the message applies.</param>
		public void LogWarning(object message, Object context) {
			if (!IsLogTypeAllowed(MsLogType.Warning))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Warning, context, CStandardLogFormat,
				MsLogType.Warning, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   A variant of Logger.Log that logs an error message.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		public void LogError(object message) {
			if (!IsLogTypeAllowed(MsLogType.Error))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Error, null, CStandardLogFormat,
				MsLogType.Error, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///   A variant of Logger.Log that logs an error message.
		///		<para>Log Format see: <see cref="CStandardLogFormat"/></para>
		/// </summary>
		/// <param name="message">String or object to be converted to string representation for display.</param>
		/// <param name="context">Object to which the message applies.</param>
		public void LogError(object message, Object context) {
			if (!IsLogTypeAllowed(MsLogType.Error))
				return;
			MakotoLogHandler.LogFormat(MsLogType.Error, context, CStandardLogFormat,
				MsLogType.Error, DateTime.Now, m_TypeOf, GetString(message));
		}

		/// <summary>
		///		A variant of Logger.Log that logs an exception message.
		///		<para>Log Format see: <see cref="CExceptionLogFormat"/></para>
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="exception">Runtime Exception.</param>
		public void LogException(MsLogType msLogType, Exception exception) {
			if (!LogEnabled)
				return;
			MakotoLogHandler.LogFormat(msLogType, null, CExceptionLogFormat, msLogType, DateTime.Now, m_TypeOf,
				GetString(exception.GetType()),
				GetString(exception.Source),
				GetString(exception.StackTrace),
				GetString(exception.Message));
			MakotoLogHandler.LogException(exception, null);
		}

		/// <summary>
		///   A variant of Logger.Log that logs an exception message.
		///		<para>Log Format see: <see cref="CExceptionLogFormat"/></para>
		/// </summary>
		/// <param name="exception">Runtime Exception.</param>
		public void LogException(Exception exception) {
			if (!LogEnabled)
				return;
			MakotoLogHandler.LogFormat(MsLogType.Error, null, CExceptionLogFormat, MsLogType.Error, DateTime.Now, m_TypeOf,
				GetString(exception.GetType()),
				GetString(exception.Source),
				GetString(exception.StackTrace),
				GetString(exception.Message));
			MakotoLogHandler.LogException(exception, null);
		}

		/// <summary>
		///   A variant of Logger.Log that logs an exception message.
		/// </summary>
		/// <param name="exception">Runtime Exception.</param>
		/// <param name="context">Object to which the message applies.</param>
		public void LogException(Exception exception, Object context) {
			if (!LogEnabled)
				return;
			MakotoLogHandler.LogException(exception, context);
		}

		/// <summary>
		///   Logs a formatted message.
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">Format arguments.</param>
		public void LogFormat(MsLogType msLogType, string format, params object[] args) {
			if (!IsLogTypeAllowed(msLogType))
				return;
			MakotoLogHandler.LogFormat(msLogType, null, format, args);
		}

		/// <summary>
		///   Logs a formatted message.
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="context">Object to which the message applies.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">Format arguments.</param>
		public void LogFormat(MsLogType msLogType, Object context, string format, params object[] args) {
			if (!IsLogTypeAllowed(msLogType))
				return;
			MakotoLogHandler.LogFormat(msLogType, context, format, args);
		}
	}
}