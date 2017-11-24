//WebConfig
<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=301879
  -->
<configuration>
  <appSettings>
    <!-- update these with your BotId, Microsoft App Id and your Microsoft App Password-->
    <add key="BotId" value="SheChat" />
    <add key="MicrosoftAppId" value="63b2acb9-e119-4dab-b047-c893742c5ab0" />
    <add key="MicrosoftAppPassword" value="nkmdTBKO6**{vcaNNV7693=" />
  </appSettings>
  <!--
    For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

    The following attributes can be set on the <httpRuntime> tag.
      <system.Web>
        <httpRuntime targetFramework="4.6" />
      </system.Web>
  -->
  <system.web>
    <customErrors mode="Off" /> 
    <compilation debug="true" targetFramework="4.6" />
    <httpRuntime targetFramework="4.6" />
  </system.web>
  <system.webServer>
    <defaultDocument>
      <files>
        <clear />
        <add value="default.htm" />
      </files>
    </defaultDocument>
    
  <handlers>
      <remove name="ExtensionlessUrlHandler-Integrated-4.0" />
      <remove name="OPTIONSVerbHandler" />
      <remove name="TRACEVerbHandler" />
      <add name="ExtensionlessUrlHandler-Integrated-4.0" path="*." verb="*" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
    </handlers></system.webServer>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Newtonsoft.Json" publicKeyToken="30ad4fe6b2a6aeed" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-8.0.0.0" newVersion="8.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http.Primitives" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-4.2.29.0" newVersion="4.2.29.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="Microsoft.Bot.Connector" publicKeyToken="31bf3856ad364e35" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-3.11.1.0" newVersion="3.11.1.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>


//MessagesController
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {         
        /// <summary>         
        /// /// POST: api/Messages         
        /// /// Receive a message from a user and reply to it         
        /// /// </summary>         
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here                 
                // If we handle user deletion, return a real message             
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed                 
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info                 
                // Not available in all channels             
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists                 
                // Activity.From + Activity.Action represent what happened             
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing             
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            return null;
        }
    }
}


//RootDialog
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Dialogs
{
    [LuisModel("13801d36-6581-473b-b027-de9f42b3eac8", "1d1c7b400e204561a89265c35c922aed")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        /*         public Task StartAsync(IDialogContext context)         
         *         {             
         *         context.Wait(MessageReceivedAsync);             
         *         return Task.CompletedTask;         
         *         }         
         *         private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)         
         *         {             
         *         var activity = await result as Activity;             
         *         // calculate something for us to return             
         *         int length = (activity.Text ?? string.Empty).Length;             
         *         // return our reply to the user             
         *         await context.PostAsync($"You sent {activity.Text} which was {length} characters");             
         *         context.Wait(MessageReceivedAsync);         
         *         }                 
         *         [LuisIntent("None")]         
         *         public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)         
         *         {             
         *         await context.PostAsync($@"You are in Intent");             
         *         context.Wait(MessageReceivedAsync);         
         *         }     
         *         }     */
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";
            await context.PostAsync(message); context.Wait(this.MessageReceived);
        }
        [LuisIntent("greetings")]
        public async Task greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Você disse: '{result.Query}'. Olá para você.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}













using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {                
            }

            return null;
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Dialogs
{
    [LuisModel("13801d36-6581-473b-b027-de9f42b3eac8", "1d1c7b400e204561a89265c35c922aed")]
    [Serializable]

    public class RootDialog : LuisDialog<object>
    {
        /*
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
        

        [LuisIntent("None")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.PostAsync($@"You are in Intent");

            context.Wait(MessageReceivedAsync);
        }
    }
    */
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("greetings")]
        public async Task greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Você disse: '{result.Query}'. Olá para você.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
    }
}























[LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Desculpa, Não consegui entender o que você quis dizer com: '{result.Query}'. Digite 'Ajuda', e eu vou tentar te ajudar.";

            await context.PostAsync(message);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = "ClearGreeting";
            try
            {
                if ((context.Activity.LocalTimestamp.Value.UtcDateTime.TimeOfDay.Hours) < 13)
                {
                    message = $"Bom dia '{context.Activity.From.Name}', ta tudo bem contigo hoje?";
                }
                else if ((context.Activity.LocalTimestamp.Value.UtcDateTime.TimeOfDay.Hours) < 20)
                {
                    message = $"Boa tarde '{context.Activity.From.Name}', ta tudo bem contigo hoje?";
                }
                else
                {
                    message = $"Boa noite '{context.Activity.From.Name}', ta tudo bem contigo hoje?";
                }
            }catch(InvalidIntentHandlerException e)
            {
                message = "Deu pau no sisteminha amigo.";
            }
            

            await context.PostAsync(message);
        }

        [LuisIntent("DeliveryTax")]
        public async Task DeliveryTax(IDialogContext context, LuisResult result)
        {
            string message = "ClearDeliveryTax";

            message = "Para pedidos abaixo de 50 reais, hoje cobramos uma taxa de 10 reais. Porém isso pode mudar quando tivermos um fluxo maior de usuários utilizando o aplicativo e o frete seja por nossa conta para voces ;)";
            await context.PostAsync(message);
        }

        [LuisIntent("Deadline")]
        public async Task Deadline(IDialogContext context, LuisResult result)
        {
            string message = "ClearDeadline";

            message = "O prazo final de devolução é de 72 horas ou 3 dias (:p) após a coleta.";

            await context.PostAsync(message);
        }

        [LuisIntent("Gathering")]
        public async Task Gathering(IDialogContext context, LuisResult result)
        {
            string message = "ClearGathering";

            message = "Hoje nós estamos coletando roupas nas segundas e quintas, das 18h as 22h... Maaas, quando estivermos maiores, todo dia será dia de lavar roupa ;)";

            await context.PostAsync(message);
        }

        [LuisIntent("Plan")]
        public async Task Plan(IDialogContext context, LuisResult result)
        {
            string message = "ClearPlan";

            message = "No momento estamos com nossos planos dentro da lava roupa, assim que eles estiverem dobrados e pronto para uso, avisaremos você. Tem alguma ideia de como você gostaria do plano? Solteiro, casado, empresa... E um contato para podermos te avisar em primeira mão assim que sair os planos!!!";

            await context.PostAsync(message);
        }

        [LuisIntent("Price")]
        public async Task Price(IDialogContext context, LuisResult result)
        {
            string message = "ClearPrice";

            message = "Analisar esta resposta de acordo com preços, se houver como trazer o preço da peça de acordo com o cep da pessoa.";

            await context.PostAsync(message);
        }
