using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _playerScore = 0;
    private bool _isYourTurn = true;
    GameObject _tile;
    public GameObject _Tile { get { return _tile; } }   
    MapController MapController;
    

    
    
    
    private void PickNextTile() {
        

    }
    public void CheckTurn() {


    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile")) {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>()._score;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
