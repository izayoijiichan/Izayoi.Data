// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : BindParameterCollection
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    /// <summary>
    /// Bind Parameter Collection
    /// </summary>
    public class BindParameterCollection :
        DbParameterCollection<BindParameter>,
        IBindParameterCollection
    {
    }
}
