using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.ModuleDTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Modül adı boş geçilemez")]
        [Display(Name="Modül Adı: ")]
        public string Name { get; set; }
    }
}
