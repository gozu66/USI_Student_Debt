using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
    public string facebook, twitter, USI, USIfb, USItw;

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

    public void OpenLinkJSPluginUSI()
    {
        #if !UNITY_EDITOR
		openWindow(USI);
        #endif
    }

    public void OpenLinkJSPluginUSIFacebook()
    {
        #if !UNITY_EDITOR
		openWindow(USIfb);
        #endif
    }

    public void OpenLinkJSPluginUSITwitter()
    {
        #if !UNITY_EDITOR
		openWindow(USItw);
        #endif
    }

    [DllImport("__Internal")]
	private static extern void openWindow(string url);

}