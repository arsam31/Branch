using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Branch.Api.DTOs;
using Branch.Data.Core.Domain;
using Branch.Data.Core.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Branch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository commentRepository,IPostRepository postRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllComments")]
        [Authorize(Roles = "admin,teacher,user")]
        public IActionResult GetAllComments()
        {
            var comment = _commentRepository.GetAll().Where(c => c.IsActive == true);
            var AllComments = new List<AddComment>();
            _mapper.Map<List<Comments>, List<AddComment>>(comment.ToList(), AllComments);
            return Ok(AllComments);
        }


        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult AddComment([FromBody]AddComment addComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentObj = _mapper.Map<Comments>(addComment);
            _commentRepository.Add(commentObj);
            _commentRepository.SaveChanges();
            return Ok("Comment created");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult UpdateComment(int id, [FromBody]AddComment addComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comments obj = _commentRepository.GetById(id);
            if (obj == null)
            {
                return NotFound("Comment not found");
            }

            obj.Audio = addComment.Audio;
            obj.Body = addComment.Body;
            obj.Document = addComment.Document;
            obj.Image = addComment.Image;
            obj.Video = addComment.Video;

            var commentObj = _mapper.Map<Comments>(addComment);
            _commentRepository.Update(obj, commentObj);
            return Ok("Comment updated successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult DeleteComment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Comments comments = _commentRepository.GetById(id);
            if (comments == null)
            {
                return NotFound("Comment not found");
            }
            comments.IsActive = false;
            _commentRepository.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}