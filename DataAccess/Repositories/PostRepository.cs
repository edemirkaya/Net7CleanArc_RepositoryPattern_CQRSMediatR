using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _ctx;

        public PostRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Post> CreatePost(Post post)
        {
            post.CreateDate = DateTime.Now;
            post.LastModified = DateTime.Now;
            _ctx.Posts.Add(post);
            await _ctx.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts
                 .FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null) return;

            _ctx.Posts.Remove(post);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _ctx.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Post> UpdatePost(string updatecontent, int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p=> p.Id == postId); 
            post.LastModified = DateTime.Now; 
            post.Content = updatecontent;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}
