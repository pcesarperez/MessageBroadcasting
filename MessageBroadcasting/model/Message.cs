using System;


namespace com.adastrafork.tools.messagebroadcasting.model {
	/// <summary>
	/// Message sent with he broadcasting system.
	/// </summary>
	public class Message : EventArgs {
		/// <summary>
		/// Message setup.
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		public Message (int messageLevel, string messageText) {
			MessageLevel = messageLevel;
			MessageText = messageText;
			ExceptionThrown = null;
		}


		/// <summary>
		/// Message setup.
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		/// <param name="exceptionThrown">Exception thrown, linked to the message.</param>
		public Message (int messageLevel, string messageText, Exception exceptionThrown) {
			MessageLevel = messageLevel;
			MessageText = messageText;
			ExceptionThrown = exceptionThrown;
		}


		/// <summary>
		/// Message level (see <code>MessageLevel</code> class).
		/// </summary>
		public int MessageLevel { get; }


		/// <summary>
		/// Message text.
		/// </summary>
		public string MessageText { get; }


		/// <summary>
		/// Exception thrown, linked to the message.
		/// </summary>
		public Exception ExceptionThrown { get; }
	}
}