using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation.Collections;

namespace DribbbleForWindowsPhone.Common
{
    /// <summary>
    /// Implementation of IObservableMap that supports reentrancy for use as a default view model.
    /// </summary>
    public class ObservableDictionary : IObservableMap<string, object>
    {
        #region Fields
        
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        #endregion Fields

        #region Events

        /// <summary>
        /// Event thar occurs when the Map has changed.
        /// </summary>
        public event MapChangedEventHandler<string, object> MapChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Returns the keys of the dictionary.
        /// </summary>
        public ICollection<string> Keys
        {
            get { return this._dictionary.Keys; }
        }

        /// <summary>
        /// Returns the values contained in the dictionary.
        /// </summary>
        public ICollection<object> Values
        {
            get { return this._dictionary.Values; }
        }

        /// <summary>
        /// The number of elements in the dictionary.
        /// </summary>
        public int Count
        {
            get { return this._dictionary.Count; }
        }

        /// <summary>
        /// Returns false.
        /// </summary>
        /// <remarks>Means which this dictionary is read-write.</remarks>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Index the dictionary using a valid key.
        /// </summary>
        /// <param name="key">A Key of the dictionary.</param>
        /// <returns>Returns an element of the dictionary with </returns>
        public object this[string key]
        {
            get
            {
                return this._dictionary[key];
            }
            set
            {
                this._dictionary[key] = value;
                this.InvokeMapChanged(CollectionChange.ItemChanged, key);
            }
        }

        #endregion Indexers

        #region Methods

        #region Private

        private void InvokeMapChanged(CollectionChange change, string key)
        {
            var eventHandler = MapChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new ObservableDictionaryChangedEventArgs(change, key));
            }
        }

        #endregion Private

        #region Public

        /// <summary>
        /// Add a new element in the dictionary.
        /// </summary>
        /// <param name="key">A key for the new element.</param>
        /// <param name="value">The value of the new element.</param>
        public void Add(string key, object value)
        {
            this._dictionary.Add(key, value);
            this.InvokeMapChanged(CollectionChange.ItemInserted, key);
        }

        /// <summary>
        /// Add new key value pair in the dictionary.
        /// </summary>
        /// <param name="item">A key value pair.</param>
        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes a element with a specific key.
        /// </summary>
        /// <param name="key">The key of the element to be removed.</param>
        /// <returns>True if the element was removed, otherwise, false.</returns>
        public bool Remove(string key)
        {
            if (this._dictionary.Remove(key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a specific key value pair.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            object currentValue;
            if (this._dictionary.TryGetValue(item.Key, out currentValue) &&
                Object.Equals(item.Value, currentValue) && this._dictionary.Remove(item.Key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clear the dictionary.
        /// </summary>
        public void Clear()
        {
            var priorKeys = this._dictionary.Keys.ToArray();
            this._dictionary.Clear();
            foreach (var key in priorKeys)
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
            }
        }

        /// <summary>
        /// Checks if a specific key is contained in the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to be checked.</param>
        /// <returns>True, if is contained, otherwise, false.</returns>
        public bool ContainsKey(string key)
        {
            return this._dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Checks if a specific key value pair is contained in the dictionary.
        /// </summary>
        /// <param name="item">The key value pair.</param>
        /// <returns>True, if is contained, otherwise, false.</returns>
        public bool Contains(KeyValuePair<string, object> item)
        {
            return this._dictionary.Contains(item);
        }

        /// <summary>
        /// Tries to get a element with a specific key, and put in a out parameter.
        /// </summary>
        /// <param name="key">The key of the element that it was attempt to get.</param>
        /// <param name="value">The variable that can be contain the get value.</param>
        /// <returns>True, if the value was getted, otherwise, false.</returns>
        public bool TryGetValue(string key, out object value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Get an enumerator of this dictionary.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }        

        /// <summary>
        /// Copy this dictionary inside of a array key value pair from a array index.
        /// </summary>
        /// <param name="array">The array to copy to.</param>
        /// <param name="arrayIndex">The initial index to past the copy.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            int arraySize = array.Length;
            foreach (var pair in this._dictionary)
            {
                if (arrayIndex >= arraySize) break;
                array[arrayIndex++] = pair;
            }
        }

        #endregion Public

        #endregion Methods

        #region IEnumerable member

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        #endregion IEnumerable member
    }
}
