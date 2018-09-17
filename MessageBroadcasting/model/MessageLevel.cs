namespace com.adastrafork.tools.messagebroadcasting.model {
	/// <summary>
	/// <para>Allowed message levels.</para>
	/// 
	/// <para>These levels map those found in NLog.</para>
	/// 
	/// <para>See https://github.com/NLog/NLog/wiki/Configuration-file#log-levels for further reference.</para>
	/// </summary>
	public static class MessageLevel {
		public const int TRACE = 0;
		public const int DEBUG = 1;
		public const int INFO = 2;
		public const int WARN = 3;
		public const int ERROR = 4;
		public const int FATAL = 5;
	}
}