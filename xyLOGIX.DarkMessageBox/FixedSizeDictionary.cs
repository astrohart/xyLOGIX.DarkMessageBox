using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyLOGIX.DarkMessageBox
{
    /// <summary>
    /// A dictionary whose key set is fixed after construction; the caller can
    /// read or overwrite <typeparamref name="TValue" /> for existing keys, but any
    /// attempt to add, remove or clear throws
    /// <see cref="T:System.NotSupportedException" />.
    /// </summary>
    public sealed class
        FixedSizeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> interface that is the
        /// source of the item(s) for this collection.
        /// </summary>
        private readonly IDictionary<TKey, TValue> _inner;

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.DarkMessageBox.FixedSizeDictionary" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="source">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> interface that is the
        /// source of the item(s) for this collection.
        /// </param>
        public FixedSizeDictionary(IDictionary<TKey, TValue> source)
            => _inner =
                source ?? throw new ArgumentNullException(nameof(source));

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.DarkMessageBox.FixedSizeDictionary" /> and returns a
        /// reference to it.
        /// </summary>
        public FixedSizeDictionary()
            => _inner = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Gets the number of elements contained in the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count
        {
            [DebuggerStepThrough] get => _inner.Count;
        }

        /// <summary>
        /// Gets a value indicating whether the
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public bool IsReadOnly
        {
            [DebuggerStepThrough] get => false;

            // we *are* writable
        }

        /// <summary>Gets or sets the element with the specified key.</summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.Collections.Generic.KeyNotFoundException">
        /// The
        /// property is retrieved and <paramref name="key" /> is not found.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The property is set and the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public TValue this[TKey key]
        {
            [DebuggerStepThrough] get => _inner[key];
            [DebuggerStepThrough]
            set
            {
                if (!_inner.ContainsKey(key)) ThrowAdd();
                _inner[key] = value;
            }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1" />
        /// containing the keys of the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1" />
        /// containing the keys of the object that implements
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection<TKey> Keys
        {
            [DebuggerStepThrough] 
            get { return _inner.Keys; }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1" />
        /// containing the values in the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1" />
        /// containing the values in the object that implements
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection<TValue> Values
        {
            [DebuggerStepThrough] 
            get { return _inner.Values; }
        }

        /// <summary>
        /// Adds an item to the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">
        /// The object to add to the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        /// The
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Add(KeyValuePair<TKey, TValue> item)
            => ThrowAdd();

        /// <summary>
        /// Removes all items from the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Clear()
            => ThrowRemove();

        /// <summary>
        /// Determines whether the
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific
        /// value.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="item" /> is found in the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise,
        /// <see langword="false" />.
        /// </returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
            => _inner.Contains(item);

        /// <summary>
        /// Copies the elements of the
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> to an
        /// <see cref="T:System.Array" />, starting at a particular
        /// <see cref="T:System.Array" /> arrayIndex.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="T:System.Array" /> that is
        /// the destination of the elements copied from
        /// <see cref="T:System.Collections.Generic.ICollection`1" />. The
        /// <see cref="T:System.Array" /> must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based arrayIndex in <paramref name="array" />
        /// at which copying begins.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="array" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="arrayIndex" /> is less than 0.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The number of elements in the
        /// source <see cref="T:System.Collections.Generic.ICollection`1" /> is greater
        /// than the available space from <paramref name="arrayIndex" /> to the end of the
        /// destination <paramref name="array" />.
        /// </exception>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            => _inner.CopyTo(array, arrayIndex);

        /// <summary>
        /// Removes the first occurrence of a specific object from the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">
        /// The object to remove from the
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="item" /> was successfully removed
        /// from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise,
        /// <see langword="false" />. This method also returns <see langword="false" /> if
        /// <paramref name="item" /> is not found in the original
        /// <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The
        /// <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public bool Remove(KeyValuePair<TKey, TValue> item)
            => ThrowRemove();

        /// <summary>
        /// Adds an element with the provided key and value to the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// An element with the same key
        /// already exists in the <see cref="T:System.Collections.Generic.IDictionary`2" />
        /// .
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public void Add(TKey key, TValue value)
            => ThrowAdd();

        /// <summary>
        /// Determines whether the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element
        /// with the specified key.
        /// </summary>
        /// <param name="key">
        /// The key to locate in the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element
        /// with the key; otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key" /> is <see langword="null" />.
        /// </exception>
        public bool ContainsKey(TKey key)
            => _inner.ContainsKey(key);

        /// <summary>
        /// Removes the element with the specified key from the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// <see langword="true" /> if the element is successfully removed; otherwise,
        /// <see langword="false" />.  This method also returns <see langword="false" /> if
        /// <paramref name="key" /> was not found in the original
        /// <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public bool Remove(TKey key)
            => ThrowRemove();

        /// <summary>Gets the value associated with the specified key.</summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        /// When this method returns, the value associated with the
        /// specified key, if the key is found; otherwise, the default value for the type
        /// of the <paramref name="value" /> parameter. This parameter is passed
        /// uninitialized.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the object that implements
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element
        /// with the specified key; otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key" /> is <see langword="null" />.
        /// </exception>
        public bool TryGetValue(TKey key, out TValue value)
            => _inner.TryGetValue(key, out value);

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be
        /// used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => _inner.GetEnumerator();

        /// <summary>
        /// Throws <see cref="T:System.NotSupportedException" /> that indicates that adding
        /// new keys is not permitted.
        /// </summary>
        /// <returns><see langword="false" /> in every event.</returns>
        /// <exception cref="T:System.NotSupportedException">
        /// Dictionary is fixed-size –
        /// adding new keys is not permitted.
        /// </exception>
        private static void ThrowAdd()
            => throw new NotSupportedException(
                "Dictionary is fixed-size – adding new keys is not permitted."
            );

        /// <summary>
        /// Throws <see cref="T:System.NotSupportedException" /> that indicates that
        /// removing elements from this collection is not allowed.
        /// </summary>
        /// <returns><see langword="false" /> in every event.</returns>
        /// <exception cref="T:System.NotSupportedException">
        /// Dictionary is fixed-size –
        /// keys cannot be removed.
        /// </exception>
        private static bool ThrowRemove()
            => throw new NotSupportedException(
                "Dictionary is fixed-size – keys cannot be removed."
            );
    }
}