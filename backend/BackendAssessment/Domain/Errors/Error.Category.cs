using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Domain.Errors
{
    public static partial class Errors{
        public class Category
        {
            public static Error CategoryNotFound => Error.Validation(code: "CategoryNotFound", description: "Category not found");
            public static Error DuplicateCategory => Error.Conflict(code: "DuplicateCategory", description: "Category already exists");
            public static Error InvalidCategory => Error.Validation(code: "InvalidCategory", description: "Invalid category data");
        }
    }
}