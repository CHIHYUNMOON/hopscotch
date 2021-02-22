using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    
    MapController _MapController;
    private int[] AILocationIndex;

    private void AIMove() {
        if (!_isYourTurn) {
            //if(_tile.transform.posit
            this.transform.position = _MapController._MapArr[AILocationIndex[0]][AILocationIndex[1]] + Vector3.up *1.0f;
            _isYourTurn = true;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    private void Awake()
    {
       
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        AILocationIndex = _MapController._AIFirstLocationIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("AIMove", 2.0f);
    }
}
