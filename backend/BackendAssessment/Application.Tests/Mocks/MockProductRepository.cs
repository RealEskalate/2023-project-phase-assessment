using Moq;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Tests.Mocks;
    public class MockProductRepository
    {
        public static Mock<IPostRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Products
                {
                    Id = 1,
                    Name = "Product 1",
                    Pricing = 19.99,
                    Availability = Availability.IsAvailable,
                    CreatorId = 1,
                    CategoryId = 1,
                    User = new User { Id = 1, Name = "User 1" },
                    Category = new Category { Id = 1, Name = "Category 1" 
                },
                new Products
                {
                    Id = 2,
                    Name = "Product 2",
                    Pricing = 29.99,
                    Availability = Availability.CommingSoon,
                    CreatorId = 2,
                    CategoryId = 2,
                    User = new User { Id = 2, Name = "User 2" },
                    Category = new Category { Id = 2, Name = "Category 2"
                }
            };

            var postRepo = new Mock<IPostRepository>();

            postRepo.Setup(repo => repo.AddAsync(It.IsAny<Post>()))
                .ReturnsAsync((Post post) =>
                {
                    post.Id = posts.Count + 1;
                    posts.Add(post);
                    return post;
                });

        postRepo.Setup(repo => repo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => posts.FirstOrDefault(p => p.Id == id));

            postRepo.Setup(repo => repo.GetAsync())
                .ReturnsAsync(posts);

            postRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Post>()))
                .Callback((Post p) =>
                {
                    var existingPost = posts.FirstOrDefault(q => q.Id == p.Id);
                    if (existingPost != null)
                    {
                        existingPost.Content = p.Content;
                        existingPost.UserId = p.UserId;
                    }
                });

            postRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Post>()))
                .Callback((Post q) =>
                {
                    posts.RemoveAll(p => p.Id == q.Id);
                });

            postRepo.Setup(repo => repo.GetPostsByTagsAsync(It.IsAny<List<string>>()))
                .ReturnsAsync((List<string> tags) => posts.Where(p => tags.Any(t => p.Content.Contains(t))).ToList());


            postRepo.Setup(repo => repo.GetPostsByUserIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int userId) => posts.Where(p => p.UserId == userId).ToList());

            postRepo.Setup(repo => repo.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => {
                    var post = posts.FirstOrDefault(p=> p.Id == id);
                    return post!=null;
                });


            return postRepo;
        }
    }

