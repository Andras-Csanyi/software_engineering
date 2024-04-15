namespace AndrasCsanyi.SoftwareEngineering.graphs.dfs.currency_change;

using System.Text;
using Xunit.Abstractions;

/// <summary>
///     Changing currency problem.
///     <para>
///         I have currency and I want to change to another one. To achieve this I use a 3rd party provider who is sending
///         me possible exchanges in the format of SOURCE - TARGET - RATE. For example:
///         <list type="bullet">
///             <item>EUR-GBP-1.18</item>
///             <item>GBP-USD-1.41</item>
///             <item>GBP-NZD-22.3</item>
///         </list>
///         Every transaction costs 0.75 unit in the target currency.
///         <para>Question: <b>Can I make the currency exchange?</b></para>
///     </para>
///     <para>
///         The 3rd party provides a <see cref="List{T}" />
///     </para>
///     <para>
///         The application should print out:
///         <list type="bullet">
///             <item>the exchanges needed to have the source currency in the target currency</item>
///             <item>transaction cost</item>
///             <item>SUM value</item>
///         </list>
///     </para>
///     <para>
///         Runtime complexity:
///         <list type="bullet">
///             <item>
///                 It has a linear component because once we go through the input list and transform it to a
///                 <see cref="Dictionary{TKey,TValue}" />, meaning: O(size of input)
///             </item>
///             <item>Depth-First-Search time complexity is O(input)</item>
///             <item><b>Summary</b>: O(N) - linear</item>
///         </list>
///     </para>
/// </summary>
public class CurrencyChange
{
    private const decimal ConversionFee = 0.75m;
    private readonly ITestOutputHelper _testOutputHelper;

    public CurrencyChange(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public decimal Exchange(
        List<Exchange> availableExchanges,
        string fromCurrency,
        string toCurrency,
        decimal value)
    {
        // convert list to hashmap, grouping by from value
        Dictionary<string, List<Exchange>> cachedAvailableExchanges = ConvertAvailableExchanges(availableExchanges);
        return TryToConvert(cachedAvailableExchanges,
            new Node { CurrencyName = fromCurrency },
            new Node { CurrencyName = toCurrency },
            value,
            new StringBuilder().Append("Start currency: ").Append(fromCurrency).Append("\n"),
            0,
            new List<Node>());
    }

    private decimal TryToConvert(Dictionary<string, List<Exchange>> cachedAvailableExchanges,
        Node actualNode,
        Node finalNode,
        decimal value,
        StringBuilder exchangePath,
        int counter,
        List<Node> visitedNodes)
    {
        visitedNodes.Add(actualNode);

        cachedAvailableExchanges.TryGetValue(actualNode.CurrencyName,
            out List<Exchange> availableExchangesFromActualNode);

        if (availableExchangesFromActualNode is null
            || !availableExchangesFromActualNode.Any())
        {
            return -1;
        }

        foreach (Exchange exchange in availableExchangesFromActualNode)
        {
            if (visitedNodes.Contains(exchange.ToNode))
            {
                continue;
            }

            if (exchange.ToNode.CurrencyName == finalNode.CurrencyName)
            {
                // final calculation
                decimal finalPrice = value * exchange.Rate.Value;
                decimal finalPriceWithFee = finalPrice + ((counter + 1) * ConversionFee);
                exchangePath
                    .Append("Exchanged from: ").Append(actualNode.CurrencyName)
                    .Append(" to: ").Append(exchange.ToNode.CurrencyName)
                    .Append(" with value from: ").Append(value)
                    .Append(" to: ").Append(value * exchange.Rate.Value)
                    .Append(" and service fee applied ")
                    .Append(counter + 1).Append(" times ")
                    .Append("(").Append(counter + 1).Append(" * ").Append(ConversionFee).Append(")")
                    .Append("\n");
                _testOutputHelper.WriteLine(exchangePath.ToString());
                return finalPriceWithFee;
            }
            else
            {
                return TryToConvert(
                    cachedAvailableExchanges,
                    exchange.ToNode,
                    finalNode,
                    value * exchange.Rate.Value,
                    exchangePath
                        .Append("Exchanged from: ").Append(actualNode.CurrencyName)
                        .Append(" to: ").Append(exchange.ToNode.CurrencyName)
                        .Append(" with value from: ").Append(value)
                        .Append(" to: ").Append(value * exchange.Rate.Value)
                        .Append("\n"),
                    counter + 1,
                    visitedNodes
                );
            }
        }

        return -1;
    }

    public Dictionary<string, List<Exchange>> ConvertAvailableExchanges(List<Exchange> availableExchanges)
    {
        Dictionary<string, List<Exchange>> result = new Dictionary<string, List<Exchange>>();
        foreach (Exchange availableExchange in availableExchanges)
        {
            if (result.TryGetValue(availableExchange.FromNode.CurrencyName, out List<Exchange> addedList))
            {
                addedList.Add(availableExchange);
                result.Remove(availableExchange.FromNode.CurrencyName);
                result.Add(availableExchange.FromNode.CurrencyName, addedList);
            }
            else
            {
                List<Exchange> list = new List<Exchange> { availableExchange };
                result.Add(availableExchange.FromNode.CurrencyName, list);
            }
        }

        return result;
    }
}