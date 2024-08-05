using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Product.Application.Features.CQRS.Commands.CategoryCommands;
using Product.Application.Features.CQRS.Handlers.CategoryHandlers;
using Product.Application.Features.CQRS.Queries.CategoryQueries;

namespace Product.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly CreateCategoryCommandHandle _createCategoryCommandHandle;
        private readonly UpdateCategoryCommandHandle _updateCategoryCommandHandle;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, CreateCategoryCommandHandle createCategoryCommandHandle, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandle updateCategoryCommandHandle)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _createCategoryCommandHandle = createCategoryCommandHandle;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _updateCategoryCommandHandle = updateCategoryCommandHandle;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }



        public IActionResult CreateCategory() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandle.Handle(command);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(value);

        }


        [HttpPost]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandle.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
