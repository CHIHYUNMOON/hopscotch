using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public override void CharacterMove(Tile nextTile)
    {
       
        base.CharacterMove(nextTile);
        
    }


    protected override void Awake()
    {
        base.Awake();
    }
    //------------------------------------------

   


    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    public override List<Tile> CheckTileCanMove()
    {
        return base.CheckTileCanMove();
    }

    protected override void Update()
    {
        base.Update();
    }


}
  