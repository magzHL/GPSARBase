using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class loadImageFromURL : MonoBehaviour
{
    [SerializeField] string _imageUrl;
    [SerializeField] Material _material;
    Texture2D _texture;
    // Start is called before the first frame update
    async void Start()
    {
        _texture = await GetRemoteTexture(_imageUrl);
        _material.mainTexture = _texture;
    }



    public static async Task<Texture2D> GetRemoteTexture ( string url )
    {
        using( UnityWebRequest www = UnityWebRequestTexture.GetTexture(url) )
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while( asyncOp.isDone==false )
                await Task.Delay( 1000/30 );//30 hertz
            
            // read results:
            if( www.isNetworkError || www.isHttpError )
            // if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
                #if DEBUG
                Debug.Log( $"{www.error}, URL:{www.url}" );
                #endif
                
                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }
}

