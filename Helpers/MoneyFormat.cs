using System.Globalization;

namespace Boopin.Helpers;

public static class MoneyFormat
{
    /// <summary>Formats as $1,234.50 regardless of the browser's culture.</summary>
    public static string ToMoney(this decimal amount) =>
        "$" + amount.ToString("N2", CultureInfo.InvariantCulture);
}
