using Newtonsoft.Json;
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

        public void GetChat()
        {
            //quick 'fix' because i was getting errors and i'm lazy
            try
            {
                client.Disconnect();
                client = null;
                credentials = null;
            }
            catch (Exception)
            {

            }

            Console.WriteLine("set channel name");
            channel_name = channelInput.Text;

            Console.WriteLine("create credentials");
            credentials = new ConnectionCredentials(BOT_CHANNEL_NAME, BOT_ACCESS_TOKEN);

            Console.WriteLine("create client");
            client = new TwitchClient();

            Console.WriteLine("sub to on log");
            client.OnLog += Client_OnLog;

            Console.WriteLine("try to initialise with credential and name");
            client.Initialize(credentials, channel_name);

            //here we will subscribe to any EVENTS we want our bot to listen for
            client.OnMessageReceived += MyMessageRecieved;
            client.OnConnected += Client_OnConnected;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;

            client.Connect();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine("log:" + e.Data);
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            if (!Polling)
            {
                return;
            }

            if (e.Command.CommandText == "vote")
            {
                if (!UsersThatHaveVoted.Contains(e.Command.ChatMessage.Username))
                {
                    if (Results.ContainsKey(e.Command.ArgumentsAsString))
                    {
                        Results[e.Command.ArgumentsAsString]++;

                        UsersThatHaveVoted.Add(e.Command.ChatMessage.Username);

                        Invoke(new Action(() => ResultsBox.Text = string.Join(Environment.NewLine, Results).Replace('[', ' ').Replace(']', ' ')));
                    }
                }
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("*BEEP BOOP* I AM NOW ONLINE");
        }

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

        private void connectButton_Click(object sender, EventArgs e)
        {
            channel_name = channelInput.Text;

            GetChat();
        }

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

        private void DisconenctButton_Click(object sender, EventArgs e)
        {
            DisconnectChat();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectChat();
        }

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

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startQuestion();
        }

        private void startQuestion()
        {
            AllowedAnswers = AllowedAnswersBox.Text.Split(',');

            Polling = true;

            foreach (string Answer in AllowedAnswers)
            {
                Results.Add(Answer.Trim(), 0);
            }

            ResultsBox.Text = string.Join(Environment.NewLine, Results).Replace('[', ' ').Replace(']', ' ');
            timerLength = numericUpDown1.Value;
            countdownTimer = (int)numericUpDown1.Value;
            timer1.Interval = (int)numericUpDown1.Value * 1000;
            timer1.Enabled = true;
            timer2.Enabled = true;

            client.SendMessage(client.JoinedChannels[0], QuestionBox.Text + " !vote " + AllowedAnswersBox.Text);
        }

        private void UpdateCountdownTimer()
        {
            if (countdownTimer > 0)
            {
                countdownTimer--;
                numericUpDown1.Value = (decimal)countdownTimer;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Polling)
            {
                client.SendMessage(client.JoinedChannels[0], "time's up!");
                numericUpDown1.Value = timerLength;
                Polling = false;
                timer2.Enabled = false;
                timer1.Enabled = false;
                UsersThatHaveVoted.Clear();
                Results.Clear();

                
                
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Polling)
            {
                UpdateCountdownTimer();
            }
        }

        public void StopQuestion()
        {
            client.SendMessage(client.JoinedChannels[0], "Poll has been cancelled");
            numericUpDown1.Value = timerLength;
            Polling = false;
            timer2.Enabled = false;
            timer1.Enabled = false;
            UsersThatHaveVoted.Clear();
            Results.Clear();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopQuestion();
        }
    }
}
