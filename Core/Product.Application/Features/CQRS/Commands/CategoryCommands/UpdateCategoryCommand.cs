using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }  // update işleminde id parametresi olmazsa burası ekleme işlemi gibi çalışır o yuzden id parametresi olmalıdır.
        public string CategoryName { get; set; }

    }
}
