using System;
using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawingLine : MonoBehaviour
{
  [SerializeField] private Transform _playersParent;
    
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private GameObject _effectEndGame;
    
    [SerializeField] private float _startOffsetZ;
    [SerializeField] private float _distBetweenPointsDraw;
    [SerializeField] private float _distBetweenPlayers;
    
    private LineRenderer _lineRenderer;
    private int _currentIndex;
    private Vector3 _lastPos;

    private MovingPlayers _movingPlayers;
    private Level _level;
    void Start()
    {
        Application.targetFrameRate = 60;
        
        _lineRenderer = GetComponent<LineRenderer>();
        
        _level = new Level();
        _movingPlayers = new MovingPlayers(_level, _playersParent);
      
        
        //инициализируем стартовых плееров
        foreach (Transform item in _playersParent)
        {
            if (item.CompareTag("Player"))
            {
                _movingPlayers.AddPlayer(item.GetComponent<Player>());
            }
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) )
        {
           _lineRenderer.positionCount = 0;
            
           _level.StartGame(_splineFollower);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( mousePos);
                    worldPos = Camera.main.transform.InverseTransformPoint(worldPos);

            if (Vector3.Distance(_lastPos, worldPos)>=_distBetweenPointsDraw || _lastPos == Vector3.zero)
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition( _lineRenderer.positionCount-1, worldPos);
                _lastPos = worldPos;
             
         
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
      
            _movingPlayers.MovingPlayerAlongaDrawLine(_distBetweenPlayers, _lineRenderer, _playersParent, _startOffsetZ);
          
        }
    }

    public void LevelFinish()
    {
        _level.EndGame( _effectEndGame);
    }
}