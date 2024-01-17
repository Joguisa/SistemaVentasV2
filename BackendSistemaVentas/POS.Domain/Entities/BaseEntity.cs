namespace POS.Domain.Entities
{
    /*
     * Esta clase es la base para las entidades, contiene los atributos que son comunes para todas las entidades
     * Id: Identificador único de la entidad
     * CreatedAt: Fecha de creación de la entidad
     * LastModifiedAt: Fecha de la última modificación de la entidad
     * IsDeleted: Indica si la entidad fue eliminada
     * 
    */
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditDeleteUser { get; set; }
        public DateTime? AuditDeleteDate { get; set; }
        public int State { get; set; }
    }
}
