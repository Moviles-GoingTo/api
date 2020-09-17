using System.ComponentModel;

namespace GoingTo_API.Domain.Models
{
    public enum ECurrency
    {
        [Description("USD")] DolarAmericano = 1,
        [Description("EUR")] Euro = 2,
        [Description("SOL")] Sol = 3
    }
}
