using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    
    MapController _MapController;
    
    private void AIMove() {
        if (!_isYourTurn) {
            //this.transform.position = _MapController._MapArr;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AIMove();
    }
}
