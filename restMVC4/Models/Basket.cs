//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace restMVC4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basket
    {
        public int IdBasket { get; set; }
        public int IdOrder { get; set; }
        public int Number { get; set; }
    
        public virtual Order Order { get; set; }
    }
}