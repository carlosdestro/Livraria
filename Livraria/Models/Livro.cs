namespace Livraria
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livro")]
    public partial class Livro
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NOME { get; set; }

        [Required]
        [StringLength(255)]
        public string AUTOR { get; set; }

        public int IDIOMA_ID { get; set; }

        public int? EDITORA_ID { get; set; }

        public int EDICAO { get; set; }

        public int? GENERO_ID { get; set; }

        [Display(Name = "DATA DE PUBLICAÇÃO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DATA_PUBLICACAO { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DATA_CADASTRO { get; set; }

        public int QUANTIDADE { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DATA_ALTERACAO { get; set; }

        public virtual Editora Editora { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Idioma Idioma { get; set; }
    }
}
