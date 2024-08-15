// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Interface : IDbParameterCollection
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;

    /// <summary>
    /// DB Parameter Collection Interface
    /// </summary>
    public interface IDbParameterCollection<TDbParameter> : IEnumerable<TDbParameter>
        where TDbParameter : DbParameter
    {
        #region Properties

        /// <summary>Specifies the number of items in the collection.</summary>
        int Count { get; }

        /// <summary>Specifies whether the collection is a fixed size.</summary>
        bool IsFixedSize { get; }

        /// <summary>Specifies whether the collection is read-only.</summary>
        bool IsReadOnly { get; }

        /// <summary>Specifies whether the collection is synchronized.</summary>
        bool IsSynchronized { get; }

        /// <summary>Specifies the Object to be used to synchronize access to the collection.</summary>
        object SyncRoot { get; }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the parameter at the specified index.
        /// </summary>
        /// <param name="index">The name of the parameter to retrieve.</param>
        /// <returns>A TDbParameter at the specified index.</returns>
        TDbParameter this[int index] { get; set; }

        /// <summary>
        /// Gets or sets the parameter at the specified index.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve.</param>
        /// <returns>A TDbParameter at the specified index.</returns>
        TDbParameter this[string parameterName] { get; set; }

        #endregion

        #region Methods

        int Add(TDbParameter value);

        //int Add(object value);

        void AddRange(Array values);

        void Clear();

        bool Contains(TDbParameter value);

        //bool Contains(object value);

        bool Contains(string parameterName);

        //void CopyTo(Array array, int index);

        //IEnumerator GetEnumerator();

        //IEnumerator<TDbParameter> GetEnumerator();

        int IndexOf(TDbParameter value);

        //int IndexOf(object value);

        int IndexOf(string parameterName);

        void Insert(int index, TDbParameter value);

        //void Insert(int index, object value);

        void Remove(TDbParameter value);

        void Remove(object value);

        void RemoveAt(int index);

        void RemoveAt(string parameterName);

        //TDbParameter GetParameter(int index);

        //TDbParameter GetParameter(string parameterName);

        //void SetParameter(int index, TDbParameter value);

        //void SetParameter(int index, DbParameter value);

        //void SetParameter(string parameterName, TDbParameter value);

        //void SetParameter(string parameterName, DbParameter value);

        #endregion
    }
}
