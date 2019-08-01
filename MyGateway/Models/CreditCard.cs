﻿namespace MyGateway.Models
{
    public class CreditCard
    {
        public string CardID { get; set; }
        public string CardType { get; set; }
        public Rate PurchasesRate { get; set; }
        public Rate CashAdvanceRate { get; set; }
        public Rate BalanceTransferRate { get; set; }
        public Rate PenaltyRate { get; set; }
    }

    public enum EnumRateType { Variable = 1, NonVariable = 2 };
}