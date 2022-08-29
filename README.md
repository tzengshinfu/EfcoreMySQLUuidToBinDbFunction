# EfcoreMySQLUuidToBinDbFunction
> MySQL UUID_TO_BIN & BIN_TO_UUID functions in EF Core.


## Installation
1. Copy the DbContext file "mysql_databaseContext_.cs" to your project.
2. Change the namespace and class to match the existing DbContext.
3. Only MySQL 8+.

## Usage example
1. Run as DbFunction
```cs
var mysqlUuid = mysqlDb.test_table.Where(t => t.uuid_to_bin_column == mysql_databaseContext.UuidToBin(Guid.Parse("5fcaf088-3143-4358-bbd7-07cf3414d308"))).Select(t => mysql_databaseContext.BinToUuid(t.uuid_to_bin_column)).First();
// mysqlUuid = {5fcaf088-3143-4358-bbd7-07cf3414d308}
```
2. Run as CSharp Method
```cs
 var guidToBinary16 = mysql_databaseContext.UuidToBin(Guid.Parse("5fcaf088-3143-4358-bbd7-07cf3414d308"));
 var mysqlBinary16 = mysqlDb.test_table.Where(t => t.uuid_to_bin_column == guidToBinary16).Select(t => t.uuid_to_bin_column).First();
 var mysqlUuid = mysql_databaseContext.BinToUuid(mysqlBinary16);
 // mysqlUuid = {5fcaf088-3143-4358-bbd7-07cf3414d308}
```
