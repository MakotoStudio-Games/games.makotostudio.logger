using System;
using MakotoStudio.Logger.Constant;
using Object = UnityEngine.Object;

namespace MakotoStudio.Logger.Interfaces {
	public interface IMakotoLogHandler {
		/// <summary>
		///   <para>Logs a formatted message.</para>
		/// </summary>
		/// <param name="msLogType">The type of the log message.</param>
		/// <param name="context">Object to which the message applies.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">Format arguments.</param>
		void LogFormat(MsLogType msLogType, Object context, string format, params object[] args);

		/// <summary>
		///   <para>A variant of ILogHandler.LogFormat that logs an exception message.</para>
		/// </summary>
		/// <param name="exception">Runtime Exception.</param>
		/// <param name="context">Object to which the message applies.</param>
		void LogException(Exception exception, Object context);
	}
}