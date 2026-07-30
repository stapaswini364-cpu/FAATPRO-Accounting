namespace FAATPRO.Application.Features.Currencies.DTOs;

public class CreateCurrencyRequest
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;
}