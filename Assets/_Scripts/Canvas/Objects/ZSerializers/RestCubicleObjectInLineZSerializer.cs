[System.Serializable]
public sealed class RestCubicleObjectInLineZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.String levelCost;
    public System.Int32 level;
    public System.Boolean IsLevelMax;
    public System.Int32 keyLevel;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public RestCubicleObjectInLineZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         levelCost = (System.String)typeof(ObjectInLine).GetField("levelCost").GetValue(instance);
         level = (System.Int32)typeof(ObjectInLine).GetField("level").GetValue(instance);
         IsLevelMax = (System.Boolean)typeof(ObjectInLine).GetField("IsLevelMax").GetValue(instance);
         keyLevel = (System.Int32)typeof(RestCubicleObjectInLine).GetField("keyLevel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(ObjectInLine).GetField("levelCost").SetValue(component, levelCost);
         typeof(ObjectInLine).GetField("level").SetValue(component, level);
         typeof(ObjectInLine).GetField("IsLevelMax").SetValue(component, IsLevelMax);
         typeof(RestCubicleObjectInLine).GetField("keyLevel", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, keyLevel);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}