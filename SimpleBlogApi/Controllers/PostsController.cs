using Microsoft.AspNetCore.Mvc;
using SimpleBlogApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        // In-memory list for storing posts
        private static List<Post> posts = new List<Post>();

        // GET: api/Posts
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            return Ok(posts);
        }

        // GET: api/Posts/{id}
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound(new { message = "Post not found" });
            return Ok(post);
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            post.Id = posts.Count > 0 ? posts.Max(p => p.Id) + 1 : 1;
            posts.Add(post);
            return Ok(new { message = "Post created successfully", data = post });
        }

        // PUT: api/Posts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, Post updatedPost)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound(new { message = "Post not found" });

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            return Ok(new { message = "Post updated successfully", data = post });
        }

        // DELETE: api/Posts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound(new { message = "Post not found" });

            posts.Remove(post);
            return Ok(new { message = "Post deleted successfully" });
        }
    }
}