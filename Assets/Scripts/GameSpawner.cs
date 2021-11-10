using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSpawner : MonoBehaviour
{
    public static GameSpawner instance;

    public GameObject coins;
    public GameObject textDamage;
    public GameObject spawnIndicator;
    public GameObject megaCreepsText;

    public Canvas HUD;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGoldCoins(Vector3 _spawnPosition) 
    {
        Instantiate(coins, _spawnPosition + Vector3.up * 1.5f, Quaternion.identity);
    }

    public void SpawnDamageText(Vector3 _spawnPosition, string _damageText,GameObject _dealer) 
    {
        GameObject _textDamage = (GameObject)Instantiate(textDamage, _spawnPosition, Quaternion.identity);
        _textDamage.GetComponentInChildren<Text>().text = _damageText;

        _textDamage.transform.SetParent(_dealer.transform);

    }

    public void SpawnPointIndicator(Vector3 _spawnPosition) 
    {
        Instantiate(spawnIndicator, _spawnPosition, Quaternion.identity);
    }

    public void SpawnMegaCreepsText(string _text) 
    {
        GameObject megaText = (GameObject)Instantiate(megaCreepsText, new Vector3(902,1000,0), Quaternion.identity);
        megaText.transform.parent = HUD.transform;
        megaText.GetComponent<Text>().text = _text;
    }
}
