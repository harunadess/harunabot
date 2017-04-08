using System;

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
    private string[] selfies;

    public CoreBot()
    {
        //random number generator
        rand = new Random();

        //set up pout paths
        setUpPouts();

        //set up smug paths
        setUpSmugs();

        //set up selfie paths
        setUpSelfies();

        //set up idle texts 
        setUpIdles();
	}

    /*
     * Sets up file locations for pout images
     */
    private void setUpPouts()
    {
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
    }


    /*
     * Sets up file locations for smug images
     */
    private void setUpSmugs()
    {
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
    }

    
    /*
     * Sets up file locations for selfie images
     */
    private void setUpSelfies()
    {
        selfies = new string[]
        {
            "selfies/selfie1.png", "selfies/selfie2.png", "selfies/selfie3.png", "selfies/selfie4.png",
            "selfies/selfie5.png", "selfies/selfie6.png", "selfies/selfie7.png", "selfies/selfie8.png",
            "selfies/selfie9.png", "selfies/selfie10.png", "selfies/selfie11.png", "selfies/selfie12.png",
            "selfies/selfie13.png", "selfies/selfie14.png", "selfies/selfie15.png", "selfies/selfie16.png",
            "selfies/selfie17.png", "selfies/selfie18.png", "selfies/selfie19.png", "selfies/selfie20.png",
            "selfies/selfie21.png", "selfies/selfie22.png", "selfies/selfie23.png", "selfies/selfie24.png",
            "selfies/selfie25.png", "selfies/selfie26.png", "selfies/selfie27.png", "selfies/selfie28.png",
            "selfies/selfie29.png", "selfies/selfie30.png", "selfies/selfie31.png", "selfies/selfie32.png",
            "selfies/selfie33.png", "selfies/selfie34.png", "selfies/selfie35.png", "selfies/selfie36.png",
            "selfies/selfie37.png", "selfies/selfie38.png", "selfies/selfie39.png", "selfies/selfie40.png",
            "selfies/selfie41.gif", "selfies/selfie42.png", "selfies/selfie43.png", "selfies/selfie44.png",
            "selfies/selfie45.png", "selfies/selfie46.png", "selfies/selfie47.png", "selfies/selfie48.png",
            "selfies/selfie49.png", "selfies/selfie50.png", "selfies/selfie51.png", "selfies/selfie52.png",
            "selfies/selfie53.png", "selfies/selfie54.png", "selfies/selfie55.png", "selfies/selfie56.gif",
            "selfies/selfie57.png", "selfies/selfie58.png", "selfies/selfie59.png", "selfies/selfie60.png",
            "selfies/selfie61.png", "selfies/selfie62.png", "selfies/selfie63.png", "selfies/selfie64.png",
            "selfies/selfie65.png", "selfies/selfie66.png", "selfies/selfie67.png", "selfies/selfie68.png",
            "selfies/selfie69.png", "selfies/selfie70.png", "selfies/selfie71.png", "selfies/selfie72.png",
            "selfies/selfie73.png", "selfies/selfie74.png", "selfies/selfie75.png", "selfies/selfie76.png",
            "selfies/selfie77.png", "selfies/selfie78.png", "selfies/selfie79.png", "selfies/selfie80.png",
            "selfies/selfie81.png", "selfies/selfie82.png", "selfies/selfie83.png", "selfies/selfie84.png",
            "selfies/selfie85.png", "selfies/selfie86.png", "selfies/selfie87.png", "selfies/selfie88.png",
            "selfies/selfie89.png", "selfies/selfie90.png", "selfies/selfie91.png", "selfies/selfie92.png",
            "selfies/selfie93.png", "selfies/selfie94.png", "selfies/selfie95.png", "selfies/selfie96.png",
            "selfies/selfie97.png", "selfies/selfie98.png", "selfies/selfie99.png", "selfies/selfie100.png",
            "selfies/selfie101.png", "selfies/selfie102.png", "selfies/selfie103.png", "selfies/selfie104.png",
            "selfies/selfie105.png", "selfies/selfie106.png", "selfies/selfie107.png", "selfies/selfie108.png",
            "selfies/selfie109.png", "selfies/selfie110.png", "selfies/selfie111.png", "selfies/selfie112.png",
            "selfies/selfie113.png", "selfies/selfie114.png", "selfies/selfie115.png", "selfies/selfie116.png",
            "selfies/selfie117.png", "selfies/selfie118.png", "selfies/selfie119.png", "selfies/selfie120.png",
            "selfies/selfie121.png", "selfies/selfie122.png", "selfies/selfie123.png", "selfies/selfie124.png",
            "selfies/selfie125.png", "selfies/selfie126.png", "selfies/selfie127.png", "selfies/selfie128.png",
            "selfies/selfie129.png", "selfies/selfie130.png", "selfies/selfie131.png", "selfies/selfie132.png",
            "selfies/selfie133.png", "selfies/selfie134.png", "selfies/selfie135.png", "selfies/selfie136.png",
            "selfies/selfie137.png", "selfies/selfie138.png", "selfies/selfie139.png", "selfies/selfie140.png",
            "selfies/selfie141.png", "selfies/selfie142.png", "selfies/selfie143.png", "selfies/selfie144.png",
            "selfies/selfie145.png", "selfies/selfie146.png", "selfies/selfie147.png", "selfies/selfie148.png",
            "selfies/selfie149.png", "selfies/selfie150.png", "selfies/selfie151.png", "selfies/selfie152.png",
            "selfies/selfie153.png", "selfies/selfie154.png", "selfies/selfie155.png", "selfies/selfie156.png",
            "selfies/selfie157.png", "selfies/selfie158.png", "selfies/selfie159.png", "selfies/selfie160.png",
            "selfies/selfie161.png", "selfies/selfie162.png", "selfies/selfie163.png", "selfies/selfie164.png",
            "selfies/selfie165.png", "selfies/selfie166.png", "selfies/selfie167.png", "selfies/selfie168.png",
            "selfies/selfie169.png", "selfies/selfie170.png", "selfies/selfie171.png", "selfies/selfie172.png",
            "selfies/selfie173.png", "selfies/selfie174.png", "selfies/selfie175.png", "selfies/selfie176.png",
            "selfies/selfie177.png",
        };
    }


    /*
     * Sets up idle text array
     */
    private void setUpIdles()
    {
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
        //pout command
        commands.CreateCommand("pout")
            .Do(async (e) =>
            {
                int randomPoutIndex = rand.Next(pouts.Length);
                string poutToPost = pouts[randomPoutIndex];

                await e.Channel.SendFile(poutToPost);
            });


        //sends smug image
        commands.CreateCommand("smug")
            .Do(async (e) =>
            {
                int randomSmugIndex = rand.Next(smugs.Length);
                string smugToPost = smugs[randomSmugIndex];

                await e.Channel.SendFile(smugToPost);
            });


        //sends selfie image
        commands.CreateCommand("selfie")
            .Do(async (e) =>
            {
                int randomSelfieIndex = rand.Next(selfies.Length);
                string selfieToPost = selfies[randomSelfieIndex];

                await e.Channel.SendFile(selfieToPost);
            });


        //sends idle text
        commands.CreateCommand("idle")
            .Do(async (e) =>
            {
                int randomIdleIndex = rand.Next(idleTexts.Length);
                string idleToPost = idleTexts[randomIdleIndex];

                await e.Channel.SendMessage(idleToPost);
            });


        //delete messages (100 at  a time)
        commands.CreateCommand("purge")
            .Do(async (e) =>
            {
                Message[] messagesToDelete;
                messagesToDelete = await e.Channel.DownloadMessages(100);

                await e.Channel.DeleteMessages(messagesToDelete);
            });


        //targeted hello/bye, h* group
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


        //server owner hello command
        commands.CreateCommand("hello")
           .Description("Greets server owner")
           .Do(async (e) =>
           {
               string userName = (e.Server.Owner.Nickname != null) ? e.User.Nickname : e.User.Name;

               await e.Channel.SendMessage("hi " + userName + " <3");
           });


        //server owner goodbye command
        commands.CreateCommand("bye")
          .Description("Says bye to server owner")
          .Do(async (e) =>
          {
              string userName = (e.Server.Owner.Nickname != null) ? e.User.Nickname : e.User.Name;

              await e.Channel.SendMessage("goodbye " + userName + " <3");
          });


        //replies to \<3 with <3
        _client.MessageReceived += async (s, e) =>
        {
            string message;
            if((e.Server.Owner.Id == e.Message.User.Id) && e.Message.RawText.Contains("\\<3"))
            {
                message = "<3";

                await e.Channel.SendMessage(message);
            }
        };


        //merk fair desu
        _client.MessageReceived += async (s, e) =>
        {
            string message = "fair";
            if (e.Message.User.Name.Contains("Merk") && e.Message.RawText.Contains("fair"))
            {
                message += " desu";

                await e.Channel.SendMessage(message);
            }
        };


        //ayy lmao desu!
        _client.MessageReceived += async (s, e) =>
        {
            string message;
            if(e.Message.RawText.Contains("ayy"))
            {
                message = "lmao desu!";

                await e.Channel.SendMessage(message);
            }
        };


        //6 sided dice roll
        commands.CreateCommand("roll")
            .Description("rolls a 6 sided dice")
            .Do(async (e) =>
            {
                int roll = rand.Next(5) + 1;

                await e.Channel.SendMessage("You rolled a " + roll);
            });


        //random number :^)
        commands.CreateCommand("random")
            .Description("generates a random number between 1 and 100")
            .Do(async (e) =>
            {
                int random = 4;

                await e.Channel.SendMessage("Your random number is: " + random);
            });


        //flip coin
        commands.CreateCommand("coin")
            .Description("flips a coin")
            .Do(async (e) =>
            {
                int random = rand.Next(2);
                string message = (random == 0) ? "heads" : "tails";

                await e.Channel.SendMessage(e.Message.User.Mention + " I choose " + message + " desu!");
            });


        //pick an option from the list, separated by a "|"
        _client.MessageReceived += async (s, e) =>
        {
            if (!e.Message.RawText.Contains("!pick") || e.Message.User.IsBot)
                return;
            //command format: !pick something | something else | something | something | something

            string message = e.Message.RawText;

            if (message.Contains("!pick") && !message.Contains("|"))
                await e.Channel.SendMessage("that is not the correct format for the command, desu!");

            message = message.Remove(0, 5); //remove command from string
            string[] options = message.Split('|'); //split into options based on char '|'

            int random = rand.Next(options.Length);
            for (int i = 0; i < options.Length; i++)
            {
               if(options[i].IndexOf(" ").Equals(0)) //if first char is space
                    options[i] = options[i].Remove(0, 1); //remove space before option text
                if (options[i].LastIndexOf(" ").Equals(options[i].Length - 1)) //if last char is a space
                    options[i] = options[i].Remove(options[i].Length - 1, 1); //remove it
            }
            string optionToSend = options[random];

            await e.Channel.SendMessage(e.Message.User.Mention + " I choose " + optionToSend + " desu!");
        };


        //generates invite link invite
        commands.CreateCommand("invite")
            .Description("generates an invite link for the bot")
            .Do(async (e) =>
            {
                string inviteLink = "https://discordapp.com/oauth2/authorize?client_id=285402443041210368&permissions=2146958463&scope=bot";

                await e.Channel.SendMessage("You can invite me from " + inviteLink + " <3");
            });
        
        
        //bot offline
        commands.CreateCommand("sleep")
            .Description("puts bot to sleep - offline")
            .Do(async (e) =>
            {
                string userName = (e.Server.Owner.Nickname != null) ? e.User.Nickname : e.User.Name;
                await e.Channel.SendMessage("goodnight " + userName + " <3"); //inform user of shutting down

                Stop();
            });
    }


    /*
     *  Util function for logging
     */
    private void Log(object sender, LogMessageEventArgs e)
    {
        Console.WriteLine($"[{e.Severity}] [{e.Source}] { e.Message }");
    }


    /*
     *  Util function for loading and parsing json
     */
     private string LoadJson(string filePath)
    {
        using (System.IO.StreamReader file = System.IO.File.OpenText(filePath))
        using (var reader = new Newtonsoft.Json.JsonTextReader(file))
        {
            var jObject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);
            var token = jObject.GetValue("token");
            string stringToken = (string)token;

            return stringToken;
        }
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
            try
            {
                string token = LoadJson("auth.json");
                await _client.Connect(token, TokenType.Bot);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
        });
    }

    /*
     * Method that is called when the !sleep command 
     * is used. Disconnects client from gateway socket
     * and disposes of client resources.
     */
    private void Stop()
    {
        _client.ExecuteAndWait(async () =>
        {
            await _client.GatewaySocket.Disconnect();
            _client.Dispose();
        });
    }
}
