using Newtonsoft.Json;
using System.Text;

namespace Lesson01;

internal class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        int startIndex = 4;
        int endIndex = 13;
        var tasks = new List<Task<Post>>();
        for (int i = startIndex; i <= endIndex; i++)
        {
            var postTask = GetSinglePost(i);
            if (postTask is not null)
                tasks.Add(postTask!);
        }
        var posts = await Task.WhenAll(tasks);

        string fileName = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../..", "posts.txt"));
        await WritePostsToFile(posts, fileName);
    }

    static async Task<Post?> GetSinglePost(int postId)
    {
        var response = await client.GetAsync(string.Format("https://jsonplaceholder.typicode.com/posts/{0}", postId));
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(content);
        }
        return default;
    }

    static async Task WritePostsToFile(Post[] posts, string fileName)
    {
        if (posts is null || posts.Length == 0)
            return;
        using StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
        for (int i = 0; i < posts.Length - 1; i++)
            await streamWriter.WriteLineAsync(posts[i].ToString() + "\n");
        await streamWriter.WriteAsync(posts[^1].ToString());
    }
}