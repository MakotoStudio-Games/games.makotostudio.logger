namespace MakotoStudio.Logger.Constant {
	public enum MsLogType {
		/// <summary>
		///   <para>LogType used for Errors.</para>
		/// </summary>
		Error,

		/// <summary>
		///   <para>LogType used for Asserts. (These could also indicate an error inside Unity itself.)</para>
		/// </summary>
		Assert,

		/// <summary>
		///   <para>LogType used for Warnings.</para>
		/// </summary>
		Warning,

		/// <summary>
		///   <para>LogType used for info and regular log messages.</para>
		/// </summary>
		Info,

		/// <summary>
		///   <para>LogType used for Exceptions.</para>
		/// </summary>
		Exception,
	}
}