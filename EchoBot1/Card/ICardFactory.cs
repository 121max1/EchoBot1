using Microsoft.Bot.Schema;

namespace EchoBot1.Card
{
    public interface ICardFactory
    {
        Attachment GetDateTimeCard();
    }
}
