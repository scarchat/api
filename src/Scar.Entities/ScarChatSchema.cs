using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

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
