
namespace Counter.DAL.models
{
    public class BaseModel
    {
      public bool IsDeleted { get; set; } = false;

      public DateTime  Created { get; set; } = DateTime.Now;

      public DateTime Updated { get; set; } = DateTime.Now;
        
    }
}
