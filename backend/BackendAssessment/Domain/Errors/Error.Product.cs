using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Domain.Errors
{
    public static partial class Errors
    {
        public class Product
        {
            public static Error ProductNotFound => Error.Validation(code: "ProductNotFound", description: "Product not found");
            public static Error DuplicateProduct => Error.Conflict(code: "DuplicateProduct", description: "Product already exists");
            public static Error InvalidProduct => Error.Validation(code: "InvalidProduct", description: "Invalid product data");
        }
        
    }
}