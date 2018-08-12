using System;
using System.Net;
using System.Text;
using System.IO;

namespace Slackbot
{
    public class SlackMessageClient
    {
        //Find your incoming webhook here: https://my.slack.com/services/new/incoming-webhook/
        public string IncomingWebhook { get; set; }

        public SlackMessageClient(string incomingWebhook)
        {
            IncomingWebhook = incomingWebhook;
        }

        /// Calls the process request method with your message data
        public string Send(Message message)
        {
            return ProcessRequest(IncomingWebhook, PreparePostData(message));
        }

        /// Gets the JSON data from the message and puts it into a payload parameter
        private string PreparePostData(Message message)
        {
            StringBuilder postData = new StringBuilder();
            postData.Append("payload={");

            if (!String.IsNullOrEmpty(message.Text))
            {
                postData.Append("\"text\":\"" + message.Text + "\"");
            }

            if (!String.IsNullOrEmpty(message.Channel))
            {
                postData.Append(",\"channel\":\"" + message.Channel + "\"");
            }

            if (!String.IsNullOrEmpty(message.Icon))
            {
                postData.Append(",\"icon_emoji\":\"" + message.Icon + "\"");
            }

            if (!String.IsNullOrEmpty(message.UserName))
            {
                postData.Append(",\"username\": \"" + message.UserName + "\"");
            }

            postData.Append("}");
            return postData.ToString();
        }

        /// Calls a web request using the webhook url and the data from the message
        private string ProcessRequest(string incomingWebhook, string sbPostData)
        {
            WebRequest request = WebRequest.Create(incomingWebhook);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(sbPostData.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            Console.WriteLine("test");
            return responseFromServer;
        }
    }
}
