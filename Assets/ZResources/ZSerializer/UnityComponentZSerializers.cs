
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace ZSerializer {

[System.Serializable]
public sealed class TrailRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single time;
    public System.Single startWidth;
    public System.Single endWidth;
    public System.Single widthMultiplier;
    public System.Boolean autodestruct;
    public System.Boolean emitting;
    public System.Int32 numCornerVertices;
    public System.Int32 numCapVertices;
    public System.Single minVertexDistance;
    public UnityEngine.Color startColor;
    public UnityEngine.Color endColor;
    public System.Single shadowBias;
    public System.Boolean generateLightingData;
    public UnityEngine.LineTextureMode textureMode;
    public UnityEngine.LineAlignment alignment;
    public UnityEngine.AnimationCurve widthCurve;
    public UnityEngine.Gradient colorGradient;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public TrailRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.TrailRenderer;
        time = instance.time;
        startWidth = instance.startWidth;
        endWidth = instance.endWidth;
        widthMultiplier = instance.widthMultiplier;
        autodestruct = instance.autodestruct;
        emitting = instance.emitting;
        numCornerVertices = instance.numCornerVertices;
        numCapVertices = instance.numCapVertices;
        minVertexDistance = instance.minVertexDistance;
        startColor = instance.startColor;
        endColor = instance.endColor;
        shadowBias = instance.shadowBias;
        generateLightingData = instance.generateLightingData;
        textureMode = instance.textureMode;
        alignment = instance.alignment;
        widthCurve = instance.widthCurve;
        colorGradient = instance.colorGradient;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.TrailRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.TrailRenderer)component;
        instance.time = time;
        instance.startWidth = startWidth;
        instance.endWidth = endWidth;
        instance.widthMultiplier = widthMultiplier;
        instance.autodestruct = autodestruct;
        instance.emitting = emitting;
        instance.numCornerVertices = numCornerVertices;
        instance.numCapVertices = numCapVertices;
        instance.minVertexDistance = minVertexDistance;
        instance.startColor = startColor;
        instance.endColor = endColor;
        instance.shadowBias = shadowBias;
        instance.generateLightingData = generateLightingData;
        instance.textureMode = textureMode;
        instance.alignment = alignment;
        instance.widthCurve = widthCurve;
        instance.colorGradient = colorGradient;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.TrailRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class LightZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.LightType type;
    public UnityEngine.LightShape shape;
    public System.Single spotAngle;
    public System.Single innerSpotAngle;
    public UnityEngine.Color color;
    public System.Single colorTemperature;
    public System.Boolean useColorTemperature;
    public System.Single intensity;
    public System.Single bounceIntensity;
    public System.Boolean useBoundingSphereOverride;
    public UnityEngine.Vector4 boundingSphereOverride;
    public System.Boolean useViewFrustumForShadowCasterCull;
    public System.Int32 shadowCustomResolution;
    public System.Single shadowBias;
    public System.Single shadowNormalBias;
    public System.Single shadowNearPlane;
    public System.Boolean useShadowMatrixOverride;
    public UnityEngine.Matrix4x4 shadowMatrixOverride;
    public System.Single range;
    public UnityEngine.Flare flare;
    public UnityEngine.LightBakingOutput bakingOutput;
    public System.Int32 cullingMask;
    public System.Int32 renderingLayerMask;
    public UnityEngine.LightShadowCasterMode lightShadowCasterMode;
    public UnityEngine.LightShadows shadows;
    public System.Single shadowStrength;
    public UnityEngine.Rendering.LightShadowResolution shadowResolution;
    public System.Single[] layerShadowCullDistances;
    public System.Single cookieSize;
    public UnityEngine.Texture cookie;
    public UnityEngine.LightRenderMode renderMode;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public LightZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Light;
        type = instance.type;
        shape = instance.shape;
        spotAngle = instance.spotAngle;
        innerSpotAngle = instance.innerSpotAngle;
        color = instance.color;
        colorTemperature = instance.colorTemperature;
        useColorTemperature = instance.useColorTemperature;
        intensity = instance.intensity;
        bounceIntensity = instance.bounceIntensity;
        useBoundingSphereOverride = instance.useBoundingSphereOverride;
        boundingSphereOverride = instance.boundingSphereOverride;
        useViewFrustumForShadowCasterCull = instance.useViewFrustumForShadowCasterCull;
        shadowCustomResolution = instance.shadowCustomResolution;
        shadowBias = instance.shadowBias;
        shadowNormalBias = instance.shadowNormalBias;
        shadowNearPlane = instance.shadowNearPlane;
        useShadowMatrixOverride = instance.useShadowMatrixOverride;
        shadowMatrixOverride = instance.shadowMatrixOverride;
        range = instance.range;
        flare = instance.flare;
        bakingOutput = instance.bakingOutput;
        cullingMask = instance.cullingMask;
        renderingLayerMask = instance.renderingLayerMask;
        lightShadowCasterMode = instance.lightShadowCasterMode;
        shadows = instance.shadows;
        shadowStrength = instance.shadowStrength;
        shadowResolution = instance.shadowResolution;
        layerShadowCullDistances = instance.layerShadowCullDistances;
        cookieSize = instance.cookieSize;
        cookie = instance.cookie;
        renderMode = instance.renderMode;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Light)component;
        instance.type = type;
        instance.shape = shape;
        instance.spotAngle = spotAngle;
        instance.innerSpotAngle = innerSpotAngle;
        instance.color = color;
        instance.colorTemperature = colorTemperature;
        instance.useColorTemperature = useColorTemperature;
        instance.intensity = intensity;
        instance.bounceIntensity = bounceIntensity;
        instance.useBoundingSphereOverride = useBoundingSphereOverride;
        instance.boundingSphereOverride = boundingSphereOverride;
        instance.useViewFrustumForShadowCasterCull = useViewFrustumForShadowCasterCull;
        instance.shadowCustomResolution = shadowCustomResolution;
        instance.shadowBias = shadowBias;
        instance.shadowNormalBias = shadowNormalBias;
        instance.shadowNearPlane = shadowNearPlane;
        instance.useShadowMatrixOverride = useShadowMatrixOverride;
        instance.shadowMatrixOverride = shadowMatrixOverride;
        instance.range = range;
        instance.flare = flare;
        instance.bakingOutput = bakingOutput;
        instance.cullingMask = cullingMask;
        instance.renderingLayerMask = renderingLayerMask;
        instance.lightShadowCasterMode = lightShadowCasterMode;
        instance.shadows = shadows;
        instance.shadowStrength = shadowStrength;
        instance.shadowResolution = shadowResolution;
        instance.layerShadowCullDistances = layerShadowCullDistances;
        instance.cookieSize = cookieSize;
        instance.cookie = cookie;
        instance.renderMode = renderMode;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshFilterZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public UnityEngine.HideFlags hideFlags;
    public MeshFilterZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshFilter;
        sharedMesh = instance.sharedMesh;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshFilter)component;
        instance.sharedMesh = sharedMesh;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh additionalVertexStreams;
    public UnityEngine.Mesh enlightenVertexStream;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public MeshRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshRenderer;
        additionalVertexStreams = instance.additionalVertexStreams;
        enlightenVertexStream = instance.enlightenVertexStream;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshRenderer)component;
        instance.additionalVertexStreams = additionalVertexStreams;
        instance.enlightenVertexStream = enlightenVertexStream;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class TransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public TransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Transform;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Transform)component;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SpriteRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Sprite sprite;
    public UnityEngine.SpriteDrawMode drawMode;
    public UnityEngine.Vector2 size;
    public System.Single adaptiveModeThreshold;
    public UnityEngine.SpriteTileMode tileMode;
    public UnityEngine.Color color;
    public UnityEngine.SpriteMaskInteraction maskInteraction;
    public System.Boolean flipX;
    public System.Boolean flipY;
    public UnityEngine.SpriteSortPoint spriteSortPoint;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public SpriteRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SpriteRenderer;
        sprite = instance.sprite;
        drawMode = instance.drawMode;
        size = instance.size;
        adaptiveModeThreshold = instance.adaptiveModeThreshold;
        tileMode = instance.tileMode;
        color = instance.color;
        maskInteraction = instance.maskInteraction;
        flipX = instance.flipX;
        flipY = instance.flipY;
        spriteSortPoint = instance.spriteSortPoint;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SpriteRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SpriteRenderer)component;
        instance.sprite = sprite;
        instance.drawMode = drawMode;
        instance.size = size;
        instance.adaptiveModeThreshold = adaptiveModeThreshold;
        instance.tileMode = tileMode;
        instance.color = color;
        instance.maskInteraction = maskInteraction;
        instance.flipX = flipX;
        instance.flipY = flipY;
        instance.spriteSortPoint = spriteSortPoint;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SpriteRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class RigidbodyZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 velocity;
    public UnityEngine.Vector3 angularVelocity;
    public System.Single drag;
    public System.Single angularDrag;
    public System.Single mass;
    public System.Boolean useGravity;
    public System.Single maxDepenetrationVelocity;
    public System.Boolean isKinematic;
    public System.Boolean freezeRotation;
    public UnityEngine.RigidbodyConstraints constraints;
    public UnityEngine.CollisionDetectionMode collisionDetectionMode;
    public UnityEngine.Vector3 centerOfMass;
    public UnityEngine.Quaternion inertiaTensorRotation;
    public UnityEngine.Vector3 inertiaTensor;
    public System.Boolean detectCollisions;
    public UnityEngine.Vector3 position;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.RigidbodyInterpolation interpolation;
    public System.Int32 solverIterations;
    public System.Single sleepThreshold;
    public System.Single maxAngularVelocity;
    public System.Int32 solverVelocityIterations;
    public UnityEngine.HideFlags hideFlags;
    public RigidbodyZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Rigidbody;
        velocity = instance.velocity;
        angularVelocity = instance.angularVelocity;
        drag = instance.drag;
        angularDrag = instance.angularDrag;
        mass = instance.mass;
        useGravity = instance.useGravity;
        maxDepenetrationVelocity = instance.maxDepenetrationVelocity;
        isKinematic = instance.isKinematic;
        freezeRotation = instance.freezeRotation;
        constraints = instance.constraints;
        collisionDetectionMode = instance.collisionDetectionMode;
        centerOfMass = instance.centerOfMass;
        inertiaTensorRotation = instance.inertiaTensorRotation;
        inertiaTensor = instance.inertiaTensor;
        detectCollisions = instance.detectCollisions;
        position = instance.position;
        rotation = instance.rotation;
        interpolation = instance.interpolation;
        solverIterations = instance.solverIterations;
        sleepThreshold = instance.sleepThreshold;
        maxAngularVelocity = instance.maxAngularVelocity;
        solverVelocityIterations = instance.solverVelocityIterations;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Rigidbody)component;
        instance.velocity = velocity;
        instance.angularVelocity = angularVelocity;
        instance.drag = drag;
        instance.angularDrag = angularDrag;
        instance.mass = mass;
        instance.useGravity = useGravity;
        instance.maxDepenetrationVelocity = maxDepenetrationVelocity;
        instance.isKinematic = isKinematic;
        instance.freezeRotation = freezeRotation;
        instance.constraints = constraints;
        instance.collisionDetectionMode = collisionDetectionMode;
        instance.centerOfMass = centerOfMass;
        instance.inertiaTensorRotation = inertiaTensorRotation;
        instance.inertiaTensor = inertiaTensor;
        instance.detectCollisions = detectCollisions;
        instance.position = position;
        instance.rotation = rotation;
        instance.interpolation = interpolation;
        instance.solverIterations = solverIterations;
        instance.sleepThreshold = sleepThreshold;
        instance.maxAngularVelocity = maxAngularVelocity;
        instance.solverVelocityIterations = solverVelocityIterations;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class CharacterControllerZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single radius;
    public System.Single height;
    public UnityEngine.Vector3 center;
    public System.Single slopeLimit;
    public System.Single stepOffset;
    public System.Single skinWidth;
    public System.Single minMoveDistance;
    public System.Boolean detectCollisions;
    public System.Boolean enableOverlapRecovery;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public CharacterControllerZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.CharacterController;
        radius = instance.radius;
        height = instance.height;
        center = instance.center;
        slopeLimit = instance.slopeLimit;
        stepOffset = instance.stepOffset;
        skinWidth = instance.skinWidth;
        minMoveDistance = instance.minMoveDistance;
        detectCollisions = instance.detectCollisions;
        enableOverlapRecovery = instance.enableOverlapRecovery;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CharacterController))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.CharacterController)component;
        instance.radius = radius;
        instance.height = height;
        instance.center = center;
        instance.slopeLimit = slopeLimit;
        instance.stepOffset = stepOffset;
        instance.skinWidth = skinWidth;
        instance.minMoveDistance = minMoveDistance;
        instance.detectCollisions = detectCollisions;
        instance.enableOverlapRecovery = enableOverlapRecovery;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CharacterController))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public System.Boolean convex;
    public UnityEngine.MeshColliderCookingOptions cookingOptions;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public MeshColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshCollider;
        sharedMesh = instance.sharedMesh;
        convex = instance.convex;
        cookingOptions = instance.cookingOptions;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshCollider)component;
        instance.sharedMesh = sharedMesh;
        instance.convex = convex;
        instance.cookingOptions = cookingOptions;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class BoxColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public UnityEngine.Vector3 size;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public BoxColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.BoxCollider;
        center = instance.center;
        size = instance.size;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.BoxCollider)component;
        instance.center = center;
        instance.size = size;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SphereColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public System.Single radius;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public SphereColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SphereCollider;
        center = instance.center;
        radius = instance.radius;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SphereCollider)component;
        instance.center = center;
        instance.radius = radius;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class Rigidbody2DZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector2 position;
    public System.Single rotation;
    public UnityEngine.Vector2 velocity;
    public System.Single angularVelocity;
    public System.Boolean useAutoMass;
    public System.Single mass;
    public UnityEngine.Vector2 centerOfMass;
    public System.Single inertia;
    public System.Single drag;
    public System.Single angularDrag;
    public System.Single gravityScale;
    public UnityEngine.RigidbodyType2D bodyType;
    public System.Boolean useFullKinematicContacts;
    public System.Boolean isKinematic;
    public System.Boolean freezeRotation;
    public UnityEngine.RigidbodyConstraints2D constraints;
    public System.Boolean simulated;
    public UnityEngine.RigidbodyInterpolation2D interpolation;
    public UnityEngine.RigidbodySleepMode2D sleepMode;
    public UnityEngine.CollisionDetectionMode2D collisionDetectionMode;
    public UnityEngine.HideFlags hideFlags;
    public Rigidbody2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Rigidbody2D;
        position = instance.position;
        rotation = instance.rotation;
        velocity = instance.velocity;
        angularVelocity = instance.angularVelocity;
        useAutoMass = instance.useAutoMass;
        mass = instance.mass;
        centerOfMass = instance.centerOfMass;
        inertia = instance.inertia;
        drag = instance.drag;
        angularDrag = instance.angularDrag;
        gravityScale = instance.gravityScale;
        bodyType = instance.bodyType;
        useFullKinematicContacts = instance.useFullKinematicContacts;
        isKinematic = instance.isKinematic;
        freezeRotation = instance.freezeRotation;
        constraints = instance.constraints;
        simulated = instance.simulated;
        interpolation = instance.interpolation;
        sleepMode = instance.sleepMode;
        collisionDetectionMode = instance.collisionDetectionMode;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Rigidbody2D)component;
        instance.position = position;
        instance.rotation = rotation;
        instance.velocity = velocity;
        instance.angularVelocity = angularVelocity;
        instance.useAutoMass = useAutoMass;
        instance.mass = mass;
        instance.centerOfMass = centerOfMass;
        instance.inertia = inertia;
        instance.drag = drag;
        instance.angularDrag = angularDrag;
        instance.gravityScale = gravityScale;
        instance.bodyType = bodyType;
        instance.useFullKinematicContacts = useFullKinematicContacts;
        instance.isKinematic = isKinematic;
        instance.freezeRotation = freezeRotation;
        instance.constraints = constraints;
        instance.simulated = simulated;
        instance.interpolation = interpolation;
        instance.sleepMode = sleepMode;
        instance.collisionDetectionMode = collisionDetectionMode;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class BoxCollider2DZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector2 size;
    public System.Single edgeRadius;
    public System.Boolean autoTiling;
    public System.Single density;
    public System.Boolean isTrigger;
    public System.Boolean usedByEffector;
    public System.Boolean usedByComposite;
    public UnityEngine.Vector2 offset;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public BoxCollider2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.BoxCollider2D;
        size = instance.size;
        edgeRadius = instance.edgeRadius;
        autoTiling = instance.autoTiling;
        density = instance.density;
        isTrigger = instance.isTrigger;
        usedByEffector = instance.usedByEffector;
        usedByComposite = instance.usedByComposite;
        offset = instance.offset;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.BoxCollider2D)component;
        instance.size = size;
        instance.edgeRadius = edgeRadius;
        instance.autoTiling = autoTiling;
        instance.density = density;
        instance.isTrigger = isTrigger;
        instance.usedByEffector = usedByEffector;
        instance.usedByComposite = usedByComposite;
        instance.offset = offset;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
}