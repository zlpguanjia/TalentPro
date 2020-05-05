using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace TalentMine.AuthenticationCenter
{
    /// <summary>
    /// 自定义的管理信息
    /// </summary>
    public class InitConfig
    {
        /// <summary>
        /// 定义ApiResource   
        /// 这里的资源（Resources）指的就是管理的API
        /// </summary>
        /// <returns>多个ApiResource</returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("ItemBankService", "用户获取API")
            };
        }

        /// <summary>
        /// 定义验证条件的Client
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "TalentMine.ItemBankService",//客户端惟一标识
                    ClientSecrets = new [] { new Secret("zlp123".Sha256()) },//客户端密码，进行了加密
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //授权方式，客户端认证，只要ClientId+ClientSecrets
                    AllowedScopes = new [] { "ItemBankService" },//允许访问的资源
                    //Claims=new List<Claim>(){
                    //    new Claim(IdentityModel.JwtClaimTypes,"Admin")
                    //}
                }
            };
        }
    }
}
