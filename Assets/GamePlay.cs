﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public GameObject Prefab;
    public Dictionary<ulong, GameObject> Players = new Dictionary<ulong, GameObject>();

    void Awake()
    {
        var d = GameLogic.Instance.Data;
        foreach (var kv in d.Players)
        {
            Players[kv.Key] = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity);
            Players[kv.Key].name = kv.Key.ToString();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    var d = GameLogic.Instance.Data;
	    foreach (var playerData in d.Players)
	    {
	        GameObject o = null;
	        if (Players.TryGetValue(playerData.Key, out o))
	        {
	            //o.transform.localPosition = Vector3.Lerp(o.transform.localPosition, playerData.Value.Pos,Time.deltaTime * 10);
	            o.transform.localPosition = playerData.Value.Pos;
	        }

	    }
    }

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(0, 100, 100, 100), "Foward"))
        {
            var msg = message.C2S_InputSkillMsg.CreateBuilder();
            msg.SetSid(1);
            Network.Instance.Send(message.ID.C2S_InputSkill, msg.Build());
        }
        else if (GUI.Button(new Rect(100, 100, 100, 100), "Back"))
        {
            var msg = message.C2S_InputSkillMsg.CreateBuilder();
            msg.SetSid(2);
            Network.Instance.Send(message.ID.C2S_InputSkill, msg.Build());
        }
        else if (GUI.Button(new Rect(200, 100, 100, 100), "Left"))
        {
            var msg = message.C2S_InputSkillMsg.CreateBuilder();
            msg.SetSid(3);
            Network.Instance.Send(message.ID.C2S_InputSkill, msg.Build());
        }
        else if (GUI.Button(new Rect(300, 100, 100, 100), "Right"))
        {
            var msg = message.C2S_InputSkillMsg.CreateBuilder();
            msg.SetSid(4);
            Network.Instance.Send(message.ID.C2S_InputSkill, msg.Build());
        }

    }

}
