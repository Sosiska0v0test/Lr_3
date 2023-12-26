namespace modified_Lr_3.Entity.GameEntities;

public class StandardGameEntity : GameEntity
{
    public StandardGameEntity(decimal changeOfRating, int playerId)
    {
        ChangeOfRating = changeOfRating;
        PlayerId = playerId;
    }
}