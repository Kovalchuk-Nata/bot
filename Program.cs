using jop.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
//using tg_bot.Clients;

namespace jop
{
    class Program
    {


        static TelegramBotClient botClient;
        public static string Key { get; set; } = "1682945822:AAE4_8O9Q-1aaEHF-6VuQ5zT_D3450yXWBk"; // api-ключ бота


        public static void Main(string[] args)

        {
            botClient = new TelegramBotClient(Key);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            botClient.OnMessage += Bot_WhoUse;

            botClient.OnMessage += Bot_OnMessage;
            botClient.OnMessage += My_buttons;

            botClient.StartReceiving(); // бот следит за обновлениями в чатах

            Console.ReadKey();

            botClient.StopReceiving();
            //CreateHostBuilder(args).Build().Run();


        }
        public static void Bot_WhoUse(object sender, MessageEventArgs e) // 
        {
            var message = e.Message;
            string name = $"{message.From.FirstName}";
            Console.WriteLine($"{name} прислал: '{message.Text}'");
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) // 
        {
            if (e.Message.Text == "/help")
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: "Привет! Давай немного расскажу тебе о том что может этот бот! \n🍭 Получить рандомный рецепт\n🍭 Рецепт по названию\n🍭Чтоб увидеть все методы тыкни на /menu");
            }

            if (e.Message.Text == "/start")
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: "Привет! Можешь потыкать менюшку /menu или почитать что ты вообще можешь здесь найти /help");
            }

            //if (e.Message.Text == "random recipe") //ответочки на сообщение
            //{
            //    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "*когда-то здесь будет рандомный рецепт*",
            //           replyToMessageId: e.Message.MessageId);
            //}

            //if (e.Message.Text == "recipe by name")
            //{
            //    await botClient.SendTextMessageAsync(e.Message.Chat.Id, "*когда-то здесь будет рецепт по названию*",
            //           replyToMessageId: e.Message.MessageId);
            //}
        }

        static async void My_buttons(object sender, MessageEventArgs e)

        {
            var message = e.Message;
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            if (e.Message.Text == "/menu")
            {
                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                {
                    Keyboard = new[] {
                                   new[] // первый этаж
                                   {
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("random recipe 🍳"),
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("recipe by name 🌮"),

                                   },
                                   new[] // второй
                                   {
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("my recipe 👩🏻‍🍳"),
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("cooking tips 🥘"),
                                   },
                                   new[] //третий
                                   {
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("healthy food 🥗"),
                                   }
                                            },
                    ResizeKeyboard = true
                };

                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Выбирай, тут много всякого 🍒", default, false, false, 0, keyboard, token);
            }

            if (e.Message.Text == "random recipe 🍳")
            {
                var recipe = new tgclient();
                recipe.RandomRecipe1(botClient, message.From.Id);
               


            }

            if (e.Message.Text == "recipe by name 🌮")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "когда я добавлю сюда нормально апишку то оно здесь будет", replyToMessageId: e.Message.MessageId);
            }

            if (e.Message.Text == "my recipe 👩🏻‍🍳")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "и базу данных добавлю 😉 \nдобавишь свой рецепт, уговорил", replyToMessageId: e.Message.MessageId);
            }

            if (e.Message.Text == "cooking tips 🥘")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "и советы здесь будут 😉", replyToMessageId: e.Message.MessageId);
            }

            if (e.Message.Text == "healthy food 🥗")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "а тут еда полезная будет 🥗", replyToMessageId: e.Message.MessageId);
            }



        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }

}
