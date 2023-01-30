using Api;
using Api.EfContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace studentsAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StuApiController : ControllerBase
    {
        public StuApiController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private readonly DataContext dbContext;
        
        

        [HttpGet]
        [Route("GetStudents")]
        public async  Task<IActionResult> GetStudents()
        {
            
                return Ok(await dbContext.Student.ToListAsync()); 
        }
        [HttpGet]
        [Route("get/{id}")]
        public async  Task<IActionResult> GetStudent(int id)
        {

            var row = await dbContext.Student.FindAsync(id);
            return row != null ? Ok(row) : NotFound(row);
        }

        [HttpPost]
        [Route("post")]

        public async Task<IActionResult> AddStudents(StudentModel studentModel)
        {
            var obj = new Student();
            obj.StuAddress = studentModel.StuAddress;
            obj.StuName = studentModel.StuName;

            await dbContext.Student.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return Ok(obj);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateStudents([FromRoute] int id,StudentModel studentModel)
        {
            var row = await dbContext.Student.FindAsync(id);
            if (row != null)
            {
                
                row.StuAddress = studentModel.StuAddress;
                row.StuName = studentModel.StuName;



                
                await dbContext.SaveChangesAsync();
                return Ok(row);
            }

            return NotFound(row);
        }

        [HttpDelete]
        [Route("Remove/{id}")]
        public async Task<IActionResult> RemoveStudent([FromRoute] int id)
        {
            var row = await dbContext.Student.FindAsync(id);
            if (row == null)
                return NotFound(row);
             dbContext.Remove(row);
             await  dbContext.SaveChangesAsync();
             return Ok(row);
        }
        
        
        

    }
}