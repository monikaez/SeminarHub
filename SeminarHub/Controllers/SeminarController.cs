using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;
using static SeminarHub.Data.Common.DataConstants;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;

        public SeminarController(SeminarHubDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var allSeminars = await context.Seminars
                .AsNoTracking()
                .Select(s => new SeminarAllViewModel
                (
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,
                    s.DateAndTime,
                    s.Organizer.UserName
                 ))
                .ToListAsync();

            return View(allSeminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarAddViewModel();
            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarAddViewModel seminarForm)
        {
            if (seminarForm == null)
            {
                return BadRequest();
            }
            DateTime dateTime = DateTime.Now;

            if (!DateTime.TryParseExact(seminarForm.DateAndTime,
                 Data.Common.DataConstants.DateFormat,
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.None,
                 out dateTime))
            {
                ModelState
                    .AddModelError(nameof(seminarForm.DateAndTime), $"Invalid date! Format must be: {DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();

                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                seminarForm.Categories = await GetCategories();
                return View(seminarForm);
            }

            var entity = new Seminar()
            {
                DateAndTime = dateTime,
                Topic = seminarForm.Topic,
                Lecturer = seminarForm.Lecturer,
                Details = seminarForm.Details,
                OrganizerId = GetUserId(),
                CategoryId = seminarForm.CategoryId,
                Duration = seminarForm.Duration,

            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var searchedSeminar = await dbContext.Seminars
        //        .Where(s => s.Id == id)
        //        .AsNoTracking()
        //        .Select(s => new SeminarDetailsViewModel()
        //        {
        //            Id = s.Id,
        //            Topic = s.Topic,
        //            Lecturer = s.Lecturer,
        //            Category = s.Category.Name,
        //            DateAndTime = s.DateAndTime.ToString(Data.Common.DataConstants.DateFormat),
        //            Duration = s.Duration,
        //            Details = s.Details,
        //            Organizer = s.Organizer.UserName
        //        })
        //        .FirstOrDefaultAsync();

        //    if (searchedSeminar == null)
        //    {
        //        return BadRequest();
        //    }

        //    return View(searchedSeminar);
        //}

        private string GetUserId()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }


        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }


    }
}
