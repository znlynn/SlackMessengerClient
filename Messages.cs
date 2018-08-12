using System;

namespace Slackbot
{

    /// Send Slack message
    public class Message
    {
        public string Text { get; set; }
        public string Channel { get; set; }
        public string UserName { get; set; }
        public string Icon { get; set; }

        /// Default channel, username and icon
        public Message(string text)
        {
            Text = text;
        }
        
        /// Default username and icon
        public Message(string text, string channel)
        {
            Text = text;
            Channel = channel;
        }
        
        /// Default icon
        public Message(string text, string channel, string username)
        {
            Text = text;
            Channel = channel;
            UserName = username;
        }

        /// Creates the message with all properties set
        public Message(string text, string channel, string username, string icon)
        {
            Text = text;
            Channel = channel;
            UserName = username;
            Icon = icon;
        }
    }
}
