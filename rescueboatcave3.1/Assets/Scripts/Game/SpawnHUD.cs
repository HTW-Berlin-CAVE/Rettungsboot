using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHUD : MonoBehaviour {

    public GameObject hud;
    public submarineStat stat;
    public animator_helper ani_helper;
    private GameObject spawned_HUD;

    public void spawnHUD()
    {
        if(spawned_HUD == null)
        {
            spawned_HUD = GameObject.Instantiate(hud, transform.position, transform.rotation, transform.parent);
            spawned_HUD.transform.Rotate(0, 90, 0);
            spawned_HUD.transform.localPosition = new Vector3(1.5f, -2.03f, 7.1f);
            stat.searchHUD();
        }
    }


    public void destroyHUD()
    {
        spawned_HUD = null;
        var oldhud = GameObject.Find("HUD(Clone)");
        stat.hudstat = null;
        Destroy(oldhud);
        oldhud = GameObject.Find("HUD(Clone)");
    }
}
