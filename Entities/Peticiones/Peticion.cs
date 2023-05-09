namespace CRM.Entities
{
    public class Peticion
    {
        public bool? Activa { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPeticion { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public int Id { get; set; }
        public int IdAdmin { get; set; }
        public int IdEstadoPeticiones { get; set; }
        public int IdPeticion { get; set; }
        public int IdTipoPeticiones { get; set; }
        public int IdTipoRespuesta { get; set; }
        public string? Respuesta { get; set; }
    }
}