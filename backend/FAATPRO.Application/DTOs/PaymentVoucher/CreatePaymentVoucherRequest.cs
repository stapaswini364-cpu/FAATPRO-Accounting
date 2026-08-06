using System;

namespace FAATPRO.Application.DTOs.PaymentVoucher;

public class CreatePaymentVoucherRequest
{
    public DateTime VoucherDate { get; set; }

    public Guid CashBankLedgerId { get; set; }

    public Guid ExpenseLedgerId { get; set; }

    public decimal Amount { get; set; }

    public string? Narration { get; set; }

    public Guid CompanyId { get; set; }

    public Guid FinancialYearId { get; set; }
}