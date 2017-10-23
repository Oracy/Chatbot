using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace Lerning.Dialogs
{
    [Serializable]
    public class GreetingDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Olá, bem-vindo ao LavandApp");
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var user = "a";
            var getName = false;
            context.UserData.TryGetValue<string>("Name", out user);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                user = message.Text;
                context.UserData.SetValue<string>("Name", user);
                context.UserData.SetValue<bool>("GetName", false);
            }

            if (string.IsNullOrEmpty(user))
            {
                await context.PostAsync("Qual o seu nome?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("Olá " + message.From.Name + ". Como podemos te ajudar hoje?"));
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}