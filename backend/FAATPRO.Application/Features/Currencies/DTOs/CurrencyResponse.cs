namespace FAATPRO.Application.Features.Currencies.DTOs;


public class CurrencyResponse
{

    public Guid Id { get; set; }


    public string Code { get; set; } = null!;


    public string Name { get; set; } = null!;


    public string Symbol { get; set; } = null!;


    public bool IsActive { get; set; }


    public DateTime CreatedAt { get; set; }

}