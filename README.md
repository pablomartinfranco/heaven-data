# Heaven Data

Heaven Data is a library for building SQL queries in a fluent and intuitive way. It supports both MSSQL and MySQL databases, and provides a range of methods for constructing complex queries.

## Usage

### Creating SQL Queries

Heaven Data allows you to create SQL queries using a fluent API. Below are some examples of how to use the library to create various types of SQL queries.

#### Select Query

```csharp
using Heaven.Data;

Func<IDbConnection> connection = () => throw new NotImplementedException("Error: connection not implemented.");

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name), nameof(User.Age))
    .From<User>()
    .Where($"{nameof(User.Age)} > @age")
    .OrderBy(nameof(User.Name))
    .QueryAsync<List<User>>(new {age = 21});
```

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name), nameof(User.Age))
    .From<User>()
    .Where($"{nameof(User.Id)} = @id")
    .QuerySingleAsync<User>(new {id = 10});
```

#### Insert Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Insert<User>()
    .Into(nameof(User.Name), nameof(User.Age))
    .Value("@name", "@age")
    .ExecuteAsync(new {name = "John Doe", age = 25});
```

#### Update Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Update<User>()
    .Set($"{nameof(User.Name)} = @name", $"{nameof(User.Age)} = @age")
    .Where($"{nameof(User.Id)} = @id")
    .ExecuteAsync(new {name = "Jane Doe", age = 27, id = 1});
```

#### Delete Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Delete()
    .From<User>()
    .Where($"{nameof(User.Id)} = @id")
    .ExecuteAsync(new {id = 1});
```

#### Join Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select($"u.{nameof(User.Id)}", $"u.{nameof(User.Name)}", $"o.{nameof(Order.OrderDate)}")
    .From<User>("u")
    .Join<Order>("o", $"u.{nameof(User.Id)} = o.{nameof(Order.UserId)}")
    .Where($"o.{nameof(Order.OrderDate)} > @orderDate")
    .QueryAsync<List<object>>(new {orderDate = "2025-01-01"});
```

### MSSQL-Specific Queries

Heaven Data provides extensions for MSSQL-specific queries.

#### Top Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name))
    .From<User>()
    .Top(10)
    .OrderBy(nameof(User.Name))
    .QueryAsync<List<User>>();
```

#### Offset-Fetch Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name))
    .From<User>()
    .OrderBy(nameof(User.Name))
    .OffsetFetch(10, 20)
    .QueryAsync<List<User>>();
```

### MySQL-Specific Queries

Heaven Data provides extensions for MySQL-specific queries.

#### Limit Query

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name))
    .From<User>()
    .OrderBy(nameof(User.Name))
    .Limit(10)
    .QueryAsync<List<User>>();
```

### Asynchronous Database Operations

Heaven Data also provides asynchronous methods for executing SQL queries using Dapper. You can concatenate the `Sql` query building with the `QueryAsync` methods to avoid using raw SQL strings directly.

#### QueryAsync

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Select(nameof(User.Id), nameof(User.Name), nameof(User.Age))
    .From<User>()
    .Where($"{nameof(User.Age)} > @age")
    .OrderBy(nameof(User.Name))
    .QueryAsync<List<User>>(new {age = 21});
```

#### Executing Non-Select Queries with ExecuteAsync

```csharp
using Heaven.Data;

var result = new Session(connection)
    .Update<User>()
    .Set($"{nameof(User.Name)} = @name", $"{nameof(User.Age)} = @age")
    .Where($"{nameof(User.Id)} = @id")
    .ExecuteAsync(new {name = "Jane Doe", age = 27, id = 1});
```

