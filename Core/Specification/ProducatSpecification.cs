using System;
using Core.Entities;
using Infrastructure.Data;

namespace Core.Specification;

public class ProductSpecification : SpecificationBase<Products>
{
    public ProductSpecification(ProductSpecParams productSpecParams)
         : base(x =>
          (string.IsNullOrEmpty(productSpecParams.Search)
                || x.Name.ToLower().Contains(productSpecParams.Search)) &&
            (!productSpecParams.Brands.Any() || productSpecParams.Brands.Contains(x.Brand)) &&
            (!productSpecParams.Types.Any() || productSpecParams.Types.Contains(x.Type)))
    {
        ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);
        AddOrderBy(x => x.Name);

        switch (productSpecParams.Sort)

        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }

    }
}
