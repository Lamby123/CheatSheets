namespace CheatSheets.Controllers
{
    using Services;
    using DataAccess;
    using Models;
    using ControllerExtensions;
    using AutoMapper;
    using DTO;

    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly JamesDbContext Context;
        public readonly IEmployeeService EmployeeService;
        public readonly IMapper Mapper;

        public ValuesController(JamesDbContext context, IEmployeeService employeeService, IMapper mapper){
            this.Context = context;
            this.EmployeeService = employeeService;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employee = EmployeeService.GetEmployees(Context);
            var dto = Mapper.Map<EmployeeDto>(employee);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var employee = EmployeeService.GetEmployeeById(Context, id);
            var dto = Mapper.Map<EmployeeDto>(employee);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        [Route("multiple")]
        public ActionResult<IEnumerable<string>> Get([CommaSeparated] List<int> ids)
        {
            var employees = EmployeeService.GetEmployeeById(Context, ids);
            var dtos = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return Ok(dtos);
        }

    }
}
