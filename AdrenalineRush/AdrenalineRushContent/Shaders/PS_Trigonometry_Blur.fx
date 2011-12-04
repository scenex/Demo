float4x4 World;
float4x4 View;
float4x4 Projection;
float4x4 matWorldViewProj;

// TODO: add effect parameters here.
sampler firstSampler;

float4 PixelShaderFunction(float2 texCoord: TEXCOORD0) : COLOR0
{	
	float4 color = 0;
	color += tex2D(firstSampler, texCoord + float2(0.001f, 0));
	color += tex2D(firstSampler, texCoord + float2(0.003f, 0));
	color += tex2D(firstSampler, texCoord + float2(-0.001f, 0));
	color += tex2D(firstSampler, texCoord + float2(-0.003f, 0)); 

	color /= 4.0f;
    
	return color;
}

technique MyPixelShader
{
    pass Pass0
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
