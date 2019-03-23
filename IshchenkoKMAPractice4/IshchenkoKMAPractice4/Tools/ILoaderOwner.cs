using System.ComponentModel;

namespace IshchenkoKMAPractice4.Tools
{
    public interface ILoaderOwner : INotifyPropertyChanged
    {
        bool IsControlEnabled { get; set; }
    }
    
}
    
