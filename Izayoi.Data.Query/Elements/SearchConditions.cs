// ----------------------------------------------------------------------
// @Namespace : Izayoi.Data.Query
// @Class     : SearchConditions
// ----------------------------------------------------------------------
namespace Izayoi.Data.Query
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Search Conditions
    /// </summary>
    public class SearchConditions : List<SearchCondition>
    {
        #region Constructors

        public SearchConditions() { }

        public SearchConditions(int capacity) : base(capacity) { }

        #endregion

        #region Methods

        public new SearchConditions Add(SearchCondition searchCondition)
        {
            base.Add(searchCondition);

            return this;
        }

        public SearchConditions Add(string fieldName, string operate, object? value = null)
        {
            base.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(string fieldName, string operate, object? value, DbType dbType)
        {
            base.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public SearchConditions Add(string fieldName, string operate, object? value, bool isExpression)
        {
            base.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, string operate, object? value = null)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, string operate, object? value, DbType dbType)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, string operate, object? value, bool isExpression)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, string operate, object? value = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, string operate, object? value, char enclosureR)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, string operate, object? value = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, string operate, object? value, DbType dbType, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, string operate, object? value, bool isExpression, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, string operate, object? value = null, DbType? dbType = null, bool isExpression = false, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        public SearchConditions Add(string fieldName, OpType operate, object? value = null)
        {
            base.Add(new SearchCondition(fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(string fieldName, OpType operate, object? value, DbType dbType)
        {
            base.Add(new SearchCondition(fieldName, operate, value, dbType));

            return this;
        }

        public SearchConditions Add(string fieldName, OpType operate, object? value, bool isExpression)
        {
            base.Add(new SearchCondition(fieldName, operate, value, isExpression));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, OpType operate, object? value, DbType dbType)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value, dbType));

            return this;
        }

        public SearchConditions Add(char enclosureL, string fieldName, OpType operate, object? value, bool isExpression)
        {
            base.Add(new SearchCondition(enclosureL, fieldName, operate, value, isExpression));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, OpType operate, object? value = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, OpType operate, object? value, char enclosureR)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, OpType operate, object? value, DbType dbType, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, OpType operate, object? value, bool isExpression, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, isExpression, enclosureR));

            return this;
        }

        public SearchConditions Add(CType connector, char enclosureL, string fieldName, OpType operate, object? value = null, DbType? dbType = null, bool isExpression = false, char? enclosureR = null)
        {
            base.Add(new SearchCondition(connector, enclosureL, fieldName, operate, value, dbType, isExpression, enclosureR));

            return this;
        }

        #endregion
    }
}
