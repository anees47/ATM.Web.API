using Microsoft.AspNetCore.Mvc;
using ATM.Web.API.Commands.Account;
using ATM.Web.API.CQRS.Queries.Account.GetAll;
using ATM.Web.API.CQRS.Queries.Account.Get;
using ATM.Web.API.CQRS.Commands.Account.Create;

namespace ATM.Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    CreateAccountCommandHandler createHandler,
    DeleteAccountCommandHandler deleteHandler,
    GetAccountByIdQueryHandler getByIdHandler,
    GetAllAccountsQueryHandler getAllHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
    {
        var result = await createHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok("Account created Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        var command = new DeleteAccountCommand { AccountId = id };
        var result = await deleteHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok("Accunt deleted Successfullly");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(Guid id)
    {
        var query = new GetAccountByIdQuery { AccountId = id };
        var result = await getByIdHandler.HandleAsync(query);
        
        if (!result.IsSuccess)
            return NotFound(result.ErrorMessage);

        return Ok(result.Account);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        var query = new GetAllAccountsQuery();
        var result = await getAllHandler.HandleAsync(query);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Accounts);
    }
} 