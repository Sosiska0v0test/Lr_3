﻿namespace modified_Lr_3.Entity.GameEntities;

public class GameEntity
{
    public int Id { get; set; }
    public decimal ChangeOfRating { get; protected init; }
    public int PlayerId { get; protected init; }
}
