using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

public class CoreBot
{
    private DiscordClient _client;
    private CommandService commands;

    private Random rand;

    private string[] pouts;
    private string[] idleTexts;
    private string[] smugs;

    public CoreBot()
    {
        //random number generator
        rand = new Random();

        //store of pout paths
        pouts = new string[]
        {
            "pouts/pout1.png", "pouts/pout2.png",
            "pouts/pout3.png", "pouts/pout4.png",
            "pouts/pout5.png", "pouts/pout6.png",
            "pouts/pout7.png", "pouts/pout8.png",
            "pouts/pout9.png", "pouts/pout10.gif",
            "pouts/pout11.gif", "pouts/pout12.png",
            "pouts/pout13.png"
        };

        //store of smug paths
        smugs = new string[]
        {
            "smugs/smug1.png", "smugs/smug2.png",
            "smugs/smug3.png", "smugs/smug4.png",
            "smugs/smug5.png", "smugs/smug6.png",
            "smugs/smug7.png", "smugs/smug8.png",
            "smugs/smug9.png", "smugs/smug10.png",
            "smugs/smug11.png", "smugs/smug12.png",
            "smugs/smug13.png",
        };

        //store of idle texts 
        idleTexts = new string[]
        {
            "Yes, if you're fine with Haruna, I'll be your partner any time.",
            "Yes, Haruna is daijoubou",
            "The admiral is very kind. Haruna appreciates your consideration.",
            "Haruna, accepting orders to standby..",
            "Daijoubou Desu!"
        };

	}

    /*
     *  Registers all active commands for HarunaBot
     */
    private void RegisterCommands()
    {
        //pouts
        commands.CreateCommand("pout")
            .Do(async (e) =>
            {
                int randomPoutIndex = rand.Next(pouts.Length);
                string poutToPost = pouts[randomPoutIndex];

                await e.Channel.SendFile(poutToPost);
            });


        //smugs
        commands.CreateCommand("smug")
            .Do(async (e) =>
            {
                int randomSmugIndex = rand.Next(smugs.Length);
                string smugToPost = smugs[randomSmugIndex];

                await e.Channel.SendFile(smugToPost);
            });


        //idling text
        commands.CreateCommand("idle")
            .Do(async (e) =>
            {
                int randomIdleIndex = rand.Next(idleTexts.Length);
                string idleToPost = idleTexts[randomIdleIndex];

                await e.Channel.SendMessage(idleToPost);
            });


        //delete messages
        commands.CreateCommand("purge")
            .Do(async (e) =>
            {
                Message[] messagesToDelete;
                messagesToDelete = await e.Channel.DownloadMessages(100);

                await e.Channel.DeleteMessages(messagesToDelete);
            });


        //targeted hello/bye
        commands.CreateGroup("h", cgb =>
        {
            cgb.CreateCommand("inHello")
            .Alias(new string[] { "hey", "hi" })
            .Description("Greets a person")
            .Parameter("GreetedPerson", ParameterType.Required)
            .Do(async (e) =>
            {
                await e.Channel.SendMessage("hi " + e.GetArg("GreetedPerson") + " <3");
            });

            cgb.CreateCommand("inBye")
            .Alias(new string[] { "goodbye", "bb" })
            .Description("Says bye to a person")
            .Parameter("PersonToBye", ParameterType.Required)
            .Do(async (e) =>
            {
                await e.Channel.SendMessage("goodbye " + e.GetArg("PersonToBye") + " <3");
            });
        });


        //server owner hello
        commands.CreateCommand("hello")
           .Description("Greets server owner")
           .Do(async (e) =>
           {
               User user = _client.GetServer(e.Server.Id).GetUser(e.Server.Owner.Id);

               await e.Channel.SendMessage("hi " + user.Nickname + " <3");
           });


        //server owner goodbye
        commands.CreateCommand("bye")
          .Description("Says bye to server owner")
          .Do(async (e) =>
          {
              User user = _client.GetServer(e.Server.Id).GetUser(e.Server.Owner.Id);

              await e.Channel.SendMessage("goodbye " + user.Nickname + " <3");
          });


        //<3
        _client.MessageReceived += async (s, e) =>
        {
            string message;
            if((e.Server.Owner.Id == e.Message.User.Id) && e.Message.RawText.Contains("\\<3"))
            //if (e.Message.RawText.Contains("\\<3"))
            {
                message = "<3";

                await e.Channel.SendMessage(message);
            }
        };


        //ayy lmao
        _client.MessageReceived += async (s, e) =>
        {
            string message;
            if(e.Message.RawText.Contains("ayy"))
            {
                message = "lmao desu!";

                await e.Channel.SendMessage(message);
            }
        };


        //dice roll
        commands.CreateCommand("roll")
            .Description("rolls a 6 sided dice")
            .Do(async (e) =>
            {
                int roll = rand.Next(6);

                await e.Channel.SendMessage("You rolled a " + roll);
            });
    }


    /*
     *  Util function for logging
     */
    private void Log(object sender, LogMessageEventArgs e)
    {
        Console.WriteLine($"[{e.Severity}] [{e.Source}] { e.Message}");
    }

    /*
     * Non-static method that starts the bot
     * Called by Program().main(args)
     */
    public void Start()
    {
        CoreBot bot = new CoreBot();

        _client = new DiscordClient(x =>
        {
            x.AppName = "HarunaBot";
            x.LogLevel = LogSeverity.Info;
            x.LogHandler = Log;
        });

        _client.UsingCommands(x =>
        {
            x.PrefixChar = '!';
            x.AllowMentionPrefix = true;
            x.HelpMode = HelpMode.Public;
        });

        commands = _client.GetService<CommandService>();

        //register commands
        RegisterCommands();

        _client.ExecuteAndWait(async () =>
        {
            await _client.Connect("token",
                TokenType.Bot);
        });
    }
}
