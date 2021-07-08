namespace Money
{
  public readonly struct Amount
  {
      public Amount(string input)
      {
          decimal InputValue = decimal.Parse(input);
          PartIntegral = Integral(InputValue);
          PartCents    = Round(InputValue * 100 - PartIntegral * 100);
          ValueCents = PartIntegral * 100 + PartCents;
      }

      Amount(long cents)
      {
          ValueCents = cents;
          PartIntegral = ValueCents / 100;
          PartCents    = ValueCents - PartIntegral * 100;
      }

      readonly long PartCents { get; init; }
      readonly long PartIntegral { get; init; }
      readonly long ValueCents { get; init; }

      public override string ToString() => $"{PartIntegral}.{PartCents:D2}";

      public decimal Value() => (decimal) ValueCents / 100m;

      public static Amount operator +(Amount a, Amount b) => new Amount(a.ValueCents + b.ValueCents);
      public static Amount operator -(Amount a, Amount b) => new Amount(a.ValueCents - b.ValueCents);
      public static Amount operator *(Amount a, decimal b) => new Amount(Round(a.ValueCents * b));

      private static long Round(decimal a) => (long) (a + 0.5m);
      private static long Integral(decimal a) => (long) a;
  }
}
