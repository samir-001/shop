using System;
using Core.Entities;
using Infrastructure.Data;

namespace Core.Specification;

public class TypeListSpecification : SpecificationBase<Products, string>
{

    public TypeListSpecification()

    {
        AddSelection(x => x.Type);
        ApplyDistinct();
    }
}
