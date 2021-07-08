namespace Money
{
  public readonly struct Amount
  {
      public Amount(string input)
      {
          decimal InputValue = decimal.Parse(input);
          PartIntegral = (long) InputValue;
          PartCents    = (long) (InputValue * 100 - PartIntegral * 100 + 0.5m);
          ValueCents = PartIntegral * 100 + PartCents;
      }

      readonly long PartCents { get; init; }
      readonly long PartIntegral { get; init; }
      readonly long ValueCents { get; init; }

      public override string ToString() => $"{PartIntegral}.{PartCents:D2}";

      public decimal Value() => (decimal) ValueCents / 100m;
  }
}
