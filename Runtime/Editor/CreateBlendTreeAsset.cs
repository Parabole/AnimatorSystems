using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class CreateBlendTreeAsset : MonoBehaviour
{
    [MenuItem("Assets/Create/Blend Tree")]
    static void CreateBlendTree()
    {
        // Create a simple material asset

        BlendTree blendTree = new BlendTree();
        AssetDatabase.CreateAsset(blendTree, "Assets/NewBlendTree.asset");

        // Print the path of the created asset
        Debug.Log(AssetDatabase.GetAssetPath(blendTree));
    }
    
}