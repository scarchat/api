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
            Field(u => u.Id)
                .Name("id");

            Field(u => u.Name)
                .Name("username");

            Field(u => u.CdnIcon, nullable: true)
                .Name("cdn_icon");
        }
    }
}
