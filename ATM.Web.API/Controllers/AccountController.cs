using Microsoft.AspNetCore.Mvc;
using ATM.Web.API.Commands.Account;
using ATM.Web.API.CQRS.Queries.Account.GetAll;
using ATM.Web.API.CQRS.Queries.Account.Get;
using ATM.Web.API.CQRS.Commands.Account.Create;
using ATM.Web.API.CQRS.Commands.Account.Deposit;
using ATM.Web.API.CQRS.Commands.Account.Withdraw;
using ATM.Web.API.CQRS.Commands.Account.Transfer;

namespace ATM.Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    CreateAccountCommandHandler createHandler,
    DeleteAccountCommandHandler deleteHandler,
    GetAccountByIdQueryHandler getByIdHandler,
    GetAllAccountsQueryHandler getAllHandler,
    DepositCommandHandler depositHandler,
    WithdrawCommandHandler withdrawHandler,
    TransferCommandHandler transferHandler) : ControllerBase
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
    public async Task<IActionResult> DeleteAccount(string id)
    {
        var command = new DeleteAccountCommand { AccountId = id };
        var result = await deleteHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok("Accunt deleted Successfullly");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(string id)
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

    [HttpPost("{id}/deposit")]
    public async Task<IActionResult> Deposit(string id, [FromForm] decimal amount)
    {
        var command = new DepositCommand { AccountId = id, Amount = amount };
        var result = await depositHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok("Deposit successful");
    }

    [HttpPost("{id}/withdraw")]
    public async Task<IActionResult> Withdraw(string id, [FromForm] decimal amount)
    {
        var command = new WithdrawCommand { AccountId = id, Amount = amount };
        var result = await withdrawHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok("Withdrawal successful");
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromForm] string fromAccountId, [FromForm] string toAccountId, [FromForm] decimal amount)
    {
        var command = new TransferCommand 
        { 
            FromAccountId = fromAccountId, 
            ToAccountId = toAccountId, 
            Amount = amount 
        };
        var result = await transferHandler.HandleAsync(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(new 
        { 
            message = "Transfer successful",
            fromAccountNewBalance = result.NewFromAccountBalance,
            toAccountNewBalance = result.NewToAccountBalance
        });
    }
} 