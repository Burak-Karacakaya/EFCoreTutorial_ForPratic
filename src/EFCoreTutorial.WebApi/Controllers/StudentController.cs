using EFCoreTutorail.Data.Context;
using EFCoreTutorail.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace EFCoreTutorial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        private async Task eagerLoadings() //default gelir.
        {
            var student = await applicationDbContext.Students.Include(i => i.Books).FirstOrDefaultAsync(i=>i.Id==1); //Eagle Loading kullanıldığı için include dememeiz gerekli.(thencloude ile devam edebiliriz)

        }

        private async Task lazyLoadings() //startup'da ayarlanması gerekir.//objeye erişirsek gidip objeyi dolduruyor.
        {
            var students = await applicationDbContext.Students.ToListAsync();
            foreach (var student in students)
            {
                foreach (var book in student.Books)
                {
                    Console.WriteLine(book.Name);
                }
            }

            //var student = await applicationDbContext.Students.FirstOrDefaultAsync(i => i.Id == 1);
            //var books = student.Books;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await lazyLoadings();
            return null;


            StudentFilter filter = new StudentFilter() { FirstName = "burak" };

            var students = applicationDbContext.Students.AsQueryable(); // Sorgu yazabilmek için-Generate etmeden.

            if (!String.IsNullOrEmpty(filter.FirstName))
                students = students.Where(i => i.FirstName == filter.FirstName);

            if (!String.IsNullOrEmpty(filter.LastName))
                students = students.Where(i => i.LastName == filter.LastName);

            if (filter.Number.HasValue)
                students = students.Where(i => i.Number == filter.Number);

            var list = students.Count();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            Student st = new Student()
            {
                FirstName = "Burak",
                LastName = "Karacakaya",
                Number = 1,
                Address = new StudentAddress()
                {
                    City = "İstanbul",
                    Country = "Türkiye",
                    District = "Maltepe",
                    FullAddress = "A sokak, No: 7"
                }
            };

            await applicationDbContext.Students.AddAsync(st);
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await applicationDbContext.Students.FindAsync(id);
            applicationDbContext.Students.Remove(student);

            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync();

            student.FirstName = "BURAK";
            student.LastName = "KAARACAKAYA";

            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
