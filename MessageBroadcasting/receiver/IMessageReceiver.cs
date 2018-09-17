using System;

using com.adastrafork.tools.messagebroadcasting.model;
using com.adastrafork.tools.messagebroadcasting.sender;


namespace com.adastrafork.tools.messagebroadcasting.receiver {
	/// <summary>
	/// <para>Interface used to declare an object as a message receiver.</para>
	/// 
	/// <para>The interface inherits from <code><see cref="IDisposable"/></code> to force the implementation of a cleanup method.</para>
	/// </summary>
	public interface IMessageReceiver : IDisposable {
		#region Receiver.

		/// <summary>
		/// Subscribes the receiver to the messages sent by a sender.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the receiver wants to subscribe to.</param>
		void SubscribeToMessagesFrom (IMessageSender sender);


		/// <summary>
		/// Unsubscribes the receiver to the messages sent by a sender.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the receiver wants to unsubscribe to.</param>
		void UnsubscribeToMessagesFrom (IMessageSender sender);


		/// <summary>
		/// Event handler, fired when a sender object, which the receiver is subscribed to, sends a broadcast message.
		/// </summary>
		/// 
		/// <param name="sender">Message sender.</param>
		/// <param name="message">Message sent by the sender.</param>
		void OnMessageSent (IMessageSender sender, Message message);

		#endregion
	}
}