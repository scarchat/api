using GraphQL.Types;

namespace Scar.Entities.Models
{
    public sealed class MessageGraph : ObjectGraphType<Message>
    {
        public MessageGraph()
        {
            Name = "message";
            Description = "A text message sent by users on the Scar platform.";

            Field(m => m.Id)
                .Name("id")
                .Description("The unique identifier of the message.");

            Field(m => m.Content)
                .Name("content")
                .Description("The raw content of the message.");

            Field<UserGraph>()
                .Name("author")
                .Description("The author of the message.");
        }
    }
}