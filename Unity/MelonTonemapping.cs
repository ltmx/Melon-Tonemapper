#region Header
// **    Copyright (C) 2023 Nicolas Reinhard, @LTMX. All rights reserved.
// **    Github Profile: https://github.com/LTMX
// **    Repository : https://github.com/LTMX/Unity.Athena

#endregion

#if UNITY_HDRP

using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

    [Serializable, SupportedOnRenderPipeline(typeof(HDRenderPipelineAsset))]
    internal sealed class MelonTonemapping : CustomPostProcessVolumeComponent, IPostProcessComponent
    {
        internal class ShaderIDs
        {
            // public static readonly int k_InputTexture = Shader.PropertyToID("_InputTexture");
            public static readonly int Contrast = Shader.PropertyToID("_Contrast");
            public static readonly int WhiteIntensity = Shader.PropertyToID("_WhiteIntensity");
        }

        public BoolParameter isActive = new(true, true);

        [Tooltip("Default to 0.15")]
        public ClampedFloatParameter WhiteIntensity = new(0.15f, 0, 1, true);
        [Tooltip("Default to 0.64")]
        public ClampedFloatParameter Contrast = new(0.64f, 0, 1, true);
 
        
        Material m_Material;
        
        public bool IsActive() => m_Material != null && isActive.value;

        public override CustomPostProcessInjectionPoint injectionPoint => CustomPostProcessInjectionPoint.AfterPostProcess;

        public override void Setup() => m_Material = CoreUtils.CreateEngineMaterial("FullScreen/MelonTonemapping");

        public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
        {
            Debug.Assert(m_Material != null);

            m_Material.SetFloat(ShaderIDs.Contrast, Contrast.value);
            m_Material.SetFloat(ShaderIDs.WhiteIntensity, WhiteIntensity.value); 
            HDUtils.DrawFullScreen(cmd, m_Material, destination);
        }

        public override void Cleanup() => CoreUtils.Destroy(m_Material);
    }
    
    #endif