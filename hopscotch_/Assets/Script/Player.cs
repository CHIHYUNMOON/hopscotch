using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public override IEnumerator CharacterMove(Tile nextTile)
    {
        //Vector3 LookDirection = nextTile.gameObject.transform.position - this.gameObject.transform.position;
        //Quaternion tmp = Quaternion.LookRotation(LookDirection);
        //Vector3 tmpEuler = tmp.eulerAngles;
        //tmpEuler.x = 0f;
        //gameObject.transform.rotation = Quaternion.Euler(tmpEuler);

        ////_animator.SetBool("isMoving", true);

        ////    this.gameObject.transform.position += LookDirection.normalized * Time.deltaTime*0.1f ;


        //_animator.SetBool("isMoving", false);
        //    _isYouSelectTile = false;
        base.CharacterMove(nextTile);
        yield return null;
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

    protected override  void Update()
    {
        base.Update();
    }
}
  