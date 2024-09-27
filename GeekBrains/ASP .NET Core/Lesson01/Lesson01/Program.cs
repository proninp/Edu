using System.Net.Http.Json;
using System.Text;

namespace Lesson01;

internal class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        var startIndex = 4;
        var endIndex = 13;
        var tasks = Enumerable.Range(startIndex, endIndex - startIndex + 1)
            .Select(i => GetSinglePost(i))
            .Where(postTask => postTask is not null)
            .ToList();
        var posts = await Task.WhenAll(tasks);

        var fileName = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "posts.txt"));
        await WritePostsToFile(posts, fileName);
    }

    static async Task<Post?> GetSinglePost(int postId)
    {
        return await client.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{postId}");
    }

    static async Task WritePostsToFile(Post[] posts, string fileName)
    {
        if (posts is null || posts.Length == 0 || string.IsNullOrEmpty(fileName))
            return;

        var lines = posts.Select(post => post.ToString());
        await File.WriteAllLinesAsync(path: fileName, contents: lines, encoding: Encoding.UTF8);
    }
}