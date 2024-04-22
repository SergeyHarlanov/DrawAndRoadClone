using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
[System.Serializable]
public class MovingPlayers
{
    
  [SerializeField]  private List<Player> _players = new List<Player>();
    private Transform _parentPlayers;

    
    private Level _level;
    public MovingPlayers(Level level, Transform parentPlayers)
    {
        _level = level;
        _parentPlayers = parentPlayers;
    }
    public List<Player> GetPlayers()
    {
        return _players;
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
        
        player.transform.parent = null;
        
        player.transform.DOScale(Vector3.zero, 0.5f);
        
        if (_players.Count==0)
        {
            _level.Restart();
        }
    }

    public void AddPlayer(Player player)
    {
        if(_players.Contains(player)) return;
        
              player.SetMovingPlayer(this);
        player.transform.parent = _parentPlayers;
        
        _players.Add(player);
    }
    public void MovingPlayerAlongaDrawLine( float distBetweenPlayers, LineRenderer lineRenderer, Transform playersParent, float startOffsetZ )
    {
        for (int i = 0; i < _players.Count; i++)
        {
            float spaceFromPlayers = distBetweenPlayers ;
                
                
            Vector3 pos = Vector3.zero;
                
            int indexLinePosition = Random.Range(0, lineRenderer.positionCount);
            pos = new Vector3(lineRenderer.GetPosition(indexLinePosition).x * spaceFromPlayers,
                      0, lineRenderer.GetPosition(indexLinePosition).y* spaceFromPlayers) 
                  + new Vector3(0, 0, startOffsetZ )+ playersParent.position;
                
        
               
            if (lineRenderer.positionCount>i && indexLinePosition == 0)
            {
                    
                indexLinePosition = Random.Range(0, lineRenderer.positionCount);
                pos = new Vector3(lineRenderer.GetPosition(i).x * (spaceFromPlayers),
                          0, lineRenderer.GetPosition(i).y* (spaceFromPlayers)) 
                      + new Vector3(0, 0, startOffsetZ )+ playersParent.position;
            }
            else
            {
                indexLinePosition = Random.Range(0, lineRenderer.positionCount);
                pos = new Vector3(lineRenderer.GetPosition(indexLinePosition).x * spaceFromPlayers,
                          0, lineRenderer.GetPosition(indexLinePosition).y* spaceFromPlayers) 
                      + new Vector3(0, 0, startOffsetZ )+ playersParent.position;

                   
            }

            pos = playersParent.InverseTransformPoint(pos);
            _players[i].transform.DOLocalMove(new Vector3(pos.x, 0,pos.z), 0.5f);
        }
    }
}