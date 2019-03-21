using System.Windows.Controls;

namespace Practice7UserList.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
