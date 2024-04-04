using System;
using System.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using UniVRM10;
using UniVRM10.URPSample;

namespace Utils
{
    public static class SpawnVrmCharacter
    {
        public static async Task<GameObject> Spawn(string path, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            try
            {
                var loadedVrm = await Vrm10.LoadPathAsync(path,
                    canLoadVrm0X: true,
                    showMeshes: false,
                    materialGenerator: new UrpVrm10MaterialDescriptorGenerator());
                if (loadedVrm == null)
                {
                    return null;
                }

                var instance = loadedVrm.GetComponent<RuntimeGltfInstance>();
                instance.ShowMeshes();
                instance.EnableUpdateWhenOffscreen();
                instance.Root.transform.position = position;
                instance.Root.transform.rotation = rotation;
                instance.Root.transform.localScale = scale;
                return instance.Root;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }
    }
}
