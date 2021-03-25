using System;

namespace ArdalisRating
{

    public class Policy
    {
        public PolicyType? Type { get; set; }
        #region Life Insurance
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsSmoker { get; set; }
        public decimal? Amount { get; set; }
        #endregion

        #region Land
        public string Address { get; set; }
        public decimal? Size { get; set; }
        public decimal? Valuation { get; set; }
        public decimal? BondAmount { get; set; }
        #endregion

        #region Auto
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? Miles { get; set; }
        public decimal? Deductible { get; set; }
        #endregion

        public override bool Equals(object obj)
        {
            return Type == ((Policy)obj)?.Type &&
                   FullName == ((Policy)obj)?.FullName &&
                   DateOfBirth == ((Policy)obj)?.DateOfBirth &&
                   IsSmoker == ((Policy)obj)?.IsSmoker &&
                   Amount == ((Policy)obj)?.Amount &&
                   Address == ((Policy)obj)?.Address &&
                   Size == ((Policy)obj)?.Size &&
                   Valuation == ((Policy)obj)?.Valuation &&
                   BondAmount == ((Policy)obj)?.BondAmount &&
                   Make == ((Policy)obj)?.Make &&
                   Model == ((Policy)obj)?.Model &&
                   Year == ((Policy)obj)?.Year &&
                   Miles == ((Policy)obj)?.Miles &&
                   Deductible == ((Policy)obj)?.Deductible;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Type != null ? Type.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DateOfBirth != null ? DateOfBirth.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IsSmoker != null ? IsSmoker.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Amount != null ? Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Size != null ? Size.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Valuation != null ? Valuation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BondAmount != null ? BondAmount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Make != null ? Make.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Model != null ? Model.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Year != null ? Year.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Miles != null ? Miles.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Deductible != null ? Deductible.GetHashCode() : 0);
                return hashCode;
            }
        }

    }
}
