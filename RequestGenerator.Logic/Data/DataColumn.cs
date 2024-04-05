using System.Collections;

namespace RequestGenerator.Logic.Data;

public class DataColumn : IList<string>
{
    private readonly List<string> data = new();

    public DataColumn(string header)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(header);

        Header = header;
    }

    public int MaxIndex => data.Count - 1;

    internal string Header { get; }

    /// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
    /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1" /> is
    /// read-only.
    /// </exception>
    public void Add(string item)
    {
        data.Add(item);
    }

    /// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.</summary>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1" /> is
    /// read-only.
    /// </exception>
    public void Clear()
    {
        data.Clear();
    }

    /// <summary>Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.</summary>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
    /// <returns>
    /// <see langword="true" /> if <paramref name="item" /> is found in the
    /// <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />.
    /// </returns>
    public bool Contains(string item) => data.Contains(item);

    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an
    /// <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
    /// </summary>
    /// <param name="array">
    /// The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
    /// from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based
    /// indexing.
    /// </param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="array" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="arrayIndex" /> is less than 0.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// The number of elements in the source
    /// <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the available space from
    /// <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.
    /// </exception>
    public void CopyTo(string[] array, int arrayIndex)
    {
        data.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the
    /// <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1" /> is
    /// read-only.
    /// </exception>
    /// <returns>
    /// <see langword="true" /> if <paramref name="item" /> was successfully removed from the
    /// <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, <see langword="false" />. This method also
    /// returns <see langword="false" /> if <paramref name="item" /> is not found in the original
    /// <see cref="T:System.Collections.Generic.ICollection`1" />.
    /// </returns>
    public bool Remove(string item) => data.Remove(item);

    public int Count => data.Count;

    /// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</summary>
    /// <returns>
    /// <see langword="true" /> if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise,
    /// <see langword="false" />.
    /// </returns>
    public bool IsReadOnly => ((IList<string>)data).IsReadOnly;

    /// <summary>Returns an enumerator that iterates through a collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)data).GetEnumerator();

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<string> GetEnumerator() => data.GetEnumerator();

    /// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.</summary>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
    /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
    public int IndexOf(string item) => data.IndexOf(item);

    /// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.</summary>
    /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
    /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
    public void Insert(int index, string item)
    {
        data.Insert(index, item);
    }

    /// <summary>Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.</summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
    public void RemoveAt(int index)
    {
        data.RemoveAt(index);
    }

    /// <summary>Gets or sets the element at the specified index.</summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The property is set and the
    /// <see cref="T:System.Collections.Generic.IList`1" /> is read-only.
    /// </exception>
    /// <returns>The element at the specified index.</returns>
    public string this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }
}