using System.Collections.Generic;

using com.adastrafork.tools.messagebroadcasting.model;
using com.adastrafork.tools.messagebroadcasting.sender;


namespace com.adastrafork.tools.messagebroadcasting.receiver {
	/// <summary>
	/// Abstract base class for the creation of message receivers.
	/// </summary>
	public abstract class MessageReceiver : IMessageReceiver {
		#region Receiver.

		private List<IMessageSender> subscriptions;


		/// <summary>
		/// Sets up the receiver.
		/// </summary>
		public MessageReceiver ( ) {
			subscriptions = new List<IMessageSender> ( );
		}


		/// <summary>
		/// Subscribes the receiver to the messages sent by a sender.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the receiver wants to subscribe to.</param>
		public void SubscribeToMessagesFrom (IMessageSender sender) {
			sender.MessageSentEvent += OnMessageSent;

			subscriptions.Add (sender);
		}


		/// <summary>
		/// Unsubscribes the receiver to the messages sent by a sender.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the receiver wants to unsubscribe to.</param>
		public void UnsubscribeToMessagesFrom (IMessageSender sender) {
			sender.MessageSentEvent -= OnMessageSent;

			subscriptions.Remove (sender);
		}


		/// <summary>
		/// Event handler, fired when a sender object, which the receiver is subscribed to, sends a broadcast message.
		/// </summary>
		/// 
		/// <param name="sender">Message sender.</param>
		/// <param name="message">Message sent by the sender.</param>
		public abstract void OnMessageSent (IMessageSender sender, Message message);


		/// <summary>
		/// Clears the list of senders, unsubscribing the receiver to every one of them.
		/// </summary>
		public void Dispose ( ) {
			foreach (IMessageSender sender in subscriptions) {
				sender.MessageSentEvent -= OnMessageSent;
			}

			subscriptions.Clear ( );
		}

		#endregion
	}
}