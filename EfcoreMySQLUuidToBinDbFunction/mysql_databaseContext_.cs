using Microsoft.EntityFrameworkCore;

namespace EfcoreMySQLUuidToBinDbFunction;
public partial class mysql_databaseContext {
    [DbFunction("UUID_TO_BIN", IsBuiltIn = true, IsNullable = true)]
    public static byte[] UuidToBin(Guid dotnetGuid) {
        var mysqlBinary16 = ChangeDotNetByteArrayToMySQLBinary16(dotnetGuid.ToByteArray());
        return mysqlBinary16;
    }
    [DbFunction("BIN_TO_UUID", IsBuiltIn = true, IsNullable = true)]
    public static Guid BinToUuid(byte[] dotnetByteArray) {
        var mysqlUuid = new Guid(ChangeDotNetByteArrayToMySQLBinary16(dotnetByteArray));
        return mysqlUuid;
    }

    private static byte[] ChangeDotNetByteArrayToMySQLBinary16(byte[] dotnetByteArray) {
        var mysqlBinary16 = new byte[dotnetByteArray.Length];
        var byteMappings = new Dictionary<int, int> {
            { 0, 3 },
            { 1, 2 },
            { 2, 1 },
            { 3, 0 },
            { 4, 5 },
            { 5, 4 },
            { 6, 7 },
            { 7, 6 },
            { 8, 8 },
            { 9, 9 },
            { 10, 10 },
            { 11, 11 },
            { 12, 12 },
            { 13, 13 },
            { 14, 14 },
            { 15, 15 }
        };

        for (var index = 0; index < dotnetByteArray.Length; index++) {
            mysqlBinary16[byteMappings[index]] = dotnetByteArray[index];
        }

        return mysqlBinary16;
    }
}
