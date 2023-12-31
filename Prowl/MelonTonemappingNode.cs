using Prowl.Runtime;
using Prowl.Runtime.Resources.RenderPipeline;

public class MelonToneMappingNode : RenderPassNode
{
    public override string Title => "Custom Tonemapping Pass";
    public override float Width => 100;

    [Input(ShowBackingValue.Never)] public RenderTexture RenderTexture;

    Material? BetterToneMat = null;

    public override void Render()
    {
        var rt = GetInputValue<RenderTexture>("RenderTexture");
        if (rt == null) return;

        BetterToneMat ??= new(Shader.Find("Defaults/MelonTonemapping.shader"));
        BetterToneMat.SetTexture("gAlbedo", rt.InternalTextures[0]);

        Graphics.Blit(renderRT, BetterToneMat, 0, Clear);
    }
}