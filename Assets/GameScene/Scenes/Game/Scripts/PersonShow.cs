using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;
using SimpleJSON;
using TMPro;

public class PersonShow : MonoBehaviour
{
    public Image profilePic;
    public TMP_Text Oname;

    public void SetupPersonWindow(Prisoner prisoner)
    {
        Oname.text = prisoner.hName;

        this.gameObject.SetActive(true);
        StartCoroutine(GetRequest("https://randomuser.me/api/?inc=picture"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                JSONObject playerJson = (JSONObject)JSON.Parse(webRequest.downloadHandler.text);
                string ImageString = playerJson["results"][0]["picture"]["large"];
                WWW www = new WWW(ImageString);
                yield return www;
                profilePic.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
            }
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}

public class ProfilePicture
{
}