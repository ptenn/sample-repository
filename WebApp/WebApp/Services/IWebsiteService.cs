using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IWebsiteService
    {
        IList<Website> FindWebsitesByOrganizationId(int organizationId);

        IList<Website> FindWebsitesByOrganizationIdIncludeBoards(int organzationId);
            
        IList<Board> FindBoardsByWebsiteId(int websiteId);
    }
}