using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services.Impl
{
    public class WebsiteService : IWebsiteService
    {
        public IList<Website> FindWebsitesByOrganizationId(int organizationId)
        {
            return new List<Website>();
        }

        public IList<Website> FindWebsitesByOrganizationIdIncludeBoards(int organzationId)
        {
            return new List<Website>();
        }

        public IList<Board> FindBoardsByWebsiteId(int websiteId)
        {
            return new List<Board>();
        }
    }
}