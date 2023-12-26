using modified_Lr_3.Entity;
using modified_Lr_3.Entity.GameEntities;

namespace modified_Lr_3;

public class DbContext
{
    public List<PlayerEntity> Players { get; } = new();
    public List<GameEntity> Games { get; } = new();
}