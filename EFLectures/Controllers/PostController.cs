using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFLectures.Models;

namespace EFLectures.Controllers;

public class PostController : Controller
{
    private MyContext db;         
    // Here we can "inject" our context service into the constructor 
    public PostController(MyContext context)    
    {        
        // When our PostController is instantiated, it will fill in db with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        db = context;    
    }

    [HttpGet("posts")]
    public IActionResult All()
    {
        List<Post> allPosts = db.Posts.ToList();

        return View("All", allPosts);
    }  

    [HttpGet("/posts/new")]
    public IActionResult NewPost()
    {
        return View("New");
    }

    [HttpPost("/posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (!ModelState.IsValid)
        {
            return View("New");
        }

        // modelstate IS valid
        db.Posts.Add(newPost);
        Console.WriteLine("Pre save changes: " + newPost.PostId);

        // db doesn't update until we run save changes
        // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
        db.SaveChanges();

        Console.WriteLine("Post save changes: " + newPost.PostId);

        return RedirectToAction("All");
        // same as redirect above:
        // return Redirect("/posts");

        /*
        The ORM .Add method generated a SQL insert mapping the new post properties
        to their corresponding SQL columns, like so:

        INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
        VALUES (newPost.Topic, newPost.Body, newPost.ImgUrl, NOW(), NOW());
        */
    }
}
