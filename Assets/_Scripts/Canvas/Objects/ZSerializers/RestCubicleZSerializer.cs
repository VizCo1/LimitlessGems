[System.Serializable]
public sealed class RestCubicleZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Single restTime;
    public System.Single probFasterRest;
    public System.Single initialProbFasterRest;
    public System.Int32 visualIndex;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public RestCubicleZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         restTime = (System.Single)typeof(RestCubicle).GetField("restTime", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         probFasterRest = (System.Single)typeof(RestCubicle).GetField("probFasterRest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         initialProbFasterRest = (System.Single)typeof(RestCubicle).GetField("initialProbFasterRest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         visualIndex = (System.Int32)typeof(QueueFlow).GetField("visualIndex", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(RestCubicle).GetField("restTime", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, restTime);
         typeof(RestCubicle).GetField("probFasterRest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, probFasterRest);
         typeof(RestCubicle).GetField("initialProbFasterRest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, initialProbFasterRest);
         typeof(QueueFlow).GetField("visualIndex", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, visualIndex);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}