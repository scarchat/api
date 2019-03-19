using GraphQL.Types;

namespace Scar.Entities.Models
{
    public sealed class UserGroupGraph : ObjectGraphType<UserGroup>
    {
        public UserGroupGraph()
        {
            Field(g => g.Id)
                .Name("id")
                .Description("The unique identifier of the usergroup.");

            Field(g => g.Name)
                .Name("name")
                .Description("The name of the usergroup");

            Field(g => g.Color)
                .Name("color")
                .Description("The base-10 color integer to be interpreted as a hex color code.");

            Field<NodePermissionsGraph>()
                .Name("nodePermissions")
                .Description("Node-level permissions of this usergroup.");

            Field<ListGraphType<ChannelPermissionsGraph>>()
                .Name("channelPermissions")
                .Description("Channel-level permissions of this usergroup.");
        }
    }
}