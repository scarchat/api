using GraphQL;
using GraphQL.Types;

namespace Scar.Entities
{
    public sealed class ScarChatSchema : Schema
    {
        public ScarChatSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ScarChatQuery>();
            Mutation = resolver.Resolve<ScarChatMutation>();
        }
    }
}