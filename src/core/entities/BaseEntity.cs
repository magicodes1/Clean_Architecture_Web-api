using System.ComponentModel.DataAnnotations;

namespace Delicious.core
{
    public abstract class BaseEntity
    {
       public virtual int Id { get;protected set; }
    }
}