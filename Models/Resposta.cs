using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    [Table("Respostas")]
    public class Resposta
    {
        [Key]
        public int RespostaId { get; set; }

        [Required(ErrorMessage = "Digite seu nome")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a resposta 1")]
        [Display(Name = "Eu sou: (Uma qualidade sua)")]
        public string Resp1 { get; set; }
        
        [Required(ErrorMessage = "Digite a resposta 2")]
        [Display(Name = "Eu gosto de:")]
        public string Resp2 { get; set; }
        
        [Required(ErrorMessage = "Digite a resposta 3")]
        [Display(Name = "Eu não gosto de:")]
        public string Resp3 { get; set; }
        
        [Required(ErrorMessage = "Digite a resposta 4")]
        [Display(Name = "Meu hobby é:")]
        public string Resp4 { get; set; }
        
        [Required(ErrorMessage = "Digite a resposta 5")]
        [Display(Name = "Meu filme, série, livro, artista favorito é:")]
        public string Resp5 { get; set; }
        
        [Required(ErrorMessage = "Digite a resposta 6")]
        [Display(Name = "Eu quero seguir a área de: (profissão)")]
        public string Resp6 { get; set; }

        public string? IP { get; set; }

        public bool? Sorteado { get; set; }
        
    }
}