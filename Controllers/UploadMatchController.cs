using TestProject.Services;
using Microsoft.AspNetCore.Mvc;
using TestProject.Data;

namespace TestProject.Controllers
{
    public class UploadMatchController : Controller
    {
        private readonly IFussballContentService _fussballContentService;

        public UploadMatchController(IFussballContentService fussballContentService)
        {
            _fussballContentService = fussballContentService;
        }

        [HttpPost]
        public IActionResult CreateMatch(string nodeName, int parentId, string contentType, Match match)
        {
            // Call the CreateContent method here
            _fussballContentService.CreateContent(nodeName, parentId, contentType, match);

            // Redirect to a confirmation page or back to the form
            return RedirectToAction("CreateMatch");
        }
    }
}