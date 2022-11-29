namespace Cloud.Domain.Entities
{
    public abstract class BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// 实体唯一标识
        /// </summary>
        public TPrimaryKey Id { get; set; }


    }
}
