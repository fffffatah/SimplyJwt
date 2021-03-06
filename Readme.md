# Getting Started

This is a simple JWT implementation that can be used in various .NET 5.0 web projects. This class library uses 'System.IdentityModel.Tokens.Jwt' and 'Microsoft.IdentityModel.Tokens' for token generation and validation.
## How to Use
First, add the package to your project via Nuget Package manager or running the following command in project directory.
```sh
Install-Package fffffatah.SimplyJwt -Version 1.0.1
```
>Navigate to 'Startup.cs' and add the following line inside 'ConfigureServices' method.
```cs
services.AddScoped<IAuthProvider, AuthProvider>(x => {
                                                        return new AuthProvider("YOUR_JWT_KEY", "JWT_ISSUER", 10);
                                                     });
```
'YOUR_JWT_KEY' is your secret key and 'JWT_ISSUER' is your organization or website (example, 'www.demo.com'). Finally, 10 is the number of minutes before the token expires. You can set your own expiry time.

>Example use case,
```cs
class Demo{
    protected readonly IAuthProvider _authProvider;
    public Demo(IAuthProvider authProvider){
        _authProvider = authProvider;
    }
    public void Generate(){
        //myClaims is a set of key value pair where Key is claim type and Value is claim value
        var myClaims = new Dictionary<string, string>();
        myClaims.Add("Id","1234");
        myClaims.Add("UType","Admin");
        var jwtToken = _authProvider.GenerateJsonWebToken(myClaims);
        /*jwtToken contains an encrypted string that holds your claims
          you can store the token on the client side and pass it with every request.
        */
    }
    public void Validate(string jwtToken){
        var keys = new List<string>();
        keys.Add("Id");
        keys.Add("UType");
        var myClaims = _authProvider.ValidateToken(jwtToken, keys);
        //myClaims is a Dictionary that holds your extracted claims from jwtToken. It will be null if the token is expired or invalid. 
    }
}
```