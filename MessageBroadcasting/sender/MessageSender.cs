using System;

using com.adastrafork.tools.messagebroadcasting.model;


namespace com.adastrafork.tools.messagebroadcasting.sender {
	/// <summary>
	/// Abstract base class for the creation of message senders.
	/// </summary>
	public abstract class MessageSender : IMessageSender {
		#region Sender.

		/// <summary>
		/// Event fired when a message is broadcast by a sender.
		/// </summary>
		public event Action<IMessageSender, Message> MessageSentEvent;


		/// <summary>
		/// Sends a broadcast message which can be picked up by a receiver.
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		public void SendMessage (int messageLevel, string messageText) => MessageSentEvent?.Invoke (this, new Message (messageLevel, messageText));


		/// <summary>
		/// <para>Sends a broadcast message which can be picked up by a receiver.</para>
		/// 
		/// <para>The message will be linked to an exception.</para>
		/// </summary>
		/// 
		/// <param name="messageLevel">Message level (see <code>MessageLevel</code> class).</param>
		/// <param name="messageText">Message text.</param>
		/// <param name="exceptionThrown">Exception thrown linked to the message.</param>
		public void SendMessage (int messageLevel, string messageText, Exception exceptionThrown) => MessageSentEvent?.Invoke (this, new Message (messageLevel, messageText, exceptionThrown));

		#endregion
	}
}