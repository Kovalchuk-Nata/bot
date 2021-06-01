using kursovaya.Clients;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace jop.Clients
{
    
    public class tgclient
    {
        private readonly RecipeClients client_tg = new RecipeClients();

        public async void RandomRecipe1(TelegramBotClient bot, int id)
        {
            var randrecipe = await client_tg.GetRandomRecipe();
            await bot.SendTextMessageAsync(id, randrecipe.Recipes[0].GetRecipe(), parseMode: ParseMode.Html);
        } 

    }
}
