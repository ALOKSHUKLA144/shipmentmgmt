using System.Security.Claims;

namespace shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
