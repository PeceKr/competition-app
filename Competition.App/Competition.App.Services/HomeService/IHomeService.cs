using Competition.App.Common.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Services.HomeService
{
    public interface IHomeService
    {
        DashboardResultsViewModel getDashBoardStats();
    }
}
