using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //------------------------------------------
    static Player _inst;
    public static Player _Inst { get { return _inst; } }
    //------------------------------------------
    public UIManager uIManager;
    protected GameObject _tile;
    public GameObject _Tile { get { return _tile; } }   

    MapController MapController;
    //------------------------------------------
    public int _playerScore = 0;
    public static bool _isYourTurn = true;
    private void Awake()
    {
        _inst = this;
    }
    //------------------------------------------
    
    

    protected virtual void OnCollisionEnter(Collision collision)
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
