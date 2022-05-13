using System;
using System.IO;
using AdaptiveCards;
using AdaptiveCards.Templating;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace EchoBot1.Card
{
    public class CardFactory : ICardFactory
    {
        private const string SelectCardTypeCardTemplatePath = "{0}\\assets\\templates\\datetime-card.json";

        public CardFactory()
        {

        }

        public Attachment GetDateTimeCard()
        {
            var template = GetCardTemplate(SelectCardTypeCardTemplatePath);
            var data = new 
            {
                Date = DateTime.Now
            };
            var serializedJson = template.Expand(data);
            return CreateAttachment(serializedJson);
        }

        private static AdaptiveCardTemplate GetCardTemplate(string templatePath)
        {
            templatePath = string.Format(templatePath, AppDomain.CurrentDomain.BaseDirectory);
            return new AdaptiveCardTemplate(File.ReadAllText(templatePath));
        }

        private static Attachment CreateAttachment(string adaptiveCardJson)
        {
            var adaptiveCard = AdaptiveCard.FromJson(adaptiveCardJson);
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
        }
    }
}
