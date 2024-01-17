namespace POS.Application.Dtos.Category.Request
{
    // Declarar atributos que el cliente me va a enviar
    // para que exista una categoría
    public class CategoryRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}
