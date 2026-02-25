using System;
using Core.Entities;
using Infrastructure.Data;

namespace Core.Specification;

public class BrandListSpecification : SpecificationBase<Products, string>
{

    public BrandListSpecification()
    
    {
        AddSelection(x => x.Brand);
        ApplyDistinct();
    }
}
