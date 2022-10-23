using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Discord_1
{
    public partial class Load : Form
    {

        
        DiscordSocketClient Client;
        
        public Load()
        {
            InitializeComponent();
            

        }

        private async void Load_Load(object sender, EventArgs e)
        {
            button2.Visible = false;

            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });
            Client.Log += Client_Log;
            try
            {
                await Client.LoginAsync(TokenType.Bot, "TOKEN HERE");
                await Client.StartAsync();
            }
            catch
            {
                MessageBox.Show("Error Logging in");
                return;
            }
            await Task.Delay(3000);
            Login_Log.ResetText();
        }
        private Task Client_Log(LogMessage arg)
        {
            Invoke((Action)delegate
            {
                Login_Log.AppendText(arg + "\n");

            });
            return null;
        }

        
        private async void button1_Click(object sender, EventArgs arg)
        {
            richTextBox1.ResetText();
            var INFO = await Client.GetUserAsync(id: 721651589982453760);
            richTextBox1.AppendText("User: " + INFO.Username + "#" + INFO.Discriminator + "\n" + "Created at: " + INFO.CreatedAt + "\n" + "Status: " + INFO.Status + "\n" + "Is Bot: " + INFO.IsBot + "\n" + "Is Webhook: " + INFO.IsWebhook + "\n" + "Avatar ID: " + INFO.AvatarId + "\n" + "Flags: " + INFO.PublicFlags);
            pictureBox1.ImageLocation = INFO.GetAvatarUrl();
           
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.TextLength < 18) { return; }

                var guild = Client.GetGuild(850301137147658261);

                var guildEvent = await guild.CreateEventAsync("test event", DateTimeOffset.UtcNow.AddDays(1), GuildScheduledEventType.External, endTime: DateTimeOffset.UtcNow.AddDays(2), location: "Space");

                richTextBox1.ResetText();
                pictureBox1.ImageLocation = null;
                ulong id = Convert.ToUInt64(textBox1.Text);
                var INFO = await Client.GetUserAsync(id);
                richTextBox1.AppendText("User: " + INFO.Username + "#" + INFO.Discriminator + "\n" + "Created at: " + INFO.CreatedAt + "\n" + "Status: " + INFO.Status + "\n" + "Is Bot: " + INFO.IsBot + "\n" + "Is Webhook: " + INFO.IsWebhook + "\n" + "Avatar ID: " + INFO.AvatarId + "\n" + "Flags: " + INFO.PublicFlags);
                pictureBox1.ImageLocation = INFO.GetAvatarUrl();
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    label4.Text = "";
                } else
                {
                    label4.Text = "Error!!!";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Width = 906;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Width = 460;
            button2.Visible = false;
            button1.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
