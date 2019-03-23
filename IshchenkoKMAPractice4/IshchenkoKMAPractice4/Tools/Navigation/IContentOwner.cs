using System.Windows.Controls;

namespace IshchenkoKMAPractice4.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}