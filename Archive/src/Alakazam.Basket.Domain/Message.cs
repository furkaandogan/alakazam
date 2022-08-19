using System;
using System.Diagnostics.CodeAnalysis;

namespace Alakazam.Basket.Domain
{
    [ExcludeFromCodeCoverage]
    public sealed class Message
    {
        public Guid Id { get; private set; }
        public MessageType Type { get; private set; }
        public string Content { get; private set; }
        public string Title { get; private set; }

        public Message(Guid id, MessageType type, string content, string title)
        {
            Id = id;
            Content = content;
            Title = title;
            Type = type;
        }
        public Message(MessageType type, string content, string title)
            : this(Guid.NewGuid(), type, content, title)
        {
        }
        public Message(MessageType type, string content)
            : this(Guid.NewGuid(), type, content, string.Empty)
        {
        }
    }

    public class MessageType
    {
        private readonly string _type;

        public MessageType(string type)
        {
            _type = type;
        }

        static MessageType()
        {
            INFO = new MessageType("info");
            WARM = new MessageType("warm");
            ERROR = new MessageType("error");
        }


        public static MessageType INFO;
        public static MessageType WARM;
        public static MessageType ERROR;
    }
}