float4x4 World;
float4x4 View;
float4x4 Projection;

float fadeMultiplier;

sampler firstSampler;

float4 PixelShaderFunction(float2 texCoord: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(firstSampler, texCoord);
	color = color * fadeMultiplier;
	return color;
}

technique FadeInTechnique
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
