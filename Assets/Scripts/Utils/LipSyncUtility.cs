using System.Collections.Generic;
using UnityEngine;
using uLipSync;
using System.Collections.ObjectModel;

public static class LipSyncUtility
{
    private static readonly List<(string phoneme, string expression)> vrmShapes = new List<(string phoneme, string expression)> { ("A", "aa"), ("I", "ih"), ("U", "ou"), ("E", "ee"), ("O", "oh") };
    public static ReadOnlyCollection<(string phoneme, string expression)> VRMShapes { get; } = new ReadOnlyCollection<(string phoneme, string expression)>(vrmShapes);

    private static readonly string profilePath = "Character/DefaultLipSyncProfile";

    /// <summary>
    /// LipSyncコンポーネントを追加する処理
    /// </summary>
    /// <param name="vrmModel"></param>
    public static void AddLipSyncComponents(GameObject vrmModelRoot)
    {
        if (vrmModelRoot.GetComponent<AudioSource>() == null) vrmModelRoot.AddComponent<AudioSource>();
        else Debug.LogWarning("AudioSourceは既にアタッチされています。");
        if (vrmModelRoot.GetComponent<uLipSync.uLipSync>() == null) vrmModelRoot.AddComponent<uLipSync.uLipSync>();
        else Debug.LogWarning("uLipSyncは既にアタッチされています。");
        if (vrmModelRoot.GetComponent<uLipSyncAudioSource>() == null) vrmModelRoot.AddComponent<uLipSyncAudioSource>();
        else Debug.LogWarning("uLipSyncAudioSourceは既にアタッチされています。");
        if (vrmModelRoot.GetComponent<uLipSyncExpressionVRM>() == null) vrmModelRoot.AddComponent<uLipSyncExpressionVRM>();
        else Debug.LogWarning("uLipSyncExpressionVRMは既にアタッチされています。");
    }

    public static void InitializeLipSync(GameObject vrmModelRoot)
    {
        // 初期設定を行う処理
        AddLipSyncComponents(vrmModelRoot);

        // Profile取得
        var loadProfile = Resources.Load<Profile>(profilePath);
        if (loadProfile == null)
        {
            throw new System.Exception("LipSyncのプロファイルが見つかりませんでした。");
        }

        // コンポーネント取得
        var uLipSync = vrmModelRoot.GetComponent<uLipSync.uLipSync>();
        var uLipSyncAudioSource = vrmModelRoot.GetComponent<uLipSyncAudioSource>();
        var uLipSyncExpressionVRM = vrmModelRoot.GetComponent<uLipSyncExpressionVRM>();

        // 初期値設定
        uLipSync.profile = loadProfile;
        uLipSync.audioSourceProxy = uLipSyncAudioSource;
        foreach (var shape in vrmShapes)
        {
            uLipSyncExpressionVRM.AddBlendShape(shape.phoneme, shape.expression);
        }
        uLipSync.onLipSyncUpdate.AddListener(uLipSyncExpressionVRM.OnLipSyncUpdate);
    }
}

