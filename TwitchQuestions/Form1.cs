using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwitchQuestions
{
    public partial class Form1 : Form
    {
        public ConnectionCredentials credentials;

        public TwitchClient client;
        
        public bool setChannel = false;
        public bool Polling = false;

        public string channel_name;
        public string BOT_ACCESS_TOKEN;
        public string BOT_CHANNEL_NAME;
        public string[] AllowedAnswers;

        public decimal timerLength;

        public int countdownTimer;
        public int chatLength = 5;

        public List<string> chatMessageList = new List<string>();
        public List<string> UsersThatHaveVoted = new List<string>();

        public Dictionary<string, int> Results = new Dictionary<string, int>();


        public Form1()
        {
            InitializeComponent();

            //read json file containing api keys and channel names
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/Secrets.json");

            JObject secrets = JObject.Parse(json);

            BOT_ACCESS_TOKEN = secrets.Value<string>("BOT_ACCESS_TOKEN");
            BOT_CHANNEL_NAME = secrets.Value<string>("BOT_CHANNEL_NAME");

        }

        /// <summary>
        /// Connects a TwitchClient to a specified twitch chat, and listens for chat events
        /// </summary>
        public void GetChat()
        {
            //if a connection is already esablished prior to trying to connecting another channel, 
            //disconnect client and reset credentials
            try
            {
                client.Disconnect();
                client = null;
                credentials = null;
            }
            catch (Exception)
            {

            }

            //sets the channel name that the client will connect to
            channel_name = channelInput.Text.ToLower();

            //creates client credentials from access tokens and bot username
            credentials = new ConnectionCredentials(BOT_CHANNEL_NAME, BOT_ACCESS_TOKEN);

            //creates new empty client
            client = new TwitchClient();

            //subs to log event to display client logs in the output window
            client.OnLog += Client_OnLog;

            //initialize client using credentials, and tell it what channel it will be going to.
            client.Initialize(credentials, channel_name);

            //subscribe to any events we want our bot to listen for

            //subs to new chat messsage
            client.OnMessageReceived += MyMessageRecieved;

            //subs to client connected
            client.OnConnected += Client_OnConnected;

            //subs to chat commands
            client.OnChatCommandReceived += Client_OnChatCommandReceived;

            //conencts client to specified twitch channel
            client.Connect();
        }

        //on client log, print log text in output window for debugging purposes
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine("log:" + e.Data);
        }

        //on recieving a chat command, check what the command is and take relevant action.
        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            //if not polling for answers, don't do anything
            if (!Polling)
            {
                return;
            }

            //if user has used the vote command and poll is active
            if (e.Command.CommandText.ToLower() == "vote")
            {
                //and the user has not already voted
                if (!UsersThatHaveVoted.Contains(e.Command.ChatMessage.Username))
                {
                    //and they have typed an allowed answer
                    if (Results.ContainsKey(e.Command.ArgumentsAsString.ToLower()))
                    {
                        //increase answers count
                        Results[e.Command.ArgumentsAsString.ToLower()]++;

                        //add user to voted list
                        UsersThatHaveVoted.Add(e.Command.ChatMessage.Username);

                        //and update results textbox
                        Invoke(new Action(() => ResultsBox.Text = string.Join(Environment.NewLine, Results).Replace('[', ' ').Replace(']', ' ')));
                    }
                }
            }
        }

        //when client connects, print a connected message in chat box. 
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Invoke(new Action(() => richTextBox1.Text = "Connected to " + channel_name));
        }

        //when there is a new message in the chat
        public void MyMessageRecieved(object sender, OnMessageReceivedArgs e)
        {
            //if there are more than the desired chat messages on screen
            //delete the oldest(first position) message to make room for a new message
            if (chatMessageList.Count >= chatLength)
            {
                //makes space for new message if there is not enough space
                chatMessageList.RemoveAt(0);
            }
            //adds the new message
            chatMessageList.Add(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
            //updates the chat display to show the new message added, using ListToText to format the messages
            Invoke(new Action(() => richTextBox1.Text = ListToText(chatMessageList)));

            //Invoke(new Action(() => richTextBox1.Text = e.ChatMessage.Username + ": " + e.ChatMessage.Message));
        }

        //calls the GetChat method to connect to the chat of a specified channel
        private void connectButton_Click(object sender, EventArgs e)
        {
            //channel specified by user input box
            channel_name = channelInput.Text;

            GetChat();
        }

        //disconnects TwitchClient if a connection is already established
        public void DisconnectChat()
        {
            try
            {
                client.Disconnect();
            }
            catch (Exception)
            {

            } 
        }

        //calls the Disconnect method when disconnect button is pressed
        private void DisconenctButton_Click(object sender, EventArgs e)
        {
            DisconnectChat();
        }

        //calls the Disconnect method when form is closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectChat();
        }

        /// <summary>
        /// Takes a list and converts it to a single string with new lines for each list item.
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns></returns>
        private string ListToText(List<string> list)
        {
            //clear the current stored string
            string result = "";

            //for each message in the list
            foreach (var listMember in list)
            {
                //add the message with a new line formatting at the end
                result += listMember.ToString() + "\n";
            }

            //return the string produced
            return result;
        }

        //calls the start question method when ask question button is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            startQuestion();
        }

        /// <summary>
        /// Posts in chat the question typed in the question box.
        /// Also posts voting options for chat to respond to the question
        /// </summary>
        private void startQuestion()
        {
            //Splits up the allowed answers text box text
            //Will be used to set voting options
            AllowedAnswers = AllowedAnswersBox.Text.Split(',');

            //set polling to true, as we will now start a poll
            Polling = true;

            //Add each vote option to the results dictionary, and give it an initial value of 0
            foreach (string Answer in AllowedAnswers)
            {
                Results.Add(Answer.Trim().ToLower(), 0);
            }

            //Set the results box text to show each of the voting options.
            ResultsBox.Text = string.Join(Environment.NewLine, Results).Replace('[', ' ').Replace(']', ' ');

            //store the initial timer length so we can revert to this after countdownn reaches 0
            timerLength = numericUpDown1.Value;

            //set up an int for the countdown timer
            //this will be decreased by 1 each second, and used to show remaining time by setting the numericupdown value to this.
            countdownTimer = (int)numericUpDown1.Value;

            //timer interal is in milliseconds, so multiply numericupdown value by 1000 to convert to seconds
            timer1.Interval = (int)numericUpDown1.Value * 1000;

            //Enable timer 1 - This wil trigger after counting down the time set by the user, and end the poll
            //Enable timer 2 - This will trigger every second, and will decrease the countdownTimer value
            timer1.Enabled = true;
            timer2.Enabled = true;

            //post the question in chat and post the options for voting in the poll
            client.SendMessage(client.JoinedChannels[0], QuestionBox.Text + " ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ !vote " + AllowedAnswersBox.Text);
        }

        /// <summary>
        /// Every second, sets the numericUpDown value to the countdownTimer value, after decreasing it by 1.
        /// </summary>
        private void UpdateCountdownTimer()
        {
            if (countdownTimer > 0)
            {
                countdownTimer--;
                numericUpDown1.Value = (decimal)countdownTimer;
            }
        }

        //timer that triggers at the end of the question period
        private void timer1_Tick(object sender, EventArgs e)
        {
            //when timer finishes, if polling
            if (Polling)
            {
                //tell chat polling has ended
                client.SendMessage(client.JoinedChannels[0], "time's up!");

                //reset timer value
                numericUpDown1.Value = timerLength;

                //disable polling
                Polling = false;

                //disable timers
                timer2.Enabled = false;
                timer1.Enabled = false;

                //clear list of users that voted
                UsersThatHaveVoted.Clear();

                //clear results, ready for next question
                Results.Clear();
            }
        }

        //timer that triggers every second
        private void timer2_Tick(object sender, EventArgs e)
        {
            //if poll is running
            if (Polling)
            {
                //update the countdown timer (calls method that decreases timer value by 1)
                UpdateCountdownTimer();
            }
        }

        //cancells the poll and resets variables that handle the question logic
        public void StopQuestion()
        {
            //tell chat poll has ended prematurely
            client.SendMessage(client.JoinedChannels[0], "Poll has been cancelled");

            //reset timer value
            numericUpDown1.Value = timerLength;

            //disable polling
            Polling = false;

            //end both timers
            timer2.Enabled = false;
            timer1.Enabled = false;

            //clear list of users that voted
            UsersThatHaveVoted.Clear();

            //clear results, ready for next question
            Results.Clear();
        }

        //calls the StopQuestion method to stop the question early
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (Polling)
            {
                StopQuestion();
            }
        }
    }
}
