using CryptoShoto.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace Client.Services;

public class PostService
{
	private readonly HttpClient httpClient;

	public PostService(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<IEnumerable<Post>> GetPosts()
	{
		return await httpClient.GetFromJsonAsync<IEnumerable<Post>>("api/posts");
	}

	public async Task DeletePost(int id)
	{	
		await httpClient.DeleteAsync($"api/posts/{id}");
	}

    public async Task AddPost(PostDTO post)
	{
		await httpClient.PostAsJsonAsync("api/posts", post);
	}

	public async Task<List<PostDTO>> GetAllPostsByUser()
	{
		return await httpClient.GetFromJsonAsync<List<PostDTO>>($"api/posts/myposts");
	}
}
