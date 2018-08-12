SlackMessageClient allows you to send alerts to slack channels based on webactivity on your site.
Attach to button clicks or eventHandlers like in the example below:


public SlackMessageClient SlackMessageClient { get; private set; }

public Message Message { get; private set; } 

private void whateverButton_Click(object sender, RoutedEventArgs e)

{

  //Find your incoming webhook here: https://my.slack.com/services/new/incoming-webhook/

  SlackMessageClient = new SlackMessageClient("enter-your-incoming-webhook-here");
        
  //Create message to send. Accepts message text, slack channel, Slack sender name, and your icon.
	
  //Only Text is required
	
  Message = new Message("User is filling out a contact form!", "general", "Contact Form Watcher", ":smile:");
        
  SlackMessageClient.Send(Message);
        
}
