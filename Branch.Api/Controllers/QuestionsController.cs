using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Branch.Api.DTOs;
using Branch.Data;
using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Branch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public QuestionsController(IPostRepository postRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        } 

        [HttpGet]
        [Authorize(Roles = "admin,teacher,user")]
        public IActionResult GetAllQuestions()
        {
            var question = _postRepository.GetAll().Where(c => c.IsActive == true);
            var AllQuestions = new List<AddPost>();
            _mapper.Map<List<Post>, List<AddPost>>(question.ToList(), AllQuestions);
            return Ok(AllQuestions);
        }



        [HttpGet("GetQuestionById")]
        [Authorize(Roles = "admin,teacher,user")]
        public IActionResult GetQuestionById(int GetQuestionById)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = _postRepository.GetById(GetQuestionById);
            var _addPost = _mapper.Map<AddPost>(post);

            if (_addPost.IsActive == true)
            {
                return Ok(_addPost);
            }
            return NotFound("Post not found");
        }


        [HttpGet("GetAllPostByCategoryId")]
        [Authorize(Roles = "admin,teacher,user")]
        public async Task<ActionResult<Post>> GetAllPostByCategoryId(int GetAllPostByCategoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var getPost = await Task.Run(() => _postRepository.FindAllPosts(GetAllPostByCategoryId));
            return Ok(getPost);
        }


        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult AddQuestion([FromBody]AddPost addPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postObj = _mapper.Map<Post>(addPost);
            _postRepository.Add(postObj);
            _postRepository.SaveChanges();
            //return CreatedAtAction("GetPostById", new { id = addPost.Id }, addPost);
            return Ok("Post created");
        }

     

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult UpdateQuestion(int id, [FromBody]AddPost addPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Post obj = _postRepository.GetById(id);
            if (obj == null)
            {
                return NotFound("Post not found");
            }

            obj.Audio = addPost.Audio;
            obj.Body = addPost.Body;
            obj.Document = addPost.Document;
            obj.Image = addPost.Image;
            obj.Video = addPost.Video;

            var postObj = _mapper.Map<Post>(addPost);
            _postRepository.Update(obj, postObj);
            return Ok("Post updated successfully");
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Post post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound("User not found");
            }
            post.IsActive = false;
            _postRepository.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }

}