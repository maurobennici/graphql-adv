using EntityFrameworkCore.Projectables;
using graph.Entities;

namespace repository.Models;

public partial class purchaseorderheader : ICommon
{
    [Projectable(UseMemberBody = nameof(MyId))]
    public int Id { get; private set; }

    [Projectable]
    internal int MyId => purchaseorderid;
}