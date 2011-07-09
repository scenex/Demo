float4x4    matWorldViewProj;
float4x4    matWorld;
float4      vLightDirection;
float4		vecEye;

float4 vDiffuseColor;
float4 vSpecularColor;
float4 vAmbient;



struct VertexShaderInput
{
    float4 Position : POSITION;

    // TODO: add input channels such as texture
    // coordinates and vertex colors here.
};

struct VertexShaderOutput
{
    // TODO: add vertex shader outputs such as colors and texture
    // coordinates here. These values will automatically be interpolated
    // over the triangle, and provided as input to your pixel shader.

	float4 Position : POSITION;
	float3 L: TEXCOORD0;
    float3 N: TEXCOORD1; 
	float3 V: TEXCOORD2;
};

VertexShaderOutput VertexShaderFunction(float4 Position: POSITION, float3 N: NORMAL)
{
    VertexShaderOutput output;
	output.Position = mul(Position, matWorldViewProj);
	output.N = mul(N, matWorld); 

	float4 PosWorld = mul(Position, matWorld);    
	output.L = vLightDirection;
	output.V = vecEye - PosWorld;
	
    return output;
}

float4 PixelShaderFunction(float3 L: TEXCOORD0, float3 N: TEXCOORD1, float3 V: TEXCOORD2) : COLOR
{
    float3 Normal = normalize(N);
    float3 LightDir = normalize(L);
    float3 ViewDir = normalize(V);   
   
    float Diff = saturate(dot(Normal, LightDir));
   
    float3 Reflect = normalize(2 * Diff * Normal - LightDir);

    float Specular = pow(saturate(dot(Reflect, ViewDir)), 20);

	float4 calcValue = vAmbient + vDiffuseColor * Diff + vSpecularColor * Specular;
	calcValue.a = 0.9f;
	return calcValue;

    //return vAmbient + vDiffuseColor * Diff + vSpecularColor * Specular;
}

technique SpecularLight
{
    pass Pass1
    {
        // TODO: set renderstates here.

        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
