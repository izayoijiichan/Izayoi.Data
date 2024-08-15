# QueryOption

[Top](../../../README.md) / [Documentation](../../Documentation.md)

## Definition

|||
|--|--|
|Namespace|Izayoi.Data.Query|
|Assembly|Izayoi.Data.Query.dll|

Represents a query option.

~~~csharp
public class QueryOption
~~~

### Inheritance
Object -> QueryOption

## Constructors

|Name|Summary|
|--|--|
|QueryOption()|Initializes an instance of the QueryOption class.|
|QueryOption(RdbKind rdbKind)|Initializes a new instance of the QueryOption class with the specified rdbKind.|
|QueryOption(RdbKind rdbKind, int rdbVersion)|Initializes a new instance of the QueryOption class with the specified rdbKind and rdbVersion.|

## Properties

#### `RdbKind` RdbKind

Gets or sets the relational database kind.

#### `RdbVersion` int

Gets or sets the relational database version.

#### `InitialBufferSize` int

Gets or sets the initial buffer size.

StringBuilder(capacity)

#### `QuotationMarks` QuotationMarkSet

Gets or sets the quotation marks.

#### `EnableFormat` bool

Gets or sets whether to enable query formatting.

The default value is false.

#### `IndentSpace` int

Gets or sets the number of spaces for indentation.

It is referenced if EnableFormat is true.

The default value is 2.

#### `BeforeComma` bool

Gets or sets whether to place the comma before or after the concatenation.

true means before; false means after.

The default value is false.

## Examples

~~~csharp
using Izayoi.Data.Query;

static void Main()
{
    QueryOption queryOption;

    queryOption = new QueryOption(RdbKind.Sqlite, 3);

    queryOption = new QueryOption(RdbKind.SqlServer, 2022)
    {
        QuotationMarks = new QuotationMarkSet('[', ']')
    };

    queryOption = new QueryOption(RdbKind.Mysql, 8)
    {
        QuotationMarks = new QuotationMarkSet('`', '`')
    };

    queryOption = new QueryOption(RdbKind.Pgsql, 16)
    {
        QuotationMarks = new QuotationMarkSet('"', '"')
    };

    queryOption = new QueryOption()
    {
        EnableFormat = true,
        IndentSpace = 4,
        BeforeComma = true,
    }
}
~~~
