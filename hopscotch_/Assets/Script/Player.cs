using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _playerScore =0;
    private bool _isYourTurn = true;
    Tile _tile;
    private void PickStarting()
    {
        
           
    }

    private void PickNextTile() {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile")) {
            _tile = collision.gameObject.GetComponent<Tile>();
            if (!_tile._isOccupied)
            {
                _playerScore += _tile._score;
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
