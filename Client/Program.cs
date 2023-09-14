// discover endpoints from metadata
using IdentityModel.Client;

var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7105");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}
