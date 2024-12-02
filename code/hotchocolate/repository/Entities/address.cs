using EntityFrameworkCore.Projectables;
using graph.Entities;

namespace repository.Models;

public partial class address : ICommon
{
    [Projectable(UseMemberBody = nameof(MyId))]
    public int Id { get; private set; }

    [Projectable]
    internal int MyId => addressid;

    [Projectable(UseMemberBody = nameof(MyFunc))]
    public string FullAddress { get; private set; }

    [Projectable]
    internal string MyFunc => $"{addressline1}-{addressline2}-{postalcode}:{BaFunc}";

    [Projectable]
    internal string? BaFunc => businessentityaddresses != null ? businessentityaddresses.First().addresstype.name : "none";
}
