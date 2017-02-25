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

    public CoreBot()
    {
     
        rand = new Random();
        pouts = new string[]
        {
            "pouts/pout1.png",
            "pouts/pout2.png",
            "pouts/pout3.png",
            "pouts/pout4.png",
            "pouts/pout5.png"
        };

        idleTexts = new string[]
        {
            "Yes, if you're fine with Haruna, I'll be your partner any time.",
            "Yes, Haruna is daijoubou",
            "The admiral is very kind. Haruna appreciates your consideration.",
            "Haruna, accepting orders to standby..",
            "Daijoubou Desu!"
        };

        commands = _client.GetService<CommandService>();

        //register commands here
        RegisterCommands();
	}

    /*
     *  Registers all active commands for HarunaBot
     */
    private void RegisterCommands()
    {
        RegisterPoutCommand();  //pouts
        RegisterIdleCommand();  //idling text
        RegisterPurgeChannelCommand();  //delete messages
        RegisterOnOfflineCommands();    //targeted hello/bye
        RegisterHelloCommand(); //server owner hello
        RegisterByeCommand();   //server owner goodbye
        RegisterHeartCommand(); //<3
    }

    /*
     *  Posts a random pout image from pouts
     */
    private void RegisterPoutCommand()
    {
        commands.CreateCommand("pout")
            .Do(async (e) =>
            {

                int randomPoutIndex = rand.Next(pouts.Length);
                string poutToPost = pouts[randomPoutIndex];
                await e.Channel.SendFile(poutToPost);
            });
    }

    /*
     *  Posts a random idle message from idleTexts
     */
    private void RegisterIdleCommand()
    {
        commands.CreateCommand("idle")
            .Do(async (e) =>
            {
                int randomIdleIndex = rand.Next(idleTexts.Length);
                string idleToPost = idleTexts[randomIdleIndex];

                await e.Channel.SendMessage(idleToPost);
            });
    }

    /*
     *  Clears all (100) messages from a selected channel
     */
     private void RegisterPurgeChannelCommand()
    {
        commands.CreateCommand("purge")
            .Do(async (e) =>
            {
                Message[] messagesToDelete;
                messagesToDelete = await e.Channel.DownloadMessages(100);

                await e.Channel.DeleteMessages(messagesToDelete);
            });
    }

    /*
     *  Singular Hello Command
     */
    private void RegisterHelloCommand()
    {
        commands.CreateCommand("hello")
            .Description("Greets server owner")
            .Do(async(e) =>
            {
                var _userId = _client.GetServer(e.Server.Id).GetUser(e.Server.Owner.Id);
                var _userName = _userId.Name;

                await e.Channel.SendMessage("hi " + _userName + " <3");
            });
    }

    /*
     *  Singular Bye Command
     */
    private void RegisterByeCommand()
    {
        commands.CreateCommand("bye")
            .Description("Says bye to server owner")
            .Do(async (e) =>
            {
                User _user = _client.GetServer(e.Server.Id).GetUser(e.Server.Owner.Id);

                await e.Channel.SendMessage("goodbye " + _user.Name + " <3");
            });
    }

    /*
     *  Group of hello x, bye x commands
     */
    private void RegisterOnOfflineCommands()
    {
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
    }

    /*
     *  <3
     */
     private void RegisterHeartCommand()
    {
        //commands.CreateCommand("<3")
        //    .Description("sends a <3")
        //    .Do(async (e) =>
        //    { 
        //        await e.Channel.SendMessage("<3");
        //    });
        _client.MessageAcknowledged += async (s, e) =>
        {
            
        };
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

        _client.ExecuteAndWait(async () =>
        {
            await _client.Connect("MjQwMjMwMjkzNTMxOTE4MzQ2.C5NBMg.t-Q_bH_6y7T9000wt4oNL87ofwg",
                TokenType.Bot);
        });
    }
}
