using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVBuilder.Domain.Models
{
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public virtual ICollection<Curriculum> Curriculum { get; set; }
    }
}