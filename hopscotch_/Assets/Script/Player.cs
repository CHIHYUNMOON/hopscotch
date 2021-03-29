using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public override void CharacterMove(Tile nextTile)
    {   
            Quaternion tmp = Quaternion.LookRotation(nextTile.gameObject.transform.position - this.gameObject.transform.position);
            Vector3 tmpEuler = tmp.eulerAngles;
            tmpEuler.x = 0f;
            gameObject.transform.rotation = Quaternion.Euler(tmpEuler);

            this.gameObject.transform.Translate(Vector3.forward);        
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
}
  