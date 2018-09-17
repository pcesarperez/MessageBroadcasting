using System;
using System.Collections.Generic;

using com.adastrafork.tools.messagebroadcasting.model;
using com.adastrafork.tools.messagebroadcasting.sender;


namespace com.adastrafork.tools.messagebroadcasting.relay {
	public abstract class MessageRelay : IMessageRelay {
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


		#region Receiver.

		private List<IMessageSender> subscriptions;


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


		#region Relay.

		/// <summary>
		/// Sets up the relay.
		/// </summary>
		public MessageRelay ( ) {
			subscriptions = new List<IMessageSender> ( );
		}


		/// <summary>
		/// Forwards a message received by a sender using the receiving event.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the relay is subscribed to.</param>
		/// <param name="message">Message to be forwarded.</param>
		public void ForwardMessage (IMessageSender sender, Message message) {
			MessageSentEvent?.Invoke (sender, message);
		}

		#endregion
	}
}