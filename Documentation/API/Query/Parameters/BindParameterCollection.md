# BindParameterCollection

[Top](../../../../README.md) / [Documentation](../../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a bind parameter collection.

~~~csharp
public class BindParameterCollection :
    DbParameterCollection<BindParameter>,
    IBindParameterCollection
~~~

### Inheritance
Object -> MarshalByRefObject -> DbParameterCollection -> DbParameterCollection\<BindParameter> -> BindParameterCollection

### Implements

IBindParameterCollection, IDbParameterCollection\<BindParameter>, IEnumerable\<BindParameter>

## Constructors

|Name|Summary|
|--|--|
|BindParameterCollection()|Initializes a new instance of the BindParameterCollection class.|

## Properties

#### `Count` int

Specifies the number of items in the collection.

#### `IsFixedSize` bool

Specifies whether the collection is a fixed size.

#### `IsReadOnly` bool

Specifies whether the collection is read-only.

#### `IsSynchronized` bool

Specifies whether the collection is synchronized.

#### `SyncRoot` object

Specifies the Object to be used to synchronize access to the collection.

## Indexers

|Name|Returns|Summary|
|--|--|--|
|this[int index]|[BindParameter](BindParameter.md)|Gets or sets the parameter at the specified index.|
|this[string parameterName]|[BindParameter](BindParameter.md)|Gets or sets the parameter at the specified index.|

## Methods

|Name|Returns|Summary|
|--|--|--|
|Add(BindParameter value)|int|Adds the specified BindParameter object to the DbParameterCollection.|
|Add(object value)|int|Adds the specified DbParameter object to the DbParameterCollection.|
|AddRange(Array values)|void|Adds an array of items with the specified values to the DbParameterCollection.|
|Clear()|void|Removes all BindParameter values from the collection.|
|Contains(BindParameter value)|bool|Indicates whether a BindParameter with the specified Value is contained in the collection.|
|Contains(object value)|bool|Indicates whether a DbParameter with the specified Value is contained in the collection.|
|Contains(string parameterName)|bool|Indicates whether a BindParameter with the specified name exists in the collection.|
|CopyTo(Array array, int index)|void|Copies an array of items to the collection starting at the specified index. (not implemented)|
|GetEnumerator()|IEnumerator|Exposes the GetEnumerator() method, which supports a simple iteration over a collection by a .NET data provider.|
|GetEnumerator()|IEnumerator\<BindParameter>|Exposes the GetEnumerator() method, which supports a simple iteration over a collection by a .NET data provider.|
|IndexOf(BindParameter value)|int|Returns the BindParameter object at the specified index in the collection.|
|IndexOf(object value)|int|Returns the DbParameter object at the specified index in the collection.|
|IndexOf(string parameterName)|int|Returns BindParameter the object with the specified name.|
|Insert(int index, BindParameter value)|void|Inserts the specified index of the BindParameter object with the specified name into the collection at the specified index.|
|Insert(int index, object value)|void|Inserts the specified index of the DbParameter object with the specified name into the collection at the specified index.|
|Remove(BindParameter value)|void|Removes the specified BindParameter object from the collection.|
|Remove(object value)|void|Removes the specified DbParameter object from the collection.|
|RemoveAt(int index)|void|Removes the BindParameter object at the specified from the collection.|
|RemoveAt(string parameterName)|void|Removes the BindParameter object with the specified name from the collection.|
|GetParameter(int index)|[BindParameter](BindParameter.md)|Returns the BindParameter object at the specified index in the collection.|
|GetParameter(string parameterName)|[BindParameter](BindParameter.md)|Returns BindParameter the object with the specified name.|
|SetParameter(int index, BindParameter value)|void|Sets the BindParameter object at the specified index to a new value.|
|SetParameter(int index, DbParameter value)|void|Sets the DbParameter object at the specified index to a new value.|
|SetParameter(string parameterName, BindParameter value)|void|Sets the BindParameter object with the specified name to a new value.|
|SetParameter(string parameterName, DbParameter value)|void|Sets the DbParameter object with the specified name to a new value.|

## Applies to

|Product|Versions|
|--|--|
|.NET|8|
