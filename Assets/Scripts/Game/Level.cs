using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level
{
    public void StartGame(SplineFollower splineFollower)
    {
       
           splineFollower.follow = true;
      
    }
    public async void EndGame(  GameObject effectEndGame)
    {
        //_players.ForEach(x => x.parent = null);
       /*
        for (int i = 0; i < _movingPlayers.GetPlayers().Count; i++)
        {
            _movingPlayers.GetPlayers()[i].transform.DOMove(finalPositions[i].transform.position, 0.8f);
        }*/
        effectEndGame.SetActive(true);
        await Task.Delay(2000);
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}