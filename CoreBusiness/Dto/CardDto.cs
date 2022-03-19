using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class CardDto
    {
        [Required(ErrorMessage = "Informe o título do card")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe o conteúdo do card")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Informe o nome da lista do card")]
        public string Lista { get; set; }
    }
}