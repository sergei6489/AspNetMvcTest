using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Введите наименование товара")]
        [DisplayName("Наименование товара")]
        public string Name { get; set; }
        [Required( ErrorMessage = "Введите категорию товара" )]
        [DisplayName("Категория товара")]
        public string Category { get; set; }
        [Required( ErrorMessage = "Введите цену товара" )]
        [DisplayName( "Цена товара" )]
        [Range(typeof(decimal),"5,0", "100000,6", ErrorMessage = "Наименьшая цена - 5 рублей")]
        public decimal Price { get; set; }
        [DisplayName("Изображение")]
        public byte[] Image { get; set; }
        [Required( ErrorMessage = "Введите описание товара" )]
        [DisplayName( "Описание товара" )]
        public string Description { get; set; }
    }
}
