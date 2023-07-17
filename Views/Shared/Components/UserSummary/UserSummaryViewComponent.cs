using Microsoft.AspNetCore.Mvc;
using Ecommerce;

namespace HtmxEcomSample.Components;

public class UserSummaryViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("Default", new UserSummaryViewComponentViewModel { 
            IsHtmxRequest = Request.Headers["HX-Request"] == "true",
            TotalItemsInCart = CartRepository.GetTotalCount()
        });
    }
}

public class UserSummaryViewComponentViewModel {
    public bool IsHtmxRequest { get; set; }
    public int? TotalItemsInCart { get; set; }
}