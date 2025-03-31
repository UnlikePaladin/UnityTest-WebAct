using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadPlayer : MonoBehaviour
{
    private string APIurl = Constants.API_URL;
    private int playerID;
    void Start()
    {
        Debug.Log("App.absURL = " + Application.absoluteURL);
        int question = Application.absoluteURL.IndexOf("?");
        //int question = 1;
        if (question != -1)
        {
            string param = Application.absoluteURL.Split('?')[1];
            //string param = "playerID=2";

            int equal = param.IndexOf("=");
            if (equal != -1)
            {
                playerID = int.Parse(param.Split("="[0])[1]);
                Debug.Log("playerID = " + playerID);
            }
        }
        else
        {
            playerID = 1;
        }
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        string fullURL = APIurl + playerID;
        Debug.Log("URL = " + fullURL);
        UnityWebRequest web = UnityWebRequest.Get(fullURL);
        web.useHttpContinue = false;
        yield return web.SendWebRequest();
        if (web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
		{
			Debug.Log("Error API: " + web.error);
		}
        else
        {
            Debug.Log(web.downloadHandler.text);
            string handler = web.downloadHandler.text.Replace("[", "").Replace("]", "");
            UIManager.player = User.CreateFromJSON(handler);
            Debug.Log(UIManager.player);
            //JSONNode userData = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            //Debug.Log("Player: " + userData[0]["NameUser"].ToString());
        }
    }
}
