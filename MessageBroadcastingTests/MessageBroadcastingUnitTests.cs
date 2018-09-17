using System;

using com.adastrafork.tools.messagebroadcasting.model;
using com.adastrafork.tools.messagebroadcasting.receiver;
using com.adastrafork.tools.messagebroadcasting.relay;
using com.adastrafork.tools.messagebroadcasting.sender;

using NUnit.Framework;


namespace com.adastrafork.tools.messagebroadcasting.tests {
	/// <summary>
	/// Test sender class.
	/// </summary>
	internal sealed class TestSender : MessageSender { }


	/// <summary>
	/// Test receiver class.
	/// </summary>
	internal sealed class TestReceiver : MessageReceiver {
		#region Receiver.

		public bool MessageReceived { get; private set; }


		/// <summary>
		/// Event handler, fired when a sender object, which the receiver is subscribed to, sends a broadcast message.
		/// </summary>
		/// 
		/// <param name="sender">Message sender.</param>
		/// <param name="message">Message sent by the sender.</param>
		public override void OnMessageSent (IMessageSender sender, Message message) {
			MessageReceived = true;

			Console.WriteLine ($"Message received in the receiver from sender: '{message.MessageText}'");
		}

		#endregion
	}


	/// <summary>
	/// Test relay class (it takes both roles, sender and receiver).
	/// </summary>
	internal sealed class TestRelay : MessageRelay {
		#region Receiver.

		public bool MessageReceived { get; private set; }


		public override void OnMessageSent (IMessageSender sender, Message message) {
			MessageReceived = true;

			Console.WriteLine ($"Message received in the relay from sender: '{message.MessageText}'");
			Console.WriteLine ("The message is beign forwarded...");

			ForwardMessage (sender, message);
		}

		#endregion
	}


	/// <summary>
	/// Unit tests for the message broadcasting library.
	/// </summary>
	[TestFixture]
	internal sealed class MessageBroadcastingUnitTests {
		/// <summary>
		/// Tests a message broadcasting with a single sender and a single receiver.
		/// </summary>
		[Test]
		public void TestReceiveMessageFromSingleSender ( ) {
			var sender = new TestSender ( );

			using (var receiver = new TestReceiver ( )) {
				receiver.SubscribeToMessagesFrom (sender);

				sender.SendMessage (MessageLevel.INFO, "This is a test.");

				Assert.That (receiver.MessageReceived, Is.True);
			}
		}


		/// <summary>
		/// Tests a message broadcasting with multiple senders and a single receiver.
		/// </summary>
		[Test]
		public void TestReceiveMessageFromMultipleSenders ( ) {
			var aSender = new TestSender ( );
			var anotherSender = new TestSender ( );

			using (var receiver = new TestReceiver ( )) {
				receiver.SubscribeToMessagesFrom (aSender);
				receiver.SubscribeToMessagesFrom (anotherSender);

				aSender.SendMessage (MessageLevel.INFO, "Message sent from a sender.");
				anotherSender.SendMessage (MessageLevel.INFO, "Message sent from another sender.");

				Assert.That (receiver.MessageReceived, Is.True);
			}
		}


		/// <summary>
		/// Tests a message broadcasting with a sender, a relay and a receiver.
		/// 
		/// Messages from the sender are chained through the relay to the receiver.
		/// </summary>
		[Test]
		public void TestMessageRelaying ( ) {
			var sender = new TestSender ( );

			using (var relay = new TestRelay ( )) {
				using (var receiver = new TestReceiver ( )) {

					relay.SubscribeToMessagesFrom (sender);
					receiver.SubscribeToMessagesFrom (relay);

					sender.SendMessage (MessageLevel.INFO, "Message sent from a sender.");
					relay.SendMessage (MessageLevel.INFO, "Message sent from a relay.");

					Assert.That (relay.MessageReceived, Is.True);
					Assert.That (receiver.MessageReceived, Is.True);
				}
			}
		}
	}
}