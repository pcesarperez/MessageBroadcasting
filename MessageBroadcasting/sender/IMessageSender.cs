using System;

using com.adastrafork.tools.messagebroadcasting.model;


namespace com.adastrafork.tools.messagebroadcasting.sender {
	/// <summary>
	/// Interface used to declare an object as a message sender.
	/// </summary>
	public interface IMessageSender {
		#region Sender.

		/// <summary>
		/// Event fired when a message is broadcast by a sender.
		/// </summary>
		event Action<IMessageSender, Message> MessageSentEvent;


		/// <summary>
		/// Sends a broadcast message which can be picked up by a receiver.
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		void SendMessage (int messageLevel, string messageText);


		/// <summary>
		/// <para>Sends a broadcast message which can be picked up by a receiver.</para>
		/// 
		/// <para>The message will be linked to an exception.</para>
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		/// <param name="exceptionThrown">Exception thrown linked to the message.</param>
		void SendMessage (int messageLevel, string messageText, Exception exceptionThrown);

		#endregion
	}
}