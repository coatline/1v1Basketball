//	Copyright (c) 2012 Calvin Rien
//        http://the.darktable.com
//
//	This software is provided 'as-is', without any express or implied warranty. In
//	no event will the authors be held liable for any damages arising from the use
//	of this software.
//
//	Permission is granted to anyone to use this software for any purpose,
//	including commercial applications, and to alter it and redistribute it freely,
//	subject to the following restrictions:
//
//	1. The origin of this software must not be misrepresented; you must not claim
//	that you wrote the original software. If you use this software in a product,
//	an acknowledgment in the product documentation would be appreciated but is not
//	required.
//
//	2. Altered source versions must be plainly marked as such, and must not be
//	misrepresented as being the original software.
//
//	3. This notice may not be removed or altered from any source distribution.
//
//  =============================================================================

using UnityEngine;
using System.Collections.Generic;

public class Mule : MonoBehaviour
{
    const string GOB_NAME = "__Mule__";

    Dictionary<string, object> pack = new Dictionary<string, object>();

    static Mule _instance;

    #region Properties

    public static Transform Transform { get { return I.transform; } }

    /// <summary>
    /// Returns true if an instance of Mule exists
    /// </summary>
    public static bool Exists { get { return _instance != null; } }

    static Mule I
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Mule>();

                if (_instance == null)
                {
                    var go = new GameObject(GOB_NAME);
                    _instance = go.AddComponent<Mule>();
                }
            }
            return _instance;
        }
    }

    #endregion

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void Set(string key, object value)
    {
        I.pack[key] = value;
    }

    /// <summary>
    /// Gets the object stored with the specified key. 
    /// Returns the default value if the key is not found.
    /// </summary>
    public static object Get(string key, object defValue = null)
    {
        if (!I.pack.ContainsKey(key))
        {
            return defValue;
        }

        return I.pack[key];
    }

    /// <summary>
    /// Gets the instance of type T stored with the specified key.
    /// Returns the default value if the key is not found.
    /// </summary>
    public static T Get<T>(string key, T defValue)
    {
        if (!I.pack.ContainsKey(key))
        {
            return defValue;
        }

        return (T)I.pack[key];
    }

    /// <summary>
    /// Gets the object stored with the specified key removing it from the "pack" if it exists
    /// Returns the default value if the key is not found.
    /// if one does not exist.
    /// </summary>
    public static object Pop(string key, object defValue = null)
    {
        object result = Get(key, defValue);

        Delete(key);
        return result;
    }

    /// <summary>
    /// Gets the instance of type T stored with the specified key removing it from the "pack" if it exists
    /// Returns the default value if the key is not found.
    /// if one does not exist.
    /// </summary>
    public static T Pop<T>(string key, T defValue)
    {
        T result = Get<T>(key, defValue);
        Delete(key);
        return result;
    }

    /// <summary>
    /// Deletes the object referenced by the given key
    /// </summary>
    /// <returns>True if an object was removed, false otherwise</returns>
    public static bool Delete(string key){ return I.pack.Remove(key); }
}
