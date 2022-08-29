namespace EfcoreMySQLUuidToBinDbFunction {
    internal class Program {
        static void Main(string[] args) {
            var mysqlDb = new mysql_databaseContext();
            var guidText = "5fcaf088-3143-4358-bbd7-07cf3414d308";

            #region Run as DbFunction
            var mysqlUuid = mysqlDb.test_table.Where(t => t.uuid_to_bin_column == mysql_databaseContext.UuidToBin(Guid.Parse(guidText))).Select(t => mysql_databaseContext.BinToUuid(t.uuid_to_bin_column)).First();
            // mysqlUuid = {5fcaf088-3143-4358-bbd7-07cf3414d308}
            #endregion

            #region Run as CSharp Method
            var guidToBinary16 = mysql_databaseContext.UuidToBin(Guid.Parse(guidText));
            var mysqlBinary16 = mysqlDb.test_table.Where(t => t.uuid_to_bin_column == guidToBinary16).Select(t => t.uuid_to_bin_column).First();
            var mysqlUuid2 = mysql_databaseContext.BinToUuid(mysqlBinary16);
            // mysqlUuid2 = {5fcaf088-3143-4358-bbd7-07cf3414d308}
            #endregion
        }
    }
}
