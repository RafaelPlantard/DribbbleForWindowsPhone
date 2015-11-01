using Windows.Foundation.Collections;

namespace DribbbleForWindowsPhone.Common
{
    internal class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
    {
        #region Constructors

        public ObservableDictionaryChangedEventArgs(CollectionChange change, string key)
        {
            this.CollectionChange = change;
            this.Key = key;
        }

        #endregion Constructors

        #region IMapChangedEventArgs members

        public CollectionChange CollectionChange { get; private set; }

        public string Key { get; private set; }

        #endregion IMapChangedEventArgs members
    }
}
