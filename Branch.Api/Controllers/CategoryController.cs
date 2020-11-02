using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Branch.Api.DTOs;
using Branch.Data;
using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using Branch.Data.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Branch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCategories")]
        [Authorize(Roles = "admin,teacher,user")]
        public IActionResult GetAllCategories()
        {
            var category = _categoryRepository.GetAll().Where(c => c.IsActive == true);
            var AllCategories = new List<AddCategory>();
            _mapper.Map<List<Category>, List<AddCategory>>(category.ToList(),AllCategories);
            return Ok(AllCategories);
        }


        ////// start getting childs and subchilds using parents ID ///////
        [HttpGet("GetAllCategoriesWithChild")]
        [Authorize(Roles = "admin,teacher,user")]
        public async Task<ActionResult<IList<AddCategory>>> GetAllCategoriesWithChild(long? ParentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await Task.Run(() => _categoryRepository.GetAll().Where(c => c.IsActive == true));
            //var AllQuestions = new List<AddCategory>();
            var oListCategories = _mapper.Map<List<Category>, List<AddCategory>>(category.ToList());
            var active = WithSubCatagory(oListCategories, ParentId ?? 0);
            return active;
        }
        //IList<AddCategory> oListCategories = _categoryRepository.Categories();
        private static List<AddCategory> WithSubCatagory(IList<AddCategory> categories, long? parentId)
        {
            return categories
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new AddCategory
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ParentId = c.ParentId,
                        WithSubCatagory = WithSubCatagory(categories, c.Id)
                    }).ToList();
        }
        ////// end getting childs and subchilds using parents ID ///////
        

        [HttpGet("{id}")]
        [Authorize(Roles ="admin,teacher,user")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objCategory = await Task.Run(() => _categoryRepository.GetById(id));
            var result = _mapper.Map<Category, AddCategory>(objCategory);
            if (objCategory.IsActive == true)
            {
                return Ok(result);
            }
            return NotFound("Category not found");
        }


        [HttpPost]
        //[Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<AddCategory>> AddCategory([FromBody] AddCategory addCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var catObj = _mapper.Map<Category>(addCategory);
            _categoryRepository.Add(catObj);
            await Task.Run(() => _categoryRepository.SaveChanges());
            ///var result = _mapper.Map<Category, AddCategory>(category);
            //return CreatedAtAction("GetCategoryById" , new { id = category.Id }, category);
            return Ok("Category cretaed successfully");
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "admin,teacher")]
        public IActionResult UpdateCategory(int id, [FromBody]AddCategory addCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category cat = _categoryRepository.GetById(id);
            if(cat == null)
            {
                return NotFound("Category could not found");
            }

            cat.Name = addCategory.Name;
            cat.Description = addCategory.Description;
            cat.Image = addCategory.Image;
            cat.Remarks = addCategory.Remarks;

            var catObj = _mapper.Map<Category>(addCategory);
            _categoryRepository.Update(cat, catObj);
            var result =   _mapper.Map<Category, AddCategory>(cat);
            return Ok("Category updated successfully");
        }



        [HttpDelete("{id}")]
        [Authorize(Roles ="admin,user")]
        public IActionResult DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category cat = _categoryRepository.GetById(id);
            if (cat == null)
            {
                return NotFound("Category not found");
            }
            cat.IsActive = false;
            _categoryRepository.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}








