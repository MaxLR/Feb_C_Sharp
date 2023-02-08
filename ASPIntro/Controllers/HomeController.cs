using Microsoft.AspNetCore.Mvc;

// Inherit from the base controller class so that our controllers inherit
// helpful methods for handling the HTTP request/response cycle
public class HomeController : Controller
{
    // attribute, HTTP type & the route URL
    [HttpGet("")]
    // following 2 lines are same as line 8
    // [HttpGet]
    // [Route("")]
    // function that runs when we receive incoming request
    public ViewResult Index()
    {
        // response to user's request
        return View("Index");
        // return View();
    }

    [HttpGet("/videos")]
    public ViewResult Videos()
    {
        List<string> youtubeVidIds = new List<string>()
        {
            "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        };

        ViewBag.VideoIds = youtubeVidIds;
        ViewBag.Message = "Hello from ViewBag!!";
        
        return View("Videos");
    }
}