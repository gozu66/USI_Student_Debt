using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
    public string facebook, twitter;

	public void OpenLinkJSPluginFacebook()
	{
		#if !UNITY_EDITOR
		openWindow(facebook);
		#endif
	}

    public void OpenLinkJSPluginTwitter()
    {
        #if !UNITY_EDITOR
		openWindow(twitter);
        #endif
    }



    [DllImport("__Internal")]
	private static extern void openWindow(string url);

}