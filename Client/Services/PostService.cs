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

    public async Task<IEnumerable<Post>> GetPosts(int page, int userid)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Post>>($"api/posts/GetPagedPosts/{page}/{userid}");
        
    }

    public async Task DeletePost(int id)
	{	
		await httpClient.DeleteAsync($"api/posts/{id}");
	}

    public async Task AddPost(PostDTO post)
	{
		await httpClient.PostAsJsonAsync("api/posts", post);
	}

	public async Task<List<Post>> GetAllPostsByUser(int userid)
	{
		return await httpClient.GetFromJsonAsync<List<Post>>($"api/posts/myposts/{userid}");
	}

    public async Task<int> GetCountOfPosts(int userid)
    {
        var all = await httpClient.GetFromJsonAsync<IEnumerable<Post>>($"api/myposts/posts/{userid}");

        if (all.Count() % 5 == 0)
            return all.Count() / 5;
        return all.Count() / 5 + 1;
    }
}
