using com.adastrafork.tools.messagebroadcasting.model;
using com.adastrafork.tools.messagebroadcasting.receiver;
using com.adastrafork.tools.messagebroadcasting.sender;


namespace com.adastrafork.tools.messagebroadcasting.relay {
	/// <summary>
	/// <para>Interface used to declare an object as a message relay.</para>
	/// 
	/// <para>A message relay behaves as a sender and a receiver at the same time, adding forwarding capability.</para>
	/// </summary>
	public interface IMessageRelay: IMessageSender, IMessageReceiver {
		#region Relay.

		/// <summary>
		/// Forwards a message received by a sender using the receiving event.
		/// </summary>
		/// 
		/// <param name="sender">Sender whose messages the relay is subscribed to.</param>
		/// <param name="message">Message to be forwarded.</param>
		void ForwardMessage (IMessageSender sender, Message message);

		#endregion
	}
}