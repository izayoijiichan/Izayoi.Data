// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : DbParameterCollection
// ----------------------------------------------------------------------
#nullable enable
namespace Izayoi.Data.Query
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;

    /// <summary>
    /// DB Parameter Collection
    /// </summary>
    public class DbParameterCollection<TDbParameter> :
        DbParameterCollection,
        IDbParameterCollection<TDbParameter>
        where TDbParameter : DbParameter
    {
        #region Fields

        protected readonly List<TDbParameter> _items = new(4);

        protected readonly object _syncRoot = new();

        #endregion

        #region Properties

        public override int Count => _items.Count;

        public override object SyncRoot => _syncRoot;

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the parameter at the specified index.
        /// </summary>
        /// <param name="index">The name of the parameter to retrieve.</param>
        /// <returns>A TDbParameter at the specified index.</returns>
        public new TDbParameter this[int index]
        {
#if NETSTANDARD2_1
            get => GetParameter(index) as TDbParameter ?? throw new InvalidCastException();
#else
            get => GetParameter(index);
#endif
            set => SetParameter(index, value);
        }

        /// <summary>
        /// Gets or sets the parameter at the specified index.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve.</param>
        /// <returns>A TDbParameter at the specified index.</returns>
        public new TDbParameter this[string parameterName]
        {
#if NETSTANDARD2_1
            get => GetParameter(parameterName) as TDbParameter ?? throw new InvalidCastException();
#else
            get => GetParameter(parameterName);
#endif
            set => SetParameter(parameterName, value);
        }

        #endregion

        #region Methods

        public virtual int Add(TDbParameter value)
        {
            _items.Add(value);

            return _items.Count - 1;
        }

        public override int Add(object value)
        {
            if (value is TDbParameter parameter)
            {
                return Add(parameter);
            }

            throw new NotSupportedException();
        }

        public override void AddRange(Array values)
        {
            if (values.GetType() != typeof(TDbParameter))
            {
                throw new NotSupportedException();
            }

            IEnumerable<TDbParameter> parameters = values.OfType<TDbParameter>();

            _items.AddRange(parameters);
        }

        public override void Clear()
        {
            _items.Clear();
        }

        public virtual bool Contains(TDbParameter value)
        {
            return _items.Contains(value);
        }

        public override bool Contains(object value)
        {
            if (value is TDbParameter parameter)
            {
                return Contains(parameter);
            }

            throw new NotSupportedException();
        }

        public override bool Contains(string parameterName)
        {
            return _items.Exists(x => x.ParameterName == parameterName);
        }

        public override void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<TDbParameter> IEnumerable<TDbParameter>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public virtual int IndexOf(TDbParameter value)
        {
            return _items.IndexOf(value);
        }

        public override int IndexOf(object value)
        {
            if (value is TDbParameter parameter)
            {
                return IndexOf(parameter);
            }

            throw new NotSupportedException();
        }

        public override int IndexOf(string parameterName)
        {
            TDbParameter? parameter = _items.FirstOrDefault(x => x.ParameterName == parameterName);

            if (parameter is null)
            {
                return -1;
            }

            return _items.IndexOf(parameter);
        }

        public virtual void Insert(int index, TDbParameter value)
        {
            _items.Insert(index, value);
        }

        public override void Insert(int index, object value)
        {
            if (value is TDbParameter parameter)
            {
                Insert(index, parameter);
            }

            throw new NotSupportedException();
        }

        public virtual void Remove(TDbParameter value)
        {
            _items.Remove(value);
        }

        public override void Remove(object value)
        {
            if (value is TDbParameter parameter)
            {
                Remove(parameter);
            }

            throw new NotSupportedException();
        }

        public override void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public override void RemoveAt(string parameterName)
        {
            int index = IndexOf(parameterName);

            _items.RemoveAt(index);
        }

#if NETSTANDARD2_1
        protected override DbParameter GetParameter(int index)
#else
        protected override TDbParameter GetParameter(int index)
#endif
        {
            return _items[index];
        }

#if NETSTANDARD2_1
        protected override DbParameter GetParameter(string parameterName)
#else
        protected override TDbParameter GetParameter(string parameterName)
#endif
        {
            int index = IndexOf(parameterName);

            return _items[index];
        }

        protected virtual void SetParameter(int index, TDbParameter value)
        {
            _items[index] = value;
        }

        protected override void SetParameter(int index, DbParameter value)
        {
            if (value is TDbParameter parameter)
            {
                _items[index] = parameter;
            }

            throw new NotSupportedException();
        }

        protected virtual void SetParameter(string parameterName, TDbParameter value)
        {
            int index = IndexOf(parameterName);

            _items[index] = value;
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            if (value is TDbParameter parameter)
            {
                SetParameter(parameterName, value);
            }

            throw new NotSupportedException();
        }

        #endregion
    }
}
