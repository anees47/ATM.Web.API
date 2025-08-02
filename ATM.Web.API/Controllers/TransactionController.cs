using Microsoft.AspNetCore.Mvc;
using ATM.Web.API.CQRS.Queries.Transaction.GetByAccount;

namespace ATM.Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController(
    GetTransactionsByAccountQueryHandler getTransactionsByAccountHandler) : ControllerBase
{
    [HttpGet("account/{accountId}")]
    public async Task<IActionResult> GetTransactionsByAccount(string accountId)
    {
        var query = new GetTransactionsByAccountQuery { AccountId = accountId };
        var result = await getTransactionsByAccountHandler.HandleAsync(query);
        
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Ok(result.Transactions);
    }
} 