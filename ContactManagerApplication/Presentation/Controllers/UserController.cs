using Application.Common.Interfaces.Queries;
using Application.Users.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Presentation.Controllers;

public class UserController(ISender sender, IUserQueries userQueries) : Controller
{

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var entities = await userQueries.GetAllUsersAsync(cancellationToken);
        
        return View(entities.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> LoadFile(string filePath, CancellationToken cancellationToken)
    {
        var input = new UploadUserCSVFileCommand
        {
            filePath = filePath
        };

        var result = await sender.Send(input, cancellationToken);

        return result.Match<IActionResult>(
            u => RedirectToAction("Index"),
            e => View("Error", e));
    }
    
    public async Task<IActionResult> DeleteUser(int userId, CancellationToken cancellationToken)
    {
        var input = new DeleteUserCommand
        {
            UserId = userId
        };
        
        var result = await sender.Send(input, cancellationToken);
        
        return result.Match<IActionResult>(
            u=>RedirectToAction("Index"),
            e=>View("Error", e));
    }
    
    public async Task<IActionResult> EditUser(
        [FromForm] int userId, [FromForm] string name, [FromForm] DateTime dateOfBirth, 
    [FromForm] bool married, [FromForm] string phone, [FromForm] decimal salary, 
        CancellationToken cancellationToken)
    {
        var input = new UpdateUserCommand
        {
            UserId = userId,
            Name = name,
            DateOfBirth = dateOfBirth,
            Married = married,
            Phone = phone,
            Salary = salary
        };
        
        var result = await sender.Send(input, cancellationToken);
        
        return result.Match<IActionResult>(
            u=>RedirectToAction("Index"),
            e=>View("Error", e));
    }
}