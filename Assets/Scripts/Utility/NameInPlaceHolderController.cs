﻿using UnityEngine;
using System.Collections;

public class NameInPlaceHolderController : MonoBehaviour
{
    public int position;

    private TextMesh text;
	
	void Start ()
    {
        text = GetComponent<TextMesh>();
        text.text = "";
	}
		
	void Update ()
    {
	    if (string.IsNullOrEmpty(text.text) && PhotonNetwork.connected)
        {
            if (PhotonNetwork.playerList.Length > position)
            {
                string name = string.Empty;

                if (PhotonNetwork.playerList[position].customProperties.ContainsKey("NAME"))
                    name = PhotonNetwork.playerList[position].customProperties["NAME"].ToString();

                if (!string.IsNullOrEmpty(name))
                {
                    text.text = name.ToShortString();
                }
            }
        }
	}
}
