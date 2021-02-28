using NewronTestOWM.BLL.Interface;
using NewronTestOWM.DAL.Entitys;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Module
{
    class IpstackLocationGetter : ILocationGetter
    {
        private IRESTConector rEST;
        private IIPHelper iPHelp;
        private string token;
        public IpstackLocationGetter(IRESTConector rESTConector,IIPHelper iPHelper,string api_token)
        {
            rEST = rESTConector;
            iPHelp = iPHelper;
            token = api_token;
        }
        public async Task<Location> GetMyLocationAsync()
        {
            var ip = await iPHelp.GetMyPublicIPStringAsync();
            string url = "http://api.ipstack.com/"+ip+"?access_key="+token+"&format=1";
            return await rEST.GetAsync<Location>(url, null, null);
        }
    }
}
