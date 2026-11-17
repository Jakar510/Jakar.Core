// Jakar.Extensions :: Jakar.Extensions
// 09/10/2024  21:09

namespace Jakar.Extensions;


public interface IObservableObject : INotifyPropertyChanging, INotifyPropertyChanged
{
    [NotifyPropertyChangedInvocator] public void OnPropertyChanged( [CallerMemberName] string property = "" );
    [NotifyPropertyChangedInvocator] public void OnPropertyChanged( PropertyChangedEventArgs  e );


    public void OnPropertyChanging( [CallerMemberName] string property = "" );
    public void OnPropertyChanging( PropertyChangingEventArgs e );


    bool SetPropertyWithoutNotify<TValue>( ref TValue backingStore, TValue value );
    bool SetProperty<TValue>( ref              TValue backingStore, TValue value, [CallerMemberName] string propertyName = "" );
}



public static class ObservableObjects
{
    public static readonly ConcurrentDictionary<string, PropertyChangedEventArgs>  PropertyChangedEventArgsCache  = new(StringComparer.Ordinal);
    public static readonly ConcurrentDictionary<string, PropertyChangingEventArgs> PropertyChangingEventArgsCache = new(StringComparer.Ordinal);



    extension( string property )
    {
        public PropertyChangedEventArgs  AsPropertyChangedEventArgs()  => PropertyChangedEventArgsCache.GetOrAdd(property ?? throw new ArgumentNullException(nameof(property)), static x => new PropertyChangedEventArgs(x));
        public PropertyChangingEventArgs AsPropertyChangingEventArgs() => PropertyChangingEventArgsCache.GetOrAdd(property ?? throw new ArgumentNullException(nameof(property)), static x => new PropertyChangingEventArgs(x));
    }
}
