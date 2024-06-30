using BussinessObject;
using DTOS.Account;
using Microsoft.AspNetCore.Mvc;
using Service;
using ShoppingAppAPI.MessageStatusResponse;

namespace ShoppingAppAPI.Controllers
{
    [ApiController]
    [Route("api/")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Account>> LoginByUserNameAndPassword(LoginParam loginParam)
        {

            try
            {
                var user = await _accountService.GetAccountIDLogin(loginParam.Username, loginParam.Password);

                if (user == null)
                {
                    return Unauthorized(new ApiResponseStatus(401, "Wrong password"));
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount(NewAccountParam newAccountParam)
        {

            try
            {
                Account account = await _accountService.GetUsernameExisted(newAccountParam.Username);
                if (account == null)
                {
                    await _accountService.AddAccount(newAccountParam);
                    return Ok();
                }
                return BadRequest(new ApiResponseStatus(400, "Username is existed!"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpGet("accounts/all")]
        public async Task<IActionResult> GetAllAccount()
        {
            IEnumerable<Account> accounts = await _accountService.GetAllAccount();
            return Ok(accounts);
        }

        [HttpGet("account/profile/{id}")]
        public async Task<IActionResult> GetAccountProfile(int id)
        {
            Account account = await _accountService.GetAccountByID(id);
            return Ok(account);
        }

        [HttpPut("account/update")]
        public async Task<IActionResult> UpdateStatusAccount(UpdateStatusAccountParam updateStatus)
        {
            try
            {
                await _accountService.UpdateAccountStatus(updateStatus.AccountID, updateStatus.Status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }

        [HttpPut("account/change-password")]
        public async Task<IActionResult> UpdatePasswordAccount(UpdatePasswordAccountParam updatePassword)
        {
            try
            {
                await _accountService.UpdatePassword(updatePassword.AccountID, updatePassword.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute function!"));
            }
        }
    }
}
