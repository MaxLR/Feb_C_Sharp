using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFLectures.Models;
using Microsoft.AspNetCore.Mvc.Filters;

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

    [SessionCheck]
    [HttpGet("posts")]
    public IActionResult All()
    {
        List<Post> allPosts = db.Posts.ToList();

        return View("All", allPosts);
    }

    [HttpGet("/posts/{postId}")]
    public IActionResult Details(int postId)
    {        
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (post == null)
        {
            return RedirectToAction("All");
        }

        return View("Details", post);
    }

    [HttpGet("/posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {        
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (post == null)
        {
            return RedirectToAction("All");
        }

        return View("Edit", post);
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

    [HttpPost("/posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        if (!ModelState.IsValid)
        {
            // editedPost.PostId = postId;
            // return View("Edit", editedPost);

            // this reuses the Edit route's functionality, but doesn't create a new reqeust/response cycle, so error messages persist
            // if you use this syntax, you NEED to make sure that the name of the .cshtml file is not defaulted in the "return View()" line of code
            return Edit(postId);
        }

        Post? dbPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (dbPost == null)
        {
            return RedirectToAction("All");
        }

        dbPost.Topic = editedPost.Topic;
        dbPost.Body = editedPost.Body;
        dbPost.ImgUrl = editedPost.ImgUrl;
        dbPost.UpdatedAt = DateTime.Now;

        db.Posts.Update(dbPost);
        db.SaveChanges();

        return RedirectToAction("Details", new { postId = postId });
    }

    [HttpPost("/posts/{postId}/delete")]
    public IActionResult Delete(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if(post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }

        return RedirectToAction("All");
    }
}

// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UUID");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}

