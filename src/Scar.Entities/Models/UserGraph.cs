using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scar.Entities.Models
{
    public sealed class UserGraph : ObjectGraphType<User>
    {
        public UserGraph()
        {
            Name = "user";
            Description = "The base, universal type for users of the Scar platform.";

            Field(u => u.Id)
                .Name("id");

            Field(u => u.Name)
                .Name("username");

            Field(u => u.CdnIcon, nullable: true)
                .Name("cdn_icon");
        }
    }
}
