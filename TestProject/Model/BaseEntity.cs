using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Shared.Resources;

namespace TestProject.Model
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }

    public interface IDateAudit
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }

    public interface IActorAudit
    {
        Guid? CreatedBy { get; set; }
        Guid? ModifiedBy { get; set; }
    }

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }

    public interface IDeleteActorAudit : ISoftDelete
    {
        Guid? DeletedBy { get; set; }
    }

    public interface IAudit : IDateAudit, IActorAudit
    {
    }

    public interface IFullAudit : IAudit, IDeleteActorAudit
    {
    }

    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; set; }
    }

    public abstract class AuditedEntity : Entity, IAudit
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }

    public abstract class BaseEntity : AuditedEntity, IFullAudit
    {
        public BaseEntity()
        {
            this.Id = SequentialGuidGenerator.Instance.Create();
            this.CreatedOn = DateTime.Now.GetDateUtcNow();
        }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
